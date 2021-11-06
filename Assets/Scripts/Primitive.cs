using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Primitive : MonoBehaviour
{
    [SerializeField] float increment;

    Mesh mesh;
    Vector3[] verts;
    int[] faces;
    Vector3[] modified;

    float angle = 0;

    // Start is called before the first frame update
    void Start()
    {
        // New mesh to store the object shape
        mesh = new Mesh();
        // Link to the mesh on the game object
        GetComponent<MeshFilter>().mesh = mesh;

        //// GEOMETRY ////
        // The vertices
        verts = new Vector3[3];
        verts[0] = new Vector3(0, 0, 0);
        verts[1] = new Vector3(6, 0, 0);
        verts[2] = new Vector3(3, 6, 0);

        modified = new Vector3[verts.Length];

        //// TOPOLOGY ////
        faces = new int[6];
        faces[0] = 0;
        faces[1] = 2;
        faces[2] = 1;
        faces[3] = 0;
        faces[4] = 1;
        faces[5] = 2;
    }

    void Update()
    {
        angle += increment;

        //// TRANSFORMS ////
        // Get a translation matrix
        //Matrix4x4 translation = Transforms.MakeTranslate(-4, 5, 3);
        //Matrix4x4 scale = Transforms.MakeScale(0.5f, 2.5f, 0.5f);
        //Matrix4x4 composite = translation * scale;
        Matrix4x4 transOrigin = Transforms.MakeTranslate(-3, -6, 0);
        Matrix4x4 transObject = Transforms.MakeTranslate(3, 6, 0);
        Matrix4x4 rotate = Transforms.MakeRotateX(angle);
        //Matrix4x4 composite = transOrigin * rotate * transObject;
        Matrix4x4 composite = transObject * rotate * transOrigin;
        // Apply the transformation to all vertices
        for (int i=0; i<verts.Length; i++) {
            Vector4 temp = new Vector4(verts[i].x, verts[i].y, verts[i].z, 1);
            modified[i] = composite * temp;
        }

        // Add the model data to the mesh
        mesh.vertices = modified;
        mesh.triangles = faces;
    }
}
