using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine_Sfx_End : MonoBehaviour
{

    public void onClick()
    {
        AkSoundEngine.PostEvent("Engine_Stop", gameObject);
    }
}
