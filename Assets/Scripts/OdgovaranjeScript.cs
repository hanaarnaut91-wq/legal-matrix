using UnityEngine;
using TMPro;
using System.Collections.Generic; // Required for Lists

public class OdgovaranjeScript : MonoBehaviour
{
    string ImegrupeZakona = "";

    public TMP_Text ImegrupeZakonaText;
    public TMP_Text specifikacijeText;
    public TMP_Text procenatText;

    public SelekcijaGrupeZakonaMaker sgm;

    public List<string> pitanjaGrupe = new List<string>();
    public int brojOdgovorenihPitanja = 0;
    public GameObject pitanjePrefab;
    public Transform ContentTransform;

    public void IzaberiGrupu(string imeGrupeNaKojojJeDugme)
    {
        ImegrupeZakona = imeGrupeNaKojojJeDugme;
        ImegrupeZakonaText.text = ImegrupeZakona;
        ListajPitanja();
        UpdateNaSpecifikaciju();
    }

    public void ListajPitanja()
    {
        int j = 0;

        //nadji zakon
        for (int i = 0; i < sgm.lines.Length; i++)
        {
            if (sgm.lines[i] == ImegrupeZakona)
            {
                j = i + 2;
            }
        }

        Debug.Log("Zakon nadjen na mjestu " + j.ToString());

        //nadji sva pitanja uz zakon
        while (sgm.lines[j].Trim() != "%")
        {
            Debug.Log(j.ToString());
            pitanjaGrupe.Add(sgm.lines[j]);
            j++;
        }

        //reset index
        j = 0;

        //set up pitanja (ako je odgovoreno nece stavljat "da/ne"//
        for(int i = 0; i < pitanjaGrupe.Count; i++)
        {
            //preconfig
            bool odgovoreno = false;
            if (pitanjaGrupe[i].Contains("#") || pitanjaGrupe[i].Contains("@"))
            {
                odgovoreno = true;
                brojOdgovorenihPitanja++;
            }
            // -----------------------------------
            GameObject p = Instantiate(pitanjePrefab, transform.position, Quaternion.identity);
            p.transform.SetParent(ContentTransform);
            p.transform.localScale = new Vector3(1.190039f, 1.190039f, 1.190039f);
            //dodijeli pitanje
            p.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = pitanjaGrupe[i];
            // ovo ako je odgovoreno pitanje
            if (odgovoreno == true)
            {
                p.gameObject.GetComponent<PitanjeScript>().UgasiOdgovore();
                odgovoreno = false;
            }
        }
    }

    //float percent = (4f / 97f) * 100f; procenat
    public void UpdateNaSpecifikaciju()
    {
        int j = 0;
        brojOdgovorenihPitanja = 0;
        pitanjaGrupe.Clear();
        //nadji zakon
        for (int i = 0; i < sgm.lines.Length; i++)
        {
            if (sgm.lines[i] == ImegrupeZakona)
            {
                j = i + 2;
            }
        }

        //nadji sva pitanja uz zakon
        while (sgm.lines[j].Trim() != "%")
        {
            Debug.Log(j.ToString());
            pitanjaGrupe.Add(sgm.lines[j]);
            j++;
        }

        //reset index
        j = 0;

        //set up pitanja (ako je odgovoreno nece stavljat "da/ne"//
        for (int i = 0; i < pitanjaGrupe.Count; i++)
        {
            //preconfig
            if (pitanjaGrupe[i].Contains("#") || pitanjaGrupe[i].Contains("@"))
            {
                brojOdgovorenihPitanja++;
            }
        }
        specifikacijeText.text = "Broj pitanja : " + pitanjaGrupe.Count.ToString() + " · Odgovoreno : " + brojOdgovorenihPitanja;
        float procenat = 0;
        procenat = (float)brojOdgovorenihPitanja / (float)pitanjaGrupe.Count * 100f;
        procenatText.text = Mathf.Floor(procenat).ToString() + "%";
    }   

    public void Resetuj()
    {
        brojOdgovorenihPitanja = 0;
        pitanjaGrupe.Clear();
        for (int i = 0; i < ContentTransform.childCount; i++)
        {
            Destroy(ContentTransform.GetChild(i).gameObject);
        }
    }
}
