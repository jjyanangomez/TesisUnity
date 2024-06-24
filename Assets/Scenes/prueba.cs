using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class prueba : MonoBehaviour
{
    public GameObject panel;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cambiarColor()
    {
        Color colorP = new Color(255F, 238F, 0F);
        colorP.a = 0.8F;
        panel.GetComponent<Image>().color = colorP;
        Estudiante estudiante = new Estudiante();
        estudiante.Nombre = PlayerPrefs.GetString("NombreJugador");
        estudiante.Correo = PlayerPrefs.GetString("CorreoJugador");
        estudiante.CodeCuestionario = PlayerPrefs.GetString("CodigoPre");
        estudiante.Puntaje = 1850;
        estudiante.ResulEvaluacion = 10;
        estudiante.ListaPreTFCorrectas = "--";
        estudiante.ListaPreTFIncorrectas = "--";
        estudiante.ListaPreEmpaCorrectas = "10-";
        estudiante.ListaPreEmpaIncorrectas = "--";
        estudiante.ListaPreOpcionCorrectas = "14-";
        estudiante.ListaPreOpcionIncorrectas = "";
        estudiante.FechaInicio = PlayerPrefs.GetString("HoraInicio");
        estudiante.FechaFinal = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        estudiante.Juego = "El regreso del Didacta";
        var objeto = JsonConvert.SerializeObject(estudiante);
        //panel.GetComponent<Image>().enabled = false;
        Debug.Log(objeto);
        RestClient.Post("https://eva3.utpl.edu.ec/gamificev/src/views/Api/", objeto);
    }

}
