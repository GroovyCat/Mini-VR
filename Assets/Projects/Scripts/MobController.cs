using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobController : MonoBehaviour
{
    public ParticleSystem envtParticle;
    public ParticleSystem destroyParticle;
    public MeshRenderer holeMeshRenderer;
    public AudioSource destoryAudio;
    public GameObject modelGameObject;
    public float hueMin = 0f;
    public float hueMax = 1f;
    public float saturationMin = 0.7f;
    public float saturationMax = 1f;
    public float valueMin = 0.7f;
    public float valueMax = 1f;
    public float arrangeRange = 0.5f;
    public float emissionIntensity = 5f;
    public float destroyDelay = 1f;


    private NavMeshAgent agent;
    private bool isDestroyed = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        agent.SetDestination(new Vector3(0f, 2f, 1f));
        agent.speed *= Random.Range(0.8f, 1.5f);

        RandomColor();

        Invoke(nameof(Destroy), 3f);
    }

    private void RandomColor()
    {
        var color = Random.ColorHSV(hueMin, hueMax, saturationMin, saturationMax, valueMin, valueMax);
        var main = envtParticle.main;
        var renderer = envtParticle.GetComponent<ParticleSystemRenderer>();

        main.startColor = new ParticleSystem.MinMaxGradient(color, color * Random.Range(1f - arrangeRange, 1f + arrangeRange));
        renderer.material.SetColor("_EmissionColor", color * emissionIntensity);

        holeMeshRenderer.material.SetColor("_EmissionColor", color * emissionIntensity);

        main = destroyParticle.main;
        renderer = destroyParticle.GetComponent<ParticleSystemRenderer>();

        main.startColor = new ParticleSystem.MinMaxGradient(color, color * Random.Range(1f - arrangeRange, 1f + arrangeRange));
        renderer.material.SetColor("_EmissionColor", color * emissionIntensity);

    }

    public void Destroy()
    {
        if (isDestroyed)
            return;

        isDestroyed = true;

        destroyParticle.Play();
        destoryAudio.Play();

        envtParticle.Stop();
        agent.enabled = false;
        modelGameObject.SetActive(false);

        Destroy(gameObject, destroyDelay);
    }
}
