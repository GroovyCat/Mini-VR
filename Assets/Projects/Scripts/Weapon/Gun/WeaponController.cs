using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class WeaponController : MonoBehaviour
{
    public UnityEvent OnGrab;
    public UnityEvent OnRelease;

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
