using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : IGameEventObsever
{
    private static ItemView instance;
    public static ItemView Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ItemView();
                Debug.Log("2");
            }
            return instance;
        }
    }

    //背包节点
    public GameObject bag;
    //背包下的格子节点
    public static Transform[] items;

    private void Awake()
    {
        bag = GameObject.Find("Bag");
        items = new Transform[8];
        GetBag();
    }
    public void init()
    {
        
    }
    public override void dataUpdate(DataType data)
    {
        bagFlushed();
    }

    private void bagFlushed()
    {
        for(int i=0;i<ItemModel.items.Length;i++)
        {
            if (ItemModel.items[i].num > 0)
            {
                items[i].name = ItemModel.items[i].name;
                items[i].GetComponent<Image>().sprite = ItemModel.sprites[ItemModel.items[i].name];
                if (ItemModel.items[i].num > 1)
                    items[i].transform.GetChild(0).GetComponent<Text>().text = ItemModel.items[i].num.ToString();
            }
                
            else
            {
                items[i].name = "null";
                items[i].GetComponent<Image>().sprite = ItemModel.sprites["null"];
                items[i].transform.GetChild(0).GetComponent<Text>().text = "";
            }
        }
    }

    private void showItem()
    {

    }

    private void GetBag()
    {
        int i = 0;
        foreach(Transform obj in bag.transform)
        {
            obj.GetComponent<Image>().sprite = ItemModel.sprites["null"];
            if(ItemModel.items[i].num > 1)
                obj.transform.GetChild(0).GetComponent<Text>().text = ItemModel.items[i].num.ToString();
            items[i] = obj;
            i++;
        }
    }

}
