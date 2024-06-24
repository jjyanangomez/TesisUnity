using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarObjeto : MonoBehaviour
{
    public GameObject Objeto;
    public GameObject Referencia;

    void Start()
    {
        Instantiate(Objeto, transform.position, Referencia.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
