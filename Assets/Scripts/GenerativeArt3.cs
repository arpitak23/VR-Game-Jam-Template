using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerativeArt3 : MonoBehaviour
{
    public GameObject shapePrefab;
    public int numShapes = 100;
    public float rotationSpeed = 20.0f;

    private GameObject[] shapes;

    void Start()
    {
        shapes = new GameObject[numShapes];

        for (int i = 0; i < numShapes; i++)
        {
            Vector3 spawnPosition = Random.insideUnitSphere * 5.0f; // Random position in a sphere of radius 5.
            shapes[i] = Instantiate(shapePrefab, spawnPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        foreach (var shape in shapes)
        {
            shape.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }
}
