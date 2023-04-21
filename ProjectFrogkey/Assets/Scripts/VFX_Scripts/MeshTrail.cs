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
    public string shaderVarRef;
    public float shaderVarRate = 0.1f;
    public float shaderVarRefreshRate = 0.05f;

    private bool isTrailActive;
    private SkinnedMeshRenderer[] skinnedMeshRenderers;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Keypad
        if (Input.GetKeyDown(KeyCode.T) && !isTrailActive)
        {
            isTrailActive = true;
            StartCoroutine(ActivateTrail(activeTime));
        }

      

    }
    public void CheckTrail()
    {
        //Controller
        if (!isTrailActive)
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
                GameObject game = new GameObject("CharacterTrail"+i);
                game.transform.SetPositionAndRotation(spawnPosition.position, spawnPosition.rotation);
               
               MeshRenderer mR =  game.AddComponent<MeshRenderer>();
                MeshFilter mF = game.AddComponent<MeshFilter>();
                
                Mesh mesh = new Mesh();
                skinnedMeshRenderers[i].BakeMesh(mesh);
           

                mF.mesh = mesh;
                mR.material = mat;
                mR.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

                StartCoroutine(AnimateMaterialFloat(mR.material,0,shaderVarRate,shaderVarRefreshRate));

                //game.SetActive(false);
                Destroy(game, meshDestroyDelay); // replace this with an object pool to conserve memory
                
            }
            yield return new WaitForSeconds(meshRefreshRate);
        }
        isTrailActive = false;
    }
    IEnumerator AnimateMaterialFloat( Material mat, float goal, float rate, float refreshRate)
    {
        float valueToAnimate = mat.GetFloat(shaderVarRef);

        while(valueToAnimate > goal)
        {
            valueToAnimate -= rate;

            mat.SetFloat(shaderVarRef, valueToAnimate);

            yield return new WaitForSeconds(refreshRate);
        }
    }
    

    
}
