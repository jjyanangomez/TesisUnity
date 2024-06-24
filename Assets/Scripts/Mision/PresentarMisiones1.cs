using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PresentarMisiones1 : MonoBehaviour
{
    //public GameObject Cubo_Principal_Mision;
    public GameObject Cubo_Mision1;
    public GameObject Cubo_Mision2;
    public GameObject Cubo_Mision3;
    public GameObject Cubo_Mision4;
    /*public GameObject Cubo_Mision5;
    public GameObject Cubo_Mision6;
    public GameObject Cubo_Mision7;*/



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void Activar_Mision(int id )
    {
        if (id == 0)
        {

        }else if (id == 5)
        {
            Cubo_Mision1.SetActive(false);
            Cubo_Mision2.SetActive(true);
        }
        else if (id == 8)
        {
            Cubo_Mision2.SetActive(false);
            Cubo_Mision3.SetActive(true);
        }
        else if (id == 9)
        {
            Cubo_Mision3.SetActive(false);
            Cubo_Mision4.SetActive(true);

        }
        else if (id == 10)
        {
            Cubo_Mision3.SetActive(false);
            Cubo_Mision4.SetActive(true);
        }
        /*else if (id == 5)
        {
            Cubo_Mision5.SetActive(true);
        }
        else if (id == 6)
        {
            Cubo_Mision6.SetActive(true);
        }
        else if (id == 7)
        {
            Cubo_Mision7.SetActive(true);
        }*/
    }

    public void Desactivar_Mision(int id)
    {
        if (id == 0)
        {
            //MensajePresionar.SetActive(false);
            //Cubo_Principal_Mision.SetActive(false);
        }
        else if (id == 1)
        {
            //MensajePresionar.SetActive(false);
            Cubo_Mision1.SetActive(false);
        }
        else if (id == 2)
        {
            //MensajePresionar.SetActive(false);
            Cubo_Mision2.SetActive(false);
        }
        else if (id == 3)
        {
            //MensajePresionar.SetActive(false);
            Cubo_Mision3.SetActive(false);
        }
        else if (id == 4)
        {
            //MensajePresionar.SetActive(false);
            Cubo_Mision4.SetActive(false);
        }
        /*else if (id == 5)
        {
            MensajePresionar.SetActive(false);
            Cubo_Mision5.SetActive(false);
        }
        else if (id == 6)
        {
            MensajePresionar.SetActive(false);
            Cubo_Mision6.SetActive(false);
        }
        else if (id == 7)
        {
            MensajePresionar.SetActive(false);
            Cubo_Mision7.SetActive(false);
        }*/
    }
    
    
}

