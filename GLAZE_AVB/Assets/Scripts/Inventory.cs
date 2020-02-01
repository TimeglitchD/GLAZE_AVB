using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<PartBehavior> parts = new List<PartBehavior>();

    // Start is called before the first frame update
    void Start()
    {
        PartBehavior[] partsArray = gameObject.GetComponentsInChildren<PartBehavior>();
        for(int i=0; i<partsArray.Length; i++)
        {
            parts.Add(partsArray[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyComponents()
    {

    }

    public void RepairComponents()
    {

    }
}
