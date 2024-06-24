using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargarPersonaje : MonoBehaviour
{
    public GameObject PersonajeJhon;
    public GameObject PersonajeLinda;
    public GameObject PersonajeFredderi;
    public GameObject PersonajeKelly;

    public bool John;
    public bool Linda;
    public bool Fredderi;
    public bool Kelly;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        John = PlayerPrefs.GetInt("JohnSelect") == 1;
        Linda = PlayerPrefs.GetInt("LindaSelect") == 1;
        Fredderi = PlayerPrefs.GetInt("FredderiSelect") == 1;
        Kelly = PlayerPrefs.GetInt("KellySelect") == 1;

        if (John)
        {
            PersonajeJhon.SetActive(true);
            Destroy(PersonajeLinda);
            Destroy(PersonajeFredderi);
            Destroy(PersonajeKelly);
        }
        else if (Linda)
        {
            PersonajeLinda.SetActive(true);
            Destroy(PersonajeJhon);
            Destroy(PersonajeFredderi);
            Destroy(PersonajeKelly);
        }
        else if (Fredderi)
        {
            PersonajeFredderi.SetActive(true);
            Destroy(PersonajeJhon);
            Destroy(PersonajeLinda);
            Destroy(PersonajeKelly);
        }
        else if (Kelly)
        {
            PersonajeKelly.SetActive(true);
            Destroy(PersonajeJhon);
            Destroy(PersonajeLinda);
            Destroy(PersonajeFredderi);
        }
    }
}
