using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent (typeof(MeshCollider))]

public class MesgGenirator : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();

        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
    }

    void CreateShape()
    {
        vertices = new Vector3[]
        {
            new Vector3(0f, 0f, 0f), //0
            new Vector3(1f, 0f, 0f), //1
            new Vector3(0f, 0f, 1f), //2
            new Vector3(1f, 0f, 1f), //3
            new Vector3(0.5f, 1f, 0.5f), //4
            new Vector3(0.5f, -1f, 0.5f), // 5
        };

        triangles = new int[]
        {
            2, 1, 0, //Top view of the triangle (Base)

           // 0, 1, 2, -> Bottom view of triangle (Base)

            1, 2, 3, //The other half of a square thats another triangle (TOP VIEW, for the bottom view, swap 1 and 3 around)

            0,2,4,  //Side one
            2,3,4, //Side two
            2,1,4, //Side three
            1,0,4,  //Side four

            //bottom
            0,2,5, //Side one
            2,3,5, //Side two
            2,1,5, //Side three
            1,0,5  //Side four
        };
    }
    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }

}
