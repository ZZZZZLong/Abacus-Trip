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
    bool isDes;


    [Header("�ı��ļ�")]
    public TextAsset textFile;
    public TextAsset textFile_1;
    public TextAsset textFile_2;
    public TextAsset textFile_3;
    public TextAsset textFile_4;

    public int index;

    [Header("ͷ��")]
    public Sprite face01, face02, face03;
    public GameObject NPC_name;//��֮�Ի���NPC����

    List<string> textList = new List<string>();

    private void Awake()
    {
        textFile = textFile_1;//��ʼ��
        //�����¼� ���������л��ı�����Ҫ��Ծ���SwitchTextFile(textFile_2);�������¼�
        EventCenter.Instance.AddEventListener<string>("KeyDia", SwitchKeyTextFile);
        isDes = false;
    }
    private void OnEnable()
    {
        GetTextFormFile(textFile);
        textFinished = true;
        StartCoroutine(SetTextUI());
    }
    void SwitchNextTextFile()
    {
        if(textFile_3 != null)
        {
            textFile = textFile_3;
        }
        //Debug.Log("�л��Ի�Ϊ��һ����ͨ�Ի�");
    }

    void SwitchKeyTextFile(string Name)
    {
        if (NPC_name.name == Name)//���������Ҫ�ı�Ի���npcname
        {
            textFile = textFile_2;
        }
        Debug.Log("�л��Ի�Ϊ�ؼ�����Ի��Ի�");
        textFile_3 = textFile_4;//����Ի�֮���л���һ����ͨ�Ի��ı�
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
            if(isDes == true)
            {
                NPC_name.SetActive(false);//����Ҫ��npc����
            }
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
            case"C":
                faceImage.sprite = face03;
                index++;
                break;
            case"W":
                CellLocalData.Instance.addMood(1, "ľ��", "�ջ𣿻�����������ʲô�أ�", "Package/Wood");
                index++;
                break;

            case"E":
                isDes = true;
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
