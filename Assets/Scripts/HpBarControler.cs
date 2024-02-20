using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarControler : MonoBehaviour
{
    [SerializeField] List<Image> images = new List<Image>();

    public void SetHpBar(int amountLeft)
    {
        foreach (Image image in images)
        {
            image.enabled = false;
        }
        for (int i = 0; i < images.Count; i++) 
        { 
            if (i < amountLeft)
            {
                images[i].enabled = true;
            }
        }
    }
}
