using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlow : MonoBehaviour
{
    // Flow enemies move down at an angle and are harder to hit
    private float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Make the enemy move down the screen at a random angle
        transform.Translate(new Vector3(Random.Range(-1f, -0.1f), -1, 0) * Time.deltaTime * speed);
        // Destroy enemy when they reach the bottom of the screen
        if (transform.position.y < -6.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
