using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql;
public class ButtonTest : MonoBehaviour
{
    static ConcreteSubject subject;
    public static int pos = 0;


    public void buy()
    {
        //DataType data = new DataType(1, dataEventType.buy, new string[3] { "highlighter", "1","200" });
        string btnName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        string price = ItemModel.itemPrice[btnName].ToString();
        DataType data = new DataType(1, dataEventType.buy, new string[3] { btnName, "1", price });
        //金币够
        if (int.Parse(data.data[2]) <= Globel.gold)
        {
            subject = new ConcreteSubject();
            subject.RegisterObserver(Gold.Instance);
            subject.RegisterObserver(ItemModel.Instance);
            subject.RegisterObserver(ItemView.Instance);
            
            subject.NotifyObserver(data);
        }
    }

    public void sell()
    {
        

        DataType data = new DataType(2, dataEventType.sell, new string[3] { ItemModel.items[pos].name, "1", ItemModel.items[pos].sellPrice.ToString() });
        
        subject.NotifyObserver(data);
    }

    public void use()
    {

        DataType data = new DataType(3, dataEventType.sell, new string[3] { ItemModel.items[pos].name, "1", "0" });
        
        subject.NotifyObserver(data);
    }

    public void GetPosition()
    {
        string btnName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        pos = int.Parse(btnName.Substring(btnName.Length - 1, 1));
    }


}
