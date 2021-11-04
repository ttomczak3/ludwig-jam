using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VolumeSlider : MonoBehaviour
{

    public Slider thisSlider;
    public float SFXVolume;
    public float MusicVolume;

    public void SetSpecificVolume(string whatValue)
    {
        float sliderValue = thisSlider.value;

        if (whatValue == "SFX")
        {
            SFXVolume = thisSlider.value;
            AkSoundEngine.SetRTPCValue("SfxVolume", SFXVolume);

        }

        if (whatValue == "Music")
        {
            MusicVolume = thisSlider.value;
            AkSoundEngine.SetRTPCValue("MusicVolume", MusicVolume);

        }

    }

}
