using UnityEngine;
using System.IO;
using System.Collections.Generic; // Required for Lists
using TMPro;

public class SelekcijaGrupeZakonaMaker : MonoBehaviour
{
    public List<string> zakoni = new List<string>();
    public List<int> brojPitanjaUZakonu = new List<int>();
    public List<int> brojOdgovorenihPitanjaUZakonu = new List<int>();
    public GameObject selekcijaZakonElement;

    public string path;
    public string content;
    public string[] lines;

    //ukupni pregled
    public TMP_Text ukupniPregledText;
    public List<int> brojOdgovorenihPitanjDa = new List<int>();
    public List<int> brojOdgovorenihPitanjaNe = new List<int>();
    public int ukupnoPitanjaSve = 0;

    //debug
    string debugStanje;

    void Start()
    {
        path = Application.persistentDataPath + "/ZakoniData.txt";
        content = File.ReadAllText(path);
        //Split into lines
        lines = content.Split('\n');
        //provjera zakona i dodavanje ----------------------------------------------------------------------------------------------
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Trim() == "=")
            {
                zakoni.Add(lines[i - 1]);
            }
        }
        // @ = odgovoreno sa da, # = odgovoreno sa ne ---------------------------------------------------------------------------------------------------
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Trim() == "=")
            {
                int ukupnoPitanja = -1;
                int j = i;

                int odgovorenih = 0;

                int da = 0;
                int ne = 0;

                while (lines[j].Trim() != "%")
                {
                    if (lines[j].Trim().Contains("@"))
                    {
                        odgovorenih++;
                        da++;
                    }
                    else if (lines[j].Trim().Contains("#"))
                    {
                        odgovorenih++;
                        ne++;
                    }

                    ukupnoPitanja++;
                    ukupnoPitanjaSve++;
                    j++;
                }
                brojPitanjaUZakonu.Add(ukupnoPitanja);
                brojOdgovorenihPitanjaUZakonu.Add(odgovorenih);
                brojOdgovorenihPitanjDa.Add(da);
                brojOdgovorenihPitanjaNe.Add(ne);
                ukupnoPitanjaSve--; //moras odbit jedan jer zakon delimiter broji i njega
            }
        }

        //pravi selekcije > .. i-1 je ime zakona .. od i do % su sva pitanja za specifikacije ..  ---------------------------------------------------------------------------
        for (int i = 0; i < zakoni.Count; i++)
        {
            GameObject o = Instantiate(selekcijaZakonElement, transform.position, Quaternion.identity);
            o.transform.SetParent(transform);
            o.transform.localScale = new Vector3(1, 1, 1);
            //dodijeli ime
            o.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = zakoni[i];
            // dodijeli koliko ima pitanja "broj pitanja : · odgovoreno n/N"
            o.transform.GetChild(2).gameObject.GetComponent<TMP_Text>().text = "broj pitanja: " + brojPitanjaUZakonu[i] + " · odgovoreno : " + brojOdgovorenihPitanjaUZakonu[i];
        }

        //Ukupni pregled onaj gore "Da · Ne · Nije odgovoreno : n/n" ----------------------------------------------------------------------
        int d = 0;
        int n = 0;
        for (int i = 0; i < brojOdgovorenihPitanjDa.Count; i++)
        {
            d += brojOdgovorenihPitanjDa[i];
        }
        for (int i = 0; i < brojOdgovorenihPitanjaNe.Count; i++)
        {
            n += brojOdgovorenihPitanjaNe[i];
        }
        int nijeOdgovoreno = ukupnoPitanjaSve - d - n;
        ukupniPregledText.text = "Da : " + d.ToString() + " · Ne : " + n.ToString() + " · Nije odgovoreno : " + nijeOdgovoreno.ToString() + "/" + ukupnoPitanjaSve.ToString();
    }

    public void UpdateMainStats()
    {
        brojOdgovorenihPitanjDa.Clear();
        brojOdgovorenihPitanjaNe.Clear();
        brojPitanjaUZakonu.Clear();
        brojOdgovorenihPitanjaUZakonu.Clear();
        ukupnoPitanjaSve = 0;

        // @ = odgovoreno sa da, # = odgovoreno sa ne ---------------------------------------------------------------------------------------------------
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Trim() == "=")
            {
                int ukupnoPitanja = -1;
                int j = i;

                int odgovorenih = 0;

                int da = 0;
                int ne = 0;

                while (lines[j].Trim() != "%")
                {
                    if (lines[j].Trim().Contains("@"))
                    {
                        odgovorenih++;
                        da++;
                    }
                    else if (lines[j].Trim().Contains("#"))
                    {
                        odgovorenih++;
                        ne++;
                    }

                    ukupnoPitanja++;
                    ukupnoPitanjaSve++;
                    j++;
                }
                brojPitanjaUZakonu.Add(ukupnoPitanja);
                brojOdgovorenihPitanjaUZakonu.Add(odgovorenih);
                brojOdgovorenihPitanjDa.Add(da);
                brojOdgovorenihPitanjaNe.Add(ne);
                ukupnoPitanjaSve--; //moras odbit jedan jer zakon delimiter broji i njega
            }
        }
        int d = 0;
        int n = 0;
        for (int i = 0; i < brojOdgovorenihPitanjDa.Count; i++)
        {
            d += brojOdgovorenihPitanjDa[i];
        }
        for (int i = 0; i < brojOdgovorenihPitanjaNe.Count; i++)
        {
            n += brojOdgovorenihPitanjaNe[i];
        }
        int nijeOdgovoreno = ukupnoPitanjaSve - d - n;
        ukupniPregledText.text = "Da : " + d.ToString() + " · Ne : " + n.ToString() + " · Nije odgovoreno : " + nijeOdgovoreno.ToString() + "/" + ukupnoPitanjaSve.ToString();
    }

    public void Save()
    {
        string content = "";
        for (int i = 0; i < lines.Length; i++)
        {
            content += lines[i];
        }
        File.WriteAllText(path, content);
    }

    public void UpdateStatsNaZakonima()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<GrupaZakonaChecker>().UpdateStats();
        }
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        { 
            for (int i = 0; i < lines.Length; i++)
            {
                debugStanje += lines[i] + "\n";
            }
            Debug.Log(debugStanje);
            debugStanje = "";
        }
    }
}
