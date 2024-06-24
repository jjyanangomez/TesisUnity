using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guia : MonoBehaviour
{
    public Generador generar;
    public BaseMisiones DBMisiones;
    public PreguntarPanel questPanel;
    public ValidarMision valmision;

    public bool EstadoPersonajeEntrega = false;
    public bool EstadoPersonajeInicia = false;
    public bool EstadoPersonajeFinaliza = false;


    private GameObject gameObjectAux;

    public void ContactoConJugador(GameObject mision)
    {
        if (EstadoPersonajeEntrega )
        {
            if (!EstadoPersonajeInicia)
            {
                gameObjectAux = mision;
                questPanel.accept_Button.gameObject.SetActive(true);
                questPanel.deny_Button.gameObject.SetActive(false);

                questPanel.ActualizarPanel(DBMisiones.misions[mision.GetComponent<MisionSuelo>().IdMision].nombre, DBMisiones.misions[mision.GetComponent<MisionSuelo>().IdMision].descripcion);

                questPanel.accept_Button.onClick.RemoveAllListeners();
                questPanel.accept_Button.onClick.AddListener(AceptarMision);
                questPanel.deny_Button.onClick.RemoveAllListeners();
                questPanel.deny_Button.onClick.AddListener(delegate () { questPanel.gameObject.SetActive(false); });
            }
            else
            {
                questPanel.accept_Button.gameObject.SetActive(false);
                questPanel.deny_Button.gameObject.SetActive(false);
                questPanel.ActualizarPanel(DBMisiones.misions[mision.GetComponent<MisionSuelo>().IdMision].nombre, "Esta mision esta pendiente finalice para acceder a otra");
            }
            
        }
        if(EstadoPersonajeEntrega == true && EstadoPersonajeInicia == true)
        {
           
        }
    }

    public void AceptarMision()
    {
        questPanel.gameObject.SetActive(false);
        restablecer();
        //Debug.LogWarning("Mision " + DBMisiones.misions[gameObjectAux.GetComponent<MisionSuelo>().IdMision].nombre + " iniciada!. ");
        valmision.listaMisionesActivas.Add(gameObjectAux);
        //Debug.LogError(DBMisiones.misions[valmision.listaMisionesActivas[0].GetComponent<MisionSuelo>().IdMision].descripcion);
        //Debug.LogWarning(valmision.listaMisionesActivas.Count);
        EstadoPersonajeInicia = true;
        valmision.listaMisionesActivas[0].GetComponent<MisionSuelo>().EstadoMision = true;
        int id = valmision.listaMisionesActivas[0].GetComponent<MisionSuelo>().IdMision;
        valmision.cambiarMision.Desactivar_Mision(id);
        Debug.Log(id);
        if (DBMisiones.misions[valmision.listaMisionesActivas[0].GetComponent<MisionSuelo>().IdMision].type == BaseMisiones.mision.QuestType.Entregar)
        {
            valmision.actualizarEstado("Dirigete al objetivo marcado");
            generar.Generar(id);
        }
        else if (DBMisiones.misions[valmision.listaMisionesActivas[0].GetComponent<MisionSuelo>().IdMision].type == BaseMisiones.mision.QuestType.Recolectar)
        {
            valmision.actualizarEstado("Recolecta todos los items  "+ DBMisiones.misions[valmision.listaMisionesActivas[0].GetComponent<MisionSuelo>().IdMision].Dato.cantidad+"/0");
            generar.Generar(id);
        }
    }

    public void restablecer()
    {
        EstadoPersonajeEntrega = true;
        EstadoPersonajeFinaliza = false;
        EstadoPersonajeInicia = false;
        questPanel.accept_Button.gameObject.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            questPanel.gameObject.SetActive(false);
        }
    }
}
