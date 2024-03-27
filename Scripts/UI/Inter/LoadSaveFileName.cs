using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LoadSaveFileName : MonoBehaviour
{
    private SaveData saveData; // 声明 SaveData 类型的变量
    GameObject Save_Name;
    public List<GameObject> Btn_List = new List<GameObject>();
    GameObject isEmpty;
    GameObject Empty;
    Text Time;
    Text Date;
    private void Awake()
    {
        saveData = new SaveData(); // 创建 SaveData 的实例
        // 在这里可以访问 saveData，并对其进行操作
        Init();
    }
    void FindChild(GameObject child)
    {
        //利用for循环 获取物体下的全部子物体
        for (int i = 0; i < child.transform.childCount; i++)
        {
            Btn_List.Add(child.transform.GetChild(i).gameObject);
        }
    }

    void Init()
    {
        FindChild(this.gameObject);
        foreach (GameObject Btn in Btn_List)
        {
            Save_Name = Btn;
            isEmpty = Save_Name.transform.GetChild(0).gameObject;
            Empty = Save_Name.transform.GetChild(1).gameObject;
            Time = isEmpty.transform.Find("Time").GetComponent<Text>();
            Date = isEmpty.transform.Find("Date").GetComponent<Text>();
            GetBtnList(Save_Name.name);
            if (Btn_List != null)
            {
                isEmpty.SetActive(true);
                Empty.SetActive(false);//显示存档记录
            }
        }
    }

    void GetBtnList(string BtnName)
    {
        switch (BtnName)
        {
            case "Btn1":
                LoadFromJson("Btn1");
                break;
            case "Btn2":
                LoadFromJson("Btn2");
                break;
            case "Btn3":
                LoadFromJson("Btn3");
                break;
            default:
                // 处理其他情况
                Debug.Log("Unknown Save_Name: " + Save_Name);
                break;
        }
    }
    void LoadFromJson(string FileName)
    {
        var saveData = SaveSystem.LoadFromJson<SaveData>($"{FileName}.sav");
        LoadData(saveData);
    }

    void LoadData(SaveData saveData)
    {
        Time.text = saveData.Save_Time;
        Date.text = saveData.Save_Date;
    }


}
