using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine_Sfx_Play : MonoBehaviour
{

    public void onClick()
    {
        AkSoundEngine.PostEvent("Engine_Play", gameObject);
    }
}
