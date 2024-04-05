using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EzDia : MonoBehaviour
{
    public GameObject dialogBox;
    public TextAsset TextCon;
    public Text textLabel;
    public int index;
    List<string> textList = new List<string>();

    private void Start()
    {
        GetTextFormFile(TextCon);
        play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            play();
    }

    private void play()
    {
        if (index == textList.Count)
        {
            dialogBox.SetActive(false);
            index = 0;
        }
        textLabel.text = "";
        textLabel.text += textList[index];
        index++;
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
}
