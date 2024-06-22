using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;    //싱글톤

    public AudioSource[] sfx;
    public AudioSource[] bgm;
    public int SFXIndex = 0;
    public int bgmIndex =0;

    private void Awake()    //싱글톤
    {
        if(instance == null)
            instance = this;
    }

    public void PlayBGM(int bgmIndex)   //Bgm인덱스에 해당하는 BMG을 실행하는 함수
    {
        
        bgm[bgmIndex].Play();
    }

    public void PlaySFX(int sfxIndex)
    {
        if(sfxIndex < sfx.Length) // sfx.Length 큰 수를 받으면 에러가 난다.
        {

            sfx[sfxIndex].pitch = Random.Range(0.85f, 1.15f);
            sfx[sfxIndex].Play();
            Debug.Log($"{sfx[sfxIndex].name}출력됨");
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

    public void StopBGM()// 비지엠 멈추는 함수
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
