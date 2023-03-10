using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent (typeof(MeshRenderer))]
public class WaterManager : MonoBehaviour
{
    private MeshFilter mf;

    private void Awake()
    {
        mf = GetComponent<MeshFilter>();
    }

    private void Update()
    {
        Vector3[] vertices = mf.mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].y = WaveManager.instance.GetWaveHeight(transform.position.x + vertices[i].x);
        }

        mf.mesh.vertices = vertices;
        mf.mesh.RecalculateNormals();

    }
}
