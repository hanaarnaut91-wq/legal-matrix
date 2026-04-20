using UnityEngine;
using TMPro;

public class GrupaZakonaChecker : MonoBehaviour
{
    public SelekcijaGrupeZakonaMaker sgm;
    public TMP_Text statsText;
    public TMP_Text imeGrupe;
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
    }
}
