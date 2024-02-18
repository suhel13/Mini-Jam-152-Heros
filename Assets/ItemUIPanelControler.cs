using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUIPanelControler : MonoBehaviour
{
    public Dictionary<string, ItemUIControler> itemUIControlers = new Dictionary<string, ItemUIControler>();
    [SerializeField] GameObject itemUIControlerPrefab;
    [SerializeField] Transform FirstIconPos;
    [SerializeField] Vector3 offset;
    
    public void UpdateItemUIControler(string name, int amount)
    {
        itemUIControlers[name].UpdateItemData(amount);
    }

    public void CreateItemUIControler(string name, Sprite itemImage, int amount)
    {
        ItemUIControler tempItemUIControler = Instantiate(itemUIControlerPrefab).GetComponent<ItemUIControler>();
        itemUIControlers.Add(name, tempItemUIControler);
        itemUIControlers[name].SetItemData(itemImage, amount);
        tempItemUIControler.transform.position = (FirstIconPos.position + offset * (itemUIControlers.Count - 1));
    }
}
