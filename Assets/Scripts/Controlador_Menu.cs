using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador_Menu : MonoBehaviour
{
    public GameObject menu;
    public GameObject botonAbrirMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void abrirMenu()
    {
        menu.SetActive(true);
        botonAbrirMenu.SetActive(false);
    }
    public void cerrarMenu()
    {
        menu.SetActive(false);
        botonAbrirMenu.SetActive(true);
    }


}
