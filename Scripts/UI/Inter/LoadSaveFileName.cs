using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LoadSaveFileName : MonoBehaviour
{
    private SaveData saveData; // ���� SaveData ���͵ı���
    GameObject Save_Name;
    public List<GameObject> Btn_List = new List<GameObject>();
    GameObject isEmpty;
    GameObject Empty;
    Text Time;
    Text Date;
    private void Awake()
    {
        saveData = new SaveData(); // ���� SaveData ��ʵ��
        // ��������Է��� saveData����������в���
        Init();
    }
    void FindChild(GameObject child)
    {
        //����forѭ�� ��ȡ�����µ�ȫ��������
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
                Empty.SetActive(false);//��ʾ�浵��¼
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
                // �����������
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
