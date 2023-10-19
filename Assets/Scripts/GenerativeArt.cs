using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerativeArt : MonoBehaviour
{
    public int resolution = 100;
    public float scale = 1.0f;
    public Material material;

    private Mesh mesh;

    void Start()
    {
        mesh = GenerateMesh();
        CreateMeshObject(mesh);
    }

    Mesh GenerateMesh()
    {
        Mesh newMesh = new Mesh();
        Vector3[] vertices = new Vector3[resolution * resolution];
        int[] triangles = new int[(resolution - 1) * (resolution - 1) * 6];
        Vector2[] uv = new Vector2[resolution * resolution];

        float stepSize = 1.0f / (resolution - 1);

        for (int y = 0; y < resolution; y++)
        {
            for (int x = 0; x < resolution; x++)
            {
                int index = x + y * resolution;
                float xPos = x * stepSize;
                float yPos = y * stepSize;
                float zPos = Mathf.PerlinNoise(xPos * scale, yPos * scale) * 2.0f - 1.0f;

                vertices[index] = new Vector3(xPos, yPos, zPos);
                uv[index] = new Vector2(xPos, yPos);

                if (x < resolution - 1 && y < resolution - 1)
                {
                    int quadIndex = (x + y * (resolution - 1)) * 6;
                    triangles[quadIndex] = index;
                    triangles[quadIndex + 1] = index + 1;
                    triangles[quadIndex + 2] = index + resolution;
                    triangles[quadIndex + 3] = index + resolution;
                    triangles[quadIndex + 4] = index + 1;
                    triangles[quadIndex + 5] = index + resolution + 1;
                }
            }
        }

        newMesh.vertices = vertices;
        newMesh.triangles = triangles;
        newMesh.uv = uv;
        newMesh.RecalculateNormals();

        return newMesh;
    }

    void CreateMeshObject(Mesh mesh)
    {
        GameObject meshObject = new GameObject("Generative Art Mesh");
        MeshFilter meshFilter = meshObject.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = meshObject.AddComponent<MeshRenderer>();
        meshFilter.mesh = mesh;
        meshRenderer.material = material;
    }
}

