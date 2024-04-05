using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookAdd : MonoBehaviour
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
            CellLocalData.Instance.addMood(9, "孙子算法", "鸡兔同笼术曰:上置头，下置足，半其足，以头除足，以足除头，即得", "Package/Book");
            Debug.Log("物品数量为：" + GameManager.Instance.cellTable.DataList.Count);
            BoxCollider2D collider = GetComponent<BoxCollider2D>();
            UIManager.Instance.OpenPanel(UIConst.NewMood);
            GameManager.Instance.isCanEnter_1 = true;
            StartCoroutine(CloseTip());
            // 检查是否找到了碰撞体组件
            if (collider != null)
            {
                // 禁用碰撞体
                collider.enabled = false;
            }
            else
            {
                Debug.LogWarning("对象没有碰撞体组件！");
            }

        }
    }
    IEnumerator CloseTip()
    {
        yield return new WaitForSeconds(1);
        UIManager.Instance.ClosePanel(UIConst.NewMood);
    }
}
