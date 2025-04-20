using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class BombController : MonoBehaviour
{
	public enum State // 폭탄 상태 
	{
		Idle,
		Drop,
	}

	public float explosionRadius; // 폭발 범위
	public LayerMask explosionHittableMask; // 폭발 대상 레이어 작업 

	public float recycleDelay = 1f; // 재생성 시간

	public UnityEvent OnExplosion; // 폭발 이벤트 
	public UnityEvent OnRecycle; // 재생성 이벤트

	private State state;

	public void Drop()
	{
		state = State.Drop;
	}

	public void Throw() // 던지는 이벤트
	{
		var interactable = GetComponent<XRGrabInteractable>(); // 그랩 인터렉션 객체 
		interactable.interactionManager.CancelInteractableSelection((IXRSelectInteractable)interactable);

		var rb = GetComponent<Rigidbody>();
		rb.AddRelativeForce(new Vector3(0f, 150f, 300f)); // 트리거 이벤트 시 해당 벡터만큼 움직여라
	}

    private void OnTriggerEnter(Collider other) 
    {
        if (state == State.Idle)
			return;

		Explosion();
    }

	private void Explosion() // 폭발
	{
		var overlaps = Physics.OverlapSphere(transform.position, explosionRadius, explosionHittableMask, 
			QueryTriggerInteraction.Collide);
		foreach (var overlap in overlaps)
		{
			var hitObject = overlap.GetComponent<Hittable>();
			hitObject?.Hit();
		}

		OnExplosion?.Invoke();
		Invoke(nameof(Recycle), recycleDelay);
	}

	private void Recycle()
	{
		state = State.Idle;

		OnRecycle?.Invoke();
	}
}
