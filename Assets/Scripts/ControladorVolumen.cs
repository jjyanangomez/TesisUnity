using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorVolumen : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image ImagenMute;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("Volumen",0.5f);
        AudioListener.volume = slider.value;
        RevisarMute();
    }
    public void RevisarMute()
    {
        if (sliderValue == 0)
        {
            ImagenMute.enabled = true;
        }
        else
        {
            ImagenMute.enabled = false;
        }
    }
    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("Volumen",sliderValue);
        AudioListener.volume = slider.value;
        RevisarMute();
    }

    
}
