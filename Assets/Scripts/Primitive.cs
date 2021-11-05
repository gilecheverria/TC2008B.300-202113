using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Primitive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // New mesh to store the object shape
        Mesh mesh = new Mesh();
        // Link to the mesh on the game object
        GetComponent<MeshFilter>().mesh = mesh;

        //// GEOMETRY ////
        // The vertices
        Vector3[] verts = new Vector3[3];
        verts[0] = new Vector3(0, 0, 0);
        verts[1] = new Vector3(6, 0, 0);
        verts[2] = new Vector3(3, 6, 0);

        //// TOPOLOGY ////
        int[] faces = new int[6];
        faces[0] = 0;
        faces[1] = 2;
        faces[2] = 1;
        faces[3] = 0;
        faces[4] = 1;
        faces[5] = 2;

        //// TRANSFORMS ////
        // Get a translation matrix
        Matrix4x4 translation = MakeTranslate(-4, 5, 3);
        Matrix4x4 scale = MakeScale(0.5f, 2.5f, 0.5f);
        Matrix4x4 composite = translation * scale;
        // Apply the transformation to all vertices
        for (int i=0; i<verts.Length; i++) {
            Vector4 temp = new Vector4(verts[i].x, verts[i].y, verts[i].z, 1);
            verts[i] = composite * temp;
        }

        // Add the model data to the mesh
        mesh.vertices = verts;
        mesh.triangles = faces;
        
    }

    Matrix4x4 MakeTranslate(float tx, float ty, float tz)
    {
        Matrix4x4 mat = Matrix4x4.identity;
        mat[0, 3] = tx;
        mat[1, 3] = ty;
        mat[2, 3] = tz;
        return mat;
    }

    Matrix4x4 MakeScale(float sx, float sy, float sz)
    {
        Matrix4x4 mat = Matrix4x4.identity;
        mat[0, 0] = sx;
        mat[1, 1] = sy;
        mat[2, 2] = sz;
        return mat;
    }
}
