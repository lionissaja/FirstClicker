using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{

    public Text itemDisplayer;
    public string itemName;
    public int level;

    [HideInInspector]
    public int currentCost;
    public int startCurrentCost = 1;

    [HideInInspector]
    public int goldPerSec;
    public int startGoldPerSec = 1;

    public float costPow = 3.14f;

    public float upgradePow = 1.07f;

    [HideInInspector]
    public bool isPurchased = false;

    void Start()
    {
        DataController.Instance.LoadItemButton(this);
        StartCoroutine("AddGoldLoop");
        UpdateUI();
    }

    public void PurchaseItem()
    {
        if(DataController.Instance.gold >= currentCost)
        {
            isPurchased = true;
            DataController.Instance.gold -= currentCost;
            level++;
            UpdateItem();
            UpdateUI();
            DataController.Instance.SaveItemButton(this);
        }
    }

    IEnumerator AddGoldLoop()
    {
        while(true)
        {
            if(isPurchased)
            {
                DataController.Instance.gold += goldPerSec;
            }

            yield return new WaitForSeconds(1.0f);
        }
    }

    public void UpdateItem()
    {
        goldPerSec = goldPerSec + startGoldPerSec * (int) Mathf.Pow(upgradePow, level);
        currentCost = startCurrentCost * (int) Mathf.Pow(costPow, level);
    }

    public void UpdateUI()
    {
        itemDisplayer.text = itemName + "\nLevel: " + level + "\nCost: " + currentCost + "\nGold Per Sec: " + goldPerSec + "\nIsPurchased: " + isPurchased;
    }
}
