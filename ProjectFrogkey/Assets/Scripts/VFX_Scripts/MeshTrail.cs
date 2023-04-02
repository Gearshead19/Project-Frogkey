using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshTrail : MonoBehaviour
{
    public float activeTime = 2f;

    [Header("MeshRelated")]
    public float meshRefreshRate = 0.1f;
    public Transform spawnPosition;
    public float meshDestroyDelay = 3f;


    [Header("Shader Related")]
    public Material mat;

    private bool isTrailActive;
    private SkinnedMeshRenderer[] skinnedMeshRenderers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && !isTrailActive)
        {
            isTrailActive = true;
            StartCoroutine(ActivateTrail(activeTime));
        }
    }

    IEnumerator ActivateTrail(float timeActive)
    {
while(timeActive >0)
        {
            timeActive -= meshRefreshRate;
            if (skinnedMeshRenderers == null)
            {
                skinnedMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
            }
            for (int i = 0; i < skinnedMeshRenderers.Length; i++)
            {
                GameObject game = new GameObject();
                game.transform.SetPositionAndRotation(spawnPosition.position, spawnPosition.rotation);

               MeshRenderer mR =  game.AddComponent<MeshRenderer>();
                MeshFilter mF = game.AddComponent<MeshFilter>();

                Mesh mesh = new Mesh();
                skinnedMeshRenderers[i].BakeMesh(mesh);

                mF.mesh = mesh;
                mR.material = mat;

                Destroy(game, meshDestroyDelay); // replace this with an object pool to conserve memory

            }
            yield return new WaitForSeconds(meshRefreshRate);
        }

        isTrailActive = false;
    }
}
