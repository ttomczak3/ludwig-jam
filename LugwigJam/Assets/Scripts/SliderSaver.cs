using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSaver : MonoBehaviour
{

    [SerializeField]
    private Slider slider;
    [SerializeField]
    private int id;

    public float sliderValue;

    void Awake()
    {
        // Loading the slider values.
        slider.value = PlayerPrefs.GetFloat("sliderValue" + id, sliderValue);
    }

    public void ChangeSlider(float value)
    {
        // Saving the slider values.
        sliderValue = value;
        PlayerPrefs.SetFloat("sliderValue" + id, sliderValue);
    }

}
