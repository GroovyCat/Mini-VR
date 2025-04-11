using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Magazine : MonoBehaviour, IReloadable
{
    public int maxBullets = 20;
    public float chargingTime = 2f;

    private int currentBullets;
    private int CurrentBullets
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

    public UnityEvent OnReloadStart;
    public UnityEvent OnReloadComplete;

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

    private IEnumerator ReloadProcesser()
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
