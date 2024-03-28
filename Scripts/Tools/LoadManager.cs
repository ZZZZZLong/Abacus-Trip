using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadManager : Singleton_Mono<LoadManager>
{
    public GameObject LoadScreen;
    public Slider slider;
    public string sceneName;
    PlayerData playerData;
    //���
    private void Awake()
    {
        GameManager.Instance.GetPlayer();//ʹ�κγ�������Ҫһ��Data��������
        playerData = GameObject.Find("Player").GetComponent<PlayerData>();

    }
    public void LoadNextLevel()
    {
        EventCenter.Instance.clear();
        StartCoroutine(LoadLevel());
    }

    public void BackPrevious()
    {
        EventCenter.Instance.clear();
        StartCoroutine(LoadPrevious());
    }

    public void LoadCurrent(string name)
    {
        EventCenter.Instance.clear();
        StartCoroutine(LoadCurrentScene(name));
    }

    IEnumerator LoadCurrentScene(string name)//����name�ļ���Ϸ
    {
        LoadScreen.SetActive(true);
        UIManager.Instance.panelDict.Clear();//��Panel�ֵ��ﻺ���UI���
        //�����Ҫ��ȡ�浵�����Ϣ��
        sceneName = playerData.LoadScene_Name(name);
        Debug.Log(sceneName);
        AsyncOperation OPR = SceneManager.LoadSceneAsync(sceneName);// ��json������볡�����֣����ص�ʱ�򿴴浵�г������ּ��س���
        OPR.allowSceneActivation = false;

        while (!OPR.isDone)
        {
            slider.value = OPR.progress;
            PlayerMove.ISMove = true;//��ֹISmove����ΪTrue
            if (OPR.progress >= 0.9f)
            {
                slider.value = 1;
                OPR.allowSceneActivation = true;
                GameManager.Instance.GetFileName(name);
            }
            yield return null;
        }
    }

    IEnumerator LoadPrevious()//�������˵�
    {
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
        
        AsyncOperation OPR = SceneManager.LoadSceneAsync("SampleScene");

        OPR.allowSceneActivation = false;
        GameManager.Instance.cellTable.DataList.Clear();//��ʼ����Ϸʱ���
        //��������ӳ�ʼ��Ҫ����Ʒ Ŀǰû��
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
