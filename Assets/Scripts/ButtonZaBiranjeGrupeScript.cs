using UnityEngine;
using TMPro;

public class ButtonZaBiranjeGrupeScript : MonoBehaviour
{
    public GameObject odgovaranje;
    public TMP_Text imeGrupeText;

    void Awake()
    {
        odgovaranje = GameObject.Find("Odgovaranje Holder").transform.GetChild(0).gameObject;
    }

    public void otvoriDer()
    {
        odgovaranje.SetActive(true);
        odgovaranje.GetComponent<OdgovaranjeScript>().IzaberiGrupu(imeGrupeText.text);
    }

}
