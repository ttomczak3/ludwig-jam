using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_1_Switch : MonoBehaviour
{

    public void onClick()
    {
        AkSoundEngine.SetSwitch("Level", "Level_1", gameObject);

    }
}
