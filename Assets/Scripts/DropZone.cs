using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DropZone : MonoBehaviour
{
    [SerializeField] private GameObject firePrefab;
    GameManager _gameManager;

    
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       GameObject fire = Instantiate(firePrefab, other.transform.position, quaternion.identity);
        if (other.gameObject.CompareTag("GoodObject"))
        {
            Debug.Log("got it");
            _gameManager.SubScore(1);
        }
        
        Destroy(fire,1.5f);
    }
}
