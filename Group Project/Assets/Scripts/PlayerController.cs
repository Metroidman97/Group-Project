using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    // Declare and initialize variables
    private float Speed = 6.0f;
    private float horizontalInput;
    private float verticalInput;

    private float horizontalScreenLimit = 9.5f;
    private float verticalScreenLimitUpper = 0f;
    private float verticalScreenLimitLower = -3.5f;

    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }

    // Control movement
    void Move()
    {
        // Read the input from the player
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        // Move the player
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * Speed);

        // Horizontal screen wrap
        if(transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }

        // Constrain the player to the bottom half of the screen
        if(transform.position.y > verticalScreenLimitUpper)
        {
            transform.position = new Vector3(transform.position.x, verticalScreenLimitUpper, 0);
        }
        else if (transform.position.y < verticalScreenLimitLower)
        {
            transform.position = new Vector3(transform.position.x, verticalScreenLimitLower, 0);
        }
    }

    void Shoot()
    {
        // Shoot bullet when space key is pressed
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
}
