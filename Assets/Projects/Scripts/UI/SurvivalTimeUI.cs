using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SurvivalTimeUI : MonoBehaviour
{
    private float startTime;

    private TextMeshProUGUI textUI;

    private void Awake()
    {
        textUI = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        float currentTime = Time.time - startTime;
        if (!enabled)
            return;

        textUI.text = $"Survival Time\n{currentTime:0.0}s";
    }

}
