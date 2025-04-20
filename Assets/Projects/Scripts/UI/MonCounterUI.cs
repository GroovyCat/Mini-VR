using UnityEngine;
using TMPro;

public class MonCounterUI : MonoBehaviour
{
    private int killCount; // kill Ƚ��
    private int spawnCount; // ���� Ƚ��

    private TextMeshProUGUI textUI; // �ؽ�Ʈ UI

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

    public void OnSpawn() // ���� ī��Ʈ 
    {
        spawnCount++;
        UpdateUI();
    }

    public void OnKill() // ų ī��Ʈ
    {
        killCount++;
        UpdateUI();
    }
}
