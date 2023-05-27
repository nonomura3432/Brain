using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
# nullable enable

public class KimotiSlider : MonoBehaviour
{
    [SerializeField] Slider kimotiSlideer;
    
    float _increaseKairaku = 5;
    float _increaseSutoresu = 5;
    float _increaseSutoresuByFrame = 0.0002f;

    float _kimoti;
    int _maxKimoti = 100;
    
    void Update()
    {
        _kimoti -= _increaseSutoresuByFrame;
        kimotiSlideer.value =  _kimoti / _maxKimoti;
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
}
