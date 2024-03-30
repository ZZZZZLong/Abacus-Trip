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
    public void LoadNextLevel(string name)
    {
        EventCenter.Instance.clear();
        StartCoroutine(LoadLevel(name));
    }

    public void BackPrevious()
    {
        EventCenter.Instance.clear();
        StartCoroutine(LoadPrevious());
    }

    public void LoadCurrent(string name)
    {
        EventCenter.Instance.clear();//������м���
        StartCoroutine(LoadCurrentScene(name));
    }

    IEnumerator LoadCurrentScene(string name)//����name�ļ���Ϸ
    {
        LoadScreen.SetActive(true);
        UIManager.Instance.panelDict.Clear();//��Panel�ֵ��ﻺ���UI���
        //�����Ҫ��ȡ�浵�����Ϣ��
        sceneName = playerData.LoadScene_Name(name);
        GameManager.Instance.GetFileName(sceneName);

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
                //GameManager.Instance.GetFileName(name);
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


    IEnumerator LoadLevel(string name)//��ʼ����Ϸ
    {
        LoadScreen.SetActive(true);
        GameManager.Instance.GetFileName(name);
        AsyncOperation OPR = SceneManager.LoadSceneAsync(name);
        OPR.allowSceneActivation = false;
        GameManager.Instance.cellTable.DataList.Clear();//��ʼ����Ϸʱ���
        //��������ӳ�ʼ��Ҫ����Ʒ Ŀǰû��
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


    public void StartNewGame()
    {
        LoadNextLevel("Scene_1");
    }

}
