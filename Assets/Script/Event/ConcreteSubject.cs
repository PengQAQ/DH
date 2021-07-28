using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteSubject : IGameEventSubject
{
    private string subjectState;

    /// <summary>
    /// 具体观察者的状态
    /// </summary>
    public string SubjectState
    {
        get { return subjectState; }
        set { subjectState = value; }
    }
}

public class ConcreteObserver:IGameEventObsever
{
    private string observerState;
    private string name;
    private ConcreteSubject subject;

    public ConcreteSubject Subject
    {
        get
        {
            return subject;
        }
        set
        {
            subject = value;
        }
    }

    public override void dataUpdate(DataType data)
    {
        observerState = subject.SubjectState;
    }
}
