using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisionSuelo : MonoBehaviour
{
    public int IdMision;

    [HideInInspector]
    public bool EstadoMision = false;
    [HideInInspector]
    public bool MisionCompletada = false;

    private bool entraste = true;

    public int cantidadItems;

    public GameObject mision1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (entraste)
            {
                mision1.SetActive(true);
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        entraste = false;
    }
}
