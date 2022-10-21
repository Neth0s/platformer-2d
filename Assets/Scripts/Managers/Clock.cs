using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    public float LevelClock { get; private set; } = 0;
    private bool levelEnded = false;

    TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (!levelEnded)
        {
            LevelClock += Time.deltaTime;
            text.text = LevelClock.ToString("00.00");
        }
    }

    public void EndLevel()
    {
        levelEnded = true;
    }
}
