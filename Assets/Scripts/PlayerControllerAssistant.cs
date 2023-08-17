using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerControllerAssistant : MonoBehaviour
{
    OVRPlayerController ovrPlayerController;
    private bool isDash = false;
    private float accelerationBasic = 0.1f;
    private float accelerationFast = 0.5f;

    void Start()
    {
        ovrPlayerController = GameObject.Find("OVRPlayerController").GetComponent<OVRPlayerController>();
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.B) || Input.GetKeyDown(KeyCode.B))
        {
            isDash = !isDash;
        }

        // Bボタン押した時に速度変数を変更
        if (isDash && ovrPlayerController.Acceleration != accelerationFast)
        {
            ovrPlayerController.Acceleration = accelerationFast;
        }
        else if(!isDash && ovrPlayerController.Acceleration != accelerationBasic)
        {
            ovrPlayerController.Acceleration = accelerationBasic;
        }
    }
}
