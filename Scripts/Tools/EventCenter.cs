using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//事件监听框架
//1.分清谁订阅事件
//2.谁触发事件
public class EventCenter : Singleton<EventCenter>//事件监听框架
    
{
    private Dictionary<string, IEventInfo> _eventDic = new Dictionary<string,IEventInfo>();

    public void AddEventListener(string name, UnityAction action)//订阅消息
    {
        if (_eventDic.ContainsKey(name))
            (_eventDic[name] as EventInfo).actions += action;
        else
            _eventDic.Add(name, new EventInfo(action));
    }
    public void AddEventListener<T>(string name, UnityAction<T> action)//带参订阅消息
    {
        if (_eventDic.ContainsKey(name))
            (_eventDic[name] as EventInfo<T>).actions += action;
        else
            _eventDic.Add(name, new EventInfo<T>(action));
    }

    public void EventTrigger(string name)//通知消息
    {
        if (_eventDic.ContainsKey(name))
            if ((_eventDic[name] as EventInfo).actions != null)
                (_eventDic[name] as EventInfo).actions.Invoke();
    }

    public void EventTrigger<T>(string name ,T info)//带参通知消息
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

    public void RemoveEventListener<T>(string name, UnityAction<T> action)//带参移除消息
    {
        if (_eventDic.ContainsKey(name))
            (_eventDic[name] as EventInfo<T>).actions -= action;
    }

    public void clear()//清空事件监听
        //主要用于场景切换时防止内存泄露
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



