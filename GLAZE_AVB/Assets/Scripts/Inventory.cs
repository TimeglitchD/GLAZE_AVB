using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory _instance;

    private GameManager gmc;

    private int coins = 0;

    private int wallparts = 5;
    [SerializeField] private int wallpartcost = 5;

    void Start()
    {
        _instance = this;
        gmc = FindObjectOfType<GameManager>();
    }

    public void BuyWallPart()
    {
        if(gmc.getCoins() > wallpartcost)
        {
            wallparts++;
            gmc.removeCoin(wallpartcost);
        }
    }

    public bool PayCost(int cost)
    {
        if(cost < wallparts)
        {
            wallparts -= cost;
            return true;
        }
        return false;
    }
}
