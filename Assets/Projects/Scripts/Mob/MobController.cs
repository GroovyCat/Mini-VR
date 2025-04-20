using UnityEngine;
using UnityEngine.Events;

public class MobController : MonoBehaviour
{
    public UnityEvent OnCreated; // 몬스터 생성 이벤트
    public UnityEvent OnDestroyed; // 몬스터 삭제 이벤트

    public float destroyDelay = 1f; // 삭제 지연 시간
    private bool isDestroyed = false; // 삭제 여부

    private void Start()
    {
        OnCreated?.Invoke(); //  Update 함수 사이클에 실행
        MobManager.Instance.OnSpawned(this); // 싱글톤 패턴
    }


    public void Destroy()
    {
        if (isDestroyed)
            return;

        isDestroyed = true;

        Destroy(gameObject, destroyDelay);

        OnDestroyed?.Invoke();
        MobManager.Instance.OnDestroyed(this); // 싱글톤 패턴
    }
}
