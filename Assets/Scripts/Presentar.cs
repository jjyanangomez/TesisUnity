using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Presentar : MonoBehaviour
{
    public GameObject Llamas;
    public GameObject Particulas_Explo;
    public GameObject CamaraPelican;
    public GameObject CamaraPrincipal;
    public AudioClip Explocion;
    public AudioClip SonidoVuelo;

    public GameObject PanelKelly;
    public GameObject PanelFredderi;
    public GameObject[] PanelJohn;
    public GameObject PanelLinda;

    public GameObject PanelInicio;
    public GameObject PanelImpactoPelican;

    public GameObject BotonIniciar;
    public GameObject SonidoVueloObjet;

    public GameObject EquipoAzul;

    public bool estadoImpacto = false;
    // Start is called before the first frame update

    private void Start()
    {
        Time.timeScale = 0F;
    }
    private void Update()
    {

    }
    public void SonidoChoque()
    {
        AudioSource.PlayClipAtPoint(Explocion, CamaraPrincipal.transform.position);
        Llamas.SetActive(true);
    }
    public void Sonido_Pelican()
    {
        AudioSource.PlayClipAtPoint(SonidoVuelo, CamaraPelican.transform.position);
    }
    public void CambiarCamara()
    {
        CamaraPelican.SetActive(false);
        CamaraPrincipal.SetActive(true);
        
    }

    //Presentar paneles de la cinematica
    public void InicioKelly()
    {
        PanelKelly.SetActive(true);
    }
    public void CambiarPanelFredderi()
    {
        PanelKelly.SetActive(false);
        PanelFredderi.SetActive(true);
    }
    public void CambiarPanelJhon()
    {
        PanelFredderi.SetActive(false);
        PanelJohn[0].SetActive(true);
        Time.timeScale = 1.0F;
    }

    public void CambiarPanelLinda()
    {
        PanelLinda.SetActive(true);
    }
    public void CambiarPanelJhonUltimo()
    {
        PanelLinda.SetActive(false);
        PanelJohn[1].SetActive(true);
    }

    public void DesactivarPanelJhonUltimo()
    {
        PanelJohn[1].SetActive(false);
    }
    public void PanelImpacto()
    {
        PanelJohn[0].SetActive(false);
        PanelImpactoPelican.SetActive(true);
        estadoImpacto = true;
    }

    public void IniciarEscena()
    {
        PanelInicio.SetActive(false);
        Time.timeScale = 0.8F;
        SonidoVueloObjet.SetActive(true);
    }

    public void Impacto()
    {
        Particulas_Explo.SetActive(true);
        SonidoVueloObjet.SetActive(false);
    }

    public void Spartans()
    {
        PanelImpactoPelican.SetActive(false);
        EquipoAzul.SetActive(true);
    }

    public void ActivarBotonIniciar()
    {
        BotonIniciar.SetActive(true);
    }
    public void CambiarEscena()
    {
        Time.timeScale = 1F;
        SceneManager.LoadScene("ElegirPersonaje");
    }
}
