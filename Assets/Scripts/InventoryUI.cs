using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI gemText;
   private void Start()
    {
       gemText = GetComponent<TextMeshProUGUI>();
    }
    public void UpdateGemtext(PlayerInventory playerInventory)
    {
        gemText.text = playerInventory.NumberOfGems.ToString();
    }
}
