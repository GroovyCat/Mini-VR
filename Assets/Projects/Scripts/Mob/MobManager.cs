using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class MobManager : MonoBehaviour
{
    private static MobManager instance;

    public static MobManager Instance
    {
        get 
        {
            if (instance == null)  
                instance = GameObject.FindAnyObjectByType<MobManager>();
            return instance;
        }
    }

    public UnityEvent<MobController> OnSpawn;
    public UnityEvent<MobController> OnDestroy;

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

    public void DestroyAll()
    {
        while (mobs.Count > 0)
        {
            mobs[0]?.Destroy();
        }
    }
}
