using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTimeLine : MonoBehaviour
{
    public GameObject NPC_1;
    public GameObject NPC_2;
    public GameObject Mood_1;
    public GameObject Mood_2;
    public GameObject Mood_3;
    private void OnDestroy()
    {
        if (gameObject != null)
        {
            try {
                NPC_1.SetActive(true);
                NPC_2.SetActive(true);
                Mood_1.SetActive(true);
                Mood_2.SetActive(true);
                Mood_3.SetActive(true);
            } catch
            {
                Debug.Log("º”‘ÿ¡ÌÕ‚≥°æ∞");
            }
            
        }
    }
}
