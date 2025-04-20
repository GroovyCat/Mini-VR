using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class BombController : MonoBehaviour
{
	public enum State // ��ź ���� 
	{
		Idle,
		Drop,
	}

	public float explosionRadius; // ���� ����
	public LayerMask explosionHittableMask; // ���� ��� ���̾� �۾� 

	public float recycleDelay = 1f; // ����� �ð�

	public UnityEvent OnExplosion; // ���� �̺�Ʈ 
	public UnityEvent OnRecycle; // ����� �̺�Ʈ

	private State state;

	public void Drop()
	{
		state = State.Drop;
	}

	public void Throw() // ������ �̺�Ʈ
	{
		var interactable = GetComponent<XRGrabInteractable>(); // �׷� ���ͷ��� ��ü 
		interactable.interactionManager.CancelInteractableSelection((IXRSelectInteractable)interactable);

		var rb = GetComponent<Rigidbody>();
		rb.AddRelativeForce(new Vector3(0f, 150f, 300f)); // Ʈ���� �̺�Ʈ �� �ش� ���͸�ŭ ��������
	}

    private void OnTriggerEnter(Collider other) 
    {
        if (state == State.Idle)
			return;

		Explosion();
    }

	private void Explosion() // ����
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
