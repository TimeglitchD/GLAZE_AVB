using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    public static Tracker _instance;
    private int enemiescaught, coinscollected, partsreturned, wallsrepaired, wallsbuild, gunsrepaired, gunsbuild, rounds;

    void Awake()
    {
        _instance = this;
    }

    // Reset scores
    public void StartGame()
    {
        enemiescaught = 0;
        coinscollected = 0;
        partsreturned = 0;
        wallsrepaired = 0;
        wallsbuild = 0;
        gunsrepaired = 0;
        gunsbuild = 0;
        rounds = 0;
    }

    // Setters
    public void CatchEnemy() { enemiescaught++; }
    public void CollectCoin() { coinscollected++; }
    public void ReturnPart() { partsreturned++; }
    public void RepairWall() { wallsrepaired++; }
    public void BuildWall() { wallsbuild++; }
    public void RepairGun() { gunsrepaired++; }
    public void BuildGun() { gunsbuild++; }
    public void SurvivedRound() { rounds++; }

    // Getters
    public int ScoreEnemy() { return enemiescaught; }
    public int CoinsCollected() { return coinscollected; }
    public int PartsReturned() { return partsreturned; }
    public int WallsRepaired() { return wallsrepaired; }
    public int WallsBuild() { return wallsbuild; }
    public int GunsRepaired() { return gunsrepaired; }
    public int GunsBuild() { return gunsbuild; }
    public int RoundsSurvived() { return rounds - 1; }
}
