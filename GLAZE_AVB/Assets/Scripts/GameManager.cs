using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum inputMode { attack, repair }
public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    [SerializeField]inputMode ModeSelector;
    [Range(0f, 2f)] [SerializeField] float gameSpeed=1f;
    [SerializeField] int Points, Coins;
    int timeActive;
    // Start is called before the first frame update
    void Start()
    {
        timeActive = Mathf.RoundToInt(Time.timeSinceLevelLoad);
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
    }
    public void addPoints(int pointsToAdd)
    {
        Points += pointsToAdd;
    }

    public inputMode getMode()
    {
        return ModeSelector;
    }
    public int getPoints()
    {
        return Points;
    }
    public int getCoins()
    {
        return Coins;
    }
    public void addCoin(int value)
    {
        Coins += value;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            ModeSelector = inputMode.repair;
        }
        else
        {
             ModeSelector = inputMode.attack;
        }
    }
}
