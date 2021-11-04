using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSaver : MonoBehaviour
{

    [SerializeField]
    public Slider slider;
    [SerializeField]
    public int id;

    public float sliderValue;

    void Awake()
    {
        slider.value = PlayerPrefs.GetFloat("sliderValue" + id, sliderValue);
    }

    public void ChangeSlider(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("sliderValue" + id, sliderValue);
    }

}
