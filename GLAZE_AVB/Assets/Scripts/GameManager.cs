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
    [SerializeField] int Points, Coins, Parts;
    [SerializeField] int coreHealth = 3;
    int timeActive;

    static int levelnr = 5;
    
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
        StartCoroutine(LoadingLevel(levelnr));
    }

    IEnumerator LoadingLevel(int level)
    {
        SceneManager.LoadScene(4, LoadSceneMode.Additive);
        SceneManager.LoadScene(level, LoadSceneMode.Additive);
        currentState = gameState.playing;
        yield return new WaitForSeconds(0.2f);
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
        StartCoroutine(LoadEndGame(levelnr));
    }

    // End level stuff

    public void EndLevel()
    {
        StartCoroutine(LoadEndGame(levelnr));
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
    // Part stuff
    public int getParts()
    {
        return Parts;
    }
    public void addPart(int value)
    {
        Parts += value;
    }
    public void removePart(int value)
    {
        Parts -= value;
    }
    // CoreHealth stuff
    public int getHealth()
    {
        return coreHealth;
    }
    public void HealthUp(int value)
    {
        coreHealth += value;
    }
    public void HealthDown(int value)
    {
        coreHealth -= value;
        if (coreHealth <= 0) EndLevel();
        Debug.Log("Current core health: " + coreHealth);
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
}
