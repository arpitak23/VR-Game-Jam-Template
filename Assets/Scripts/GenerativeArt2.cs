using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerativeArt2 : MonoBehaviour
{
    public GameObject circlePrefab;
    public int numCircles = 100;
    public float moveSpeed = 2.0f;
    public float minSize = 0.1f;
    public float maxSize = 1.0f;
    public Color[] colors;

    private GameObject[] circles;

    void Start()
    {
        circles = new GameObject[numCircles];

        for (int i = 0; i < numCircles; i++)
        {
            //Vector3 spawnPosition = new Vector3(Random.Range(0.0f, 10.0f), Random.Range(0.0f, 10.0f), 0.0f);
            Vector3 spawnPosition = new Vector3(Random.Range(0.0f, 10.0f), Random.Range(0.0f, 10.0f), Random.Range(0.0f, 10.0f));
            circles[i] = Instantiate(circlePrefab, spawnPosition, Quaternion.identity);

            float size = Random.Range(minSize, maxSize);
            circles[i].transform.localScale = new Vector3(size, size, size);

            int colorIndex = Random.Range(0, colors.Length);
            circles[i].GetComponent<Renderer>().material.color = colors[colorIndex];
        }
    }

    void Update()
    {
        for (int i = 0; i < numCircles; i++)
        {
            Vector3 currentPosition = circles[i].transform.position;
            Vector3 newPosition = currentPosition + new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0.0f) * moveSpeed * Time.deltaTime;
            circles[i].transform.position = newPosition;
        }
    }
}
