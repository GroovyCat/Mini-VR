using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class TeleportActionHandler : MonoBehaviour
{
    public InputActionReference inputActionRef; // inputsystem에서 사용할 인터렉션 키 정보

    public UnityEvent OnShow;
    public UnityEvent OnHide;

    private void OnEnable() // 이벤트 처리
    {
        inputActionRef.action.performed += OnPerformed;
        inputActionRef.action.canceled += OnCanceled;
    }

    private void OnDisable() //이벤트 처리
    {
        inputActionRef.action.performed += OnPerformed;
        inputActionRef.action.canceled += OnCanceled;
    }

    public void OnPerformed(InputAction.CallbackContext obj)
    {
        StartCoroutine(DelayCall(OnShow));
    }

    public void OnCanceled(InputAction.CallbackContext obj)
    {
        StartCoroutine(DelayCall(OnHide));
    }

    private IEnumerator DelayCall(UnityEvent e)
    {
        yield return null;
        e?.Invoke();
    }
}
