using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour
{
    private float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Make the enemy move down the screen
        transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * speed);
        // Destroy enemy when they reach the bottom of the screen
        if( transform.position.y < -6.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
