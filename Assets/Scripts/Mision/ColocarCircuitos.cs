using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColocarCircuitos : MonoBehaviour
{
    public int sumar = 200;
    public int idItem;
    public int Puntaje;

    public GameObject jugador;

    private bool entro = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && entro)
        {
            jugador.GetComponent<ControlJugador>().total += 1;
            Debug.Log("Saber por q se incrementa: "+ jugador.GetComponent<ControlJugador>().total);
            jugador.GetComponent<ControlJugador>().estadoPreguntar = false;
            jugador.GetComponent<ControlJugador>().ActualizarMensajeColocar();
            jugador.GetComponent<ControlJugador>().valMision.Preguntas.CargarPantalla();
            Time.timeScale = 0;
            NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntos", sumar);
            gameObject.GetComponent<Target>().enabled = false;
            entro = false;
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugador = other.gameObject;
            entro = true;
            other.gameObject.GetComponent<ControlJugador>().MensajePresentar.SetActive(true);
            other.gameObject.GetComponent<ControlJugador>().MensajePresentar.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Presiona la tecla E para colocar el circuito";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        entro = false;
        other.gameObject.GetComponent<ControlJugador>().MensajePresentar.SetActive(false);
    }
}
