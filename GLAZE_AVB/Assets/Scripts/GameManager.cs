using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum inputMode { attack, repair, build }
public enum gameState {  menu, playing, pause, died }
public class GameManager : MonoBehaviour
{
    private gameState currentState = gameState.menu;

    public static GameManager _instance;
    [SerializeField]inputMode ModeSelector;
    
    [Range(0f, 2f)] [SerializeField] float gameSpeed=1f;
    [SerializeField] int Points, Coins, WorkerParts, SoldierParts;
    [SerializeField] int health = 3;
    int timeActive;

    // Worker stuff
    [SerializeField] private int workerPartCost = 5;
    [SerializeField] private int workerbuildCost = 3;
    public int getWorkerBuildCost() { return workerbuildCost; }
    [SerializeField] private int workerrepairCost = 1;
    public int getWorkerRepairCost() { return workerrepairCost; }

    // Solder stuff
    [SerializeField] private int soldierPartCost = 0;
    [SerializeField] private int soldierBuildCost = 0;
    public int getSoldierBuildCost() { return soldierBuildCost; }
    [SerializeField] private int soldierRepairCost = 0;
    public int getSoldierRepairCost() { return soldierRepairCost; }

    // To find behavior for UI
    private List<PartBehavior> wallbehaviorCodes;
    public PartBehavior getBehavior(int index) { return wallbehaviorCodes[index]; }

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        timeActive = Mathf.RoundToInt(Time.timeSinceLevelLoad);
        SceneManager.LoadScene(1, LoadSceneMode.Additive);  // Load Menu
    }

    public gameState getGameState()
    {
        return currentState;
    }
    public void setGameState(gameState newState)    
    {
        currentState = newState;
    }
    // Loading the level
    public void LoadLevel()
    {
        StartCoroutine(LoadingLevel(5));
    }

    IEnumerator LoadingLevel(int level)
    {
        SceneManager.LoadScene(level, LoadSceneMode.Additive);
        yield return new WaitForSeconds(0.5f);

        // To communicate the walls to the UI
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        wallbehaviorCodes = new List<PartBehavior>();
        for(int i=0; i<walls.Length; i++)
        {
            PartBehavior behavior = walls[i].GetComponent<PartBehavior>();
            if (behavior != null) wallbehaviorCodes.Add(behavior);
            Debug.Log(behavior + "Added");
        }

        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(4, LoadSceneMode.Additive);
        currentState = gameState.playing;
        SceneManager.UnloadSceneAsync(1);
    }

    // Pause menu stuff
    private bool pause = false;
    public void PauseGame()
    {
        if (pause) return;
        currentState = gameState.pause;
        SceneManager.LoadScene(3, LoadSceneMode.Additive);
        pause = true;
    }

    public void UnloadPauseMenu()
    {
        currentState = gameState.playing;
        SceneManager.UnloadSceneAsync(3);
        pause = false;
    }

    public void EndLevelPauseMenu()
    {
        SceneManager.UnloadSceneAsync(3);
        StartCoroutine(LoadEndGame(5));
    }

    // End level stuff

    public void EndLevel()
    {
        StartCoroutine(LoadEndGame(5));
    }

    IEnumerator LoadEndGame(int level)
    {
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
        currentState = gameState.died;
        yield return new WaitForSeconds(0.2f);
        SceneManager.UnloadSceneAsync(4);
        SceneManager.UnloadSceneAsync(level);
    }

    IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(0.2f);
        currentState = gameState.menu;
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }

    // input mode
    public inputMode getMode()
    {
        return ModeSelector;
    }
    // Point stuff
    public int getPoints()
    {
        return Points;
    }
    public void addPoints(int pointsToAdd)
    {
        Points += pointsToAdd;
    }
    // Coin stuff
    public int getCoins()
    {
        return Coins;
    }
    public void addCoin(int value)
    {
        Coins += value;
    }
    public void removeCoin(int value)
    {
        Coins -= value;
    }
    // Worker Part stuff
    public int getWorkerParts()
    {
        return WorkerParts;
    }
    public void addWorkerPart()
    {
        WorkerParts++;
    }
    // Soldier Part stuff
    public int getSoldierParts()
    {
        return SoldierParts;
    }
    public void addSoldierParts(int value)
    {
        SoldierParts += value;
    }
    // Health stuff
    public int getHealth()
    {
        return health;
    }
    public void addHealth(int value)
    {
        health += value;
    }
    public void removeHealth(int value)
    {
        health -= value;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            ModeSelector = inputMode.repair;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            ModeSelector = inputMode.build;
        }
        else
        {
             ModeSelector = inputMode.attack;
        }

        if(Input.GetKey(KeyCode.Escape))
        {
            PauseGame();
        }
    }


    // Pay/buy worker stuff
    public void BuyWorkerPart()
    {
        if (Coins >= workerPartCost)
        {
            addWorkerPart();
            removeCoin(workerPartCost);
        }
        else
        {
            Debug.Log("Not enough coins!");
        }
    }

    public bool PayWorkerCost(int cost)
    {
        if (cost <= WorkerParts)
        {
            WorkerParts -= cost;
            return true;
        }
        Debug.Log("Not enough parts!");
        return false;
    }

    // Pay/buy solder stuff
    public void BuySoldierPart()
    {
        Debug.Log("Cannot buy solders yet!!!");
        return;

        if (Coins >= soldierPartCost)
        {
            addWorkerPart();
            removeCoin(soldierPartCost);
        }
        else
        {
            Debug.Log("Not enough coins!");
        }
    }
    public bool PaySolderCost(int cost)
    {
        if (cost <= SoldierParts)
        {
            WorkerParts -= cost;
            return true;
        }
        return false;
    }
}
