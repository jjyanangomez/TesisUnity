using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ValidarMision : MonoBehaviour
{
    public BaseMisiones BDMisiones;
    public TextMeshProUGUI MensajeEstado;
    public PresentarMisiones1 cambiarMision;

    public Manejador Preguntas;

    public List<GameObject> listaMisiones = new List<GameObject>();
    public List<GameObject> listaMisionesActivas = new List<GameObject>();
    public List<GameObject> listaMisionesTerminadas = new List<GameObject>();

    public int idMision;

    [Header("Objetos de referencia")]
    public GameObject ubicacionConstructor;

    [Header("Objetos que se generan")]
    public GameObject objeto_generar_Constructor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Completar(int id)
    {
        if (listaMisionesActivas[0].GetComponent<MisionSuelo>().MisionCompletada == true)
        {
            int sumar = 600;
            NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntos",sumar);
            listaMisionesTerminadas.Add(listaMisionesActivas[0].GetComponent<GameObject>());
            actualizarEstado("Completaste la Misión "+/*listaMisionesActivas[0].GetComponent<MisionSuelo>().IdMision.ToString()*/"... Habla con la Bibliotecaria");
            listaMisionesActivas.RemoveAt(0);
            
            cambiarMision.Activar_Mision(id);
        }
    }

    public void CrearConstructor()
    {
        GameObject objeto = Instantiate(objeto_generar_Constructor, ubicacionConstructor.transform.position, Quaternion.identity);
        objeto.transform.parent = ubicacionConstructor.transform;
    }

    public void actualizarEstado(string info)
    {
        MensajeEstado.text = info;
    }

}
