using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
/// <summary>
/// Ui - Slider 컴포넌트가 있는 오브젝트에 이 클래스를 부착한다.(add)
/// </summary>
public class VolumContollor : MonoBehaviour
{
    

    public AudioMixer audioMixer;
    public Slider slider;

    public string mixerParameterName; // BGM, SFX 작성해주는 공간
    public float sliderMultySlider = 25; // -1 에서 0 사이의 슬라이더를 더 크게 줄이기 위한 함수


    private void Start()
    {
        slider.onValueChanged.AddListener(SliderValue);
        slider.minValue = 0.0000001f;
    }

    public void SliderValue(float value)
    {
        
        audioMixer.SetFloat(mixerParameterName, Mathf.Log10(value) * sliderMultySlider); //Log가 0이되면 무한이됨 ;;
    }

}


