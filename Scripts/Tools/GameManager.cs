using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class GameManager : Singleton_Mono<GameManager>
{
    static PlayerData playerData;
    public static Vector2 playerPosition = new Vector2(1.5f,0);
    public CellTable cellTable;
    public int MakeCell_Index;

    private void Awake()
    {
        MakeCell_Index = 0;
        cellTable = Resources.Load<CellTable>("Package/CellTable");
        
        PlayerInit();
    }
    void PlayerInit()
    {
        playerData = GameObject.Find("Player").transform.GetChild(0).GetComponent<PlayerData>();
        playerData.transform.position = playerPosition;
        //player初始化，为什么要设置两遍，因为一个是新游戏一个是加载游戏 
    }

    public void SetPlayerPos(string name)//设置存档数据内容
    {
        playerData = GameObject.Find("Player").transform.GetChild(0).GetComponent<PlayerData>();
        playerData.Load(name);
        playerPosition = playerData.Position;
    }

    //Set背包函数，在新游戏的时候清零,加载进游戏的时候读取

    public void InitPackage(string name)
    {
        cellTable.DataList.Clear();//清空数据
        playerData.Load(name);//加载了后CellTable就重新赋值了
    }

}
