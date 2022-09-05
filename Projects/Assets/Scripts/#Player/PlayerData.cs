using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    [Range(1,100)]
    private int live = 1;
    public void Healing(int value)
    {
        live += value;
    }
}