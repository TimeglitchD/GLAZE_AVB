using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinsDisplay : MonoBehaviour
{
    TextMeshProUGUI text;
    GameManager gmc;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        gmc = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = gmc.getCoins().ToString();   
    }
}
