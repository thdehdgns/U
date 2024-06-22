using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;    //�̱���

    public AudioSource[] sfx;
    public AudioSource[] bgm;
    public int SFXIndex = 0;
    public int bgmIndex =0;

    private void Awake()    //�̱���
    {
        if(instance == null)
            instance = this;
    }

    public void PlayBGM(int bgmIndex)   //Bgm�ε����� �ش��ϴ� BMG�� �����ϴ� �Լ�
    {
        
        bgm[bgmIndex].Play();
    }

    public void PlaySFX(int sfxIndex)
    {
        if(sfxIndex < sfx.Length) // sfx.Length ū ���� ������ ������ ����.
        {

            sfx[sfxIndex].pitch = Random.Range(0.85f, 1.15f);
            sfx[sfxIndex].Play();
            Debug.Log($"{sfx[sfxIndex].name}��µ�");
        }
    }

    private void Start()
    {
        //PlayRandomBgm();
        //PlayBGM(bgmIndex);
    }

    private void Update()
    {
        
    }

    public void StopBGM()// ������ ���ߴ� �Լ�
    {
        for(int i = 0; i < bgm.Length; i++)
        {
            bgm[i].Stop();
        }
    }

    public void PlayRandomSfx()
    {
        StopSFX();
        int randomIndex = Random.Range(0, sfx.Length);
        PlaySFX(randomIndex);

    }

    public void StopSFX()
    {
        for (int i = 0; i < sfx.Length; i++)
        {
            sfx[i].Stop();
        }

    }


    public void PlayRandomBgm()
    {
        StopBGM();
        int randomIndex = Random.Range(0, bgm.Length);
        PlayBGM(randomIndex);

    }

    

}
