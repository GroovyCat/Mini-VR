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
        Invoke(nameof(Destroy), 3f);

        OnCreated?.Invoke();
    }


    public void Destroy()
    {
        if (isDestroyed)
            return;

        isDestroyed = true;

        Destroy(gameObject, destroyDelay);

        OnDestroyed?.Invoke();
    }
}
