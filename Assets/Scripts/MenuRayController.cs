using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRayController : MonoBehaviour
{
    [SerializeField] private Transform anchor;
    private float maxDistance = 15;
    private LineRenderer lineRenderer;
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(anchor.position, anchor.forward);

        lineRenderer.SetPosition(0, ray.origin);

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            lineRenderer.SetPosition(1, hit.point);

            target = hit.collider.gameObject;
            if (target.CompareTag("MenuBtn"))
            {
                target.GetComponent<ChangeStageButton>().ChangeBtnState(true);
            }

            if (OVRInput.GetDown(OVRInput.RawButton.A) || Input.GetKeyDown(KeyCode.A))
            {
                if (target.GetComponent<ChangeStageButton>().isOn)
                {
                    SceneManager.Instance.ChangeScene(target.GetComponent<ChangeStageButton>().index);
                }
            }

        }
        else
        {
            lineRenderer.SetPosition(1, ray.origin + (ray.direction * maxDistance));

            if (target != null)
            {
                target.GetComponent<ChangeStageButton>().ChangeBtnState(false);
            }
        }
    }
}
