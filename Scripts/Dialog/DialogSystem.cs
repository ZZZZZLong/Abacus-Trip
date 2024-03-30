using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("UI组件")]
    public Text textLabel;
    public Image faceImage;
    public float textSpeed;

    bool textFinished;
    bool cancelTyping;
    bool isDes;


    [Header("文本文件")]
    public TextAsset textFile;
    public TextAsset textFile_1;
    public TextAsset textFile_2;
    public TextAsset textFile_3;
    public TextAsset textFile_4;

    public int index;

    [Header("头像")]
    public Sprite face01, face02, face03;
    public GameObject NPC_name;//与之对话的NPC名字
    public GameObject OtherNpc;

    List<string> textList = new List<string>();

    private void Awake()
    {
        textFile = textFile_1;//初始化
        //设置事件 当触发后切换文本，主要针对剧情SwitchTextFile(textFile_2);带参数事件
        isDes = false;
    }
    private void Start()
    {
        Debug.Log("开始监听");
        if (NPC_name.name == "NPC1")
        {
            EventCenter.Instance.AddEventListener<string>("KeyDiaNPC1", SwitchKeyTextFile);
        }
        else if (NPC_name.name == "NPC2")
        {
            EventCenter.Instance.AddEventListener<string>("KeyDiaNPC2", SwitchKeyTextFile);
        }
        else if(NPC_name.name == "NPC3")
        {
            EventCenter.Instance.AddEventListener<string>("KeyDiaNPC3", SwitchKeyTextFile);
        }
        else if(NPC_name.name == "NPC4")
        {
            EventCenter.Instance.AddEventListener<string>("KeyDiaNPC4", SwitchKeyTextFile);
        }
    }
    private void OnEnable()
    {
        PlayerMove.ISMove = false;
        //EventCenter.Instance.AddEventListener<string>("KeyDia", SwitchKeyTextFile);
        GetTextFormFile(textFile);
        textFinished = true;
        StartCoroutine(SetTextUI());
    }
    //private void ReMoveLs()
    //{
    //    Debug.Log("取消监听");
    //    EventCenter.Instance.RemoveEventListener<string>("KeyDia", SwitchKeyTextFile);
    //}

    void SwitchNextTextFile()
    {
        if(textFile_3 != null)
        {
            textFile = textFile_3;
        }
        //Debug.Log("切换对话为下一个普通对话");
    }

    void SwitchKeyTextFile(string Name)
    {
        if (NPC_name.name == Name)//在这添加需要改变对话的npcname
        {
            Debug.Log("有推车了");
            textFile = textFile_2;
            textFile_3 = textFile_4;//特殊对话之后切换另一个普通对话文本
        }
        if(NPC_name.name == "NPC2")
        {
            Debug.Log("NPC2的对话切换了");
        }
        
    }

    //void changeOtherNPCText(DialogSystem OtherDia, string Name)
    //{
    //    if(OtherDia != null)
    //    {
            
    //        if (OtherNpc.name == Name)//在这添加需要改变对话的npcname
    //        {
    //            OtherDia.textFile = OtherDia.textFile_2;
    //            Debug.Log(OtherDia);
    //            OtherDia.textFile_3 = OtherDia.textFile_4;//特殊对话之后切换另一个普通对话文本
    //        }
    //    }
    //}
    

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && index == textList.Count)
        {
            gameObject.SetActive(false);//脚本挂在panel上 当前挂在的对象消失= 文本框消失
            
            if(textFile_3 != null)
            {
                SwitchNextTextFile();
            }
            PlayerMove.ISMove = true;
            index = 0;
            if(isDes == true)
            {
                Destroy(NPC_name);//不需要的npc隐藏
            }
            return;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(textFinished && !cancelTyping)
            {
                StartCoroutine(SetTextUI());
            }
            else if (!textFinished && !cancelTyping)
            {
                cancelTyping = true;
            }
        }
    }


    void GetTextFormFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var lineDate = file.text.Split('\n');

        foreach (var line in lineDate)
        {
            textList.Add(line);
        }
    }

    IEnumerator SetTextUI()
    {
        textFinished = false;
        textLabel.text = "";

        switch (textList[index].Trim())//实际存在一行中的是A和回车'\n'
        {
            case"A":
                faceImage.sprite = face01;
                index++;
                break;
            case"B":
                faceImage.sprite = face02;
                index++;
                break;
            case"C":
                faceImage.sprite = face03;
                index++;
                break;
            
            case"D":
                //ReMoveLs();
                PlayerMove.ISMove = true;
                Destroy(gameObject);
                index++;
                break;

            case "W":
                //ReMoveLs();
                CellLocalData.Instance.addMood(1, "木材", "烧火？还可以用来做什么呢？", "Package/Wood");
                index++;
                break;

            case"E":
                //ReMoveLs();
                isDes = true;
                CellLocalData.Instance.RemoveMood(4);
                CellLocalData.Instance.addMood(5, "未加工的木材", "完全没有处理的木材，去找木匠或许会有办法", "Package/Wood");
                EventCenter.Instance.EventTrigger("KeyDia"+OtherNpc.name, "NPC2");//NPC2的对话改变了
                index++;
                break;
            
            case"F":
                //ReMoveLs();//在每句话结尾清空事件监听
                Cam_1 cam = gameObject.transform.parent.GetComponent<Cam_1>();
                cam.isRight = false;
                isDes = true;
                index++;
                break;
            
            case"H":
               // ReMoveLs();
                CellLocalData.Instance.RemoveMood(3);//失去水
                index++;
                break;

            case "S":
                //ReMoveLs();
                CellLocalData.Instance.RemoveMood(5);//失去未加工的木材
                index++;
                break;

        }


        //for (int i = 0; i < textList[index].Length; i++)
        //{
        //    textLabel.text += textList[index][i];

        //    yield return new WaitForSeconds(textSpeed);
        //}
        //textFinished = true;

        int letter = 0;
        while(!cancelTyping && letter < textList[index].Length - 1)
        {
            textLabel.text += textList[index][letter];
            letter++;
            yield return new WaitForSeconds(textSpeed);
        }
        textLabel.text = textList[index];
        cancelTyping = false;
        textFinished = true;
        index++;
    }

}
