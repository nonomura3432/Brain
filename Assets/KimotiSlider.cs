using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
# nullable enable

public class KimotiSlider : MonoBehaviour
{
    [SerializeField] Slider kimotiSlideer;
    GameDirector gameDirector;

    readonly float _increaseKairaku = 5;
    readonly float _increaseSutoresu = 30;
    readonly float _increaseSutoresuByFrame = 0.0025f;

    readonly float _deadLine = 10;

    float _kimoti;
    int _maxKimoti = 100;

    void Start()
    {
        gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        _kimoti = _maxKimoti / 2;
    }

    void Update()
    {
        if (gameDirector.isShowStory) return;
        _kimoti -= _increaseSutoresuByFrame;
        kimotiSlideer.value =  _kimoti / _maxKimoti;
        if(_kimoti <= _deadLine)
        {
            OnDead();
            gameDirector.GameOver();
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
