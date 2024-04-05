using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartAudioUI : MonoBehaviour
{
    public AudioSource BGM;
    public Slider Vslider;
    public GameObject panel;

    private void Start()
    {
        BGM = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        Vslider.value = SoundManager.Vnum;
    }
    private void Update()
    {
        BGM.volume = Vslider.value;
        SoundManager.Vnum = BGM.volume;
    }
    public void OpenAudioUI()
    {
        panel.SetActive(true);
    }

    public void CloseAudio()
    {
        panel.SetActive(false);
    }

}

