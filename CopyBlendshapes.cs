using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyBlendshapes : MonoBehaviour
{


    public SkinnedMeshRenderer sourceSkinnedMeshRenderer;

    private SkinnedMeshRenderer smr;

    private int blendShapeCount;

    // Start is called before the first frame update
    void Start()
    {
        blendShapeCount = sourceSkinnedMeshRenderer.sharedMesh.blendShapeCount;
        smr = GetComponent<SkinnedMeshRenderer>();
        if (!smr) Debug.LogError("No Skinned Mesh Rendere on this object");
        if (!sourceSkinnedMeshRenderer) Debug.LogError("You have to link a Skinned Mesh Renderer as source");
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i <blendShapeCount; i++) {
            smr.SetBlendShapeWeight(i, sourceSkinnedMeshRenderer.GetBlendShapeWeight(i));
		}

    }
}
