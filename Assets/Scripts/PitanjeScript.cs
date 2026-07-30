using TMPro;
using UnityEngine;

public class PitanjeScript : MonoBehaviour
{
    public GameObject Odgovori;
    public GameObject porukaDaJeGotovo;

    public string pitanje;
    public int pitanjeIndex = -1;
    public TMP_Text gdjeJePitanje;

    public OdgovaranjeScript os;
    public SelekcijaGrupeZakonaMaker sgm;

    private bool initialized;

    private void Start()
    {
        ResolveReferences();

        // This fallback only works when the question text is unique.
        // OdgovaranjeScript.Initialize(...) should normally initialize the index first.
        if (!initialized)
            ResolveIndexFallback();
    }

    public void Initialize(
        OdgovaranjeScript owner,
        int sourceLineIndex,
        string questionText)
    {
        os = owner;
        sgm = owner != null ? owner.sgm : sgm;

        pitanjeIndex = sourceLineIndex;
        pitanje = LegalMatrixDataParser.RemoveAnswerMarker(questionText);

        if (gdjeJePitanje != null)
            gdjeJePitanje.text = pitanje;

        initialized = true;
    }

    public void InitializeFromBlock(
        OdgovaranjeScript owner,
        int lawBlockIndex,
        int questionIndex)
    {
        os = owner;
        sgm = owner != null ? owner.sgm : sgm;

        if (sgm == null ||
            lawBlockIndex < 0 ||
            lawBlockIndex >= sgm.LawBlocks.Count)
        {
            Debug.LogError("Neispravan indeks zakonskog bloka: " + lawBlockIndex);
            return;
        }

        LegalMatrixLawBlock block = sgm.LawBlocks[lawBlockIndex];

        if (questionIndex < 0 || questionIndex >= block.Questions.Count)
        {
            Debug.LogError(
                "Neispravan indeks pitanja " + questionIndex +
                " u bloku " + lawBlockIndex);
            return;
        }

        LegalMatrixQuestion record = block.Questions[questionIndex];

        Initialize(
            owner,
            record.SourceLineIndex,
            record.Text);
    }

    private void ResolveReferences()
    {
        if (os == null)
        {
            GameObject odgovaranjeObject = GameObject.Find("Odgovaranje");

            if (odgovaranjeObject != null)
                os = odgovaranjeObject.GetComponent<OdgovaranjeScript>();
        }

        if (sgm == null && os != null)
            sgm = os.sgm;
    }

    private void ResolveIndexFallback()
    {
        if (sgm == null)
        {
            Debug.LogError("SelekcijaGrupeZakonaMaker nije pronađen.");
            return;
        }

        if (gdjeJePitanje != null)
        {
            pitanje =
                LegalMatrixDataParser.RemoveAnswerMarker(
                    gdjeJePitanje.text);
        }

        int uniqueIndex;

        if (sgm.TryFindUniqueQuestionIndex(pitanje, out uniqueIndex))
        {
            pitanjeIndex = uniqueIndex;
            initialized = true;
            return;
        }

        Debug.LogError(
            "Pitanje nije inicijalizirano stvarnim indeksom, " +
            "a njegov tekst nije jedinstven: " + pitanje);
    }

    public void OdgovorDa()
    {
        SetAnswer(LegalMatrixAnswer.Yes);
    }

    public void OdgovorNe()
    {
        SetAnswer(LegalMatrixAnswer.No);
    }

    public void PonistiOdgovor()
    {
        SetAnswer(LegalMatrixAnswer.Unanswered);
    }

    private void SetAnswer(LegalMatrixAnswer answer)
    {
        ResolveReferences();

        if (sgm == null)
        {
            Debug.LogError("Odgovor nije sačuvan: nedostaje SGM referenca.");
            return;
        }

        if (pitanjeIndex < 0 || pitanjeIndex >= sgm.lines.Length)
        {
            Debug.LogError(
                "Odgovor nije sačuvan: neispravan indeks pitanja " +
                pitanjeIndex);
            return;
        }

        if (!sgm.SetAnswer(pitanjeIndex, answer))
            return;

        UgasiOdgovore();

        if (os != null)
            os.UpdateNaSpecifikaciju();
    }

    public void UgasiOdgovore()
    {
        if (porukaDaJeGotovo != null)
            porukaDaJeGotovo.SetActive(true);

        if (Odgovori != null)
            Odgovori.SetActive(false);
    }

    public void PrikaziOdgovore()
    {
        if (porukaDaJeGotovo != null)
            porukaDaJeGotovo.SetActive(false);

        if (Odgovori != null)
            Odgovori.SetActive(true);
    }
}
