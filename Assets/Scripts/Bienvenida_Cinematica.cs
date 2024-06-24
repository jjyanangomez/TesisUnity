using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bienvenida_Cinematica : MonoBehaviour
{
    public GameObject UbicacionBibliotecaria;
    public GameObject Flood;
    public GameObject panelBienvenida;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;
    public GameObject panel6;
    public GameObject panel7;
    public GameObject panel8;
    public GameObject Panel_Aviso;
    public GameObject Panel_Flood;
    public GameObject TextoIndicar;
    public List<GameObject> players = new List<GameObject>();

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
        foreach (var player in players)
        {
            if (player != null)
            {
                player.transform.GetComponent<Invector.vCharacterController.vThirdPersonInput>().enabled = false;
            }
            
        }
    }
    public void activarPanel2()
    {
        panel1.SetActive(false);
        panel6.SetActive(true);
    }
    public void activarPanel3()
    {
        panel6.SetActive(false);
        panel2.SetActive(true);
    }
    public void activarPanel4()
    {
        panel2.SetActive(false);
        panel3.SetActive(true);
    }
    public void activarPanel5()
    {
        panel3.SetActive(false);
        panel4.SetActive(true);
    }
    public void activarPanel6()
    {
        panel4.SetActive(false);
        panel5.SetActive(true);
    }
    public void activarPanel7()
    {
        panel5.SetActive(false);
        panel7.SetActive(true);
    }
    public void activarPanel8()
    {
        panel7.SetActive(false);
        panel8.SetActive(true);
    }
    public void activarMision1()
    {
        panelBienvenida.SetActive(false);
        panel8.SetActive(false);
        TextoIndicar.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Encuentra a la Bibliotecaria quien te va ayudar";
        UbicacionBibliotecaria.SetActive(true);
        Panel_Aviso.SetActive(true);
        Panel_Flood.SetActive(true);
        Flood.SetActive(true);
        foreach (var player in players)
        {
            if (player != null)
            {
                player.transform.GetComponent<Invector.vCharacterController.vThirdPersonInput>().enabled = true;
            }

        }
    }
}
