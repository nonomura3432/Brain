using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
# nullable enable

public class KimotiSlider : MonoBehaviour
{
    [SerializeField] Slider kimotiSlideer;

    readonly float _increaseKairaku = 5;
    readonly float _increaseSutoresu = 30;
    readonly float _increaseSutoresuByFrame = 0.0002f;

    readonly float _deadLine = 10;

    float _kimoti;
    int _maxKimoti = 100;

    void Start()
    {
        _kimoti = _maxKimoti / 2;
    }

    void Update()
    {
        _kimoti -= _increaseSutoresuByFrame;
        kimotiSlideer.value =  _kimoti / _maxKimoti;
        if(_kimoti <= _deadLine)
        {
            OnDead();
        }
    }

    public void HitKairaku()
    {
        _kimoti += _increaseKairaku;
        kimotiSlideer.value =  _kimoti / _maxKimoti;
    }

    public void HitSutoresu()
    {
        _kimoti -= _increaseSutoresu;
        kimotiSlideer.value = _kimoti / _maxKimoti;
    }

    void OnDead()
    {
        Debug.Log($"ゲームオーバー");
    }
}
