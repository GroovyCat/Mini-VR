using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MobManager : MonoBehaviour
{
    private static MobManager instance;

    public static MobManager Instance // 속성
    {
        get 
        {
            if (instance == null)  
                instance = GameObject.FindAnyObjectByType<MobManager>();
            return instance;
        }
    }

    public UnityEvent<MobController> OnSpawn; // 스폰 이벤트
    public UnityEvent<MobController> OnDestroy; // 삭제 이벤트

    private List<MobController> mobs = new List<MobController>();

    private void Awake()
    {
        instance = this;
    }

    public void OnSpawned(MobController mob)
    {
        mobs.Add(mob);
        OnSpawn?.Invoke(mob);
    }

    public void OnDestroyed(MobController mob)
    {
        if (mobs.Remove(mob))
        {
            OnDestroy?.Invoke(mob);
        }
    }

    public void DestroyAll() // 몹 전체 삭제
    {
        while (mobs.Count > 0)
        {
            mobs[0]?.Destroy();
        }
    }
}
