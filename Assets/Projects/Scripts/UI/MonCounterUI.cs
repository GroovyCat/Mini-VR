using UnityEngine;
using TMPro;

public class MonCounterUI : MonoBehaviour
{
    private int killCount; // kill 횟수
    private int spawnCount; // 스폰 횟수

    private TextMeshProUGUI textUI; // 텍스트 UI

    private void Awake()
    {
        textUI = GetComponent<TextMeshProUGUI>();
    }

    private void UpdateUI()
    {
        if (!enabled)
            return;

        textUI.text = $"Kill/Alive/Spawn\n{killCount}/{spawnCount - killCount}/{spawnCount}";
    }

    private void OnEnable()
    {
        killCount = 0; spawnCount = 0;
        UpdateUI();
    }

    public void OnSpawn() // 스폰 카운트 
    {
        spawnCount++;
        UpdateUI();
    }

    public void OnKill() // 킬 카운트
    {
        killCount++;
        UpdateUI();
    }
}
