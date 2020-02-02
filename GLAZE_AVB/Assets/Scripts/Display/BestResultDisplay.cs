using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestResultDisplay : MonoBehaviour
{
    Text text;
    GameManager gmc;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        gmc = FindObjectOfType<GameManager>();

        List<HighScore> listScore = HighscoresManager.Load();
        HighScore best = listScore[0];
        text.text = best.getName() + " got " + best.getScore();
    }
}
