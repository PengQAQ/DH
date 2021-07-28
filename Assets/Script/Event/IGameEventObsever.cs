using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 观察者
/// </summary>
public abstract class IGameEventObsever :MonoBehaviour
{
    /// <summary>
    /// 实现方法
    /// </summary>
    public abstract void dataUpdate(DataType data);

    
}
