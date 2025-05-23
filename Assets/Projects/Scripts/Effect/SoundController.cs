using UnityEngine;

public class SoundController : MonoBehaviour
{
    public float minPitch = 0.8f;
    public float maxPitch = 1.2f;

    private AudioSource target;

    private void Awake()
    {
        target = GetComponent<AudioSource>();
    }

    public void Call()
    {
        target.pitch = Random.Range(minPitch, maxPitch);
        target.Play();
    }

}
