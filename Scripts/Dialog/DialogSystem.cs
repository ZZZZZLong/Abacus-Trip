using System.Collections;
using System.Collections.Generic;
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


    [Header("文本文件")]
    TextAsset textFile;
    public TextAsset textFile_1;
    public TextAsset textFile_2;
    public TextAsset textFile_3;

    public int index;

    [Header("头像")]
    public Sprite face01, face02;


    List<string> textList = new List<string>();

    private void Awake()
    {
        textFile = textFile_1;//初始化
        //设置事件 当触发后切换文本，主要针对剧情SwitchTextFile(textFile_2);带参数事件
        EventCenter.Instance.AddEventListener("KeyDia", SwitchKeyTextFile);
        
    }
    private void OnEnable()
    {
        GetTextFormFile(textFile);
        textFinished = true;
        StartCoroutine(SetTextUI());
    }
    void SwitchNextTextFile()
    {
        textFile = textFile_3;
        //Debug.Log("切换对话为下一个普通对话");
    }

    void SwitchKeyTextFile()
    {
        textFile = textFile_2;
        Debug.Log("切换对话为关键剧情对话对话");

    }
    

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
            return;
        }
        if(Input.GetKeyDown(KeyCode.Space) && textFinished) 
        {
            StartCoroutine(SetTextUI());
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(textFinished && !cancelTyping)
            {
                StartCoroutine(SetTextUI());
            }
            else if (!textFinished)
            {
                cancelTyping = !cancelTyping;
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
