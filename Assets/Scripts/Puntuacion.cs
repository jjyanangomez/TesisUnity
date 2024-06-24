using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntuacion : MonoBehaviour
{
    public int puntuacion = 0;
    public int numPreguntas = 0;
    public float Resultado = 0;
    public TextMeshProUGUI marcador;
    public TextMeshProUGUI preguntas;
    public TextMeshProUGUI ResultadosEva;
    public GameObject TotalPreguntas;

    // Start is called before the first frame update
    void Start()
    {
        ActualizarMarcador();
        TotalPreguntas = GameObject.Find("Funciones");
        ActualizarPreguntas();
        ActualizarResultados();
    }

    // Update is called once per frame
    void Update()
    {
        NotificationCenter.DefaultCenter().AddObserver(this, "IncrementarPuntos");
        NotificationCenter.DefaultCenter().AddObserver(this, "IncrementarPregunta");
        NotificationCenter.DefaultCenter().AddObserver(this, "IncrementarValorResultado");
    }

    void IncrementarPuntos(Notification notification)
    {
        int puntosIncrementar = (int)notification.data;
        puntuacion += puntosIncrementar;
        //Debug.Log("Incrementado" +  puntosIncrementar + "puntos. Total ganados:" + puntuacion);
        ActualizarMarcador();
    }
    void IncrementarPregunta(Notification notification)
    {
        int puntosIncrementar = (int)notification.data;
        numPreguntas += puntosIncrementar;
        ActualizarPreguntas();
    }

    void IncrementarValorResultado(Notification notification)
    {
        float puntosIncrementar = (float)notification.data;
        Resultado += puntosIncrementar;
        ActualizarResultados();
    }

    void ActualizarMarcador()
    {
        marcador.text = puntuacion.ToString();
    }

    void ActualizarPreguntas()
    {
        preguntas.text = numPreguntas + "/"+TotalPreguntas.GetComponent<Manejador>().NumPreCuestionario.ToString();
    }
    void ActualizarResultados()
    {
        ResultadosEva.text = Resultado.ToString("F2");
    }

}
