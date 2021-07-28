using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    private void Start()
    {
        Globel.gold = 4000;

        UIManager.Instance.init();
        UIManager.Instance.showUI("Main");
        ItemView.Instance.init();
        ItemModel.Instance.init();
        Gold.Instance.init();
    }
}
