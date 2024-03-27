using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodAdd : MonoBehaviour
{
    public GameObject Button;

    private void OnTriggerEnter2D(Collider2D other)
    {
        EventCenter.Instance.AddEventListener("HideBtn", HideBtn);
        Button.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Button.SetActive(false);
    }
    void HideBtn()
    {
        if (Button != null)
        {
            Button.SetActive(false);
        }
    }

    private void Update()
    {
        if (Button.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            Button.SetActive(false);
            //talkUI.SetActive(true);//拾取物品提示
            CellLocalData.Instance.addMood(1, "木材", "烧火？还可以用来做什么呢？", "Package/Wood");
            Debug.Log("物品数量为：" + GameManager.Instance.cellTable.DataList.Count);
        }
    }
}
