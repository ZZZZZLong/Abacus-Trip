using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringAdd : MonoBehaviour
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
            CellLocalData.Instance.addMood(3, "水", "快去交给王奶奶吧", "Package/Water");
            Debug.Log("物品数量为：" + GameManager.Instance.cellTable.DataList.Count);
            BoxCollider2D collider = GetComponent<BoxCollider2D>();

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

            UIManager.Instance.OpenPanel(UIConst.NewMood);
            StartCoroutine(CloseTip());
        }
    }

    IEnumerator CloseTip()
    {
        yield return new WaitForSeconds(1);
        UIManager.Instance.ClosePanel(UIConst.NewMood);
    }
}
