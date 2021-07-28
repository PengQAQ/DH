using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏中所有事件的主题
/// </summary>
public class IGameEventSubject 
{
    //所有的观察者
    private List<IGameEventObsever> observers = new List<IGameEventObsever>();

    /// <summary>
    /// 注册观察者
    /// </summary>
    /// <param name="ob"></param>
    public void RegisterObserver(IGameEventObsever ob)
    {
        observers.Add(ob);
    }

    public void RemoveObserver(IGameEventObsever ob)
    {
        observers.Remove(ob);
    }

    /// <summary>
    /// 通知所有的观察者
    /// </summary>
    public virtual void NotifyObserver(DataType data)
    {
        foreach (IGameEventObsever ob in observers)
        {
            ob.dataUpdate(data);
        }
    }
}
