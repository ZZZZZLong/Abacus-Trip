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
    //差背包
    private void Awake()
    {
        GameManager.Instance.GetPlayer();//使任何场景都需要一个Data来存数据
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

    IEnumerator LoadCurrentScene(string name)//加载name文件游戏
    {
        LoadScreen.SetActive(true);
        UIManager.Instance.panelDict.Clear();//将Panel字典里缓存的UI清空
        //在这就要读取存档里的信息了
        sceneName = playerData.LoadScene_Name(name);
        Debug.Log(sceneName);
        AsyncOperation OPR = SceneManager.LoadSceneAsync(sceneName);// 在json里面存入场景名字，加载的时候看存档中场景名字加载场景
        OPR.allowSceneActivation = false;

        while (!OPR.isDone)
        {
            slider.value = OPR.progress;
            PlayerMove.ISMove = true;//防止ISmove不能为True
            if (OPR.progress >= 0.9f)
            {
                slider.value = 1;
                OPR.allowSceneActivation = true;
                GameManager.Instance.GetFileName(name);
            }
            yield return null;
        }
    }

    IEnumerator LoadPrevious()//返回主菜单
    {
        LoadScreen.SetActive(true);
        UIManager.Instance.panelDict.Clear();//将Panel字典里缓存的UI清空
        AsyncOperation OPR = SceneManager.LoadSceneAsync("Start");

        OPR.allowSceneActivation = false;

        while (!OPR.isDone)
        {
            slider.value = OPR.progress;
            PlayerMove.ISMove = true;//防止ISmove不能为True
            if (OPR.progress >= 0.9f)
            {
                slider.value = 1;
                OPR.allowSceneActivation = true;
            }
            yield return null;
        }
    }


    IEnumerator LoadLevel()//开始新游戏
    {
        LoadScreen.SetActive(true);
        
        AsyncOperation OPR = SceneManager.LoadSceneAsync("SampleScene");

        OPR.allowSceneActivation = false;
        GameManager.Instance.cellTable.DataList.Clear();//开始新游戏时清空
        //在这里添加初始需要的物品 目前没有
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
