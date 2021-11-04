using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveMusic : MonoBehaviour
{
    public Slider sliderMusic;

    public float sliderValue;

    // Start is called before the first frame update
    void Start()
    {
        sliderMusic.value = PlayerPrefs.GetFloat("save", sliderValue);
    }

    public void ChangeSlider(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("save", sliderValue);
    }
}
