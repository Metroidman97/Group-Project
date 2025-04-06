using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float speed;

    private GameManager gameManager;

    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move item from the left of the screen to the right
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // Destroy object when it gets to the right side of the screen
        if (transform.position.x > gameManager.horizontalScreenLimit * 1.25f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if colliding with player instead of enemy
        if (collision.tag == "Player")
        {
            // Play sound when collected
            AudioSource.PlayClipAtPoint(clip, transform.position);

            // Check if this object is a coin
            if (this.tag == "Coin")
            {
                gameManager.AddScore(1);
                Destroy(this.gameObject);
            }
            else if (this.tag == "Heart") // Check if this object is a heart instead
            {
                collision.GetComponent<PlayerController>().GainLife();
                Destroy(this.gameObject);
            }
        }
    }
}
