using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIControler : MonoBehaviour
{
    string holdedItem;
    [SerializeField] TMPro.TextMeshProUGUI itemAmount;
    [SerializeField] Image itemImage;
    
    public void UpdateItemData(int amount)
    {
        itemAmount.text = amount.ToString();
    }
    public void SetItemData(Sprite itemImage, int amount)
    {
        itemAmount.text = amount.ToString();
        this.itemImage.sprite = itemImage;
    }
}
