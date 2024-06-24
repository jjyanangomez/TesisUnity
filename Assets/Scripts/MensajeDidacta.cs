using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MensajeDidacta : MonoBehaviour
{
    public GameObject Mensaje;
    public bool estado = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (estado)
        {
            Mensaje.SetActive(true);
        }
        else
        {
            Mensaje.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estado = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estado = false;
        }
    }
}
