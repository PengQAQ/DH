using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject:MonoBehaviour
{
    List<Observer> observers = new List<Observer>();

    /// <summary>
    /// 注册观察者
    /// </summary>
    /// <param name="ob"></param>
    public void RegisterObserver(Observer ob)
    {
        observers.Add(ob);
    }

    public void RemoveObserver(Observer ob)
    {
        observers.Remove(ob);
    }

    /// <summary>
    /// 通知所有的观察者
    /// </summary>
    public void NotifyObserver()
    {
        foreach(Observer ob in observers)
        {
            ob.DataUpdate();
        }
    }
}

public abstract class Observer:MonoBehaviour
{
    public abstract void DataUpdate();
}
