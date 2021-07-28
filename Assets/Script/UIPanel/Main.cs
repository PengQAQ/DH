using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : BaseUI
{
    public void OpenPanel(string name)
    {
        UIManager.Instance.showUI(name);
    }

    public override void OnClose()
    {
        base.OnClose();
    }

    public void PopPanle()
    {
        UIManager.Instance.popPanel();
    }
}
