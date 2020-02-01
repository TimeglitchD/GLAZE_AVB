using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartBehavior : MonoBehaviour
{
    [SerializeField] private GameObject imgObject;
    private Collider wallcollider;

    private bool repairing = false;
    [SerializeField] private float repairTimer = 2f;
    private float timer = 0;
    GameManager gmc;
    [SerializeField] private int cost = 10;
    private bool hasComponents = false;

    // Start is called before the first frame update
    void Start()
    {
        wallcollider = gameObject.GetComponent<Collider>();
        gmc = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(repairing)
        {
            Repairing();
        }
    }

    // Enemy steals part
    public void StealPart()
    {
        imgObject.SetActive(false);
        wallcollider.isTrigger = true;
        //wallcollider.enabled = false;
        Debug.Log("Collide with wall");
    }

    // What does this part cost to buy?
    public int FindCostPart()
    {
        return cost;
    }

    // For buying or recollecting part
    public void ReturnPart()
    {
        hasComponents = true;
    }

    // Start repairing
    public void RepairPart()
    {
        if(hasComponents) repairing = true;
    }

    // Count time until repaired
    public void Repairing()
    {
        timer += Time.deltaTime;
        if (timer > repairTimer)
        {
            imgObject.SetActive(true);
            wallcollider.enabled = true;
            hasComponents = false;
            repairing = false;
        }
    }
    private void OnMouseDown()
    {
        if (gmc.getMode() == inputMode.repair)
        {
            imgObject.SetActive(true);
            wallcollider.isTrigger = false;
            Debug.Log("Repair!");
        }
        
    }
}
