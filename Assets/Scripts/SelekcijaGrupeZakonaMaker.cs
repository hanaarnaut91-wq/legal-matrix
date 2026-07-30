using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using UnityEngine;

public class SelekcijaGrupeZakonaMaker : MonoBehaviour
{
    public List<string> zakoni = new List<string>();
    public List<int> brojPitanjaUZakonu = new List<int>();
    public List<int> brojOdgovorenihPitanjaUZakonu = new List<int>();
    public GameObject selekcijaZakonElement;

    [Tooltip("Optional container for generated law-selection elements. Uses this transform when empty.")]
    public Transform selectionContainer;

    public string path;
    public string content;
    public string[] lines;

    public TMP_Text ukupniPregledText;
    public List<int> brojOdgovorenihPitanjDa = new List<int>();
    public List<int> brojOdgovorenihPitanjaNe = new List<int>();
    public int ukupnoPitanjaSve;
    public TMP_Text percentText;

    public GameObject EvaluationPage;
    public GameObject EvaluationFailed;

    public IReadOnlyList<LegalMatrixLawBlock> LawBlocks
    {
        get { return lawBlocks; }
    }

    private List<LegalMatrixLawBlock> lawBlocks = new List<LegalMatrixLawBlock>();
    private readonly List<GameObject> spawnedSelections = new List<GameObject>();
    private string debugStanje = string.Empty;

    private void Start()
    {
        path = Path.Combine(Application.persistentDataPath, "ZakoniData.txt");

        if (!File.Exists(path))
        {
            Debug.LogError("ZakoniData.txt ne postoji: " + path);
            enabled = false;
            return;
        }

        ReloadFromDisk();
        RecalculateStats();
        BuildSelectionElements();
        RefreshMainStatsDisplay();
    }

    public void ReloadFromDisk()
    {
        if (string.IsNullOrWhiteSpace(path))
            path = Path.Combine(Application.persistentDataPath, "ZakoniData.txt");

        content = File.Exists(path) ? File.ReadAllText(path, Encoding.UTF8) : string.Empty;
        lines = File.Exists(path) ? File.ReadAllLines(path, Encoding.UTF8) : new string[0];
        RebuildParsedData();
    }

    private void RebuildParsedData()
    {
        lawBlocks = LegalMatrixDataParser.ParseQuestionBlocks(lines);

        zakoni.Clear();
        for (int i = 0; i < lawBlocks.Count; i++)
            zakoni.Add(lawBlocks[i].LawName);
    }

    public void RecalculateStats()
    {
        brojPitanjaUZakonu.Clear();
        brojOdgovorenihPitanjaUZakonu.Clear();
        brojOdgovorenihPitanjDa.Clear();
        brojOdgovorenihPitanjaNe.Clear();
        ukupnoPitanjaSve = 0;

        for (int i = 0; i < lawBlocks.Count; i++)
        {
            LegalMatrixLawBlock block = lawBlocks[i];

            int yes = 0;
            int no = 0;

            for (int q = 0; q < block.Questions.Count; q++)
            {
                switch (block.Questions[q].Answer)
                {
                    case LegalMatrixAnswer.Yes:
                        yes++;
                        break;

                    case LegalMatrixAnswer.No:
                        no++;
                        break;
                }
            }

            int total = block.Questions.Count;
            int answered = yes + no;

            brojPitanjaUZakonu.Add(total);
            brojOdgovorenihPitanjaUZakonu.Add(answered);
            brojOdgovorenihPitanjDa.Add(yes);
            brojOdgovorenihPitanjaNe.Add(no);
            ukupnoPitanjaSve += total;
        }
    }

    private void BuildSelectionElements()
    {
        ClearSelectionElements();

        if (selekcijaZakonElement == null)
        {
            Debug.LogError("selekcijaZakonElement nije postavljen.");
            return;
        }

        Transform parent = selectionContainer != null ? selectionContainer : transform;

        for (int i = 0; i < lawBlocks.Count; i++)
        {
            GameObject item = Instantiate(selekcijaZakonElement, parent);
            item.transform.localScale = Vector3.one;
            spawnedSelections.Add(item);

            if (item.transform.childCount > 1)
            {
                TMP_Text lawNameText = item.transform.GetChild(1).GetComponent<TMP_Text>();
                if (lawNameText != null)
                    lawNameText.text = lawBlocks[i].LawName;
            }

            if (item.transform.childCount > 2)
            {
                TMP_Text statsText = item.transform.GetChild(2).GetComponent<TMP_Text>();
                if (statsText != null)
                {
                    statsText.text =
                        "broj pitanja: " + brojPitanjaUZakonu[i] +
                        " · odgovoreno: " + brojOdgovorenihPitanjaUZakonu[i];
                }
            }

            GrupaZakonaChecker checker = item.GetComponent<GrupaZakonaChecker>();
            if (checker != null)
                checker.Initialize(this, i);
        }
    }

    private void ClearSelectionElements()
    {
        for (int i = 0; i < spawnedSelections.Count; i++)
        {
            if (spawnedSelections[i] != null)
                Destroy(spawnedSelections[i]);
        }

        spawnedSelections.Clear();
    }

