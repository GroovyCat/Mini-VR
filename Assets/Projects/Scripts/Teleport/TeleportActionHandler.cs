using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class TeleportActionHandler : MonoBehaviour
{
    public InputActionReference inputActionRef; // inputsystem���� ����� ���ͷ��� Ű ����

    public UnityEvent OnShow;
    public UnityEvent OnHide;

    private void OnEnable() // �̺�Ʈ ó��
    {
        inputActionRef.action.performed += OnPerformed;
        inputActionRef.action.canceled += OnCanceled;
    }

    private void OnDisable() //�̺�Ʈ ó��
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
