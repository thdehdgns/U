using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
/// <summary>
/// Ui - Slider ������Ʈ�� �ִ� ������Ʈ�� �� Ŭ������ �����Ѵ�.(add)
/// </summary>
public class VolumContollor : MonoBehaviour
{
    

    public AudioMixer audioMixer;
    public Slider slider;

    public string mixerParameterName; // BGM, SFX �ۼ����ִ� ����
    public float sliderMultySlider = 25; // -1 ���� 0 ������ �����̴��� �� ũ�� ���̱� ���� �Լ�


    private void Start()
    {
        slider.onValueChanged.AddListener(SliderValue);
        slider.minValue = 0.0000001f;
    }

    public void SliderValue(float value)
    {
        
        audioMixer.SetFloat(mixerParameterName, Mathf.Log10(value) * sliderMultySlider); //Log�� 0�̵Ǹ� �����̵� ;;
    }

}


