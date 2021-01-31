using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    private Rigidbody2D body;

    [SerializeField] float movingSpeed;

    private float currentSpeed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // if (Input.GetKey(KeyCode.D))
        // {
        //     currentSpeed += movingSpeed;
        //     
        //     // body.position = new Vector2(body.position.x + 1 * movingSpeed, body.position.y);
        // }
        // if (Input.GetKey(KeyCode.A))
        // {
        //     currentSpeed -= movingSpeed;
        //     
        //    // body.position = new Vector2(body.position.x - 1 * movingSpeed, body.position.y);
        // }
        if (Input.GetAxis("Horizontal") != 0)
        {
            body.velocity = new Vector2(currentSpeed * Time.deltaTime * movingSpeed,body.velocity.y);
        }
        else
        {
            currentSpeed = body.velocity.x;
        }
        
        //body.position = body.velocity;
    }

    
    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKey(KeyCode.D))
        // {
        //     currentSpeed += movingSpeed;
        //     
        //     // body.position = new Vector2(body.position.x + 1 * movingSpeed, body.position.y);
        // }
        // if (Input.GetKey(KeyCode.A))
        // {
        //     currentSpeed -= movingSpeed;
        //     
        //     // body.position = new Vector2(body.position.x - 1 * movingSpeed, body.position.y);
        // }
        currentSpeed += Input.GetAxis("Horizontal");
        Debug.Log(currentSpeed);
    }
}
