using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_1_State : MonoBehaviour
{

    public void onClick()
    {
        AkSoundEngine.SetState("Level", "Level_1");
    }
}
