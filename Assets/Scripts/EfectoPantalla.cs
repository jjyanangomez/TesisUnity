using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EfectoPantalla : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void PasarNivel()
    {
        SceneManager.LoadScene("LongbowCinematica");
    }
    public void HacerFade()
    {
        anim.SetTrigger("FadeOut");
    }

}
