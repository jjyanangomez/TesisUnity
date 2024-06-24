using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Didacta_Gana : MonoBehaviour
{
    public GameObject PanelDidacta;
    public GameObject PanelResultados;
    public GameObject Texto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activar_Panel1()
    {
        PanelDidacta.transform.GetChild(0).gameObject.SetActive(true);
    }
    public void Activar_Panel2()
    {
        PanelDidacta.transform.GetChild(0).gameObject.SetActive(false);
        PanelDidacta.transform.GetChild(1).gameObject.SetActive(true);
    }
    public void Activar_Panel3()
    {
        PanelDidacta.transform.GetChild(1).gameObject.SetActive(false);
        PanelDidacta.transform.GetChild(2).gameObject.SetActive(true);
    }
    public void Desactivar_Panel3()
    {
        PanelDidacta.transform.GetChild(2).gameObject.SetActive(false);
    }
    public void ActivarRespuestas()
    {
        PanelResultados.SetActive(true);
    }
}
