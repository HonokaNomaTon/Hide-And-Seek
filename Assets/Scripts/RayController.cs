using System.Collections;
using UnityEngine;

public class RayController : MonoBehaviour
{
    [SerializeField]private Transform anchor;
    private float maxDistance = 15;
    private LineRenderer lineRenderer;
    GameObject target;

    [SerializeField]
    private NumberOfRemaining _numberOfRemaining;

    private bool isGrab = false;
    private string tagId = "";

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(anchor.position, anchor.forward);

        lineRenderer.SetPosition(0, ray.origin);

        // 右コントローラのトリガーDown
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) || Input.GetKeyDown(KeyCode.R))
        {
            isGrab = true;
        }
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) || Input.GetKeyUp(KeyCode.R))
        {
            isGrab = false;
        }

        if (isGrab && tagId == "Grabbable" && target.transform.parent == null)
        {
            target.transform.parent = anchor.transform;
        }
        else if (!isGrab && target != null && target.transform.parent != null)
        {
            target.transform.parent = null;
        }


        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            lineRenderer.SetPosition(1, hit.point);

            target = hit.collider.gameObject;
            tagId = target.tag;
            if (target.CompareTag("Target") || target.CompareTag("Fake"))
            {
                //左のコントローラーを0.1秒間振動させる
                StartCoroutine(Vibrate(duration: 0.1f, controller: OVRInput.Controller.LTouch));
                target.GetComponent<Tongullkun>().Select();
            }

            // 右コントローラのAボタンを押した場合
            if (OVRInput.GetDown(OVRInput.RawButton.A) || Input.GetKeyDown(KeyCode.A))
            {
                if (target.CompareTag("Target"))
                {
                    _numberOfRemaining.UpdateTongullkunCount();
                }
                target.GetComponent<Tongullkun>().Found();
                //_numberOfRemaining.UpdateTongullkunCount();
            }
        }
        else
        {
            lineRenderer.SetPosition(1, ray.origin + (ray.direction * maxDistance));

            if (target != null && (tagId == "Target" || tagId == "Fake"))
            {
                target.GetComponent<Tongullkun>().Hidden();
            }

            //タグ初期化
            tagId = "";
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


