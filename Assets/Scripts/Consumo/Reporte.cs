using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using Newtonsoft.Json;
using System;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Reporte : MonoBehaviour
{
    public GameObject Objetomanejador;

    public string ListpreTFCorrectas = "";
    public string ListpreTFInCorrectas = "";
    public string ListpreEmparCorrectas = "";
    public string ListpreEmparInCorrectas = "";
    public string ListpreOpcionCorrectas = "";
    public string ListpreOpcionInCorrectas = "";

    public string NombreEstudiante;
    public string CorreoEstudiante;
    public string CodigoCuestionario;
    public int Puntaje;
    public float resultadoEvaluacion;
    // Start is called before the first frame update
    void Start()
    {
        Objetomanejador = GameObject.Find("Funciones");
    }

    // Update is called once per frame
    void Update()
    {
        NotificationCenter.DefaultCenter().AddObserver(this, "ConcatenarListpreTFCorrectas");
        NotificationCenter.DefaultCenter().AddObserver(this, "ConcatenarListpreTFInCorrectas");
        NotificationCenter.DefaultCenter().AddObserver(this, "ConcatenarListpreEmparCorrectas");
        NotificationCenter.DefaultCenter().AddObserver(this, "ConcatenarListpreEmparInCorrectas");
        NotificationCenter.DefaultCenter().AddObserver(this, "ConcatenarListpreOpcionCorrectas");
        NotificationCenter.DefaultCenter().AddObserver(this, "ConcatenarListpreOpcionInCorrectas");
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaCulminado");
    }

    void ConcatenarListpreTFCorrectas(Notification notification)
    {
        string Id = (string)notification.data;
        ListpreTFCorrectas += (Id + "-");
    }

    void ConcatenarListpreTFInCorrectas(Notification notification)
    {
        string Id = (string)notification.data;
        ListpreTFInCorrectas += (Id + "-");
    }

    void ConcatenarListpreEmparCorrectas(Notification notification)
    {
        string Id = (string)notification.data;
        ListpreEmparCorrectas += (Id + "-");
    }

    void ConcatenarListpreEmparInCorrectas(Notification notification)
    {
        string Id = (string)notification.data;
        ListpreEmparInCorrectas += (Id + "-");
    }

    void ConcatenarListpreOpcionCorrectas(Notification notification)
    {
        string Id = (string)notification.data;
        ListpreOpcionCorrectas += (Id + "-");
    }

    void ConcatenarListpreOpcionInCorrectas(Notification notification)
    {
        string Id = (string)notification.data;
        ListpreOpcionInCorrectas += (Id + "-");
    }
    //Metodo para EnviarPost
    void PersonajeHaCulminado(Notification notification)
    {

        StartCoroutine(enviarPost());
        if (GetComponent<Puntuacion>().Resultado <= 0)
        {
            SceneManager.LoadScene("Longbow_CinematicaFinal2GameOver");
        }
        else
        {
            SceneManager.LoadScene("Longbow_CinematicaFinal");
        }
        
    }

    IEnumerator enviarPost()
    {        
        Estudiante estudiante = new Estudiante();
        estudiante.Nombre = PlayerPrefs.GetString("NombreJugador");
        estudiante.Correo = PlayerPrefs.GetString("CorreoJugador");
        estudiante.CodeCuestionario = PlayerPrefs.GetString("CodigoPre");
        estudiante.Puntaje = Objetomanejador.GetComponent<Puntuacion>().puntuacion;
        estudiante.ResulEvaluacion = Objetomanejador.GetComponent<Puntuacion>().Resultado;
        estudiante.ListaPreTFCorrectas = ListpreTFCorrectas;
        estudiante.ListaPreTFIncorrectas = ListpreTFInCorrectas;
        estudiante.ListaPreEmpaCorrectas = ListpreEmparCorrectas;
        estudiante.ListaPreEmpaIncorrectas = ListpreEmparInCorrectas;
        estudiante.ListaPreOpcionCorrectas = ListpreOpcionCorrectas;
        estudiante.ListaPreOpcionIncorrectas = ListpreOpcionInCorrectas;
        estudiante.FechaInicio = PlayerPrefs.GetString("HoraInicio");
        estudiante.FechaFinal = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        estudiante.Juego = "El regreso del Didacta";
        var objeto = JsonConvert.SerializeObject(estudiante);
        Debug.Log(objeto);
        //UnityWebRequest request = new UnityWebRequest("http://localhost/Tesis/UnificacionPlatform/src/views/Api/EnvioPOST.php", "POST");
        UnityWebRequest request = new UnityWebRequest("https://eva3.utpl.edu.ec/gamificev/src/views/Api/EnvioPOST.php", "POST");
        byte[] jsonBytes = new System.Text.UTF8Encoding().GetBytes(objeto.ToString());
        request.uploadHandler = new UploadHandlerRaw(jsonBytes);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Access-Control-Allow-Origin", "*");
        request.SetRequestHeader("Access-Control-Allow-Methods", "POST, HEAD");
        yield return request.SendWebRequest();

        // Verificar si ocurrió algún error en la respuesta
        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Solicitud POST exitosa");
            Debug.Log("Respuesta: " + request.downloadHandler.text);
        }
        else
        {
            Debug.Log("Error en la solicitud POST: " + request.error);
        }
    }
}
