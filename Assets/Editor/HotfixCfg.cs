using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using System;
using System.Reflection;

public class HotfixCfg 
{
    [Hotfix]
    public static List<Type> by_field = new List<Type>()
    {
        typeof(BaseUI),

    };

    

}
