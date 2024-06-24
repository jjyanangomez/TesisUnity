using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarLugar : MonoBehaviour
{
    public GameObject objetivo;
    public GameObject Enemigo;
    public GameObject lugarFlood;
    public GameObject lugarSpartan;

    public GameObject MEnsajeBibliotecaria;
    public GameObject MEnsajeDidacta;
    public GameObject PanelOscurecer;

    private void Start()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Player");
        objetivo = obj[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activarTeletranport()
    {
        //Atacar();
        //Flood
        /*Enemigo.GetComponent<Transform>().position = lugarFlood.GetComponent<Transform>().position;
        Debug.Log("Flood:" + this.transform.position.x);*/
        //Spartans
        objetivo.SetActive(false);
        Enemigo.SetActive(true);
        MEnsajeDidacta.GetComponent<MensajeDidacta>().estado = false;
        objetivo.GetComponent<Transform>().position = lugarSpartan.GetComponent<Transform>().position;
        Debug.Log("spartan:" + objetivo.GetComponent<Transform>().transform.position.x);
        MEnsajeBibliotecaria.SetActive(true);
        objetivo.GetComponent<Animator>().SetBool("Golpear", false);
        PanelOscurecer.SetActive(false);
    }
}
