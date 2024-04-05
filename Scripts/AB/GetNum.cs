using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GetNum : MonoBehaviour
{
    int i;
    public double total;
    GameObject ObjImages;
    GameObject ObjTopImages;
    GameObject ObjButtomImages;
    GameObject ObjImage;
    public GameObject Dang;

    private void Start()
    {
        //添加监听器
        ObjTopImages = transform.GetChild(0).gameObject;
        ObjButtomImages = transform.GetChild(1).gameObject;
    }


    public void OnButton()
    {
        for (int j = 0; j < Dang.transform.childCount; j++)
        {
            GameObject childTransform = Dang.transform.GetChild(j).gameObject;
            Color imageColor = childTransform.GetComponent<Image>().color;
            if (imageColor.a == 1f)
            {
                i = int.Parse(Dang.transform.GetChild(j).gameObject.name);
            }
        }

        GetSum(i);
        EventCenter.Instance.EventTrigger("TiJiaoDaAn");
    }

    void GetSum(int j)
    {
        total = 0;
        for (i = j; i < 9; i++)//结束之后i+1,9为9排珠子
        {
            double atotal = int.Parse(GetObjName(i, ObjButtomImages)) + (int.Parse(GetObjName(i, ObjTopImages))) * 5;//下珠+上珠*5等于这一个位数的值
            double power = Math.Pow(10, i - j);
            atotal *= (double)power;
            total += atotal;
        }//个位以上

        for (i = j; i > 0; i--)
        {
            Debug.Log("循环");
            double atotal2 = int.Parse(GetObjName(i - 1, ObjButtomImages)) + (int.Parse(GetObjName(i - 1, ObjTopImages)) * 5); // 下珠+上珠*5等于这一个位数的值
            double power = Math.Pow(10, i - j - 1); // 小数部分的权重为 10 的负 i 次方
            atotal2 *= (double)power; // 小数部分的值
            total += atotal2;
        }
    }
    string GetObjName(int j, GameObject Obj)
    {
        ObjImages = Obj.transform.GetChild(j).gameObject;


        for (int m = 0; m <= ObjImages.transform.childCount - 1; m++)
        {
            GameObject childObj = ObjImages.transform.GetChild(m).gameObject;
            if (childObj.activeSelf)
            {
                ObjImage = childObj;
            }
        }//得到激活的子物体
        return ObjImage.name;
    }
}
