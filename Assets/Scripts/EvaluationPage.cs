using UnityEngine;
using System.IO;
using System.Collections.Generic; // Required for Lists
using TMPro;
using UnityEngine.UI;

public class EvaluationPage : MonoBehaviour
{
    public SelekcijaGrupeZakonaMaker sgm;

    string path;
    string content;
    public string[] lines;

    string pathEval;
    string contentEval;
    public string [] linesEval;

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
    }

    public int severityLevel;
    public GameObject StepenPravnogRizikaVelikaSlova;

    public string TextObjasnjenja = "";


    EvaluacijaPitanja Parse(string input)
    {
        string[] parts = input.Split('|');

        return new EvaluacijaPitanja
        {
            severityLevel = int.Parse(parts[1]),
            clan = parts[2],
            kategorija = parts[0],
            objasnjenje = parts[3],
            preporuka = parts[4]
        };
    }

    //EVALUACIJA
    public List<EvaluacijaPitanja> evaluacije = new List<EvaluacijaPitanja>();

    int legal = 0;
    int financial = 0;
    int operational = 0;

    public Image krug;
    public Image pillar1legal;
    public Image pillar2finjance;
    public Image pillar3operacije;

    public TMP_Text procenatFinansijeText;
    public TMP_Text procenatOperacijeText;
    public TMP_Text procenatLegalnoText;
    public TMP_Text procenatUkupnoPitanjaText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        //ocisti od prije
        for(int i = 0; i < contentPageZaObjasnjenja.childCount; i++)
        {
            Destroy(contentPageZaObjasnjenja.GetChild(i));
        }
        evaluacije.Clear();


        //otvoriti sva pitanja i ucitati ih
        path = Application.persistentDataPath + "/ZakoniData.txt";
        content = File.ReadAllText(path);
        lines = content.Split('\n');

        pathEval = Application.persistentDataPath + "/SeverityData.txt";
        contentEval = File.ReadAllText(pathEval);
        linesEval = contentEval.Split("\n");
        // ucitano

        //dupla petlja koja prati koja su NE (odgovorena sa #) i dodaje to pitanje u gore liste (ahem, severity, objasnjenje, i koja kategorija)
        for(int i = 0; i < lines.Length; i++)
        {
            if(lines[i].Contains("#"))
            {
                EvaluacijaPitanja eval = Parse(linesEval[i]);
                if (i < 54)
                {
                    eval.zakon = "Zakon o radu FBiH";
                }
                else if (i > 57 && i < 62)
                {
                    eval.zakon = "Zakon o zapošljavanju stranaca";
                }
                else if (i > 65 && i < 71)
                {
                    eval.zakon = "Zakon o štrajku";
                }
                //ovdje treba jos ostale zakone dodat u picku lijepu materinu
                evaluacije.Add(eval);
            }
        }

        //procjeni rizik
        for (int i = 0; i < evaluacije.Count; i++)
        {
            severityLevel += evaluacije[i].severityLevel;
        }

        //procjeni kategoriju
        for (int i = 0; i < evaluacije.Count; i++)
        {
            switch(evaluacije[i].kategorija){
                case "legal":
                    legal++;
                    break;
                case "operational":
                    operational++;
                    break;
                case "financial":
                    financial++;
                    break;
                default:
                    break;
            }
        }

        //OVO JE HARD CODED ZA ONE CHARTOVE i nivo rizika :D
        if (severityLevel < 15)
        {
            StepenPravnogRizikaVelikaSlova.transform.GetChild(2).gameObject.SetActive(true);
        }
        else if (severityLevel > 15 && severityLevel < 45)
        {
            StepenPravnogRizikaVelikaSlova.transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (severityLevel > 45)
        {
            StepenPravnogRizikaVelikaSlova.transform.GetChild(0).gameObject.SetActive(true);
        }

        float procenatUkupno = Mathf.Floor(((float)evaluacije.Count / (float)sgm.ukupnoPitanjaSve) * 100f);
        float procenatFinansije = Mathf.Floor(((float)financial / 7f) * 100f);
        float procenatOperacije = Mathf.Floor(((float)operational / 8f) * 100f);
        float procenatLegalno = Mathf.Floor(((float)legal / 75f) * 100f);

        /*
             public Image krug;
    public Image pillar1legal;
    public Image pillar2finjance;
    public Image pillar3operacije;

    public TMP_Text procenatFinansijeText;
    public TMP_Text procenatOperacijeText;
    public TMP_Text procenatLegalnoText;
    public TMP_Text procenatUkupnoPitanjaText;*/

        krug.fillAmount = procenatUkupno / 100;
        pillar1legal.fillAmount = procenatLegalno / 100;
        pillar2finjance.fillAmount = procenatFinansije / 100;
        pillar3operacije.fillAmount = procenatOperacije / 100;

        procenatFinansijeText.text = procenatFinansije.ToString() + "%";
        procenatOperacijeText.text = procenatOperacije.ToString() + "%";
        procenatLegalnoText.text = procenatLegalno.ToString() + "%";
        procenatUkupnoPitanjaText.text = procenatUkupno.ToString() + "%";

        foreach (EvaluacijaPitanja e in evaluacije)
        {
            GameObject o = Instantiate(objasnjenjeElement, transform.position, Quaternion.identity);
            o.transform.SetParent(contentPageZaObjasnjenja);
            o.transform.localScale = new Vector3(1, 1, 1);
            //dodijeli rizik na osnovu severity-a
            string aaaah = "";
            switch(e.severityLevel)
            {
                case 5:
                    aaaah = "VISOK RIZIK";
                    break;
                case 4:
                    aaaah = "SREDNJE VISOK RIZIK";
                    break;
                case 3:
                    aaaah = "MEDIALAN RIZIK";
                    break;
                case 2:
                    aaaah = "MEDIALNO NIZAK RIZIK";
                    break;
                case 1:
                    aaaah = "NIZAK RIZIK";
                    break;
                default:
                    break;
            }
            o.transform.GetChild(4).gameObject.GetComponent<TMP_Text>().text = aaaah;
            // preporuka i objasnjenje
            o.transform.GetChild(5).gameObject.GetComponent<TMP_Text>().text = e.objasnjenje;
            o.transform.GetChild(6).gameObject.GetComponent<TMP_Text>().text = e.preporuka;
        }
    }

}

 /*Legal Matrix je sistem pravne prevencije koji pomaže kompanijama da na vrijeme prepoznaju i spriječe pravne rizike u poslovanju. Kroz digitalnu provjeru i usklađivanjem obaveza biznisi
 dobijaju jasan pregled svog pravnog statusa i potencijalnih rizika. Nakon inicijalne provjere, proces se nastavlja kroz strukturalnu analizu kompanija, koja pomaže da se otklone nedostaci i 
 uspostavi stabilniji pravni sistem sigurnosti biznisa i završava samom prevencijom.*/