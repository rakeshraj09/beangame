using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    [SerializeField] float speed = 0.2f;

    private void Update()
    {
        if(transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        transform.position = new Vector2(transform.position.x - speed, transform.position.y);
    }

}
