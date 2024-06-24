using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using TMPro;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using System.IO;


public class Manejador : MonoBehaviour
{
    public string URL = "";
    public static Informacion Cuesti;
    [Header("Preguntas de TF")]
    public GameObject PanelPreguntasTF;

    [Header("Preguntas de Opcion")]
    public GameObject PanelPreguntasOpcion;

    [Header("Preguntas de Emparejamiento")]
    public GameObject PanelPreguntasEmpa;
    [Header("Variables para resultados")]
    public int NumPreCuestionario = 0;

    public float ValorResulCuestionario = 0;

    public static List<PreguntasTF> listPreguntasTF = new List<PreguntasTF>();
    public static List<PreguntasOpcion> listaPreguntasOpcion = new List<PreguntasOpcion>();
    public static List<PreguntasEmparejamiento> listaPreguntasEmparejamiento = new List<PreguntasEmparejamiento>();

    public static PreguntasTF preTF;
    public static PreguntasOpcion preOpcion;
    public static PreguntasEmparejamiento preEmpareja;

    public static List<int> numPreguntas = new List<int>();
    public List<string> respuestasListaDrop = new List<string>() {"","",""};
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        GetRequest();
    }
    public string GetUrl()
    {
        //URL = "http://localhost/Tesis/UnificacionPlatform/src/views/Api/?key=" + PlayerPrefs.GetString("CodigoPre");
        URL = "https://eva3.utpl.edu.ec/gamificev/src/views/Api/?key=" + PlayerPrefs.GetString("CodigoPre");
        Debug.Log(URL);
        return URL;
    }
    public void GetRequest()
    {
        StartCoroutine(MakeWeatherRequest());
    }

    public IEnumerator MakeWeatherRequest()
    {
        UnityWebRequest request = UnityWebRequest.Get(GetUrl());
        Debug.Log(request);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);

        }
        else
        {
            var myclase = JsonConvert.DeserializeObject<Informacion>(request.downloadHandler.text);
            //Cuestionario myclase = JsonUtility.FromJson<Cuestionario>(request.downloadHandler.text);
            Debug.Log("Probando obtencion de datos: " + myclase.Cuestionario.NombreCuestionario);
            Cuesti = myclase;
            NumPreCuestionario = Cuesti.Cuestionario.NumPreguntas;
            //listPreguntasTF = myclase.Cuestionario.Banco.PreguntasTF;
            foreach (var item in myclase.Cuestionario.Banco.PreguntasTF)
            {
                listPreguntasTF.Add(item);
            }
            foreach (var item in myclase.Cuestionario.Banco.PreguntasEmparejamiento)
            {
                listaPreguntasEmparejamiento.Add(item);
            }
            foreach (var item in myclase.Cuestionario.Banco.PreguntasOpcion)
            {
                listaPreguntasOpcion.Add(item);
            }
            numPreguntas.Add(listPreguntasTF.Count);
            numPreguntas.Add(listaPreguntasEmparejamiento.Count);
            numPreguntas.Add(listaPreguntasOpcion.Count);

        }
    }
    /*
     1) Verdadero Falso
     2) Opcion
     3) Emparejamiento
     */
    public void ObtenerPreguntaRandom()
    {
        int sumaPre = listPreguntasTF.Count + listaPreguntasOpcion.Count + listaPreguntasEmparejamiento.Count;
        Debug.Log(sumaPre);
        int TypePre = Random.Range(1,4);
        if (sumaPre >= 1)
        {
            if (TypePre == 1)
            {
                if (listPreguntasTF.Count != 0)
                {
                    int valor = Random.Range(0, listPreguntasTF.Count);
                    preTF = listPreguntasTF[valor];
                    listPreguntasTF.RemoveAt(valor);
                    Debug.LogWarning("Pregunta de TF: " + preTF.Respuesta);
                    return;
                }
                else
                {
                    ObtenerPreguntaRandom();
                }
            }
            else if (TypePre == 2)
            {
                if (listaPreguntasOpcion.Count != 0)
                {
                    int valor = Random.Range(0, listaPreguntasOpcion.Count);
                    preOpcion = listaPreguntasOpcion[valor];
                    listaPreguntasOpcion.RemoveAt(valor);
                    Debug.LogWarning("Pregunta de opción: "+preOpcion.OpValida1);
                    return;
                }
                else
                {
                    ObtenerPreguntaRandom();
                }
            }
            else if (TypePre == 3)
            {
                if (listaPreguntasEmparejamiento.Count != 0)
                {
                    int valor = Random.Range(0, listaPreguntasEmparejamiento.Count);
                    preEmpareja = listaPreguntasEmparejamiento[valor];
                    listaPreguntasEmparejamiento.RemoveAt(valor);
                    Debug.LogWarning("Pregunta de empare " + preEmpareja.Enunciado1);
                    return;
                }
                else
                {
                    ObtenerPreguntaRandom();
                }
            }
        }
        else
        {
            //return;
            Debug.Log("Ya no existen preguntas");
        }
        
    }

    public void limpiar(int valor)
    {
        
        
        
        if (valor == 1)
        {
            preTF = null;
        }
        else if (valor == 2)
        {
            preOpcion = null;
        }
        else if (valor == 3)
        {
            preEmpareja = null;
        }
    }
    

    public void CargarPantalla()
    {
        ObtenerPreguntaRandom();
        if (preTF != null)
        {
            PanelPreguntasTF.SetActive(true);
            PanelPreguntasTF.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = preTF.Pregunta;
            //Debug.LogWarning("Existe valor 1"+ PanelPreguntasTF.transform.GetChild(0).gameObject.name);
        }
        else if (preOpcion != null)
        {
            PanelPreguntasOpcion.SetActive(true);
            //Debug.Log(preOpcion.ToString());
            PanelPreguntasOpcion.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = preOpcion.Pregunta;
            PanelPreguntasOpcion.transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = preOpcion.Respuesta1;
            PanelPreguntasOpcion.transform.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().text = preOpcion.Respuesta2;
            PanelPreguntasOpcion.transform.GetChild(6).gameObject.GetComponent<TextMeshProUGUI>().text = preOpcion.Respuesta3;
            PanelPreguntasOpcion.transform.GetChild(7).gameObject.GetComponent<TextMeshProUGUI>().text = preOpcion.Respuesta4;
        }
        else if (preEmpareja != null)
        {
            PanelPreguntasEmpa.SetActive(true);
            PanelPreguntasEmpa.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = preEmpareja.Pregunta;
            PanelPreguntasEmpa.transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = preEmpareja.ResPrimerEnunciado;
            PanelPreguntasEmpa.transform.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().text = preEmpareja.ResSegundoEnunciado;
            PanelPreguntasEmpa.transform.GetChild(6).gameObject.GetComponent<TextMeshProUGUI>().text = preEmpareja.ResTercerEnunciado;
            List<string> aux = new List<string>() { preEmpareja.Enunciado1, preEmpareja.Enunciado2, preEmpareja.Enunciado3 };
            Randomico(aux);
            string valorNulo = "---";
            aux.Insert(0, valorNulo);
            PanelPreguntasEmpa.transform.GetChild(7).gameObject.GetComponent<Dropdown>().AddOptions(aux);
            PanelPreguntasEmpa.transform.GetChild(8).gameObject.GetComponent<Dropdown>().AddOptions(aux);
            PanelPreguntasEmpa.transform.GetChild(9).gameObject.GetComponent<Dropdown>().AddOptions(aux);
        }
    }
    //Metodo para randomizar
    public void Randomico<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
        
    }
    public void Validar(int valor)
    {

        if (valor == 1)
        {
            bool respuesta = false;
            if (preTF.Respuesta == "Verdadero")
            {
                respuesta = true;
            }
            if (PanelPreguntasTF.transform.GetChild(6).gameObject.GetComponent<Toggle>().isOn == true)
            {
                if (respuesta == true)
                {
                    PanelPreguntasTF.transform.GetChild(9).gameObject.GetComponent<TextMeshProUGUI>().text = "Correcto!";
                    PanelPreguntasTF.transform.GetChild(10).gameObject.GetComponent<TextMeshProUGUI>().text = "Calificación = " + Cuesti.Cuestionario.ValorPregunta.ToString("F2");
                    PanelPreguntasTF.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Retroalimentación: " + preTF.RetroAlimentacion;
                    Color colorP = new Color();
                    colorP = Color.green;
                    colorP.a = 0.8F;
                    PanelPreguntasTF.transform.GetChild(1).gameObject.GetComponent<Image>().color = colorP;
                    PanelPreguntasTF.transform.GetChild(1).gameObject.GetComponent<Image>().enabled = true;
                    PanelPreguntasTF.transform.GetChild(3).gameObject.SetActive(true);
                    PanelPreguntasTF.transform.GetChild(2).gameObject.SetActive(false);
                    NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntos", 600);
                    NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPregunta", 1);
                    //preTFCorrectas++;
                    NotificationCenter.DefaultCenter().PostNotification(this, "ConcatenarListpreTFCorrectas", preTF.IdBancoTrueFalse.ToString());
                    ValorResulCuestionario = ValorResulCuestionario + (float)Cuesti.Cuestionario.ValorPregunta;
                    NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarValorResultado", (float)Cuesti.Cuestionario.ValorPregunta);
                }
                else
                {
                    PanelPreguntasTF.transform.GetChild(9).gameObject.GetComponent<TextMeshProUGUI>().text = "Incorrecto! ";
                    PanelPreguntasTF.transform.GetChild(10).gameObject.GetComponent<TextMeshProUGUI>().text = "Calificación = 0";
                    PanelPreguntasTF.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Retroalimentación: " + preTF.RetroAlimentacion;
                    Color colorP = new Color();
                    colorP = Color.red;
                    colorP.a = 0.8F;
                    PanelPreguntasTF.transform.GetChild(1).gameObject.GetComponent<Image>().color = colorP;
                    PanelPreguntasTF.transform.GetChild(1).gameObject.GetComponent<Image>().enabled = true;
                    PanelPreguntasTF.transform.GetChild(3).gameObject.SetActive(true);
                    PanelPreguntasTF.transform.GetChild(2).gameObject.SetActive(false);
                    NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPregunta", 1);
                    NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntos", 100);
                    //preTFInCorrectas++;
                    NotificationCenter.DefaultCenter().PostNotification(this, "ConcatenarListpreTFInCorrectas", preTF.IdBancoTrueFalse.ToString());
                    ValorResulCuestionario = ValorResulCuestionario + 0;
                    NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarValorResultado",(float)0);
                }
            }
            else if (PanelPreguntasTF.transform.GetChild(7).gameObject.GetComponent<Toggle>().isOn == true)
            {
                if (respuesta == false)
                {
                    PanelPreguntasTF.transform.GetChild(9).gameObject.GetComponent<TextMeshProUGUI>().text = "Correcto!";
                    PanelPreguntasTF.transform.GetChild(10).gameObject.GetComponent<TextMeshProUGUI>().text = "Calificación = " + Cuesti.Cuestionario.ValorPregunta.ToString("F2");
                    PanelPreguntasTF.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Retroalimentación: " + preTF.RetroAlimentacion;
                    Color colorP = new Color();
                    colorP = Color.green;
                    colorP.a = 0.8F;
                    PanelPreguntasTF.transform.GetChild(1).gameObject.GetComponent<Image>().color = colorP;
                    PanelPreguntasTF.transform.GetChild(1).gameObject.GetComponent<Image>().enabled = true;
                    PanelPreguntasTF.transform.GetChild(3).gameObject.SetActive(true);
                    PanelPreguntasTF.transform.GetChild(2).gameObject.SetActive(false);
                    NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntos", 600);
                    NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPregunta", 1);
                    //preTFCorrectas++;
                    NotificationCenter.DefaultCenter().PostNotification(this, "ConcatenarListpreTFCorrectas", preTF.IdBancoTrueFalse.ToString());
                    ValorResulCuestionario = ValorResulCuestionario + (float)Cuesti.Cuestionario.ValorPregunta;
                    NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarValorResultado", (float)Cuesti.Cuestionario.ValorPregunta);
                }
                else
                {
                    PanelPreguntasTF.transform.GetChild(9).gameObject.GetComponent<TextMeshProUGUI>().text = "Incorrecto! ";
                    PanelPreguntasTF.transform.GetChild(10).gameObject.GetComponent<TextMeshProUGUI>().text = "Calificación = 0";
                    PanelPreguntasTF.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Retroalimentación: " + preTF.RetroAlimentacion;
                    Color colorP = new Color();
                    colorP = Color.red;
                    colorP.a = 0.8F;
                    PanelPreguntasTF.transform.GetChild(1).gameObject.GetComponent<Image>().color = colorP;
                    PanelPreguntasTF.transform.GetChild(1).gameObject.GetComponent<Image>().enabled = true;
                    PanelPreguntasTF.transform.GetChild(3).gameObject.SetActive(true);
                    PanelPreguntasTF.transform.GetChild(2).gameObject.SetActive(false);
                    NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPregunta", 1);
                    NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntos", 100);
                    //preTFInCorrectas++;
                    NotificationCenter.DefaultCenter().PostNotification(this, "ConcatenarListpreTFInCorrectas", preTF.IdBancoTrueFalse.ToString());
                    NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntos", 100);
                    ValorResulCuestionario = ValorResulCuestionario + 0;
                    NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarValorResultado", (float)0);
                }
            }
        }
        else if (valor == 2)
        {
            int aciertos = 0;
            int contador = 0;
            bool respuesta1 = false;
            bool respuesta2 = false;
            bool respuesta3 = false;
            bool respuesta4 = false;
            if (preOpcion.OpValida1 == "Correcto")
            {
                respuesta1 = true;
                contador++;
            }
            if (preOpcion.OpValida2 == "Correcto")
            {
                respuesta2 = true;
                contador++;
            }
            if (preOpcion.OpValida3 == "Correcto")
            {
                respuesta3 = true;
                contador++;
            }
            if (preOpcion.OpValida4 == "Correcto")
            {
                respuesta4 = true;
                contador++;
            }
            float valorRespuesta = (float)Cuesti.Cuestionario.ValorPregunta / contador;
            float RespuestaCompleta = 0;
            if (PanelPreguntasOpcion.transform.GetChild(8).gameObject.GetComponent<Toggle>().isOn == true)
            {
                if (respuesta1 == true)
                {
                    RespuestaCompleta = RespuestaCompleta + valorRespuesta;
                    aciertos++;
                }
                else
                {
                    RespuestaCompleta = RespuestaCompleta - valorRespuesta;
                }
            }
            if (PanelPreguntasOpcion.transform.GetChild(9).gameObject.GetComponent<Toggle>().isOn == true)
            {
                if (respuesta2 == true)
                {
                    RespuestaCompleta = RespuestaCompleta + valorRespuesta;
                    aciertos++;
                }
                else
                {
                    RespuestaCompleta = RespuestaCompleta - valorRespuesta;

                }
            }
            if (PanelPreguntasOpcion.transform.GetChild(10).gameObject.GetComponent<Toggle>().isOn == true)
            {
                if (respuesta3 == true)
                {
                    RespuestaCompleta = RespuestaCompleta + valorRespuesta;
                    aciertos++;
                }
                else
                {
                    RespuestaCompleta = RespuestaCompleta - valorRespuesta;
                }
            }
            if (PanelPreguntasOpcion.transform.GetChild(11).gameObject.GetComponent<Toggle>().isOn == true)
            {
                if (respuesta4 == true)
                {
                    RespuestaCompleta = RespuestaCompleta + valorRespuesta;
                    aciertos++;
                }
                else
                {
                    RespuestaCompleta = RespuestaCompleta - valorRespuesta;
                }
            }
            Color colorP = new Color();
            if (RespuestaCompleta < 0)
            {
                RespuestaCompleta = 0;
                NotificationCenter.DefaultCenter().PostNotification(this, "ConcatenarListpreOpcionInCorrectas", preOpcion.IdBancoOpcion.ToString());
                ValorResulCuestionario = ValorResulCuestionario + (float)RespuestaCompleta;
                NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarValorResultado", (float)RespuestaCompleta);

                PanelPreguntasOpcion.transform.GetChild(12).gameObject.GetComponent<TextMeshProUGUI>().text = "Incorrecto!";
                colorP = Color.red;

            }
            else
            {
                if (RespuestaCompleta.ToString("F2") == Cuesti.Cuestionario.ValorPregunta.ToString("F2"))
                {
                    PanelPreguntasOpcion.transform.GetChild(12).gameObject.GetComponent<TextMeshProUGUI>().text = "Correcto!";
                    colorP = Color.green;
                }
                else
                {
                    PanelPreguntasOpcion.transform.GetChild(12).gameObject.GetComponent<TextMeshProUGUI>().text = "Parcialmente Correcto!";
                    colorP = Color.yellow;
                }
                NotificationCenter.DefaultCenter().PostNotification(this, "ConcatenarListpreOpcionCorrectas", preOpcion.IdBancoOpcion.ToString());
                ValorResulCuestionario = ValorResulCuestionario + (float)RespuestaCompleta;
                NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarValorResultado", (float)RespuestaCompleta);
            }
            PanelPreguntasOpcion.transform.GetChild(13).gameObject.GetComponent<TextMeshProUGUI>().text = "Calificación = " + RespuestaCompleta.ToString("F2");
            PanelPreguntasOpcion.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Retroalimentación: "+preOpcion.RetroAlimentacion;
            
            
            colorP.a = 0.8F;
            PanelPreguntasOpcion.transform.GetChild(1).gameObject.GetComponent<Image>().color = colorP;
            PanelPreguntasOpcion.transform.GetChild(1).gameObject.GetComponent<Image>().enabled = true;
            PanelPreguntasOpcion.transform.GetChild(3).gameObject.SetActive(true);
            PanelPreguntasOpcion.transform.GetChild(2).gameObject.SetActive(false);
            CalcularPuntaje(contador,aciertos);
        }
        else if (valor == 3)
        {
            int aciertos = 0;
            float valorRespuesta = (float)Cuesti.Cuestionario.ValorPregunta / 3;
            float RespuestaCompleta = 0;
            if (respuestasListaDrop[0] == preEmpareja.Enunciado1)
            {
                RespuestaCompleta = RespuestaCompleta + valorRespuesta;
                aciertos++;
            }
            else
            {
                RespuestaCompleta = RespuestaCompleta - valorRespuesta;
            } 
            if (respuestasListaDrop[1] == preEmpareja.Enunciado2)
            {
                RespuestaCompleta = RespuestaCompleta + valorRespuesta;
                aciertos++;
            }
            else
            {
                RespuestaCompleta = RespuestaCompleta - valorRespuesta;
            }
            if (respuestasListaDrop[2] == preEmpareja.Enunciado3)
            {
                RespuestaCompleta = RespuestaCompleta + valorRespuesta;
                aciertos++;
            }
            else
            {
                RespuestaCompleta = RespuestaCompleta - valorRespuesta;
            }
            Color colorP = new Color();
            if (RespuestaCompleta < 0)
            {
                RespuestaCompleta = 0;
                NotificationCenter.DefaultCenter().PostNotification(this, "ConcatenarListpreEmparInCorrectas", preEmpareja.IdBancoEmpar.ToString());
                ValorResulCuestionario = ValorResulCuestionario + (float)RespuestaCompleta;
                NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarValorResultado", (float)RespuestaCompleta);
                PanelPreguntasEmpa.transform.GetChild(10).gameObject.GetComponent<TextMeshProUGUI>().text = "Incorrecto!";
                colorP = Color.red;
            }
            else
            {
                if (RespuestaCompleta.ToString("F2") == Cuesti.Cuestionario.ValorPregunta.ToString("F2"))
                {
                    PanelPreguntasEmpa.transform.GetChild(10).gameObject.GetComponent<TextMeshProUGUI>().text = "Correcto!";
                    colorP = Color.green;
                }
                else
                {
                    PanelPreguntasEmpa.transform.GetChild(10).gameObject.GetComponent<TextMeshProUGUI>().text = "Parcialmente Correcto";
                    colorP = Color.yellow;
                }
                NotificationCenter.DefaultCenter().PostNotification(this, "ConcatenarListpreEmparCorrectas", preEmpareja.IdBancoEmpar.ToString());
                ValorResulCuestionario = ValorResulCuestionario + (float)RespuestaCompleta;
                NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarValorResultado", (float)RespuestaCompleta);
            }
            PanelPreguntasEmpa.transform.GetChild(11).gameObject.GetComponent<TextMeshProUGUI>().text = "Calificación ="+RespuestaCompleta.ToString("F2");
            PanelPreguntasEmpa.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Retroalimentación: "+preEmpareja.RetroAlimentacion;
            
            colorP.a = 0.8F;
            PanelPreguntasEmpa.transform.GetChild(1).gameObject.GetComponent<Image>().color = colorP;
            PanelPreguntasEmpa.transform.GetChild(1).gameObject.GetComponent<Image>().enabled = true;
            PanelPreguntasEmpa.transform.GetChild(3).gameObject.SetActive(true);
            PanelPreguntasEmpa.transform.GetChild(2).gameObject.SetActive(false);
            CalcularPuntaje(3, aciertos);
            
        }

    }
    /********Estos metodos permite obtener el resultado del combo box***********/
    public void SeleccionarDropDown_1(int valor)
    {
        respuestasListaDrop[0] = PanelPreguntasEmpa.transform.GetChild(7).gameObject.GetComponent<Dropdown>().options[valor].text;
        //Debug.Log(PanelPreguntasEmpa.transform.GetChild(7).gameObject.GetComponent<Dropdown>().options[valor].text);
    }
    public void SeleccionarDropDown_2(int valor)
    {
        respuestasListaDrop[1] = PanelPreguntasEmpa.transform.GetChild(8).gameObject.GetComponent<Dropdown>().options[valor].text;
        //Debug.Log(PanelPreguntasEmpa.transform.GetChild(8).gameObject.GetComponent<Dropdown>().options[valor].text);
    }
    public void SeleccionarDropDown_3(int valor)
    {
        respuestasListaDrop[2] = PanelPreguntasEmpa.transform.GetChild(9).gameObject.GetComponent<Dropdown>().options[valor].text;
        //Debug.Log(PanelPreguntasEmpa.transform.GetChild(9).gameObject.GetComponent<Dropdown>().options[valor].text);
    }
    /******************* Restablece las pantallas de las preguntas para evitar problemas a futuro***************/
    public void Restablecer(int valor)
    {
        if (valor == 1)
        {
            PanelPreguntasTF.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "";
            PanelPreguntasTF.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "";
            PanelPreguntasTF.transform.GetChild(2).gameObject.SetActive(true);
            PanelPreguntasTF.transform.GetChild(3).gameObject.SetActive(false);
            PanelPreguntasTF.transform.GetChild(6).gameObject.GetComponent<Toggle>().isOn = false;
            PanelPreguntasTF.transform.GetChild(7).gameObject.GetComponent<Toggle>().isOn = false;
            PanelPreguntasTF.transform.GetChild(9).gameObject.GetComponent<TextMeshProUGUI>().text = "";
            PanelPreguntasTF.transform.GetChild(1).gameObject.GetComponent<Image>().enabled = false;
            Time.timeScale = 1;
        }
        else if (valor == 2)
        {
            PanelPreguntasOpcion.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "";
            PanelPreguntasOpcion.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "";
            PanelPreguntasOpcion.transform.GetChild(2).gameObject.SetActive(true);
            PanelPreguntasOpcion.transform.GetChild(3).gameObject.SetActive(false);
            PanelPreguntasOpcion.transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = "";
            PanelPreguntasOpcion.transform.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().text = "";
            PanelPreguntasOpcion.transform.GetChild(6).gameObject.GetComponent<TextMeshProUGUI>().text = "";
            PanelPreguntasOpcion.transform.GetChild(7).gameObject.GetComponent<TextMeshProUGUI>().text = "";
            PanelPreguntasOpcion.transform.GetChild(8).gameObject.GetComponent<Toggle>().isOn = false;
            PanelPreguntasOpcion.transform.GetChild(9).gameObject.GetComponent<Toggle>().isOn = false;
            PanelPreguntasOpcion.transform.GetChild(10).gameObject.GetComponent<Toggle>().isOn = false;
            PanelPreguntasOpcion.transform.GetChild(11).gameObject.GetComponent<Toggle>().isOn = false;
            PanelPreguntasOpcion.transform.GetChild(12).gameObject.GetComponent<TextMeshProUGUI>().text = "";
            PanelPreguntasOpcion.transform.GetChild(1).gameObject.GetComponent<Image>().enabled = false;
            Time.timeScale = 1;
        }
        else if (valor == 3)
        {
            PanelPreguntasEmpa.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "";
            PanelPreguntasEmpa.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "";
            PanelPreguntasEmpa.transform.GetChild(2).gameObject.SetActive(true);
            PanelPreguntasEmpa.transform.GetChild(3).gameObject.SetActive(false);
            PanelPreguntasEmpa.transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = "";
            PanelPreguntasEmpa.transform.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().text = "";
            PanelPreguntasEmpa.transform.GetChild(6).gameObject.GetComponent<TextMeshProUGUI>().text = "";
            PanelPreguntasEmpa.transform.GetChild(10).gameObject.GetComponent<TextMeshProUGUI>().text = "";
            //PanelPreguntasEmpa.transform.GetChild(7).gameObject.GetComponent<Dropdown>().options.Clear();
            PanelPreguntasEmpa.transform.GetChild(7).gameObject.GetComponent<Dropdown>().ClearOptions();
            PanelPreguntasEmpa.transform.GetChild(8).gameObject.GetComponent<Dropdown>().ClearOptions();
            PanelPreguntasEmpa.transform.GetChild(9).gameObject.GetComponent<Dropdown>().ClearOptions();
            PanelPreguntasEmpa.transform.GetChild(1).gameObject.GetComponent<Image>().enabled = false;
            Time.timeScale = 1;
        }
    }

    public void CalcularPuntaje(int contador, int aciertos)
    {
        int total = 0;
        if (aciertos != 0)
        {
            total = (600 / contador) * aciertos;
        }
        NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntos", total);
        NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPregunta", 1);
    }
}

