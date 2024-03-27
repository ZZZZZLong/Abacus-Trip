using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("UI���")]
    public Text textLabel;
    public Image faceImage;
    public float textSpeed;

    bool textFinished;
    bool cancelTyping;


    [Header("�ı��ļ�")]
    TextAsset textFile;
    public TextAsset textFile_1;
    public TextAsset textFile_2;
    public TextAsset textFile_3;

    public int index;

    [Header("ͷ��")]
    public Sprite face01, face02;


    List<string> textList = new List<string>();

    private void Awake()
    {
        textFile = textFile_1;//��ʼ��
        //�����¼� ���������л��ı�����Ҫ��Ծ���SwitchTextFile(textFile_2);�������¼�
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
        //Debug.Log("�л��Ի�Ϊ��һ����ͨ�Ի�");
    }

    void SwitchKeyTextFile()
    {
        textFile = textFile_2;
        Debug.Log("�л��Ի�Ϊ�ؼ�����Ի��Ի�");

    }
    

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && index == textList.Count)
        {
            gameObject.SetActive(false);//�ű�����panel�� ��ǰ���ڵĶ�����ʧ= �ı�����ʧ
            
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

        switch (textList[index].Trim())//ʵ�ʴ���һ���е���A�ͻس�'\n'
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
