using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class InventorySlot : MonoBehaviour
{ /*
    public Image icon;
    public TextMeshProUGUI lableText;
    public TextMeshProUGUI numberOfItems;

    public void ClearSlot()
    {
        icon.enabled = false;
        lableText.enabled = false;
        numberOfItems.enabled = false;
    }

    public void DrawSlot(Collectable collectable)
    {
        if(collectable == null) { 
            ClearSlot();
            return; }


        icon.enabled = true;
        lableText.enabled = true;
        numberOfItems.enabled = true;


        icon.sprite = collectable.collectableData.icon;
        lableText.text = collectable.collectableData.displayName;
        numberOfItems.text = collectable.stackSize.ToString();
    }
    */
}
