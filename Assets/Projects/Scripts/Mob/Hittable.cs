using UnityEngine;
using UnityEngine.Events;

public class Hittable : MonoBehaviour
{
    public UnityEvent OnHit; // 쏘였을때의 이벤튼

    public void Hit()
    {
        OnHit?.Invoke();
    }
}
