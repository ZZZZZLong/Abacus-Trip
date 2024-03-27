using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton_Mono<SoundManager>
{
    private AudioSource audioSource;

    private Dictionary<string, AudioClip> dictAudio;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        dictAudio = new Dictionary<string, AudioClip>();
    }


    //加载音频 需要确保音频文件的路径在Resource文件夹内
    public AudioClip LoadAudio(string path)
    {
        return(AudioClip)Resources.Load(path);
    }

    //获取音频 将其缓存在dictAudio中 避免重复加载
    private AudioClip GetAidio(string path)
    {
        if(!dictAudio.ContainsKey(path))
        {
            dictAudio[path] = LoadAudio(path);
        }
        return dictAudio[path];
    }

    public void PlayBGM(string name, float volume = 1.0f)
    {
        audioSource.Stop();
        audioSource.clip = GetAidio(name); 
        audioSource.Play();
    }

    public void StopBGM()
    {
        audioSource.Stop();
    }

    public void PlaySound(string path, float volume = 1.0f)
    {
        //PlayOneShot函数会使得音频叠加播放
        this.audioSource.PlayOneShot(GetAidio(path), volume);
    }

    public void PlaySound(AudioSource audioSource, string path, float volume = 1.0f)
    {
        audioSource.PlayOneShot(GetAidio(path), volume);
    }







}
