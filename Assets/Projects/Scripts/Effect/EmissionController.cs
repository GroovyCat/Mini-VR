using UnityEngine;

public class EmissionController : MonoBehaviour
{
    public float intensity = 5f;
    public float min = 0f;
    public float max = 3f;

    private Renderer target;

    private void Awake()
    {
        target = GetComponent<Renderer>();
    }

    public void MobCall(Color color)
    {
        target.material.SetColor("_EmissionColor", color * intensity);
    }

    public void GunCall(float ratio)
    {
        var intensity = Mathf.Lerp(min, max, ratio);
        target.material.SetColor("_EmissionColor", target.material.color * intensity);
    }
}
