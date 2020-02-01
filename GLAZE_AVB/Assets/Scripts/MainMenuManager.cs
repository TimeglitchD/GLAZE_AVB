using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    private GameManager gmc;

    [SerializeField] private Button startgame;

    // Start is called before the first frame update
    void Start()
    {
        gmc = FindObjectOfType<GameManager>();
        startgame.onClick.AddListener(gmc.LoadLevel);
    }
}
