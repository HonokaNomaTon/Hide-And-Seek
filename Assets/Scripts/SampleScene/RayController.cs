using System.Collections;
using UnityEngine;

public class RayController : MonoBehaviour
{
    [SerializeField]private Transform anchor;
    private float maxDistance = 100;
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(anchor.position, anchor.forward);

        lineRenderer.SetPosition(0, ray.origin);

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            lineRenderer.SetPosition(1, hit.point);

            GameObject target = hit.collider.gameObject;

            // 右コントローラのAボタンを押した場合
            if (OVRInput.GetDown(OVRInput.RawButton.A))
            {
                if (target.CompareTag("Target"))
                {
                    // ブロックを赤色に変化させる。
                    target.GetComponent<MeshRenderer>().material.color = Color.blue;
                }
                else {
                    //左のコントローラーを0.5秒間振動させる
                    StartCoroutine(Vibrate(duration: 0.5f, controller: OVRInput.Controller.LTouch));
                }
            }
        }
        else
        {
            lineRenderer.SetPosition(1, ray.origin + (ray.direction * maxDistance));
        }
    }


    /// <summary>
    /// Oculus Quest(やQuest2)のコントローラーを振動させる
    /// </summary>
    public static IEnumerator Vibrate(float duration = 0.1f, float frequency = 0.1f, float amplitude = 0.1f, OVRInput.Controller controller = OVRInput.Controller.Active)
    {
        //コントローラーを振動させる
        OVRInput.SetControllerVibration(frequency, amplitude, controller);

        //指定された時間待つ
        yield return new WaitForSeconds(duration);

        //コントローラーの振動を止める
        OVRInput.SetControllerVibration(0, 0, controller);
    }
}


