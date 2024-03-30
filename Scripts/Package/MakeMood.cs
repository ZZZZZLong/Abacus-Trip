using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MakeMood : MonoBehaviour
{
    public GameObject MakeCell_1;
    public GameObject MakeCell_2;
    public GameObject MakeCell_New;
    public GameObject Error;
    public GameObject Success;
    public Button yourButton;
    

    int id_1;
    int id_2;

    private void Awake()
    {
        MakeCell_1.SetActive(true);
        MakeCell_2.SetActive(true);
        MakeCell_New.SetActive(false);
        yourButton.gameObject.SetActive(true);//隐藏按钮
    }

    public void MakeMoodBtn()
    {
        MakeMoodCell MC_1 = MakeCell_1.GetComponent<MakeMoodCell>();
        MakeMoodCell MC_2 = MakeCell_2.GetComponent<MakeMoodCell>();
        id_1 = MC_1.MoodId;
        id_2 = MC_2.MoodId;
        MakeMoodBtn_Way(id_1, id_2);
    }

    void MakeMoodBtn_Way(int x, int y)//合成列表
    {
        Debug.Log(x +" "+ y);
        if((x == 1 && y == 2) ||(x == 2 && y == 1))
        {
            CellLocalData.Instance.addMood(4, "推车", "交给村口农夫吧！", "Package/Car");
            Debug.Log("物品数量为：" + GameManager.Instance.cellTable.DataList.Count);
            ClearCellTable(x, y);

            SettingUI();//合成成功后设置UI信息

            Sprite woodSprite = Resources.Load<Sprite>("Package/Car");
            MakeCell_New.GetComponent<Image>().sprite = woodSprite;
            MakeCell_New.transform.Find("Title").GetComponent<Text>().text = "获得推车！";
        }
        else if((x == 6 && y == 7) || (x == 7 && y == 6))
        {
            CellLocalData.Instance.addMood(8, "算盘", "用它来解决问题吧！", "Package/AB-ICon");
            ClearCellTable(x, y);

            SettingUI();//合成成功后设置UI信息
            Sprite woodSprite = Resources.Load<Sprite>("Package/AB-ICon");
            MakeCell_New.GetComponent<Image>().sprite = woodSprite;
            MakeCell_New.transform.Find("Title").GetComponent<Text>().text = "获得算盘！";
            GameManager.Instance.isCanEnter_1 = true;
        }
        else
        {
            Error.SetActive(true);
        }
    }

    void SettingUI()
    {
        MakeCell_1.SetActive(false);
        MakeCell_2.SetActive(false);
        MakeCell_New.SetActive(true);
        yourButton.gameObject.SetActive(false);//隐藏按钮
        Success.SetActive(true);
    }




    void ClearCellTable(int x, int y)
    {
        //foreach (CellTableItem item in GameManager.Instance.cellTable.DataList)
        //{
        //    if (item.id == x || item.id == y)//每次循环查看id的信息
        //    {//如果符合条件就清空
        //        GameManager.Instance.cellTable.DataList.Remove(item);
        //        Debug.Log("ID: " + item.id);
        //    }
        //    // 在这里执行其他操作
        //}
        List<CellTableItem> itemsToRemove = new List<CellTableItem>();

        // 遍历并标记需要删除的元素
        foreach (CellTableItem item in GameManager.Instance.cellTable.DataList)
        {
            if (item.id == x || item.id == y)
            {
                itemsToRemove.Add(item);
                Debug.Log("ID: " + item.id);
            }
        }

        // 删除标记的元素
        foreach (CellTableItem itemToRemove in itemsToRemove)
        {
            GameManager.Instance.cellTable.DataList.Remove(itemToRemove);
        }
    }



}
