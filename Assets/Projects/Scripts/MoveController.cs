using UnityEngine;
using UnityEngine.AI;

public class MoveController : MonoBehaviour
{
    public Vector3 dest;

    private NavMeshAgent target;

    public float min = 0.8f;
    public float max = 1.5f;
    private void Awake()
    {
        target = GetComponent<NavMeshAgent>();
    }

    public void Call()
    {
        target.SetDestination(dest);
        target.speed *= Random.Range(min, max);
    }
}
