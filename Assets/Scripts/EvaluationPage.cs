using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EvaluationPage : MonoBehaviour
{
    public SelekcijaGrupeZakonaMaker sgm;

    private string path;
    private string content;
    public string[] lines;

    private string pathEval;
    private string contentEval;
    public string[] linesEval;

    public Transform contentPageZaObjasnjenja;
    public GameObject objasnjenjeElement;

    public struct EvaluacijaPitanja
    {
        public int severityLevel;
        public string clan;
        public string kategorija;
        public string objasnjenje;
        public string preporuka;
        public string zakon;
        public string pitanje; // Add this
    }

    public int severityLevel;
    public GameObject StepenPravnogRizikaVelikaSlova;
    public string TextObjasnjenja = string.Empty;

    public List<EvaluacijaPitanja> evaluacije =
        new List<EvaluacijaPitanja>();

    private int legal;
    private int financial;
    private int operational;

    public Image krug;
    public Image pillar1legal;
    public Image pillar2finjance;
    public Image pillar3operacije;

    public TMP_Text procenatFinansijeText;
    public TMP_Text procenatOperacijeText;
    public TMP_Text procenatLegalnoText;
    public TMP_Text procenatUkupnoPitanjaText;

    private void OnEnable()
    {
        ResetState();
        ClearExplanationObjects();

        path = Path.Combine(Application.persistentDataPath, "ZakoniData.txt");
        pathEval = Path.Combine(Application.persistentDataPath, "SeverityData.txt");

        if (!File.Exists(path) || !File.Exists(pathEval))
        {
            Debug.LogError(
                "Nedostaje ZakoniData.txt ili SeverityData.txt u: " +
                Application.persistentDataPath);

            return;
        }

        content = File.ReadAllText(path, Encoding.UTF8);
        lines = File.ReadAllLines(path, Encoding.UTF8);

        contentEval = File.ReadAllText(pathEval, Encoding.UTF8);
        linesEval = File.ReadAllLines(pathEval, Encoding.UTF8);

        List<LegalMatrixLawBlock> questionBlocks =
            LegalMatrixDataParser.ParseQuestionBlocks(lines);

        List<LegalMatrixRiskBlock> riskBlocks =
            LegalMatrixDataParser.ParseRiskBlocks(linesEval);

        BuildEvaluation(questionBlocks, riskBlocks);
        CalculateAndDisplayStatistics(questionBlocks, riskBlocks);
        BuildExplanationObjects();
    }

    private void ResetState()
    {
        evaluacije.Clear();
        severityLevel = 0;
        legal = 0;
        financial = 0;
        operational = 0;
        TextObjasnjenja = string.Empty;

        if (StepenPravnogRizikaVelikaSlova != null)
        {
            for (int i = 0;
                 i < StepenPravnogRizikaVelikaSlova.transform.childCount;
                 i++)
            {
                StepenPravnogRizikaVelikaSlova
                    .transform
                    .GetChild(i)
                    .gameObject
                    .SetActive(false);
            }
        }
    }

    private void ClearExplanationObjects()
    {
        if (contentPageZaObjasnjenja == null)
            return;

        for (int i = contentPageZaObjasnjenja.childCount - 1; i >= 0; i--)
        {
            Destroy(contentPageZaObjasnjenja.GetChild(i).gameObject);
        }
    }

    private void BuildEvaluation(
        List<LegalMatrixLawBlock> questionBlocks,
        List<LegalMatrixRiskBlock> riskBlocks)
    {
        if (questionBlocks.Count != riskBlocks.Count)
        {
            Debug.LogError(
                "Broj blokova se ne podudara. Pitanja: " +
                questionBlocks.Count + ", rizici: " + riskBlocks.Count);
        }

        int blockCount = Mathf.Min(questionBlocks.Count, riskBlocks.Count);

        for (int blockIndex = 0; blockIndex < blockCount; blockIndex++)
        {
            LegalMatrixLawBlock questionBlock = questionBlocks[blockIndex];
            LegalMatrixRiskBlock riskBlock = riskBlocks[blockIndex];

            if (questionBlock.LawName != riskBlock.LawName)
            {
                Debug.LogError(
                    "Zakoni nisu poravnati u bloku " + blockIndex +
                    ": '" + questionBlock.LawName +
                    "' naspram '" + riskBlock.LawName + "'.");
            }

            if (questionBlock.Questions.Count != riskBlock.Risks.Count)
            {
                Debug.LogError(
                    "Broj pitanja i rizika se ne podudara za blok '" +
                    questionBlock.LawName + "'. Pitanja: " +
                    questionBlock.Questions.Count + ", rizici: " +
                    riskBlock.Risks.Count);
            }

            int recordCount = Mathf.Min(
                questionBlock.Questions.Count,
                riskBlock.Risks.Count);

            for (int questionIndex = 0;
                 questionIndex < recordCount;
                 questionIndex++)
            {
                LegalMatrixQuestion question =
                    questionBlock.Questions[questionIndex];

                if (question.Answer != LegalMatrixAnswer.No)
                    continue;

                LegalMatrixRisk risk = riskBlock.Risks[questionIndex];

                evaluacije.Add(new EvaluacijaPitanja
                {
                    severityLevel = risk.Severity,
                    pitanje = question.Text,
                    clan = risk.Article,
                    kategorija = risk.Category,
                    objasnjenje = risk.Explanation,
                    preporuka = risk.Recommendation,
                    zakon = questionBlock.LawName
                });
            }
        }
    }

    private void CalculateAndDisplayStatistics(
        List<LegalMatrixLawBlock> questionBlocks,
        List<LegalMatrixRiskBlock> riskBlocks)
    {
        int totalQuestions = 0;
        int totalLegal = 0;
        int totalFinancial = 0;
        int totalOperational = 0;

        for (int i = 0; i < questionBlocks.Count; i++)
            totalQuestions += questionBlocks[i].Questions.Count;

        for (int i = 0; i < riskBlocks.Count; i++)
        {
            for (int r = 0; r < riskBlocks[i].Risks.Count; r++)
            {
                switch (riskBlocks[i].Risks[r].Category)
                {
                    case "legal":
                        totalLegal++;
                        break;

                    case "financial":
                        totalFinancial++;
                        break;

                    case "operational":
                        totalOperational++;
                        break;
                }
            }
        }

        for (int i = 0; i < evaluacije.Count; i++)
        {
            severityLevel += evaluacije[i].severityLevel;

            switch (evaluacije[i].kategorija)
            {
                case "legal":
                    legal++;
                    break;

                case "financial":
                    financial++;
                    break;

                case "operational":
                    operational++;
                    break;
            }
        }

        SetRiskLevelIndicator();

        float overallPercent = Percentage(evaluacije.Count, totalQuestions);
        float financialPercent = Percentage(financial, totalFinancial);
        float operationalPercent = Percentage(operational, totalOperational);
        float legalPercent = Percentage(legal, totalLegal);

        SetFill(krug, overallPercent);
        SetFill(pillar1legal, legalPercent);
        SetFill(pillar2finjance, financialPercent);
        SetFill(pillar3operacije, operationalPercent);

        SetPercentText(procenatFinansijeText, financialPercent);
        SetPercentText(procenatOperacijeText, operationalPercent);
        SetPercentText(procenatLegalnoText, legalPercent);
        SetPercentText(procenatUkupnoPitanjaText, overallPercent);
    }

    private void SetRiskLevelIndicator()
    {
        if (StepenPravnogRizikaVelikaSlova == null ||
            StepenPravnogRizikaVelikaSlova.transform.childCount < 3)
        {
            return;
        }

        int childIndex;

        if (severityLevel <= 15)
            childIndex = 2;
        else if (severityLevel <= 45)
            childIndex = 1;
        else
            childIndex = 0;

        StepenPravnogRizikaVelikaSlova
            .transform
            .GetChild(childIndex)
            .gameObject
            .SetActive(true);
    }

    private void BuildExplanationObjects()
    {
        if (contentPageZaObjasnjenja == null ||
            objasnjenjeElement == null)
        {
            return;
        }

        for (int i = 0; i < evaluacije.Count; i++)
        {
            EvaluacijaPitanja evaluation = evaluacije[i];

            GameObject item =
                Instantiate(objasnjenjeElement, contentPageZaObjasnjenja);

            item.transform.localScale = Vector3.one;

            if (item.transform.childCount > 4)
            {
                TMP_Text riskText =
                    item.transform.GetChild(4).GetComponent<TMP_Text>();

                if (riskText != null)
                    riskText.text = SeverityLabel(evaluation.severityLevel);
            }

            if (item.transform.childCount > 5)
            {
                TMP_Text explanationText =
                    item.transform.GetChild(5).GetComponent<TMP_Text>();

                if (explanationText != null)
                    explanationText.text = evaluation.pitanje;
            }

            if (item.transform.childCount > 6)
            {
                TMP_Text recommendationText =
                    item.transform.GetChild(6).GetComponent<TMP_Text>();

                if (recommendationText != null)
                    recommendationText.text = evaluation.preporuka;
            }

            // ---------------------------- //
            TMP_Text zakoniClan = 
                    item.transform.GetChild(1).GetComponent<TMP_Text>();
            zakoniClan.text = evaluation.zakon + " / " + evaluation.clan;
        }
    }

    private static string SeverityLabel(int severity)
    {
        switch (severity)
        {
            case 5:
                return "VISOK RIZIK";

            case 4:
                return "SREDNJE VISOK RIZIK";

            case 3:
                return "MEDIJALAN RIZIK";

            case 2:
                return "MEDIJALNO NIZAK RIZIK";

            case 1:
                return "NIZAK RIZIK";

            default:
                return "NEPOZNAT RIZIK";
        }
    }

    private static float Percentage(int value, int total)
    {
        if (total <= 0)
            return 0f;

        return Mathf.Floor((float)value / total * 100f);
    }

    private static void SetFill(Image image, float percent)
    {
        if (image != null)
            image.fillAmount = Mathf.Clamp01(percent / 100f);
    }

    private static void SetPercentText(TMP_Text text, float percent)
    {
        if (text != null)
            text.text = percent + "%";
    }
}
