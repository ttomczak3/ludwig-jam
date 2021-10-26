using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tachometer : MonoBehaviour {
    public Rigidbody target;

    public float maxRPM = 0.0f; // The maximum speed of the target ** IN KM/H **

    public float minTachoArrowAngle;
    public float maxTachoArrowAngle;

    [Header("UI")]
    public Text tachoLabel; // The label that displays the speed;
    public RectTransform arrow; // The arrow in the speedometer

    public float RPM = 0.0f;
    private void Update() {
       

        if (tachoLabel != null)
            tachoLabel.text = ((int)RPM) + " km/h";
        if (arrow != null)
            arrow.localEulerAngles =
                new Vector3(0, 0, Mathf.Lerp(minTachoArrowAngle, maxTachoArrowAngle, RPM / maxRPM));
    }
}
