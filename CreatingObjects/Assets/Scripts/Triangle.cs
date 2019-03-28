using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        MeshRenderer meshRender = gameObject.AddComponent<MeshRenderer>();

        Vector3[] vertices = new Vector3[]
        {
            new Vector3(-1,0,-1), //Left Verticy
            new Vector3(0,0,1), //Top Verticy
            new Vector3(1,0,-1)  //Right Verticy
        };

        Vector2[] uvMap = new Vector2[]
        {
            new Vector2(0,0), //Left Verticy
            new Vector2(1,1), //Top Verticy
            new Vector2(1,0)  //Right Verticy
        };

        int[] indices = new int[]
        {
            0, 1, 2
        };
        //for (int i = 0; i < vertices.Length; i++) //This is just to test out the vertices
        //{
        //    GameObject test = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //    test.transform.position = vertices[i];
        //    test.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        //}

        Mesh mesh = meshFilter.mesh;
        mesh.vertices = vertices;
        mesh.triangles = indices;
        mesh.uv = uvMap;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
