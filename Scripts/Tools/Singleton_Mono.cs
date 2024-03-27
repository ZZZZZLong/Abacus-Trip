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
                //动态创建 动态挂载 在场景中创建空物体
                GameObject obj = new GameObject();
                //得到T脚本类名 为对象改名
                obj.name = typeof(T).ToString();
                //动态挂载对应的单例脚本
                instance = obj.AddComponent<T>();
                //过场景时不移除对象
                DontDestroyOnLoad(obj);
            }
            return instance;
        }
        
    }
}

