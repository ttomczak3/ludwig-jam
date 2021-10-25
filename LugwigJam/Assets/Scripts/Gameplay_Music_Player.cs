using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay_Music_Player : MonoBehaviour
{

    public void onClick()
    {
        AkSoundEngine.PostEvent("Game_Music_Play", gameObject);
    }   
}
