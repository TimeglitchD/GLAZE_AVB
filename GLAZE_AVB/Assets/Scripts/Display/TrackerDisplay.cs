using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackerDisplay : MonoBehaviour
{
    [SerializeField] private Text txtenemy, txtcoins, txtparts, txtrepwall, txtbwall, txtrepgun, txtbgun, txtScore;

    void Start()
    {
        txtenemy.text = Tracker._instance.ScoreEnemy().ToString();
        txtcoins.text = Tracker._instance.CoinsCollected().ToString();
        txtparts.text = Tracker._instance.PartsReturned().ToString();
        txtrepwall.text = Tracker._instance.WallsRepaired().ToString();
        txtbwall.text = Tracker._instance.WallsBuild().ToString();
        txtrepgun.text = Tracker._instance.GunsRepaired().ToString();
        txtbgun.text = Tracker._instance.GunsBuild().ToString();

        GameManager gmc = FindObjectOfType<GameManager>();
        txtScore.text = gmc.getPoints().ToString();
    }
}
