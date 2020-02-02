using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField]int value;
    
    [SerializeField] AudioClip collectClip;
    GameManager gmc;
    // Start is called before the first frame update
    void Start()
    {
        gmc = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnMouseDown()
    {
        AudioSource.PlayClipAtPoint(collectClip, transform.position);
        gmc.addCoin(value);
        Destroy(this.gameObject);
    }
}
