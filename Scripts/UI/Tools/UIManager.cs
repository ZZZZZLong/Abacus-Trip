using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    private Transform _uiRoot;

    private Dictionary<string, string> pathDict;
    //缓存预制件
    private Dictionary<string, GameObject> prefabDict;
    //一打开界面的缓存字典
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
        // 检查是否已打开
        if (panelDict.TryGetValue(name, out panel))
        {
            return panel;
        }
        return null;
    }


    //打开界面
    public BasePanel OpenPanel(string name)
    {
        BasePanel panel = null;
        //检查是否已经打开
        if (panelDict.TryGetValue(name, out panel))
        {
            Debug.Log("界面已打开: " + name);
            return null;
        }
        //检查路径是否有配置
        string path = "";
        if(!pathDict.TryGetValue(name, out path))
        {
            Debug.Log("界面名称有误，或未配置路径： " + name);
            return null;
        }

        //使用缓存的预制件
        GameObject panelPrefab = null;
        if (!prefabDict.TryGetValue(name, out panelPrefab))
        {
            string realpath = "Prefabs/" + path;
            panelPrefab = Resources.Load<GameObject>(realpath) as GameObject;
            prefabDict.Add(name, panelPrefab);
        }

        //打开界面
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
    //关闭界面
    public bool ClosePanel(string name)
    {
        BasePanel panel = null;
        if (!panelDict.TryGetValue(name,out panel))
        {
            Debug.Log("界面未打开：" + name);
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
            //需要新的UI就往里面加
            {UIConst.PackageCon,"UI/PackageContent" },
            {UIConst.Setting,"UI/Setting" },
            {UIConst.Baocun,"UI/Baocun" },
            {UIConst.Duqu,"UI/Duqu" },
            {UIConst.MakeUI,"UI/MakeUI" },
            {UIConst.NewMood,"UI/NewMood" },
            {UIConst.Block,"UI/Block" },
            {UIConst.Sure,"UI/Sure" },
            {UIConst.End_1,"UI/End_1" },
            {UIConst.Suc,"UI/Suc" },
            {UIConst.Book,"UI/Book" },
            {UIConst.Audio,"UI/Audio" },
            {UIConst.Tech,"UI/Tech" }
        };
    }
}

public class UIConst
{
    //在这里存储所有ui对象的名称（不同的界面） 目前需要开始界面 和菜单（暂停）界面 和背景基本界面 配置路径表 
    public const string PackageCon = "PackageContent";
    public const string Setting = "Setting";
    public const string Baocun = "Baocun";
    public const string Duqu = "Duqu";
    public const string MakeUI = "MakeUI";
    public const string NewMood = "NewMood";
    public const string Block = "Block";
    public const string Sure = "Sure";
    public const string End_1 = "End_1";
    public const string Suc = "Suc";
    public const string Book = "Book";
    public const string Audio = "Audio";
    public const string Tech = "Tech";

}
