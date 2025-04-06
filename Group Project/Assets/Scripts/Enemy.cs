using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject explosionPrefab;

    private GameManager gameManager;

    public int scoreValue;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().LoseLife();
            //Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Weapon")
        {
            Destroy(collision.gameObject);
            //Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            gameManager.AddScore(scoreValue);
            Destroy(this.gameObject);
        }
    }
}
