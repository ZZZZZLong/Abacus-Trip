using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace SaveSystemTutorial
{
    public class SaveUI : MonoBehaviour
    {
        [Header("-- Texts --")]
        [SerializeField] Text Time;
        [SerializeField] Text Data;

        PlayerData playerData;
        LoadManager loadManager;

        public Transform Btn;
        public Button Sbtn1;
        public Button Sbtn2;
        private Button Gbtn;

        void Awake()
        {
            EventCenter.Instance.AddEventListener<Button>("GetSave", GetSave);
            EventCenter.Instance.AddEventListener<Button>("GetButton", GetButton);
            if (Sbtn1 != null)
                Sbtn1.onClick.AddListener(() => OverSaveBtn());
            if (Sbtn2 != null)
                Sbtn2.onClick.AddListener(() => LoadBtn());
        }
        void GetButton(Button GBtn)
        {
            Gbtn = GBtn;
        }

        void GetSave(Button GBtn)
        {
            Save_BtnName(GBtn.name);//保存存档在文件夹里
            Gbtn = GBtn;
            ReadSave();
        }
        void ReadSave()//读取在文件夹里的存档//为CellTable赋值参考Woodadd
        {
            GameObject isEmpty = Gbtn.transform.GetChild(0).gameObject;
            GameObject Empty = Gbtn.transform.GetChild(1).gameObject;
            Text Time = isEmpty.transform.Find("Time").GetComponent<Text>();
            Text Date = isEmpty.transform.Find("Date").GetComponent<Text>();
            DateTime currentTime = DateTime.Now;

            Time.text = currentTime.ToString("HH:mm:ss");
            Date.text = currentTime.ToString("yyyy/MM/dd");

            isEmpty.SetActive(true);
            Empty.SetActive(false);//显示存档记录
        }
        

        public void Save_BtnName(string Btn)
        {
            playerData = GameObject.Find("Player").transform.GetChild(0).GetComponent<PlayerData>();
            playerData.Save(Btn);
        }

        public void OverSaveBtn()//覆盖存档
        {
            if (Gbtn != null)
            {
                QDBC.OverQDBC(Gbtn);//调用函数
            }
        }
        public void LoadBtn()
        {
            if (Gbtn != null)
            {
                loadManager = GameObject.Find("LoadManager").transform.GetComponent<LoadManager>();
                loadManager.LoadCurrent(Gbtn.name);//传按钮不用管了
            }
        }

        
    }
}
