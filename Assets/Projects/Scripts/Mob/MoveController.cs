using UnityEngine;
using UnityEngine.AI;

public class MoveController : MonoBehaviour
{
    private NavMeshAgent target; // ���������� �̵��ϴ� AI������Ʈ

    public float min = 0.8f; // �ּҼӵ� 
    public float max = 1.5f; // �ִ�ӵ�

    private void Awake()
    {
        target = GetComponent<NavMeshAgent>();
    }

    public void Call()
    {
        target.SetDestination(Core.Instance.transform.position); // ���������� �̵�
        target.speed *= Random.Range(min, max); // ���� �ӵ�
    }
}
