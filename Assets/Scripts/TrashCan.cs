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

    [SerializeField] private float maxSpeed;

    private GameManager _gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        _gameManager = FindObjectOfType<GameManager>();
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
        
        if (body.velocity.x >= maxSpeed)
        {
            body.velocity = new Vector2(maxSpeed, body.velocity.y);
        }

        if (body.velocity.x<= -maxSpeed)
        {
            body.velocity = new Vector2(-maxSpeed, body.velocity.y);
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
        
        Debug.Log(body.velocity.x);

        if (transform.position.x < -10.0f && body.velocity.x < 0)
        {
            body.position = new Vector2(10.0f, body.position.y);
        }
        if (transform.position.x > 10.0f && body.velocity.x > 0)
        {
            body.position = new Vector2(-10.0f, body.position.y);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GoodObject"))
        {
            Debug.Log("got it");
            _gameManager.AddScore(1);
        }
        else
        {
            _gameManager.SubScore(1);
        }
        Destroy(other.gameObject,0.3f);
    }

   

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.CompareTag("GoodObject"))
    //     {
    //         Debug.Log("got it");
    //         _gameManager.AddScore(1);
    //     }
    //     Destroy(other.gameObject,0.3f);
    // }
}
