using UnityEngine;

public class EmissionController : MonoBehaviour
{
    public float intensity = 5f;

    private Renderer target;

    private void Awake()
    {
        target = GetComponent<Renderer>();
    }

    public void Call(Color color)
    {
        target.material.SetColor("_EmissionColor", color * intensity);
    }
}
