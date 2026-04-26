using UnityEngine;
using TMPro;

public class GrupaZakonaChecker : MonoBehaviour
{
    public SelekcijaGrupeZakonaMaker sgm;
    public TMP_Text statsText;
    public TMP_Text imeGrupe;
    public TMP_Text procenatText;
    int index;
    public void Start()
    {
        sgm = transform.parent.gameObject.GetComponent<SelekcijaGrupeZakonaMaker>();
    }

    public void UpdateStats()
    {
        for (int i = 0; i < sgm.zakoni.Count; i++)
        {
            if(sgm.zakoni[i] == imeGrupe.text)
            {
                index = i;
                break;
            }    
        }
        statsText.text = "broj pitanja: " + sgm.brojPitanjaUZakonu[index] + " · odgovoreno : " + sgm.brojOdgovorenihPitanjaUZakonu[index];
        float procenat = 0;
        procenat = (float)sgm.brojOdgovorenihPitanjaUZakonu[index] / (float)sgm.brojPitanjaUZakonu[index] * 100f;
        procenatText.text = Mathf.Floor(procenat).ToString() + "%";
    }
}
