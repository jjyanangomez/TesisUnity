using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlJugador : MonoBehaviour
{
    public BaseMisiones BDMisiones;
    public ValidarMision valMision;
    //public PresentarMisiones1 cambiarMision;

    public int total=0;

    public GameObject objetoAux;
    public GameObject mision1;

    public bool estadoPreguntar = false;
    public GameObject MensajePresentar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (valMision.listaMisionesActivas.Count >=1)
        {
            if (total == valMision.listaMisionesActivas[0].GetComponent<MisionSuelo>().cantidadItems)
            {
                valMision.listaMisionesActivas[0].GetComponent<MisionSuelo>().MisionCompletada = true;
                Debug.Log("Entre:" +total);
                valMision.Completar(valMision.listaMisionesActivas[0].GetComponent<MisionSuelo>().IdMision);
                total = 0;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
       
    }
    public void ActualizarMensajeItem()
    {
        valMision.actualizarEstado("Recolecta todos los items  " + total + " / " +valMision.listaMisionesActivas[0].GetComponent<MisionSuelo>().cantidadItems);
    }
    public void ActualizarMensajeColocar()
    {
        valMision.actualizarEstado("Coloca en sus respectivos lugares todos los objetos  " + total + " / " + valMision.listaMisionesActivas[0].GetComponent<MisionSuelo>().cantidadItems);
    }

    public void restablecerEstado()
    {
    }
}
