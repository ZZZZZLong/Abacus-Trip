using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton_Mono<T> : MonoBehaviour where T:Singleton_Mono<T>
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();

                // ���û���ҵ�ͬ��ʵ�����򴴽���ʵ���������ڳ�����
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).ToString();
                    instance = obj.AddComponent<T>();
                    DontDestroyOnLoad(obj);
                }
            }
            return instance;
        }
        
    }
}

