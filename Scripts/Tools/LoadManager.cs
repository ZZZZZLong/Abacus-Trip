using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadManager : Singleton_Mono<LoadManager>
{
    public GameObject LoadScreen;
    public Slider slider;
    PlayerData playerData;
    //���
    private void Awake()
    {
        
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
    }

    public void BackPrevious()
    {
        StartCoroutine(LoadPrevious());
    }

    public void LoadCurrent(string name)
    {
        StartCoroutine(LoadCurrentScene(name));
    }

    IEnumerator LoadCurrentScene(string name)//����name�ļ���Ϸ
    {
        LoadScreen.SetActive(true);
        UIManager.Instance.panelDict.Clear();//��Panel�ֵ��ﻺ���UI���
        AsyncOperation OPR = SceneManager.LoadSceneAsync("SampleScene");
        OPR.allowSceneActivation = false;
        
        
        GameManager.Instance.SetPlayerPos(name);
        GameManager.Instance.InitPackage(name);
        //Set������GameManager���ú���
        
        
        while (!OPR.isDone)
        {
            slider.value = OPR.progress;
            PlayerMove.ISMove = true;//��ֹISmove����ΪTrue
            if (OPR.progress >= 0.9f)
            {
                slider.value = 1;
                OPR.allowSceneActivation = true;
            }
            yield return null;
        }
    }

    IEnumerator LoadPrevious()//�������˵�
    {
        GameManager.playerPosition = new Vector2(1.5f, 0);
        LoadScreen.SetActive(true);
        UIManager.Instance.panelDict.Clear();//��Panel�ֵ��ﻺ���UI���
        AsyncOperation OPR = SceneManager.LoadSceneAsync("Start");

        OPR.allowSceneActivation = false;

        while (!OPR.isDone)
        {
            slider.value = OPR.progress;
            PlayerMove.ISMove = true;//��ֹISmove����ΪTrue
            if (OPR.progress >= 0.9f)
            {
                slider.value = 1;
                OPR.allowSceneActivation = true;
            }
            yield return null;
        }
    }


    IEnumerator LoadLevel()//��ʼ����Ϸ
    {
        LoadScreen.SetActive(true);
        
        AsyncOperation OPR = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        OPR.allowSceneActivation = false;
        GameManager.Instance.cellTable.DataList.Clear();//��ʼ����Ϸʱ���

        while (!OPR.isDone)
        {
            slider.value = OPR.progress;
            if(OPR.progress >= 0.9f)
            {
                slider.value = 1;
                OPR.allowSceneActivation = true;
            }
            yield return null;
        }

    }

}
