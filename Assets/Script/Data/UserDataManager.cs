using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataManager : Subject
{
    private string mSubjectState;
    public string subjectState
    {
        set
        {
            mSubjectState = value;
            NotifyObserver();
        }
        get
        {
            return mSubjectState;
        }
    }
}
