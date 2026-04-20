using UnityEngine;
using TMPro;

public class PitanjeScript : MonoBehaviour
{
    public GameObject Odgovori;
    public GameObject porukaDaJeGotovo;

    public string pitanje;
    public int pitanjeIndex;
    public TMP_Text gdjeJePitanje;

    public SelekcijaGrupeZakonaMaker sgm;

    public void Start()
    {
        sgm = GameObject.Find("Odgovaranje").gameObject.GetComponent<OdgovaranjeScript>().sgm;
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
    }

    public void OdgovorNe()
    {
        sgm.lines[pitanjeIndex] += "#";
        sgm.Save();
        UgasiOdgovore();
    }

    public void UgasiOdgovore()
    {
        porukaDaJeGotovo.SetActive(true);
        Odgovori.SetActive(false);
    }
}
