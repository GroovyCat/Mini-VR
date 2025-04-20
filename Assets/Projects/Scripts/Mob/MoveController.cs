using UnityEngine;
using UnityEngine.AI;

public class MoveController : MonoBehaviour
{
    private NavMeshAgent target; // 도착지까지 이동하는 AI에이전트

    public float min = 0.8f; // 최소속도 
    public float max = 1.5f; // 최대속도

    private void Awake()
    {
        target = GetComponent<NavMeshAgent>();
    }

    public void Call()
    {
        target.SetDestination(Core.Instance.transform.position); // 도착지까지 이동
        target.speed *= Random.Range(min, max); // 랜덤 속도
    }
}
