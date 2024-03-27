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
        //PlayOneShot������ʹ����Ƶ���Ӳ���
        this.audioSource.PlayOneShot(GetAidio(path), volume);
    }

    public void PlaySound(AudioSource audioSource, string path, float volume = 1.0f)
    {
        audioSource.PlayOneShot(GetAidio(path), volume);
    }







}
