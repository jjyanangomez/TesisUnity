using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ai_Enemigo : MonoBehaviour
{
    public GameObject objetivo;
    public float Velocidad;
    public NavMeshAgent IA;

    public Animator Anim;
    public GameObject ObjetoBrazo; 
    private bool estado = false;
    private void Start()
    {
        GameObject[] obj =  GameObject.FindGameObjectsWithTag("Player");
        objetivo = obj[0];
    }
    // Update is called once per frame
    void Update()
    {
        if (objetivo)
        {
            IA.speed = Velocidad;
            IA.SetDestination(objetivo.GetComponent<Transform>().position);

            if (IA.velocity == Vector3.zero)
            {
                Anim.SetBool("EstadoAtacar", true);
            }
            else
            {
                Anim.SetBool("EstadoAtacar", false);
            }
        }

       


    }
     public void RealizarAtaque()
    {
        ObjetoBrazo.GetComponent<Collider>().enabled = true;
    }

    public void RetirarAtaque()
    {
        ObjetoBrazo.GetComponent<Collider>().enabled = false;
    }
}
