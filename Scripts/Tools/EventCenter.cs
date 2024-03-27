using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//�¼��������
//1.����˭�����¼�
//2.˭�����¼�
public class EventCenter : Singleton<EventCenter>//�¼��������
    
{
    private Dictionary<string, IEventInfo> _eventDic = new Dictionary<string,IEventInfo>();

    public void AddEventListener(string name, UnityAction action)//������Ϣ
    {
        if (_eventDic.ContainsKey(name))
            (_eventDic[name] as EventInfo).actions += action;
        else
            _eventDic.Add(name, new EventInfo(action));
    }
    public void AddEventListener<T>(string name, UnityAction<T> action)//���ζ�����Ϣ
    {
        if (_eventDic.ContainsKey(name))
            (_eventDic[name] as EventInfo<T>).actions += action;
        else
            _eventDic.Add(name, new EventInfo<T>(action));
    }

    public void EventTrigger(string name)//֪ͨ��Ϣ
    {
        if (_eventDic.ContainsKey(name))
            if ((_eventDic[name] as EventInfo).actions != null)
                (_eventDic[name] as EventInfo).actions.Invoke();
    }

    public void EventTrigger<T>(string name ,T info)//����֪ͨ��Ϣ
    {
        if (_eventDic.ContainsKey(name))
            if ((_eventDic[name] as EventInfo<T>).actions != null)
                (_eventDic[name] as EventInfo<T>).actions.Invoke(info);
    }

    public void RemoveEventListener(string name, UnityAction action)
    {
        if(_eventDic.ContainsKey(name))
            (_eventDic[name] as EventInfo).actions -= action;
    }

    public void RemoveEventListener<T>(string name, UnityAction<T> action)//�����Ƴ���Ϣ
    {
        if (_eventDic.ContainsKey(name))
            (_eventDic[name] as EventInfo<T>).actions -= action;
    }

    public void clear()//����¼�����
        //��Ҫ���ڳ����л�ʱ��ֹ�ڴ�й¶
    {
        _eventDic.Clear();
    }
}

public interface IEventInfo { }

public class EventInfo : IEventInfo
{
    public UnityAction actions;
    public EventInfo(UnityAction action)
    {
        actions += action;
    }
}
public class EventInfo<T> : IEventInfo
{
    public UnityAction<T> actions;
    public EventInfo(UnityAction<T> action)
    {
        actions += action;
    }
}



