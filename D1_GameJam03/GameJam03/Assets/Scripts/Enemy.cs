using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    public NavMeshAgent agent;
    private GameManager gameManager;
    public int health = 100, damage = 1;
    public float speed = 3.5F;

    // Use this for initialization
    void Start()
    {
        agent.speed = speed;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gameObject.transform.LookAt(gameManager.Objective.transform);
        agent.SetDestination(gameManager.Objective.transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
            gameManager.money += 1000;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected");
        if (collision.collider.tag == "Objective")
        {
            gameManager.lives -= damage;
            Destroy(this.gameObject);

        }

    }
}
