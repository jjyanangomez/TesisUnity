using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using Newtonsoft.Json;
using UnityEngine.Networking;
using TMPro;

public class VistaResultados : MonoBehaviour
{
    string URL ;
    private ResultadosEstudiantes Resultado;
    public GameObject ScrollViewContent;
    public GameObject student;
    public List<GameObject> elements = new List<GameObject>();
    private bool estado = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string GetUrl()
    {
    
        //URL = "http://localhost/Tesis/UnificacionPlatform/src/views/Api/Resultados.php?key=" + PlayerPrefs.GetString("CodigoPre");
        URL = "https://eva3.utpl.edu.ec/gamificev/src/views/Api/Resultados.php?key=" + PlayerPrefs.GetString("CodigoPre");
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
            var myclase = JsonConvert.DeserializeObject<ResultadosEstudiantes>(request.downloadHandler.text);
            
            if (myclase.status)
            {
                Resultado = myclase;
                Debug.Log("Probando obtencion de datos: " + myclase.Resultados[0].Correo);

                for (int i = 0; i < myclase.Resultados.Count; i++)
                {
                    int valor = i + 1;
                    student.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = valor.ToString();
                    student.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = myclase.Resultados[i].Nombre.ToString();
                    student.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = myclase.Resultados[i].Puntaje.ToString();
                    student.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = myclase.Resultados[i].ResultadoEva.ToString("F2");
                    student.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = myclase.Resultados[i].Duracion.ToString();
                    

                    GameObject panel = (GameObject)Instantiate(student);
                    panel.transform.SetParent(ScrollViewContent.transform);
                    panel.transform.localPosition = Vector3.zero;
                    panel.transform.localScale = Vector3.one;

                }
                estado = true;
            }
            else
            {
                Debug.Log("No hay datos por el momento");
            }
        }
    }
    public void Cargar()
    {
        if (estado == true)
        {
            LImpiar();
        }
        GetRequest();
    }
    void obtenerLista()
    {
        for (int i = 0; i < ScrollViewContent.transform.childCount; i++)
        {
            elements.Add(ScrollViewContent.transform.GetChild(i).gameObject);
        }
    }
    void LImpiar()
    {
        obtenerLista();
        foreach (GameObject element in elements)
        {
            Destroy(element);
        }
    }
}
