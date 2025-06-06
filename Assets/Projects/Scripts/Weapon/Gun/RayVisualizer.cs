using System.Collections;
using UnityEngine;

public class RayVisualizer : MonoBehaviour
{
    [Header("Ray")]
    public LineRenderer ray;
    public LayerMask hitRayMask;
    public float distance = 100f;

    [Header("Reticle Point")]
    public GameObject reticlePoint;
    public bool showReticle = true;

    private void Awake()
    {
        Off();
    }

    public void On()
    {
        StopAllCoroutines();
        StartCoroutine(Process());
    }

    public void Off()
    {
        StopAllCoroutines();
        ray.enabled = false;
        reticlePoint.SetActive(false);
    }

    private IEnumerator Process() // 레이 선 처리 작업 코루틴
    {
        while (true)
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, distance, hitRayMask))
            {
                ray.SetPosition(1, transform.InverseTransformPoint(hitInfo.point));
                ray.enabled = true;

                reticlePoint.transform.position = hitInfo.point;
                reticlePoint.SetActive(showReticle);
            }
            else
            {
                ray.enabled = false;

                reticlePoint.SetActive(false);
            }
            yield return null;
        }
    }
}
