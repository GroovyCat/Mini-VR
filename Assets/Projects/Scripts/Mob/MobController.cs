using UnityEngine;
using UnityEngine.Events;

public class MobController : MonoBehaviour
{
    public UnityEvent OnCreated;
    public UnityEvent OnDestroyed;

    public float destroyDelay = 1f;
    private bool isDestroyed = false;

    private void Start()
    {
        OnCreated?.Invoke();
        MobManager.Instance.OnSpawned(this);
    }


    public void Destroy()
    {
        if (isDestroyed)
            return;

        isDestroyed = true;

        Destroy(gameObject, destroyDelay);

        OnDestroyed?.Invoke();
        MobManager.Instance.OnDestroyed(this);
    }
}
