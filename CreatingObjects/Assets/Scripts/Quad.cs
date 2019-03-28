using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quad : MonoBehaviour
{

    public float divident;
    public Vector3[] vertices;
    // Start is called before the first frame update
    void Start()
    {
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        MeshRenderer meshRender = gameObject.AddComponent<MeshRenderer>();

        vertices = new Vector3[]
        {
            new Vector3(-1,0,1), //Top Left
            new Vector3(1,0,1), //Top Right
            new Vector3(1,0,-1), //Bottom Right
            new Vector3(-1, 0,-1), //Bottom Left
            new Vector3(3,0,1),
            new Vector3(3,0,-1),
            new Vector3(5,0,1),
            new Vector3(5,0,-1),
        };

        Vector2[] uvMap = new Vector2[] //NEED TO FIX UV MAP
        {
            new Vector2(0,0), //Bottom Left Verticy
            new Vector2(1/divident,1), //Top Right Verticy
            new Vector2(0,1), //Top Left Verticy
            new Vector2(1,0)  //Bottom Right Verticy
        };

        int[] indices = new int[]
        {
            0, 1, 2,
            2, 3, 0,
            1, 4, 5,
            5, 2, 1,
            4, 6, 7,
            7, 5, 4

        };

        for (int i = 0; i < vertices.Length; i++) //This is just to test out the vertices
        {
            GameObject test = GameObject.CreatePrimitive(PrimitiveType.Cube);
            test.transform.position = vertices[i];
            test.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        }

        Mesh mesh = meshFilter.mesh;
        mesh.vertices = vertices;
        mesh.triangles = indices;
        mesh.uv = uvMap;
    }

    // Update is called once per frame
    void Update()
    {
        divident = vertices.Length - 1;
    }
}
