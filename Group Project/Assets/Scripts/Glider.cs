using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glider : MonoBehaviour
{
    public float speed;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Make object move forward, regardless of direction
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // Destroy object when it goes off screen
        if (transform.position.y >= gameManager.screenTop * 1.25f || transform.position.y <= gameManager.verticalScreenLimitLower * 1.25 || transform.position.x <= -gameManager.horizontalScreenLimit * 1.25)
        {
            Destroy(this.gameObject);
        }
    }
}
