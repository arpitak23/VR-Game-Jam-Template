using UnityEngine;

public class LineArt : MonoBehaviour
{
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -5f;
    public float maxY = 5f;

    private LineRenderer lineRenderer;
    private Vector3[] linePositions;
    private int linePointCount = 0;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0; // Initially, there are no points.

        linePositions = new Vector3[100]; // You can adjust the size based on your needs.
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GenerateRandomLine();
        }
    }

    void GenerateRandomLine()
    {
        // Generate random positions within the specified range.
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Vector3 randomPosition = new Vector3(randomX, randomY, 0);

        // Add the random position to the line positions array.
        linePositions[linePointCount] = randomPosition;

        // Increase the point count and update the line renderer.
        linePointCount++;
        lineRenderer.positionCount = linePointCount;
        lineRenderer.SetPositions(linePositions);
    }
}
