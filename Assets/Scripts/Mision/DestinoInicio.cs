using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinoInicio : MonoBehaviour
{

    public int id_destino = 1;
    public GameObject mision1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //reached = true;
            Destroy(gameObject);
            mision1.SetActive(true);
        }
    }
}
