using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // Adjust the speed for the application.
    [Range(0.1f,10f)][SerializeField] private float speed = 1.0f;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    [SerializeField] GameObject coinPrefab;
    private bool hasDirection = false;
    private bool goBack = false;
    GameManager gmc;
    // Make the enemy move towards direction
    public void StartMoving()
    {
       
    }

    private void Start()
    {
       //position on start is start position
        startPosition = transform.position;
        gmc = FindObjectOfType<GameManager>();
    }
    public void SetTarget(Transform target, Transform returnToDirection)
    {
        // provide the enemy with the target to move to (this gives possibility to diversify direction too)
        // startPosition = returnToDirection.position;
        startPosition = transform.position;
        targetPosition = target.position;
        hasDirection = true; //Flag it to go moving if there is a target selected
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("what?");
        if(collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Hits wall");
            goBack = true;
        }

        if (collision.gameObject.CompareTag("Core"))
        {
            Debug.Log("Hits core");
        }
    }
    void Move()
    {
        // Wait for direction
        if (hasDirection)
        {
            float step = speed * Time.deltaTime;
            //content is 'money'
            // If the enemy has not yet reached the player go to player
            if (goBack)
            {
                //change content to part
                targetPosition = startPosition;

                if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                {
                    gameObject.SetActive(false);
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        }
        
    }
    private void OnMouseDown()
    {
        
        gmc.addPoints(10);
        this.gameObject.SetActive(false);
        Instantiate(coinPrefab, new Vector3(transform.position.x,1f,transform.position.z), Quaternion.identity);
        ///
    }

    void SelectSpriteDirection()
    {
        //if currentpos lower than 
    }
}
