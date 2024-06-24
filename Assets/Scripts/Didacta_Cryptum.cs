using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Didacta_Cryptum : MonoBehaviour
{
    public GameObject camara;
    public GameObject camaraPelican;
    public GameObject Didacta;

    public GameObject Panel1Didacta;

    public GameObject PanelOscurecer;

    public Animator Pelican;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivarPanel1()
    {
        Panel1Didacta.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void ActivarPanel2()
    {
        Panel1Didacta.transform.GetChild(0).gameObject.SetActive(false);
        Panel1Didacta.transform.GetChild(1).gameObject.SetActive(true);
    }

    public void desactivarDidacta()
    {
        Didacta.SetActive(false);
    }

    public void CambiarCamara()
    {
        
        camaraPelican.SetActive(true);
        camara.SetActive(false);
        Panel1Didacta.transform.GetChild(1).gameObject.SetActive(false);

    }
    public void ActivarPanelOscurecer()
    {
        PanelOscurecer.GetComponent<Animator>().enabled = true;
    }

    public void ActivarPelican()
    {
        Pelican.enabled = true;
    }
}
