using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using TMPro;
using System;

public class Validacion : MonoBehaviour
{
    public string URL = "";
    DateTime tiempo;
    public string codigoScena = "";
    public string nombreJugador = "";
    public string CorreoJugador = "";
    private seguridad Resultado;
    public TMP_InputField Codigo;
    public TMP_InputField Nombre;
    public TMP_InputField Correo;
    public GameObject Error;
    // Start is called before the first frame update

    public static Validacion codigoPregunta;

    private void Awake()
    {
        if (codigoPregunta == null)
        {
            codigoPregunta = this;
            DontDestroyOnLoad(gameObject);

        }
        else if (codigoPregunta != this)
        {
            Destroy(gameObject);

        }
        
        

    }
    public string GetUrl()
    {
    
        //URL = "http://localhost/Tesis/UnificacionPlatform/src/views/Api/CuestionariosExi.php?key=" + Codigo.text;
        URL = "https://eva3.utpl.edu.ec/gamificev/src/views/Api/CuestionariosExi.php?key=" + Codigo.text;
        Debug.Log(URL+"/mira");
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
            var myclase = JsonConvert.DeserializeObject<seguridad>(request.downloadHandler.text);
            Resultado = myclase;
            //Cuestionario myclase = JsonUtility.FromJson<Cuestionario>(request.downloadHandler.text);
            Debug.Log("Probando obtencion de datos: " + myclase.status);
            if (Resultado.status == true)
            {
                if ((Codigo.text != "") && (Nombre.text != "") && email_bien_escrito(Correo.text))
                {
                    Debug.Log("" + email_bien_escrito(Correo.text));
                    ObtenerCodigo();
                }
                else
                {
                    Error.SetActive(true);
                    Error.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text="Correo Incorrecto";
                }
            }
            else
            {
                Error.SetActive(true);
                Error.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "El código de la Evaluación es Incorrecto o no está habilitado";
            }
        }
    }

    public void validar()
    {
        GetRequest();
    }

    private void ObtenerCodigo()
    {
        codigoScena = Codigo.text;
        nombreJugador = Nombre.text;
        CorreoJugador = Correo.text;
        PlayerPrefs.SetString("CodigoPre", Codigo.text);
        PlayerPrefs.SetString("NombreJugador", Nombre.text);
        PlayerPrefs.SetString("CorreoJugador", Correo.text);
        PlayerPrefs.SetString("HoraInicio",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        Debug.Log(PlayerPrefs.GetString("HoraInicio"));
        SceneManager.LoadScene("Longbow");

    }
    private bool email_bien_escrito(string email)
    {
        string expresion;
        string expresion2;
        bool estado1;
        bool estado2;
        expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
        expresion2 = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
        if (Regex.IsMatch(email, expresion))
        {
            if (Regex.Replace(email, expresion, string.Empty).Length == 0)
            {
                estado1 = true;
            }
            else
            {
                estado1 = false;
            }
        }
        else
        {
            estado1 = false;
        }
        if (Regex.IsMatch(email, expresion2))
        {
            if (Regex.Replace(email, expresion2, string.Empty).Length == 0)
            {
                estado2 = true;
            }
            else
            {
                estado2 = false;
            }
        }
        else
        {
            estado2 = false;
        }

        if (estado1 == false && estado2 == false)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}
