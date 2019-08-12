using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    public void OnMouseDown()
    {
        //gold = gold + goldPerClick;
        DataController.Instance.gold += DataController.Instance.goldPerClick;
    }

}
