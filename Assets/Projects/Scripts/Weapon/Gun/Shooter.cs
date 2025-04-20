using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Shooter : MonoBehaviour
{
    public LayerMask hittableMask; // 맞혀진 레이어
    public Transform shootPoint; // 쏜 지점
    public GameObject hitEffectPrefab; // 이펙트 프리팹

    public float shootDelay = 0.1f; // 샷 지연 시간
    public float maxDistance = 100f; // 거리

    public UnityEvent<Vector3> OnShootSuccess;
    public UnityEvent OnShootFail;

    private Magazine magazine;

    private void Awake()
    {
        magazine = GetComponent<Magazine>();
    }

    private void Start()
    {
        Stop();
    }

    public void Play()
    {
        StopAllCoroutines();
        StartCoroutine(Process());
    }

    public void Stop()
    {
        StopAllCoroutines();
    }

    private IEnumerator Process()
    {
        var wfs = new WaitForSeconds(shootDelay);

        while (true)
        {
            if (magazine.Use())
            {
                Shoot();
            }
            else
            {
                OnShootFail?.Invoke();
            }

            yield return wfs; 
        }
    }

    private void Shoot()
    {
        if (Physics.Raycast(shootPoint.position, shootPoint.forward, out RaycastHit hitInfo, maxDistance, hittableMask))
        {
            Instantiate(hitEffectPrefab, hitInfo.point, Quaternion.identity);

            var hitObject = hitInfo.transform.GetComponent<Hittable>();
            hitObject?.Hit();
            
            OnShootSuccess?.Invoke(hitInfo.point);
        }
        else
        {
            var hitPoint = shootPoint.position + shootPoint.forward * maxDistance;
            OnShootSuccess?.Invoke(hitPoint);
        }
    }

}
