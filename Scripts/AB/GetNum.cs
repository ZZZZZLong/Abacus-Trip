using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNum : MonoBehaviour
{
    int i;
    public float total;
    GameObject ObjImages;
    GameObject ObjTopImages;
    GameObject ObjButtomImages;
    GameObject ObjImage;
    public GameObject Dang;

    private void Start()
    {
        //��Ӽ�����
        ObjTopImages = transform.GetChild(0).gameObject;
        ObjButtomImages = transform.GetChild(1).gameObject;
    }


    public void OnButton()
    {
        i = int.Parse(Dang.transform.GetChild(0).gameObject.name);
        Debug.Log(i);
        GetSum(i);
    }

    void GetSum(int j)
    {
        total = 0;
        for (i = j; i < 9; i++)//����֮��i+1,9Ϊ9������
        {
            float atotal = int.Parse(GetObjName(i, ObjButtomImages)) + (int.Parse(GetObjName(i, ObjTopImages))) * 5;//����+����*5������һ��λ����ֵ
            double power = Math.Pow(10, i - j);
            atotal *= (float)power;
            total += atotal;
        }//��λ����

        for (i = j; i > 0; i--)
        {
            Debug.Log("ѭ��");
            float atotal2 = int.Parse(GetObjName(i - 1, ObjButtomImages)) + (int.Parse(GetObjName(i - 1, ObjTopImages)) * 5); // ����+����*5������һ��λ����ֵ
            double power = Math.Pow(10, i - j - 1); // С�����ֵ�Ȩ��Ϊ 10 �ĸ� i �η�
            atotal2 *= (float)power; // С�����ֵ�ֵ
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
        }//�õ������������
        return ObjImage.name;
    }
}
