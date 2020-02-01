using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartBehavior : MonoBehaviour
{
    [SerializeField] private GameObject imgObject;
    private Collider wallcollider;

    private bool repairing = false;
    [SerializeField] private float repairTimer = 2f;
    private bool building = false;
    [SerializeField] private float buildTimer = 4f;
    private float _timer = 0;

    [SerializeField] private int buildCost = 3;
    [SerializeField] private int repairCost = 1;

    private int state = 4;
    [SerializeField] private List<Sprite> states;

    private GameManager gmc;

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
            Building(repairTimer);
        }
        if (building)
        {
            Building(buildTimer);
        }
    }

    // Enemy steals part
    public void StealPart()
    {
        imgObject.SetActive(false);
        wallcollider.enabled = false;
        Debug.Log("Collide with wall");
    }

    // Start repairing
    public void RepairPart()
    {
        // Check if able to repair
        if (Inventory._instance.PayCost(repairCost))
        {
            _timer = 0;
            repairing = true;
        }
    }

    // For buying or recollecting part
    public void BuyPart()
    {
        // Check if able to repair
        if (Inventory._instance.PayCost(buildCost))
        {
            _timer = 0;
            repairing = true;
        }
    }

    // Buy wall
    public void Building(float timer)
    {
        timer += Time.deltaTime;
        if (_timer > timer)
        {
            imgObject.SetActive(true);
            wallcollider.isTrigger = true;
            repairing = false;
        }
    }

    // Capture mouse
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
