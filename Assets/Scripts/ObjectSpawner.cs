using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]private List<GameObject> catchableObjects;
    [SerializeField]private List<GameObject> notCatchableObjects;

    private Vector2 spawnPosition;

    private BoxCollider2D collider;

    [SerializeField] private float time;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        timer = time;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnObject();
            timer = time;
        }
    }

    float SelectSpawPosition()
    {
        float position = Random.Range(collider.bounds.min.x, collider.bounds.min.y);
        return position;
    }
    
    void SpawnObject()
    {
        int rand = Random.Range(0, 2);
        int objectIndex;
        GameObject objectToSpawn;
        if (rand == 0)
        { 
            objectIndex = Random.Range(0, catchableObjects.Count);
            objectToSpawn = Instantiate(catchableObjects[objectIndex],
                new Vector3(SelectSpawPosition(), transform.position.y, transform.position.x)
                , quaternion.identity);
            objectToSpawn.transform.rotation = new Quaternion(transform.rotation.x,transform.rotation.y,Random.Range(0,5),transform.rotation.w);
        }
        else
        {
            objectIndex = Random.Range(0, notCatchableObjects.Count);
            objectToSpawn = Instantiate(notCatchableObjects[objectIndex],
                new Vector3(SelectSpawPosition(), transform.position.y, transform.position.x)
                , quaternion.identity);
            objectToSpawn.transform.rotation = new Quaternion(transform.rotation.x,transform.rotation.y,Random.Range(0,5),transform.rotation.w);
        }
    }
    
}
