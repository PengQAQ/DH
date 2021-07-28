using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 数据触发的事件类型
/// </summary>
public enum dataEventType
{
    Null = 0,
    buy,
    sell,
    use,
}
public class DataType 
{
    //数据id
    public int dataId;
    //数据类型
    public dataEventType dataType;
    //数据数组
    //数组大小为3，{"物品名"，"物品数量","物品价格"}
    public string[] data;

    public DataType(int dataId, dataEventType dataType, string[] data)
    {
        this.dataId = dataId;
        this.dataType = dataType;
        this.data = data;
    }
}
