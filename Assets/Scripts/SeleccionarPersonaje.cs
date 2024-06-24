using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeleccionarPersonaje : MonoBehaviour
{
    public bool John = true;
    public bool Linda = false;
    public bool Fredderi = false;
    public bool Kelly = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        John = PlayerPrefs.GetInt("JohnSelect") == 1;
        Linda = PlayerPrefs.GetInt("LindaSelect") == 1;
        Fredderi = PlayerPrefs.GetInt("FredderiSelect") == 1;
        Kelly = PlayerPrefs.GetInt("KellySelect") == 1;
    }
    // Update is called once per frame
    void Update()
    {
        if (John == false && Linda == false && Fredderi == false && Kelly == false)
        {
            John = true;
        }
        
    }

    public void PersonajeJohn()
    {
        John = true;
        Linda = false;
        Fredderi = false;
        Kelly = false;
        Guardar();
}
    public void PersonajeLinda()
    {
        John = false;
        Linda = true;
        Fredderi = false;
        Kelly = false;
        Guardar();
    }
    public void PersonajeFredderi()
    {
        John = false;
        Linda = false;
        Fredderi = true;
        Kelly = false;
        Guardar();
    }
    public void PersonajeKelly()
    {
        John =  false;
        Linda = false;
        Fredderi = false;
        Kelly = true;
        Guardar();
    }

    public void Guardar()
    {
        PlayerPrefs.SetInt("JohnSelect",John ? 1:0);
        PlayerPrefs.SetInt("LindaSelect", Linda ? 1 : 0);
        PlayerPrefs.SetInt("FredderiSelect", Fredderi ? 1 : 0);
        PlayerPrefs.SetInt("KellySelect", Kelly ? 1 : 0);
    }

    /*public void Jugar()
    {
        Guardar();
        SceneManager.LoadScene("Longbow");
    }*/
}
