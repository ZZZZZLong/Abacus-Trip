using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceTrigger : MonoBehaviour
{
    public GameObject Button;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        Button.SetActive(true);
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        Button.SetActive(false);
    }

    private void Update()
    {
        if (Button.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            PlayerMove.ISMove = false;
            Button.SetActive(false);
            EventCenter.Instance.EventTrigger("isEnter");
        }
    }
}
