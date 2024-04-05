using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton_Mono<SoundManager>
{
    private AudioSource audioSource;
    public static float Vnum;

    private Dictionary<string, AudioClip> dictAudio;

    private void Awake()
    {
        Vnum = 0.5f;
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
        dictAudio = new Dictionary<string, AudioClip>();
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    //������Ƶ ��Ҫȷ����Ƶ�ļ���·����Resource�ļ�����
    public AudioClip LoadAudio(string path)
    {
        return(AudioClip)Resources.Load(path);
    }

    //��ȡ��Ƶ ���仺����dictAudio�� �����ظ�����
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
        audioSource.volume = Vnum;
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
        audioSource.volume = Vnum;
        //PlayOneShot������ʹ����Ƶ���Ӳ���
        this.audioSource.PlayOneShot(GetAidio(path), volume);
    }

    public void PlaySound(AudioSource audioSource, string path, float volume = 1.0f)
    {
        audioSource.volume = Vnum;
        audioSource.PlayOneShot(GetAidio(path), volume);
    }

    public void PlayLoopSound(string path, float volume = 1.0f)
    {
        audioSource.loop = true;
        audioSource.volume = Vnum;
        //PlayOneShot������ʹ����Ƶ���Ӳ���
        this.audioSource.PlayOneShot(GetAidio(path), volume);
    }






}
