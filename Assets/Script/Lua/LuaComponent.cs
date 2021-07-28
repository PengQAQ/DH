using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class LuaComponent : MonoBehaviour
{
    public LuaTable luaTable;
    /// <summary>
    /// 函数
    /// </summary>
    LuaFunction luaStart;
    LuaFunction luaUpdate;
    LuaFunction luaAwake;


    public static LuaTable Add(GameObject go, LuaTable tableClass)
    {
        LuaFunction luaCtor = tableClass.Get<LuaFunction>("ctor");
        if (luaCtor == null)
            return null;

        object[] rets = luaCtor.Call(tableClass);
        if (rets.Length != 1)
            return null;
        LuaComponent cmp = go.AddComponent<LuaComponent>();
        cmp.luaTable = tableClass;
        cmp.InityLuaFunction();
        cmp.CallAwake();
        return cmp.luaTable;
    }

    public static LuaTable Get(GameObject go, LuaTable table)
    {
        LuaComponent[] cmps = go.GetComponents<LuaComponent>();
        string tableStr = table.ToString();
        for(int i=0;i<cmps.Length;i++)
        {
            string temp = cmps[i].luaTable.ToString();
            if (string.Equals(tableStr, cmps[i].luaTable.ToString()))
                return cmps[i].luaTable;
        }
        return null;
    }

    private void InityLuaFunction()
    {
        luaStart = luaTable.Get<LuaFunction>("Start");
        luaAwake = luaTable.Get<LuaFunction>("Awake");
        luaUpdate = luaTable.Get<LuaFunction>("Update");

    }

    private void CallAwake()
    {
        if (luaAwake != null)
            luaAwake.Call(luaTable, gameObject);
    }

    private void Start()
    {
        if (luaStart != null)
            luaStart.Call(luaTable, gameObject);
    }

    private void Update()
    {
        if (luaUpdate != null)
            luaUpdate.Call();
    }
}
