using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public GameObject OtherNpc;

    List<string> textList = new List<string>();

    private void Awake()
    {
        textFile = textFile_1;//��ʼ��
        //�����¼� ���������л��ı�����Ҫ��Ծ���SwitchTextFile(textFile_2);�������¼�
        isDes = false;
    }
    private void Start()
    {
        Debug.Log("��ʼ����");
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
    //    Debug.Log("ȡ������");
    //    EventCenter.Instance.RemoveEventListener<string>("KeyDia", SwitchKeyTextFile);
    //}

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
            Debug.Log("���Ƴ���");
            textFile = textFile_2;
            textFile_3 = textFile_4;//����Ի�֮���л���һ����ͨ�Ի��ı�
        }
        if(NPC_name.name == "NPC2")
        {
            Debug.Log("NPC2�ĶԻ��л���");
        }
        
    }

    //void changeOtherNPCText(DialogSystem OtherDia, string Name)
    //{
    //    if(OtherDia != null)
    //    {
            
    //        if (OtherNpc.name == Name)//���������Ҫ�ı�Ի���npcname
    //        {
    //            OtherDia.textFile = OtherDia.textFile_2;
    //            Debug.Log(OtherDia);
    //            OtherDia.textFile_3 = OtherDia.textFile_4;//����Ի�֮���л���һ����ͨ�Ի��ı�
    //        }
    //    }
    //}
    

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
                Destroy(NPC_name);//����Ҫ��npc����
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
            
            case"D":
                //ReMoveLs();
                PlayerMove.ISMove = true;
                Destroy(gameObject);
                index++;
                break;

            case "W":
                //ReMoveLs();
                CellLocalData.Instance.addMood(1, "ľ��", "�ջ𣿻�����������ʲô�أ�", "Package/Wood");
                index++;
                break;

            case"E":
                //ReMoveLs();
                isDes = true;
                CellLocalData.Instance.RemoveMood(4);
                CellLocalData.Instance.addMood(5, "δ�ӹ���ľ��", "��ȫû�д����ľ�ģ�ȥ��ľ��������а취", "Package/Wood");
                EventCenter.Instance.EventTrigger("KeyDia"+OtherNpc.name, "NPC2");//NPC2�ĶԻ��ı���
                index++;
                break;
            
            case"F":
                //ReMoveLs();//��ÿ�仰��β����¼�����
                Cam_1 cam = gameObject.transform.parent.GetComponent<Cam_1>();
                cam.isRight = false;
                isDes = true;
                index++;
                break;
            
            case"H":
               // ReMoveLs();
                CellLocalData.Instance.RemoveMood(3);//ʧȥˮ
                index++;
                break;

            case "S":
                //ReMoveLs();
                CellLocalData.Instance.RemoveMood(5);//ʧȥδ�ӹ���ľ��
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
