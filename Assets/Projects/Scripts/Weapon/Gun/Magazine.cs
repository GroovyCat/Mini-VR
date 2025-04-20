using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Magazine : MonoBehaviour, IReloadable
{
    public int maxBullets = 20; // 총알 수
    public float chargingTime = 2f; // 충전 시간

    private int currentBullets;

    private int CurrentBullets // 속성
    {
        get => currentBullets;
        set
        {
            if (value < 0)
                currentBullets = 0;
            else if (value > maxBullets)
                currentBullets = maxBullets;
            else
                currentBullets = value;

            OnBulletsChanged?.Invoke(currentBullets);
            OnChargeChanged?.Invoke((float)currentBullets / maxBullets);
        }
    }

    public UnityEvent OnReloadStart; // 재장전 시간 이벤트
    public UnityEvent OnReloadComplete; // 재장전 완료 이벤트

    public UnityEvent<int> OnBulletsChanged;
    public UnityEvent<float> OnChargeChanged;

    private void Start()
    {
        CurrentBullets = maxBullets;
    }

    public bool Use(int amount = 1)
    {
        if (CurrentBullets >= amount)
        {
            CurrentBullets -= amount;
            return true;
        }
        else 
            return false;
    }

    [ContextMenu("Reload")]
    public void StartReload()
    {
        if (currentBullets == maxBullets) return;

        StopAllCoroutines();
        StartCoroutine(ReloadProcesser());
    }

    public void StopReload()
    {
        StopAllCoroutines();
    }

    private IEnumerator ReloadProcesser() // 총 재장전 실행 코루틴
    {
        OnReloadStart?.Invoke();

        var startTime = Time.time;
        var startBullet = currentBullets;
        var enoughPercent = 1f - ((float)currentBullets / maxBullets);
        var enoughChargingTime = chargingTime * enoughPercent;

        while (true)
        {
            var t = (Time.time - startTime) / enoughChargingTime;
            if (t >= 1f)
            {
                break;
            }

            CurrentBullets = (int)Mathf.Lerp(startBullet, maxBullets, t);
            yield return null;
        }

        CurrentBullets = maxBullets;

        OnReloadComplete?.Invoke();
    }

}
