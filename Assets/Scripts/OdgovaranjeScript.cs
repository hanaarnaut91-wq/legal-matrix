using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OdgovaranjeScript : MonoBehaviour
{
    private string imeGrupeZakona = string.Empty;

    [SerializeField]
    private int izabraniZakonIndex = -1;

    public TMP_Text ImegrupeZakonaText;
    public TMP_Text specifikacijeText;
    public TMP_Text procenatText;

    public SelekcijaGrupeZakonaMaker sgm;

    public List<string> pitanjaGrupe = new List<string>();
    public int brojOdgovorenihPitanja;
    public GameObject pitanjePrefab;
    public Transform ContentTransform;

    public int IzabraniZakonIndex
    {
        get { return izabraniZakonIndex; }
    }

    private void Awake()
    {
        if (sgm == null)
            sgm = FindObjectOfType<SelekcijaGrupeZakonaMaker>();
    }

    // Preferred method. GrupaZakonaChecker calls this with its exact block index.
    public void IzaberiGrupuPoIndeksu(int zakonIndex)
    {
        if (!IsValidLawIndex(zakonIndex))
        {
            Debug.LogError("Neispravan indeks zakonske grupe: " + zakonIndex);
            return;
        }

        izabraniZakonIndex = zakonIndex;
        imeGrupeZakona = sgm.LawBlocks[zakonIndex].LawName;

        if (ImegrupeZakonaText != null)
            ImegrupeZakonaText.text = imeGrupeZakona;

        ListajPitanja();
        UpdateNaSpecifikaciju();
    }

    // Compatibility method for old Unity button bindings.
    // It is safe only when the law name occurs exactly once.
    public void IzaberiGrupu(string imeGrupeNaKojojJeDugme)
    {
        if (sgm == null)
        {
            Debug.LogError("SGM referenca nije postavljena.");
            return;
        }

        int foundIndex = -1;
        int matches = 0;

        for (int i = 0; i < sgm.LawBlocks.Count; i++)
        {
            if (sgm.LawBlocks[i].LawName == imeGrupeNaKojojJeDugme)
            {
                foundIndex = i;
                matches++;
            }
        }

        if (matches == 0)
        {
            Debug.LogError(
                "Zakonska grupa nije pronađena: " +
                imeGrupeNaKojojJeDugme);
            return;
        }

        if (matches > 1)
        {
            Debug.LogError(
                "Naziv zakona se pojavljuje više puta: '" +
                imeGrupeNaKojojJeDugme +
                "'. Koristi IzaberiGrupuPoIndeksu preko " +
                "GrupaZakonaChecker.IzaberiOvuGrupu().");
            return;
        }

        IzaberiGrupuPoIndeksu(foundIndex);
    }

    public void ListajPitanja()
    {
        ClearQuestionObjects();

        pitanjaGrupe.Clear();
        brojOdgovorenihPitanja = 0;

        if (!IsValidLawIndex(izabraniZakonIndex))
            return;

        if (pitanjePrefab == null || ContentTransform == null)
        {
            Debug.LogError(
                "pitanjePrefab ili ContentTransform nisu postavljeni.");
            return;
        }

        LegalMatrixLawBlock block =
            sgm.LawBlocks[izabraniZakonIndex];

        for (int i = 0; i < block.Questions.Count; i++)
        {
            LegalMatrixQuestion record = block.Questions[i];

            pitanjaGrupe.Add(record.Text);

            if (record.Answer != LegalMatrixAnswer.Unanswered)
                brojOdgovorenihPitanja++;

            GameObject questionObject =
                Instantiate(pitanjePrefab, ContentTransform);

            questionObject.transform.localScale =
                new Vector3(1.190039f, 1.190039f, 1.190039f);

            PitanjeScript pitanjeScript =
                questionObject.GetComponent<PitanjeScript>();

            if (pitanjeScript == null)
            {
                Debug.LogError(
                    "Prefab pitanja nema PitanjeScript komponentu.");
                Destroy(questionObject);
                continue;
            }

            // This is the critical fix: the exact file-line index is supplied.
            pitanjeScript.Initialize(
                this,
                record.SourceLineIndex,
                record.Text);

            if (record.Answer != LegalMatrixAnswer.Unanswered)
                pitanjeScript.UgasiOdgovore();
            else
                pitanjeScript.PrikaziOdgovore();
        }
    }

    public void UpdateNaSpecifikaciju()
    {
        brojOdgovorenihPitanja = 0;
        pitanjaGrupe.Clear();

        if (!IsValidLawIndex(izabraniZakonIndex))
        {
            SetSpecificationText(0, 0);
            return;
        }

        LegalMatrixLawBlock block =
            sgm.LawBlocks[izabraniZakonIndex];

        for (int i = 0; i < block.Questions.Count; i++)
        {
            LegalMatrixQuestion question = block.Questions[i];

            pitanjaGrupe.Add(question.Text);

            if (question.Answer != LegalMatrixAnswer.Unanswered)
                brojOdgovorenihPitanja++;
        }

        SetSpecificationText(
            block.Questions.Count,
            brojOdgovorenihPitanja);
    }

    private void SetSpecificationText(int total, int answered)
    {
        if (specifikacijeText != null)
        {
            specifikacijeText.text =
                "Broj pitanja: " + total +
                " · Odgovoreno: " + answered;
        }

        float percent = total > 0
            ? (float)answered / total * 100f
            : 0f;

        if (procenatText != null)
            procenatText.text = Mathf.Floor(percent) + "%";
    }

    public void RefreshCurrentGroup()
    {
        if (!IsValidLawIndex(izabraniZakonIndex))
            return;

        ListajPitanja();
        UpdateNaSpecifikaciju();
    }

    public void Resetuj()
    {
        brojOdgovorenihPitanja = 0;
        pitanjaGrupe.Clear();
        ClearQuestionObjects();

        izabraniZakonIndex = -1;
        imeGrupeZakona = string.Empty;

        if (ImegrupeZakonaText != null)
            ImegrupeZakonaText.text = string.Empty;

        SetSpecificationText(0, 0);
    }

    private void ClearQuestionObjects()
    {
        if (ContentTransform == null)
            return;

        for (int i = ContentTransform.childCount - 1; i >= 0; i--)
        {
            Destroy(ContentTransform.GetChild(i).gameObject);
        }
    }

    private bool IsValidLawIndex(int index)
    {
        return sgm != null &&
               index >= 0 &&
               index < sgm.LawBlocks.Count;
    }
}
