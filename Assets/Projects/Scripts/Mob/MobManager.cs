using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MobManager : MonoBehaviour
{
    private static MobManager instance;

    public static MobManager Instance // �Ӽ�
    {
        get 
        {
            if (instance == null)  
                instance = GameObject.FindAnyObjectByType<MobManager>();
            return instance;
        }
    }

    public UnityEvent<MobController> OnSpawn; // ���� �̺�Ʈ
    public UnityEvent<MobController> OnDestroy; // ���� �̺�Ʈ

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

    public void DestroyAll() // �� ��ü ����
    {
        while (mobs.Count > 0)
        {
            mobs[0]?.Destroy();
        }
    }
}
