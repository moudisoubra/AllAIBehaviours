using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{

    public int XQuads;
    public int ZQuads;
    public int totalQuad;

    public int totalVerticesX;
    public int totalVerticesZ;
    public int verticesArraySize;

    public int TotalCreated;

    int indicesPerQuad = 6;
    public int totalIndicesArraySize;



    // Start is called before the first frame update
    void Start()
    {
        TotalCreated = 0;
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        MeshRenderer meshRender = gameObject.AddComponent<MeshRenderer>();

        totalQuad = XQuads * ZQuads;
        totalVerticesX = XQuads + 1;
        totalVerticesZ = ZQuads + 1;
        verticesArraySize = totalVerticesX * totalVerticesZ;
        totalIndicesArraySize = totalQuad * indicesPerQuad;

        Vector3[] vertices = new Vector3[verticesArraySize];
        //{
        //    new Vector3 (-1, 0 ,1),
        //    new Vector3 (1, 0, 1),
        //    new Vector3 (3, 0, 1),
        //    new Vector3 (5, 0, 1),

        //    new Vector3(-1, 0, -1),
        //    new Vector3(1, 0, -1),
        //    new Vector3(3, 0, -1),
        //    new Vector3(5, 0, -1)
        //};



        for (int z = 0; z < totalVerticesZ; z++)
        {
            for (int x = 0; x < totalVerticesX; x++)
            {
                int index = x + z * totalVerticesX;
                vertices[index] = new Vector3(x, 0, -z);
                GameObject test = GameObject.CreatePrimitive(PrimitiveType.Cube);
                test.transform.position = vertices[index];
                test.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            }
        }

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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
