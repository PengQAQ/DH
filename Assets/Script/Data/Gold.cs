using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : IGameEventObsever
{
    private static Text text;
    private static Gold instance;
    private static readonly object obj = new object();
    public static Gold Instance
    {
        get
        {
            lock (obj)
            {
                if (instance == null)
                {
                    instance = new Gold();
                    Debug.Log("1");
                }
                return instance;
            }
        }
    }
    public void init()
    {
         
    }
    private void Start()
    {
        text = this.gameObject.GetComponent<Text>();
        text.text = Globel.gold.ToString();
    }

    public override void dataUpdate(DataType data)
    {
        if(data.dataType == dataEventType.buy)
        {
            Globel.gold -= int.Parse(data.data[2]);
        }
        else
        {
            Globel.gold += int.Parse(data.data[2]);
        }
        

        text.text = Globel.gold.ToString();
        Debug.Log("Gold");
    }

    
}
