using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField]int value;
    [Range(0f,100f)][SerializeField]float rotationSpeed=5f;
    [SerializeField] AudioClip coinClip;
    GameManager gmc;
    // Start is called before the first frame update
    void Start()
    {
        gmc = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 1f*rotationSpeed, 0));
    }
    private void OnMouseDown()
    {
        AudioSource.PlayClipAtPoint(coinClip, transform.position);
        gmc.addCoin(value);
        Destroy(this.gameObject);
    }
}
