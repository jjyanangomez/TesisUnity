using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicaComienzo : MonoBehaviour
{
    public GameObject PanelBienvenida;
    public GameObject BotonInicio;

    public GameObject CamaraPelican;
    public GameObject CamaraPrincipal;
    // Start is called before the first frame update
    void Start()
    {
        CamaraPelican.SetActive(true);
        CamaraPrincipal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
