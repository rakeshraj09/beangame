using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        transform.position = new Vector2(transform.position.x - speed, transform.position.y);
    }
}
