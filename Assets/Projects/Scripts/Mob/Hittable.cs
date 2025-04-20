using UnityEngine;
using UnityEngine.Events;

public class Hittable : MonoBehaviour
{
    public UnityEvent OnHit; // ������� �̺�ư

    public void Hit()
    {
        OnHit?.Invoke();
    }
}
