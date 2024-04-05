using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class OnNightShow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1.0f;
        DOTween.To(() => canvasGroup.alpha, x => canvasGroup.alpha = x, 0.0f, 2);
        StartCoroutine(DesGameObj());
    }

    IEnumerator DesGameObj()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }
}
