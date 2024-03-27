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
                //��̬���� ��̬���� �ڳ����д���������
                GameObject obj = new GameObject();
                //�õ�T�ű����� Ϊ�������
                obj.name = typeof(T).ToString();
                //��̬���ض�Ӧ�ĵ����ű�
                instance = obj.AddComponent<T>();
                //������ʱ���Ƴ�����
                DontDestroyOnLoad(obj);
            }
            return instance;
        }
        
    }
}

