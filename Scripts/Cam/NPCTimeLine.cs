using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTimeLine : MonoBehaviour
{
    public GameObject NPC_1;
    public GameObject NPC_2;
    private void OnDestroy()
    {
        if (NPC_1 != null)
        {
            NPC_1.SetActive(true);
            NPC_2.SetActive(true);
        }

    }
}