    public bool SetAnswer(int sourceLineIndex, LegalMatrixAnswer answer)
    {
        if (lines == null || sourceLineIndex < 0 || sourceLineIndex >= lines.Length)
        {
            Debug.LogError("Neispravan indeks pitanja: " + sourceLineIndex);
            return false;
        }

        if (answer == LegalMatrixAnswer.Unanswered)
        {
            lines[sourceLineIndex] =
                LegalMatrixDataParser.RemoveAnswerMarker(lines[sourceLineIndex]);
        }
        else
        {
            char marker = answer == LegalMatrixAnswer.Yes ? '@' : '#';
            lines[sourceLineIndex] =
                LegalMatrixDataParser.RemoveAnswerMarker(lines[sourceLineIndex]) + marker;
        }

        Save();
        RebuildParsedData();
        RecalculateStats();
        RefreshMainStatsDisplay();
        UpdateStatsNaZakonima();
        return true;
    }

    public bool TryGetQuestionSourceIndex(
        int lawBlockIndex,
        int questionIndex,
        out int sourceLineIndex)
    {
        sourceLineIndex = -1;

        if (lawBlockIndex < 0 || lawBlockIndex >= lawBlocks.Count)
            return false;

        LegalMatrixLawBlock block = lawBlocks[lawBlockIndex];

        if (questionIndex < 0 || questionIndex >= block.Questions.Count)
            return false;

        sourceLineIndex = block.Questions[questionIndex].SourceLineIndex;
        return true;
    }

    public bool TryFindUniqueQuestionIndex(string questionText, out int sourceLineIndex)
    {
        sourceLineIndex = -1;
        int matches = 0;
        string wanted = LegalMatrixDataParser.RemoveAnswerMarker(questionText);

        for (int i = 0; i < lawBlocks.Count; i++)
        {
            for (int q = 0; q < lawBlocks[i].Questions.Count; q++)
            {
                if (lawBlocks[i].Questions[q].Text == wanted)
                {
                    sourceLineIndex = lawBlocks[i].Questions[q].SourceLineIndex;
                    matches++;
                }
            }
        }

        if (matches == 1)
            return true;

        sourceLineIndex = -1;

        if (matches > 1)
        {
            Debug.LogError(
                "Pitanje nije jedinstveno. Mora se proslijediti njegov stvarni indeks: " +
                wanted);
        }

        return false;
    }

    public void UpdateMainStats()
    {
        ReloadFromDisk();
        RecalculateStats();
        RefreshMainStatsDisplay();
        UpdateStatsNaZakonima();
    }

    private void RefreshMainStatsDisplay()
    {
        int yes = 0;
        int no = 0;

        for (int i = 0; i < brojOdgovorenihPitanjDa.Count; i++)
            yes += brojOdgovorenihPitanjDa[i];

        for (int i = 0; i < brojOdgovorenihPitanjaNe.Count; i++)
            no += brojOdgovorenihPitanjaNe[i];

        int unanswered = Mathf.Max(0, ukupnoPitanjaSve - yes - no);

        if (ukupniPregledText != null)
        {
            ukupniPregledText.text =
                "Da: " + yes +
                " · Ne: " + no +
                " · Nije odgovoreno: " + unanswered +
                "/" + ukupnoPitanjaSve;
        }

        float percent = ukupnoPitanjaSve > 0
            ? (float)(yes + no) / ukupnoPitanjaSve * 100f
            : 0f;

        if (percentText != null)
            percentText.text = Mathf.Floor(percent) + "%";
    }

    public void Save()
    {
        if (string.IsNullOrWhiteSpace(path))
            path = Path.Combine(Application.persistentDataPath, "ZakoniData.txt");

        File.WriteAllLines(path, lines ?? new string[0], Encoding.UTF8);
        content = File.ReadAllText(path, Encoding.UTF8);
    }

    public void UpdateStatsNaZakonima()
    {
        for (int i = 0; i < spawnedSelections.Count; i++)
        {
            if (spawnedSelections[i] == null)
                continue;

            GrupaZakonaChecker checker =
                spawnedSelections[i].GetComponent<GrupaZakonaChecker>();

            if (checker != null)
                checker.UpdateStats();
        }
    }

    public void Evaluate()
    {
        UpdateMainStats();

        int answered = 0;
        for (int i = 0; i < brojOdgovorenihPitanjDa.Count; i++)
            answered += brojOdgovorenihPitanjDa[i];

        for (int i = 0; i < brojOdgovorenihPitanjaNe.Count; i++)
            answered += brojOdgovorenihPitanjaNe[i];

        Debug.Log("Broj odgovorenih pitanja: " + answered);

        if (answered < 30)
        {
            if (EvaluationFailed != null)
                EvaluationFailed.SetActive(true);

            return;
        }

        if (EvaluationPage != null)
            EvaluationPage.SetActive(true);
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space))
            return;

        debugStanje = lines == null ? string.Empty : string.Join("\n", lines);
        Debug.Log(debugStanje);
        debugStanje = string.Empty;
    }
}
