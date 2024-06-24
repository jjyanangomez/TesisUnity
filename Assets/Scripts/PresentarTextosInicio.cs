using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PresentarTextosInicio : MonoBehaviour
{

    public Transform[] Views;
    public float transitions;
    Transform currentView;

    public GameObject PanelInformacion;

    public GameObject Panel_Botones;
    public GameObject Panel_Seleccionar;
    public GameObject Boton_Restaurar;
    public GameObject Boton_Jugar;
    // Start is called before the first frame update
    void Start()
    {
        currentView = transform;
        Boton_Restaurar.SetActive(false);
        Boton_Jugar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CambiarVistaJhon()
    {
        currentView = Views[0];
        DesactivarBotones();
        Boton_Restaurar.SetActive(true);
        Boton_Jugar.SetActive(true);
    }

    public void CambiarVistaLinda()
    {
        currentView = Views[1];
        DesactivarBotones();
        Boton_Restaurar.SetActive(true);
        Boton_Jugar.SetActive(true);
    }

    public void CambiarVistaFredderi()
    {
        currentView = Views[2];
        DesactivarBotones();
        Boton_Restaurar.SetActive(true);
        Boton_Jugar.SetActive(true);
    }

    public void CambiarVistaKelly()
    {
        currentView = Views[3];
        DesactivarBotones();
        Boton_Restaurar.SetActive(true);
        Boton_Jugar.SetActive(true);
    }

    public void RestaurarVistas()
    {
        currentView = Views[4];
        ActivarBotones();
        Boton_Restaurar.SetActive(false);
        Boton_Jugar.SetActive(false);
        PanelInformacion.SetActive(false);
    }

    private void DesactivarBotones()
    {
        Panel_Botones.SetActive(false);
        Panel_Seleccionar.SetActive(false);
    }

    private void ActivarBotones()
    {
        Panel_Botones.SetActive(true);
        Panel_Seleccionar.SetActive(true);
    }






    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitions);
    }




}
