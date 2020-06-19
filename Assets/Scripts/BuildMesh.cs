﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMesh : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Building a mesh from scratch
        //Vector3[] newVertices;
        //Vector2[] newUV;
        //int[] newTriangles;
        //Mesh mesh = new Mesh();
        //GetComponent<MeshFilter>().mesh = mesh;
        //mesh.vertices = newVertices;
        //mesh.uv = newUV;
        //mesh.triangles = newTriangles;

        ChangeTrianglesAndVertices();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ModifyCube()
    {
        // Modifying vertex attributes
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;
        float coef = 5.0f;

        for (var i = 0; i < vertices.Length; i += 1)
        {
            vertices[i] += normals[i] * coef;
        }

        mesh.vertices = vertices;
    }

    void ChangeTrianglesAndVertices()
    {
        // Continously changing the mesh triangles and vertices
        float width = 1f;
        float height = 2f;
        float length = 1f;

        // set standart material
        //MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        //meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));

        MeshFilter filter = GetComponent<MeshFilter>();
        Mesh mesh = filter.mesh;

        mesh.Clear();

        // Do some calculations...
        Vector3 p0 = new Vector3(-width, -height, length);
        Vector3 p1 = new Vector3(width, -height, length);
        Vector3 p2 = new Vector3(width, -height, -length);
        Vector3 p3 = new Vector3(-width, -height, -length);
        Vector3 p4 = new Vector3(-width, height, length);
        Vector3 p5 = new Vector3(width, height, length);
        Vector3 p6 = new Vector3(width, height, -length);
        Vector3 p7 = new Vector3(-width, height, -length);

        Vector3[] newVertices = new Vector3[24]
        {
            // Bottom
	        p0, p1, p2, p3,
 
	        // Left
	        p7, p4, p0, p3,
 
	        // Front
	        p4, p5, p1, p0,
 
	        // Back
	        p6, p7, p3, p2,
 
	        // Right
	        p5, p6, p2, p1,
 
	        // Top
	        p7, p6, p5, p4
        };

        int[] newTriangles = new int[]
        {
            // Bottom
	        3, 1, 0,
            3, 2, 1,			
 
	        // Left
	        3 + 4 * 1, 1 + 4 * 1, 0 + 4 * 1,
            3 + 4 * 1, 2 + 4 * 1, 1 + 4 * 1,
 
	        // Front
	        3 + 4 * 2, 1 + 4 * 2, 0 + 4 * 2,
            3 + 4 * 2, 2 + 4 * 2, 1 + 4 * 2,
 
	        // Back
	        3 + 4 * 3, 1 + 4 * 3, 0 + 4 * 3,
            3 + 4 * 3, 2 + 4 * 3, 1 + 4 * 3,
 
	        // Right
	        3 + 4 * 4, 1 + 4 * 4, 0 + 4 * 4,
            3 + 4 * 4, 2 + 4 * 4, 1 + 4 * 4,
 
	        // Top
	        3 + 4 * 5, 1 + 4 * 5, 0 + 4 * 5,
            3 + 4 * 5, 2 + 4 * 5, 1 + 4 * 5,
        };

        Vector2 _00 = new Vector2(0f, 0f);
        Vector2 _10 = new Vector2(1f, 0f);
        Vector2 _01 = new Vector2(0f, 1f);
        Vector2 _11 = new Vector2(1f, 1f);
        Vector2[] newUV = new Vector2[]
        {
            // Bottom
	        _11, _01, _00, _10,
 
	        // Left
	        _11, _01, _00, _10,
 
	        // Front
	        _11, _01, _00, _10,
 
	        // Back
	        _11, _01, _00, _10,
 
	        // Right
	        _11, _01, _00, _10,
 
	        // Top
	        _11, _01, _00, _10,
        };
        //for (int i = 0; i < newUV.Length; i++)
        //{
        //    newUV[i] = new Vector2(newVertices[i].x, newVertices[i].z);
        //}

        Vector3 up = Vector3.up;
        Vector3 down = Vector3.down;
        Vector3 front = Vector3.forward;
        Vector3 back = Vector3.back;
        Vector3 left = Vector3.left;
        Vector3 right = Vector3.right;
        Vector3[] newNormals = new Vector3[]
        {
            // Bottom
	        down, down, down, down,
 
	        // Left
	        left, left, left, left,
 
	        // Front
	        front, front, front, front,
 
	        // Back
	        back, back, back, back,
 
	        // Right
	        right, right, right, right,
 
	        // Top
	        up, up, up, up
        };
        
        mesh.vertices = newVertices;
        mesh.uv = newUV;
        mesh.normals = newNormals;
        mesh.triangles = newTriangles;

        mesh.RecalculateBounds();
        mesh.Optimize();
    }
}
