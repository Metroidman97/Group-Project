using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Attack enemies move in from the side of the screen
    private float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Make the enemy move across the screen
        transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed);
        // Destroy enemy when they reach the left side of the screen
        if (transform.position.x < -9.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
