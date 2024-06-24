using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CinematicaMision1 : MonoBehaviour
{
    public GameObject panelMision1;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;

    public GameObject activadorMision;

    public GameObject TextoIndicar;
    // Start is called before the first frame update
    public void activarPanel1()
    {
        panel1.SetActive(true);
    }
    public void activarPanel2()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
    }
    public void activarPanel3()
    {
        activadorMision.GetComponent<ActivarMisionConstructor>().enabled = true;
        panel2.SetActive(false);
        panel3.SetActive(true);
    }
    public void activarMision1()
    {
        panelMision1.SetActive(false);
        panel3.SetActive(false);
        TextoIndicar.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Completa la Misión";
        activadorMision.SetActive(false);
    }

}
