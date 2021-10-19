using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Button_Click : MonoBehaviour
{
    // Start is called before the first frame update
    public void onClick ()
    {
        AkSoundEngine.PostEvent("Button_Click", gameObject);
    }
}
