using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicaFinal : MonoBehaviour
{
    public GameObject panelFinal;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;

    public GameObject PelicanIncendio;
    public GameObject Pelican;
    public GameObject Cubo_cine_Final;
    public GameObject Incendio;
    public GameObject Mision4;

    public GameObject Puntaje;
    public Puntuacion punto;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void activarPanel1()
    {
        panel1.SetActive(true);
    }
    public void activarPanel2()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
    }
    public void activarPanel3()
    {
        panel2.SetActive(false);
        panel3.SetActive(true);
    }
    public void activarPanel4()
    {
        panel3.SetActive(false);
        panel4.SetActive(true);
    }

    public void CambiarPelicans()
    {    
        panelFinal.SetActive(false);
        Mision4.SetActive(false);
        if (punto.Resultado <= 0)
        {
            Cubo_cine_Final.SetActive(true);
        }
        else
        {
            PelicanIncendio.SetActive(false);
            Incendio.SetActive(false);
            Pelican.SetActive(true);
        }

        Puntaje.transform.GetChild(0).gameObject.SetActive(true);
        Puntaje.transform.GetChild(1).gameObject.SetActive(true);
    }
}
