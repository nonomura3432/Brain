using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    [SerializeField] Text _waveText;
    public int waveCount;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        IncrementCount();

    }

    public void IncrementCount()
    {
        waveCount++;
        if (waveCount ==4)
        {
            Reset();
        }
        _waveText.text = $"Wave {waveCount}";
    }

    public void Reset()
    {
        waveCount = 1;
        _waveText.text = $"Wave {waveCount}";
    }
    
}
