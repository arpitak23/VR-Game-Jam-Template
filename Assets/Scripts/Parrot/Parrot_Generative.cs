using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parrot_Generative : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    public int numObjects = 100;
    public float moveSpeed = 1.0f;

    private GameObject[] objects;

    void Start()
    {
        objects = new GameObject[numObjects];

        for (int i = 0; i < numObjects; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-15f, 15f), Random.Range(0.5f, 20f), 0f);
            GameObject prefab = objectPrefabs[Random.Range(0, objectPrefabs.Length)];
            objects[i] = Instantiate(prefab, spawnPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        foreach (var obj in objects)
        {
            Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
            //obj.transform.Translate(randomDirection * moveSpeed * Time.deltaTime);
        }
    }
}
