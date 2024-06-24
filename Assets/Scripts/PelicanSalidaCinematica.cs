using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelicanSalidaCinematica : MonoBehaviour
{
    public GameObject PanelEquipoAzul;
    public GameObject PanelResultados;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivarPanel1Equipo()
    {
        PanelEquipoAzul.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void ActivarPanel2Equipo()
    {
        PanelEquipoAzul.transform.GetChild(0).gameObject.SetActive(false);
        PanelEquipoAzul.transform.GetChild(1).gameObject.SetActive(true);
    }
    public void ActivarPanel3Equipo()
    {
        PanelEquipoAzul.transform.GetChild(1).gameObject.SetActive(false);
        PanelEquipoAzul.transform.GetChild(2).gameObject.SetActive(true);
    }
    public void DesactivarPanel3Equipo()
    {
        PanelEquipoAzul.transform.GetChild(2).gameObject.SetActive(false);
    }

    public void ActivarPanelResultados()
    {
        PanelResultados.SetActive(true);
    }

}
