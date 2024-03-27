using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static void SaveByJson(string saveFileName, object data)
    {
        var json = JsonUtility.ToJson(data);

        var path = Path.Combine(Application.persistentDataPath,saveFileName);

        File.WriteAllText(path, json);

        
        try
        {
            Debug.Log($"�ɹ��浵������{path}");

        }
        catch (System.Exception exception)
        {
            Debug.LogError($"�浵��{path}ʧ��.\n{exception}");
        }
    }

    public static T LoadFromJson<T>(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);
        try
        {
            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<T>(json);
            return data;
        }
        catch (System.Exception exception)
        {
            Debug.LogError($"�浵��ȡʧ����{path}. \n{exception}");
            return default;
        }

    }

    public static void DeleteSaveFlie(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);


        try
        {
            File.Delete(path);
        }
        catch(System.Exception exception) 
        {
            Debug.LogError($"�浵λ�ô���:{path}. \n{exception}");
        }


    }
}

/* ʹ�÷�����
    1.����һ��������ʵ��SaveSystem.SaveByJson(PLAYER_DATA_FILE_NAME, SavingData());
    2.����һ����������ʾ�浵���ݵĴ浵���� const String PLAYER_DATA_FILE_NAME = "PlayerData.zs"//��׺����
    3.����������ݵ�SaveData��ͷ���SavingData
    4.����һ���ύ

 
 
 
 
 */
