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
        //player��ʼ����ΪʲôҪ�������飬��Ϊһ��������Ϸһ���Ǽ�����Ϸ 
    }

    public void SetPlayerPos(string name)//���ô浵��������
    {
        playerData = GameObject.Find("Player").transform.GetChild(0).GetComponent<PlayerData>();
        playerData.Load(name);
        playerPosition = playerData.Position;
    }

    //Set����������������Ϸ��ʱ������,���ؽ���Ϸ��ʱ���ȡ

    public void InitPackage(string name)
    {
        cellTable.DataList.Clear();//�������
        playerData.Load(name);//�����˺�CellTable�����¸�ֵ��
    }

}
