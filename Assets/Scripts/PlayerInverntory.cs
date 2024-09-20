using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfGems
    {
        get;
        private set;
    }
    public UnityEvent<PlayerInventory> OnGemsCollected;
    public void GemsCollected()
    {
        NumberOfGems++;
        OnGemsCollected.Invoke(this);
    }
}
