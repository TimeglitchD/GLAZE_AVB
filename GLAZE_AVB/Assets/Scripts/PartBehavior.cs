using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartBehavior : MonoBehaviour
{
    [SerializeField] private GameObject imgObject;
    private Collider wallcollider;
    [SerializeField] AudioClip Repairclip;
    private bool repairing = false;
    [SerializeField] private float repairTimer = 2f;
    private bool building = false;
    [SerializeField] private float buildTimer = 4f;
    private float _timer = 0;

    [SerializeField] private int buildCost = 3;
    [SerializeField] private int repairCost = 1;

    private int state = 3;
    private SpriteRenderer sprRenderer;
    [SerializeField] private List<Sprite> states = new List<Sprite>();

    private GameManager gmc;

    // Start is called before the first frame update
    void Start()
    {
        wallcollider = gameObject.GetComponent<Collider>();
        sprRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        sprRenderer.sprite = states[state];
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
    public bool StealPart()
    {
        if (state == 0) return false;
        state--;

        sprRenderer.sprite = states[state];
        Debug.Log("State: " + state);

        return true;
    }

    // Start repairing
    public void RepairPart()
    {
        if (state == 0) return; // If wall needs to be rebuild

        wallcollider.isTrigger = false;

        // Check if able to repair
        if (Inventory._instance.PayCost(repairCost))
        {
            _timer = 0;
            repairing = true;
            AudioSource.PlayClipAtPoint(Repairclip, transform.position);
        }
    }

    // For buying or recollecting part
    public void BuildPart()
    {
        if (state != 0) return; // If wall needs to be repaired

        wallcollider.isTrigger = false;

        // Check if able to repair
        if (Inventory._instance.PayCost(buildCost))
        {
            _timer = 0;
            building = true;
        }
    }

    // Buy wall
    public void Building(float timer)
    {
        _timer += Time.deltaTime;
        if (_timer > timer)
        {
            Debug.Log("Repaired");
            state = 3;
            sprRenderer.sprite = states[state];
            wallcollider.isTrigger = true;
            repairing = false;
        }
    }

    // Capture mouse
    private void OnMouseDown()
    {
        if (gmc.getMode() == inputMode.repair)
        {
            RepairPart();
        }
        if(gmc.getMode() == inputMode.build)
        {
            BuildPart();
        }
    }
}
