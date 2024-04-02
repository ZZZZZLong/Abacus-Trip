using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowNum : MonoBehaviour
{
    public GameObject Canvas;


    private void Update()
    {
        GetNum G = Canvas.GetComponent<GetNum>();
        Text text = transform.GetComponent<Text>();
        text.text = G.total.ToString();
    }
}
