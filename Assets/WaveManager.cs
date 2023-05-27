using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    [SerializeField] Text _waveText;
    int _waveCount;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        IncrementCount();

    }

    public void IncrementCount()
    {
        _waveCount++;
        if (_waveCount ==4)
        {
            Reset();
        }
        _waveText.text = $"Wave {_waveCount}";
    }

     void Reset()
    {
        _waveCount = 1;
    }
    
}
