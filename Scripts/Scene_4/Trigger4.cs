using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger4 : MonoBehaviour
{
    public GameObject DiaLogue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DiaLogue.SetActive(true);
    }
}
