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

    public void LoadCurrent(string name)//这个是按钮的名字
    {
        EventCenter.Instance.clear();//清空所有监听
        StartCoroutine(LoadCurrentScene(name));
    }

    IEnumerator LoadCurrentScene(string name)//加载name文件游戏
    {
        LoadScreen.SetActive(true);
        UIManager.Instance.panelDict.Clear();//将Panel字典里缓存的UI清空
        //在这就要读取存档里的信息了
        sceneName = playerData.LoadScene_Name(name);
        GameManager.Instance.GetFileName(sceneName);
        SetInit(sceneName);//加载存档的时候初始化设置

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
                //GameManager.Instance.GetFileName(name);
            }
            yield return null;
        }
    }

    IEnumerator LoadPrevious()//返回主菜单
    {
        LoadScreen.SetActive(true);
        SoundManager.Instance.StopBGM();
        SoundManager.Instance.PlayBGM(Globals.BGM_1);
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


    IEnumerator LoadLevel(string name)//开始指定游戏
    {
        LoadScreen.SetActive(true);
        GameManager.Instance.GetFileName(name);
        AsyncOperation OPR = SceneManager.LoadSceneAsync(name);
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

    public void SetInit(string name)
    {
        SoundManager.Instance.StopBGM();
        Debug.Log(name);
        GameManager.Instance.cellTable.DataList.Clear();
        if (name == "Scene_1")
        {
            GameManager.Instance.isCanEnter_1 = false;
            GameManager.Instance.isCanEnter_2 = false;
            SoundManager.Instance.PlayBGM(Globals.BGM_2);
        }
        else if (name == "Scene_3")
        {
            CellLocalData.Instance.addMood(7, "木珠子", "小孩子的玩具，可以用来做算盘的珠子", "Package/Mz");//改变赋值
            CellLocalData.Instance.addMood(9, "孙子算法", "鸡兔同笼术曰:上置头，下置足，半其足，以头除足，以足除头，即得", "Package/Book");
            GameManager.Instance.isCanEnter_1 = false;
            GameManager.Instance.isCanEnter_2 = true;
            SoundManager.Instance.PlayBGM(Globals.BGM_2);
        }
        else if (name == "Scene_4")
        {
            Debug.Log("场景五重置了");
            GameManager.Instance.isCanEnter_1 = false;
            GameManager.Instance.isCanEnter_2 = true;
            SoundManager.Instance.PlayBGM(Globals.BGM_2);
        }
        else if (name == "Scene_5")
        {
            Debug.Log("场景五重置了");
            GameManager.Instance.isCanEnter_1 = true;
            GameManager.Instance.isCanEnter_2 = false;
            SoundManager.Instance.PlayBGM(Globals.BGM_2);
        }
        else if(name == "Abacus")
        {
            GameManager.Instance.isCanEnter_1 = false;
            GameManager.Instance.isCanEnter_2 = false;
            SoundManager.Instance.PlayBGM(Globals.BGM_1);
        }
    }




    public void StartNewGame()
    {
        SoundManager.Instance.StopBGM();
        GameManager.Instance.cellTable.DataList.Clear();//开始游戏时清空
        LoadNextLevel("Scene_1");
        SoundManager.Instance.PlayBGM(Globals.BGM_2);
    }

}
