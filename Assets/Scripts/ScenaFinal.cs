using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenaFinal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeHaCulminado");
        
    }
}
