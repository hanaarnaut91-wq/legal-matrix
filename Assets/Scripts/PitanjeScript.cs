using UnityEngine;
using TMPro;

public class PitanjeScript : MonoBehaviour
{
    public GameObject Odgovori;
    public GameObject porukaDaJeGotovo;

    public string pitanje;
    public int pitanjeIndex;
    public TMP_Text gdjeJePitanje;

    public OdgovaranjeScript os;
    public SelekcijaGrupeZakonaMaker sgm;

    public void Start()
    {
        os = GameObject.Find("Odgovaranje").gameObject.GetComponent<OdgovaranjeScript>();
        sgm = os.sgm;
        NadjiPitanjeUBazi();
    }

    public void NadjiPitanjeUBazi()
    {
        pitanje = gdjeJePitanje.text;
        for(int i = 0; i < sgm.lines.Length; i++)
        {
            if(sgm.lines[i].Contains(gdjeJePitanje.text))
            {
                pitanjeIndex = i;
            }
        }
    }

    public void OdgovorDa()
    {
        sgm.lines[pitanjeIndex] = sgm.lines[pitanjeIndex] + "@";
        sgm.Save();
        UgasiOdgovore();
        os.UpdateNaSpecifikaciju();
    }

    public void OdgovorNe()
    {
        sgm.lines[pitanjeIndex] += "#";
        sgm.Save();
        UgasiOdgovore();
        os.UpdateNaSpecifikaciju();
    }

    public void UgasiOdgovore()
    {
        porukaDaJeGotovo.SetActive(true);
        Odgovori.SetActive(false);
    }
}
