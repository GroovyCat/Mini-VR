using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class WeaponController : MonoBehaviour
{
    public UnityEvent OnGrab; // 그랩 인터랙션 이벤트
    public UnityEvent OnRelease; // 그랩 인터랙션 종료 시 이벤트

    public void Grab(SelectEnterEventArgs args)
    {
        var interactor = args.interactableObject;
        if (interactor is XRDirectInteractor) 
        {
            OnGrab?.Invoke();
        }   
    }

    public void Release(SelectExitEventArgs args)
    {
        var interactor = args.interactableObject;
        if (interactor is XRDirectInteractor)
        {
            OnRelease?.Invoke();
        }
    }
}
