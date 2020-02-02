using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts : MonoBehaviour
{
    [SerializeField]int value;
    [Range(1f,100f)][SerializeField]float rotationSpeed=5f;
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
        gmc.collectWorkerPart();
        Destroy(this.gameObject);
    }
}
