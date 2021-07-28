using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemModel : IGameEventObsever
{
    //单例模式
    public static ItemModel instance;

    public static ItemModel Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ItemModel();
                Debug.Log("3");
            }
            return instance;
        }
    }

    public class Item
    {
        public string name;
        public Sprite sprite;
        public int num;
        public int sellPrice;

        public Item(string name, Sprite sprite, int num, int sellPrice)
        {
            this.name = name;
            this.sprite = sprite;
            this.num = num;
            this.sellPrice = sellPrice;
        }
    }
    
    //存储物品的数组
    public static Item[] items;
    //物品图片字典
    public static Dictionary<string, Sprite> sprites;
    //物品价格字典
    public static Dictionary<string, int> itemPrice;
    //背包大小
    public static int bagSize;
    //背包目前格子
    public static int nowSize;
    private void Awake()
    {
        
    }
    /// <summary>
    /// 数据初始化
    /// </summary>
    public void init()
    {
        bagSize = 8;
        nowSize = 0;
        items = new Item[bagSize];
        sprites = new Dictionary<string, Sprite>();
        itemPrice = new Dictionary<string, int>();
        GetAllSprite();
        for(int i=0;i<items.Length;i++)
        {
            items[i] = new Item("null", null, 0,0);
        }
        
    }


    private void GetAllSprite()
    {
        string UIpath = "Assets/Resource/ItemSprite";
        string[] allPath = AssetDatabase.FindAssets("t:Sprite", new string[] { UIpath });

        for (int i = 0; i < allPath.Length; i++)
        {
            string path = AssetDatabase.GUIDToAssetPath(allPath[i]);
            Sprite obj = AssetDatabase.LoadAssetAtPath(path, typeof(Sprite)) as Sprite;
            sprites.Add(obj.name, obj);
            itemPrice.Add(obj.name, i * 10);
        }
    }


    public override void dataUpdate(DataType data)
    {
        print(data.data[1]);
        Item it = new Item(data.data[0], sprites[data.data[0]], int.Parse(data.data[1]), theSellPrice(itemPrice[data.data[0]]));
        if (data.dataType == dataEventType.buy)
        {
            bool flag = false;
            for(int i=0;i<items.Length;i++)
            {
                if(items[i].name == "null")
                    break;
                if(it.name == items[i].name)
                {
                    items[i].num++;
                    flag = true;
                }
            }
            if(!flag && nowSize + 1<bagSize)
            {
                items[nowSize] = it;
                nowSize++;
            }
        }
        if (data.dataType == dataEventType.sell || data.dataType == dataEventType.use)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (it.name == items[i].name)
                {
                    items[i].num--;
                    break;
                }
            }
        }
    }

    private int theSellPrice(int price)
    {
        return (int)(price * 0.7);
    }
}
