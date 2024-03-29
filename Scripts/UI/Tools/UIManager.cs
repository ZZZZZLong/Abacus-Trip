using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    private Transform _uiRoot;

    private Dictionary<string, string> pathDict;
    //����Ԥ�Ƽ�
    private Dictionary<string, GameObject> prefabDict;
    //һ�򿪽���Ļ����ֵ�
    public  Dictionary<string, BasePanel> panelDict;

    public int sortingOrder = 0; 

    public Transform UIRoot
    {
        get
        {
            if (_uiRoot == null)
            {
                if (GameObject.Find("Canvas"))
                {
                    _uiRoot = GameObject.Find("Canvas").transform;
                }
                else
                {
                    _uiRoot = new GameObject("Canvas").transform;
                }
            };
            return _uiRoot;
        }
    }


    public UIManager()
    {
        InitDicts();
    }

    public BasePanel GetPanel(string name)
    {
        BasePanel panel = null;
        // ����Ƿ��Ѵ�
        if (panelDict.TryGetValue(name, out panel))
        {
            return panel;
        }
        return null;
    }


    //�򿪽���
    public BasePanel OpenPanel(string name)
    {
        BasePanel panel = null;
        //����Ƿ��Ѿ���
        if (panelDict.TryGetValue(name, out panel))
        {
            Debug.Log("�����Ѵ�: " + name);
            return null;
        }
        //���·���Ƿ�������
        string path = "";
        if(!pathDict.TryGetValue(name, out path))
        {
            Debug.Log("�����������󣬻�δ����·���� " + name);
            return null;
        }

        //ʹ�û����Ԥ�Ƽ�
        GameObject panelPrefab = null;
        if (!prefabDict.TryGetValue(name, out panelPrefab))
        {
            string realpath = "Prefabs/" + path;
            panelPrefab = Resources.Load<GameObject>(realpath) as GameObject;
            prefabDict.Add(name, panelPrefab);
        }

        //�򿪽���
        GameObject panelObject = GameObject.Instantiate(panelPrefab , UIRoot ,false);
        panel = panelObject.GetComponent<BasePanel>();
        panelDict.Add(name, panel);
        Debug.Log(name);
        panel.OpenPanel(name);
        Canvas panelCavas = panelObject.GetComponent<Canvas>();
        panelCavas.sortingOrder = sortingOrder;
        sortingOrder += 1;
        
        return panel;

    }
    //�رս���
    public bool ClosePanel(string name)
    {
        BasePanel panel = null;
        if (!panelDict.TryGetValue(name,out panel))
        {
            Debug.Log("����δ�򿪣�" + name);
            return false;
        }
        panel.ClosePanel();
        
        return true;
    }

   
    public void InitDicts()
    {
        prefabDict = new Dictionary<string, GameObject>();
        panelDict = new Dictionary<string, BasePanel>();
        
        pathDict = new Dictionary<string, string>()
        {
            //��Ҫ�µ�UI���������
            {UIConst.PackageCon,"UI/PackageContent" },
            {UIConst.Setting,"UI/Setting" },
            {UIConst.Baocun,"UI/Baocun" },
            {UIConst.Duqu,"UI/Duqu" },
            {UIConst.MakeUI,"UI/MakeUI" },
            {UIConst.NewMood,"UI/NewMood" }
        };
    }
}

public class UIConst
{
    //������洢����ui��������ƣ���ͬ�Ľ��棩 Ŀǰ��Ҫ��ʼ���� �Ͳ˵�����ͣ������ �ͱ����������� ����·���� 
    public const string PackageCon = "PackageContent";
    public const string Setting = "Setting";
    public const string Baocun = "Baocun";
    public const string Duqu = "Duqu";
    public const string MakeUI = "MakeUI";
    public const string NewMood = "NewMood";
}
