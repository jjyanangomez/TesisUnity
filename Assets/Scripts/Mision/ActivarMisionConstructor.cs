using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActivarMisionConstructor : MonoBehaviour
{
    [Header("Objetos de referencia")]
    public List<GameObject> Ubicacion1 = new List<GameObject>();
    public List<GameObject> Ubicacion2 = new List<GameObject>();

    [Header("Objetos que se generan")]
    public GameObject objeto_generar;

    public Manejador manejador;
    public GameObject jugador;
    public int pistacho;

    public GameObject Mensaje;
    private bool Entraste = true;
    void Start()
    {
        if (pistacho == 1)
        {
            float spacing = 0.1f;
            gameObject.GetComponent<MisionSuelo>().cantidadItems = Manejador.numPreguntas[0];
            jugador.GetComponent<ControlJugador>().valMision.listaMisionesActivas.Add(gameObject);
            for (int i = 0; i < Manejador.numPreguntas[0]; i++)
            {
                
                int opcionGenerar = Random.Range(1, 3);
                //Debug.Log(opcionGenerar);
                if (opcionGenerar == 1)
                {
                    float valorZ = Random.Range(Ubicacion1[1].transform.position.z, Ubicacion1[3].transform.position.z);
                    float valorX = Random.Range(Ubicacion1[0].transform.position.x, Ubicacion1[1].transform.position.x);
                    Vector3 v3 = new Vector3(valorX, Ubicacion1[1].transform.position.y, valorZ);
                    GameObject objeto =  Instantiate(objeto_generar, v3, Quaternion.identity);
                    /*********/
                    Vector3 newPosition = objeto.transform.position;
                    newPosition.x += Random.Range(-spacing, spacing);
                    objeto.transform.position = newPosition;
                    objeto.transform.parent = Ubicacion1[0].transform;
                }
                else
                {
                    float valorZ = Random.Range(Ubicacion2[1].transform.position.z, Ubicacion2[3].transform.position.z);
                    float valorX = Random.Range(Ubicacion2[0].transform.position.x, Ubicacion2[1].transform.position.x);
                    //Debug.Log("estoy generando");
                    Vector3 v3 = new Vector3(valorX, Ubicacion2[1].transform.position.y, valorZ);
                    GameObject objeto = Instantiate(objeto_generar, v3, Quaternion.identity);
                    /*****************/
                    Vector3 newPosition = objeto.transform.position;
                    newPosition.x += Random.Range(-spacing, spacing);
                    objeto.transform.position = newPosition;
                    objeto.transform.parent = Ubicacion2[0].transform;
                }
            }
        }
        else if (pistacho == 2)
        {
            float spacing = 0.1f;
            gameObject.GetComponent<MisionSuelo>().cantidadItems = Manejador.numPreguntas[1];
            jugador.GetComponent<ControlJugador>().valMision.listaMisionesActivas.Add(gameObject);
            for (int i = 0; i < Manejador.numPreguntas[1]; i++)
            {
                int opcionGenerar = Random.Range(1, 3);
                //Debug.Log(opcionGenerar);
                if (opcionGenerar == 1)
                {
                    float valorZ = Random.Range(Ubicacion1[1].transform.position.z, Ubicacion1[3].transform.position.z);
                    float valorX = Random.Range(Ubicacion1[0].transform.position.x, Ubicacion1[1].transform.position.x);
                    Vector3 v3 = new Vector3(valorX, Ubicacion1[1].transform.position.y, valorZ);
                    GameObject objeto = Instantiate(objeto_generar, v3, Quaternion.identity);
                    /*****************/
                    Vector3 newPosition = objeto.transform.position;
                    newPosition.x += Random.Range(-spacing, spacing);
                    objeto.transform.position = newPosition;
                    objeto.transform.parent = Ubicacion1[0].transform;
                }
                else
                {
                    float valorZ = Random.Range(Ubicacion2[1].transform.position.z, Ubicacion2[3].transform.position.z);
                    float valorX = Random.Range(Ubicacion2[0].transform.position.x, Ubicacion2[1].transform.position.x);
                    //Debug.Log("estoy generando");
                    Vector3 v3 = new Vector3(valorX, Ubicacion2[1].transform.position.y, valorZ);
                    GameObject objeto = Instantiate(objeto_generar, v3, Quaternion.identity);
                    /*****************/
                    Vector3 newPosition = objeto.transform.position;
                    newPosition.x += Random.Range(-spacing, spacing);
                    objeto.transform.position = newPosition;
                    objeto.transform.parent = Ubicacion2[0].transform;

                }
            }
        }
        else if (pistacho == 3)
        {
            float spacing = 0.1f;
            gameObject.GetComponent<MisionSuelo>().cantidadItems = Manejador.numPreguntas[2];
            jugador.GetComponent<ControlJugador>().valMision.listaMisionesActivas.Add(gameObject);
            for (int i = 0; i < Manejador.numPreguntas[2]; i++)
            {
                int opcionGenerar = Random.Range(1,3);
                //Debug.Log(opcionGenerar);
                if (opcionGenerar == 1)
                {
                    float valorZ = Random.Range(Ubicacion1[0].transform.position.z, Ubicacion1[1].transform.position.z);
                    float valorX = Random.Range(Ubicacion1[1].transform.position.x, Ubicacion1[3].transform.position.x);
                    Vector3 v3 = new Vector3(valorX, Ubicacion1[1].transform.position.y, valorZ);
                    GameObject objeto = Instantiate(objeto_generar, v3, Quaternion.identity);
                    /*****************/
                    Vector3 newPosition = objeto.transform.position;
                    newPosition.x += Random.Range(-spacing, spacing);
                    objeto.transform.position = newPosition;
                    objeto.transform.parent = Ubicacion1[0].transform;
                }
                else
                {
                    float valorZ = Random.Range(Ubicacion2[1].transform.position.z, Ubicacion2[3].transform.position.z);
                    float valorX = Random.Range(Ubicacion2[0].transform.position.x, Ubicacion2[1].transform.position.x);
                    //Debug.Log("estoy generando");
                    Vector3 v3 = new Vector3(valorX, 238.9f, valorZ);
                    GameObject objeto = Instantiate(objeto_generar, v3, Quaternion.identity);
                    /*****************/
                    Vector3 newPosition = objeto.transform.position;
                    newPosition.x += Random.Range(-spacing, spacing);
                    objeto.transform.position = newPosition;
                    objeto.transform.parent = Ubicacion2[0].transform;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (Entraste)
        {
            if (other.CompareTag("Player"))
            {
                jugador = other.gameObject;
                Entraste = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
}
