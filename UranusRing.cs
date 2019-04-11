using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UranusRing : MonoBehaviour {

    //Ring Creation Code From: https://www.youtube.com/watch?v=Rze4GEFrYYs

    [Range(3, 360)]

    //Set the segments of the ring
    public int segments = 3;

    //Set how far from the center of the planet the ring starts
    public float innerRadius = 0.7f;

    //Set thickness of the ring
    public float thickness = 0.5f;

    //Assign material to ring
    public Material ringMaterial;

    //Private variables
    GameObject ringTwo;
    Mesh ringMesh;
    MeshFilter ringMF;
    MeshRenderer ringMR;

    void Start() {

        //Create ring object
        ringTwo = new GameObject(name + " Ring");
        
        //Parent ring to planet
        ringTwo.transform.parent = transform;

        //Set the scale, position and rotation of the ring
        ringTwo.transform.localScale = Vector3.one;
        ringTwo.transform.localPosition = Vector3.zero;
        ringTwo.transform.localRotation = Quaternion.Euler(90, 0, 0);
        ringMF = ringTwo.AddComponent<MeshFilter>();
        ringMesh = ringMF.mesh;
        ringMR = ringTwo.AddComponent<MeshRenderer>();

        //Mesh renderers material is assigned to our material
        ringMR.material = ringMaterial;

        //Build Ring Mesh
        Vector3[] vertices = new Vector3[(segments + 1) * 2 * 2];
        int[] triangles = new int[segments * 6 * 2];
        Vector2[] uv = new Vector2[(segments + 1) * 2 * 2];
        int halfway = (segments + 1) * 2;

        for (int i = 0; i < segments + 1; i++)
        {
            float progress = (float)i / (float)segments;
            float angle = Mathf.Deg2Rad * progress * 360;
            float x = Mathf.Sin(angle);
            float z = Mathf.Cos(angle);

            vertices[i * 2] = vertices[i * 2 + halfway] = new Vector3(x, 0f, z) * (innerRadius + thickness);
            vertices[i * 2 + 1] = vertices[i * 2 + 1 + halfway] = new Vector3(x, 0f, z) * innerRadius;
            uv[i * 2] = uv[i * 2 + halfway] = new Vector2(progress, 0f);
            uv[i * 2 + 1] = uv[i * 2 + 1 + halfway] = new Vector2(progress, 1f);

            if (i != segments)
            {
                triangles[i * 12] = i * 2;
                triangles[i * 12 + 1] = triangles[i * 12 + 4] = (i + 1) * 2;
                triangles[i * 12 + 2] = triangles[i * 12 + 3] = i * 2 + 1;
                triangles[i * 12 + 5] = (i + 1) * 2 + 1;

                triangles[i * 12 + 6] = i * 2 + halfway;
                triangles[i * 12 + 7] = triangles[i * 12 + 10] = i * 2 + 1 + halfway;
                triangles[i * 12 + 8] = triangles[i * 12 + 9] = (i + 1) * 2 + halfway;
                triangles[i * 12 + 11] = (i + 1) * 2 + 1 + halfway;
            }
        }

        //Assign vertices, triangles and uv to the mesh
        ringMesh.vertices = vertices;
        ringMesh.triangles = triangles;
        ringMesh.uv = uv;
        ringMesh.RecalculateNormals();

    }
}
