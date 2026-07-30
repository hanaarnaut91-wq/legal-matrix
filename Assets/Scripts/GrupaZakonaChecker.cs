using TMPro;
using UnityEngine;

public class GrupaZakonaChecker : MonoBehaviour
{
    public SelekcijaGrupeZakonaMaker sgm;
    public OdgovaranjeScript odgovaranjeScript;

    public TMP_Text statsText;
    public TMP_Text imeGrupe;
    public TMP_Text procenatText;

    [SerializeField]
    private int zakonIndex = -1;

    public int ZakonIndex
    {
        get { return zakonIndex; }
    }

    public void Initialize(
        SelekcijaGrupeZakonaMaker maker,
        int newIndex)
    {
        sgm = maker;
        zakonIndex = newIndex;

        if (odgovaranjeScript == null)
            odgovaranjeScript = FindObjectOfType<OdgovaranjeScript>();

        if (sgm != null &&
            zakonIndex >= 0 &&
            zakonIndex < sgm.zakoni.Count &&
            imeGrupe != null)
        {
            imeGrupe.text = sgm.zakoni[zakonIndex];
        }

        UpdateStats();
    }

    private void Start()
    {
        if (sgm == null && transform.parent != null)
            sgm = transform.parent.GetComponent<SelekcijaGrupeZakonaMaker>();

        if (odgovaranjeScript == null)
            odgovaranjeScript = FindObjectOfType<OdgovaranjeScript>();

        if (zakonIndex < 0)
        {
            Debug.LogError(
                "GrupaZakonaChecker nije inicijaliziran indeksom zakona.");
        }
    }

    // Connect the law-selection button to this method.
    public void IzaberiOvuGrupu()
    {
        if (odgovaranjeScript == null)
            GameObject.Find("Odgovaranje Holder").transform.GetChild(0).gameObject.SetActive(true);
            odgovaranjeScript = GameObject.Find("Odgovaranje Holder").transform.GetChild(0).gameObject.GetComponent<OdgovaranjeScript>();

        if (odgovaranjeScript == null)
        {
            Debug.LogError("OdgovaranjeScript nije pronađen.");
            return;
        }

        odgovaranjeScript.IzaberiGrupuPoIndeksu(zakonIndex);
    }

    public void UpdateStats()
    {
        if (sgm == null ||
            zakonIndex < 0 ||
            zakonIndex >= sgm.brojPitanjaUZakonu.Count ||
            zakonIndex >= sgm.brojOdgovorenihPitanjaUZakonu.Count)
        {
            return;
        }

        int total = sgm.brojPitanjaUZakonu[zakonIndex];
        int answered = sgm.brojOdgovorenihPitanjaUZakonu[zakonIndex];

        if (statsText != null)
        {
            statsText.text =
                "broj pitanja: " + total +
                " · odgovoreno: " + answered;
        }

        float percent = total > 0
            ? (float)answered / total * 100f
            : 0f;

        if (procenatText != null)
            procenatText.text = Mathf.Floor(percent) + "%";
    }
}
