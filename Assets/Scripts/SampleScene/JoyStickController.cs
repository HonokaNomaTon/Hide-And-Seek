using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class JoyStickController : MonoBehaviour
{
    float angle = 2;

    void Update()
    {
        ChangeDirection();
        Move();
    }

    //OVRCameraRigの角度変更
    void ChangeDirection()
    {
        if (OVRInput.Get(OVRInput.RawButton.LThumbstickLeft))
        {
            this.transform.Rotate(0, -angle, 0);
        }
        else if (OVRInput.Get(OVRInput.RawButton.LThumbstickRight))
        {
            this.transform.Rotate(0, angle, 0);
        }
    }

    void Move()
    {
        //右ジョイスティックの情報取得
        Vector2 stickR = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);
        //OVRCameraRigの位置変更
        this.transform.position += this.transform.rotation * (new Vector3((stickR.x), 0, (stickR.y)));
    }
}
