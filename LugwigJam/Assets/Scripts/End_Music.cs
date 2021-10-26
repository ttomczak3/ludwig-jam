using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_Music : MonoBehaviour
{


    public void onClick()
    {
        AkSoundEngine.PostEvent("Game_Music_Stop", gameObject);
    }
}
