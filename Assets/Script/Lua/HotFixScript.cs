using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;
public class HotFixScript : MonoBehaviour
{
    private LuaEnv luaEnv;
    public void awake()
    {
        luaEnv = new LuaEnv();
        luaEnv.AddLoader(MyLoader);
        luaEnv.DoString("require 'BaseUI'");
        //luaEnv.DoString("require 'BaseUI'");
        
    }
    private byte[] MyLoader(ref string filePath)
    {
        string absPath = @"C:\Unity\UI\Lua\" + filePath + ".lua.txt";
        return System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(absPath));
    }

    private void OnDestroy()
    {
        
    }
}
