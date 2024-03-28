using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class GameManager : Singleton_Mono<GameManager>
{
    public static PlayerData playerData;
    public CellTable cellTable;
    public int MakeCell_Index;
    public GameObject Player;
    public string FileName;
    private void Awake()
    {
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
    }

    //Set����������������Ϸ��ʱ������,���ؽ���Ϸ��ʱ���ȡ

    public void InitLoad(string name)
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerData = GameObject.Find("Player").GetComponent<PlayerData>();
        //cellTable.DataList.Clear();//�������
        playerData.Load(name);//�����˺�CellTable�����¸�ֵ��
        FileName = null;
    }

}
