using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PointsDisplay : MonoBehaviour
{
    GameManager gmc;
    // Start is called before the first frame update
    void Start()
    {
        gmc = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = gmc.getPoints().ToString();
    }
}
