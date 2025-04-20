using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefab; // 몬스터 프리팹 배열

    public bool playOnStart = true; 
    public float startFactor = 1f; // 시작 시간 
    public float additiveFactor = 0.1f; // 추가 지연 시간
    public float delayPerSpawnGroup = 3f; // 각 스폰 지연 시간

    private void Start()
    {
        if (playOnStart)
            Play();
    }

    public void Play()
    {
        StartCoroutine(Process());
    }

    public void Stop()
    {
        StopAllCoroutines();
    }

    private IEnumerator Process()
    {
        var factor = startFactor;
        var wfs = new WaitForSeconds(delayPerSpawnGroup);

        while (true)
        {
            yield return wfs;

            yield return StartCoroutine(SpawnProcess(factor));
            factor += additiveFactor;
        }
    }

    private IEnumerator SpawnProcess(float factor)
    {
        var count = Random.Range(factor, factor * 2f); // 몹 생성 개수

        for (int i = 0; i < count; i++)
        {
            Spawn();
            if (Random.value < 0.2f)
                yield return new WaitForSeconds(Random.Range(0.01f, 0.02f));
        }
    }

    private void Spawn()
    {
        int index = Random.Range(0, 2); // 랜덤 몹
        Instantiate(prefab[index], transform.position, transform.rotation, transform);
    }
}
