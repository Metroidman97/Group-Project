using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Start is called before the first frame update
    public enum EnemyType { Basic, Flow, Attack };
    public EnemyType enemyType;
    public float speed = 3f;
    public Vector3 moveDirection = new Vector3(0, -1, 0);

    void Awake()
    {
        SetEnemyAttributes();
    }

    //Update is called once per frame
    void Update()
    {
        MoveEnemy();
        CheckOutOfBounds();
    }

    public void SetEnemyType(EnemyType type)
    {
        enemyType = type;
        SetEnemyAttributes();
    }
    private void SetEnemyAttributes()
    {
        switch (enemyType)
        {
            case EnemyType.Flow:
                speed = 3f;
                moveDirection = new Vector3(-7, -1, 0);
                break;
            case EnemyType.Attack:
                speed = 4f;
                moveDirection = new Vector3(-1, 0, 0);
                break;
            default:
                speed = 3f;
                moveDirection = new Vector3(0, -1, 0);
                break;
        }
    }

    public void MoveEnemy()
    {
        transform.Translate(moveDirection * Time.deltaTime * speed);
    }

    public void CheckOutOfBounds()
    {
        if (transform.position.y < -6.5f)
        {
            Destroy(this.gameObject);
        }
    }
}