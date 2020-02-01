using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory _instance;

    private int coins = 0;

    private int caughtwallparts = 0;

    private int _wallpart;
    public int wallpart
    {
        get { return _wallpart; }
    }

    void Start()
    {
        _instance = this;
    }

    public void BuyWallPart()
    {

    }

    public bool PayCost(int cost)
    {
        if(cost < _wallpart)
        {
            _wallpart -= cost;
            return true;
        }
        return false;
    }
}
