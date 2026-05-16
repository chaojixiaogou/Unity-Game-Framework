using System;
using System.Collections.Generic;

public class EventManager : Singleton<EventManager>
{
    // 事件字典：事件名 - 对应回调方法
    private readonly Dictionary<string, Action<object>> _eventDic = new Dictionary<string, Action<object>>();

    /// <summary>
    /// 注册监听事件
    /// </summary>
    public void AddEvent(string eventName, Action<object> callBack)
    {
        if (_eventDic.ContainsKey(eventName))
        {
            _eventDic[eventName] += callBack;
        }
        else
        {
            _eventDic.Add(eventName, callBack);
        }
    }

    /// <summary>
    /// 移除事件监听
    /// </summary>
    public void RemoveEvent(string eventName, Action<object> callBack)
    {
        if (_eventDic.TryGetValue(eventName, out var action))
        {
            action -= callBack;
        }
    }

    /// <summary>
    /// 派发/触发事件
    /// </summary>
    public void DispatchEvent(string eventName, object param = null)
    {
        if (_eventDic.TryGetValue(eventName, out var action))
        {
            action?.Invoke(param);
        }
    }

    /// <summary>
    /// 清空所有事件
    /// </summary>
    public void ClearAllEvent()
    {
        _eventDic.Clear();
    }
}