using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueFlood : MonoBehaviour
{
    public GameObject objetivo;
    public GameObject Enemigo;
    public GameObject lugarFlood;
    public GameObject lugarSpartan;
    public GameObject brazoFlood;
    public GameObject MEnsajeBibliotecaria;
    public GameObject MEnsajeDidacta;
    public GameObject panelOscurecer;
    private void Start()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Player");
        objetivo = obj[0];
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            objetivo.GetComponent<Animator>().SetBool("Golpear", true);
            panelOscurecer.SetActive(true);
            Enemigo.SetActive(false);
            Enemigo.GetComponent<Transform>().position = lugarFlood.GetComponent<Transform>().position;
            Debug.Log("Flood:" + this.transform.position.x);
            brazoFlood.GetComponent<Collider>().enabled = false;

        }
    }

}


