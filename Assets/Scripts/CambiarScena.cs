using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarScena : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambiarCinematica()
    {
        SceneManager.LoadScene("LongbowCinematica");
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene("Intro");
    }
}
