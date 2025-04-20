using UnityEngine;
using UnityEngine.Events;

public class MobController : MonoBehaviour
{
    public UnityEvent OnCreated; // ���� ���� �̺�Ʈ
    public UnityEvent OnDestroyed; // ���� ���� �̺�Ʈ

    public float destroyDelay = 1f; // ���� ���� �ð�
    private bool isDestroyed = false; // ���� ����

    private void Start()
    {
        OnCreated?.Invoke(); //  Update �Լ� ����Ŭ�� ����
        MobManager.Instance.OnSpawned(this); // �̱��� ����
    }


    public void Destroy()
    {
        if (isDestroyed)
            return;

        isDestroyed = true;

        Destroy(gameObject, destroyDelay);

        OnDestroyed?.Invoke();
        MobManager.Instance.OnDestroyed(this); // �̱��� ����
    }
}
