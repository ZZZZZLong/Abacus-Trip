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
    //差背包
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

    IEnumerator LoadCurrentScene(string name)//加载name文件游戏
    {
        LoadScreen.SetActive(true);
        UIManager.Instance.panelDict.Clear();//将Panel字典里缓存的UI清空
        AsyncOperation OPR = SceneManager.LoadSceneAsync("SampleScene");
        OPR.allowSceneActivation = false;
        
        
        GameManager.Instance.SetPlayerPos(name);
        GameManager.Instance.InitPackage(name);
        //Set背包在GameManager设置函数
        
        
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

    IEnumerator LoadPrevious()//返回主菜单
    {
        GameManager.playerPosition = new Vector2(1.5f, 0);
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
        
        AsyncOperation OPR = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        OPR.allowSceneActivation = false;
        GameManager.Instance.cellTable.DataList.Clear();//开始新游戏时清空

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
