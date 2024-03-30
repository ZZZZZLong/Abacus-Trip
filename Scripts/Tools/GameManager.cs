using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class GameManager : Singleton_Mono<GameManager>
{
    public static PlayerData playerData;
    public CellTable cellTable;
    public CellTable cellTable_Scene1;
    public CellTable cellTable_Scene2;
    public CellTable cellTable_Scene3;
    public int MakeCell_Index;
    public GameObject Player;
    public string FileName;
    public bool isCanEnter;

    private void Awake()
    {
        isCanEnter = false;
        MakeCell_Index = 0;
        GetPack();
    }

    public void GetFileName(string Name)
    {
        FileName = Name;
    }

    public void GetPlayer()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void GetPack()
    {
        cellTable = Resources.Load<CellTable>("Package/CellTable");
        cellTable_Scene1 = Resources.Load<CellTable>("Package/cellTable_Scene1");
        cellTable_Scene2 = Resources.Load<CellTable>("Package/cellTable_Scene2");
        cellTable_Scene3 = Resources.Load<CellTable>("Package/cellTable_Scene3");
    }

    //Set背包函数，在新游戏的时候清零,加载进游戏的时候读取

    public void InitLoad(string name)
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerData = GameObject.Find("Player").GetComponent<PlayerData>();
        //cellTable.DataList.Clear();//清空数据
        Debug.Log(playerData);
        playerData.Load(name);//加载了后CellTable就重新赋值了
        FileName = null;
    }

    //如果要写定制化的初始化内容 在这里添加InitNewGame函数load一个New.sav存档

}
