using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAudioManager : MonoBehaviour
{
    public AudioSource[] sfx;
    public AudioSource[] bgm;
    public int SFXIndex = 0;

    public void PlayBGM(int bgmIndex)
    {
        bgm[bgmIndex].Play();
    }

    public void PlaySFX(int sfxIndex)
    {
        sfx[sfxIndex].Play();
    }

    private void Start()
    {
        //PlayBGM(1);
    }


    public void PlayRandomSfx()
    {
        StopSFX();
        int randomIndex = Random.Range(0, bgm.Length);
        PlaySFX(randomIndex);

    }

    public void StopSFX()
    {
        for (int i = 0; i < sfx.Length; i++)
        {
            sfx[i].Stop();
        }
        
    }

    private void Update()
    {
        
    }
}
