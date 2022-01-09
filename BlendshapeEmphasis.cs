using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendshapeEmphasis : MonoBehaviour
{

    [Header("Expression tuning")]
    public float browEmphasis = 1;
    public float eyeEmphasis = 1;
    public float cheekEmphasis = 1;
    public float noseEmphasis = 1;
    public float mouthEmphasis = 1;
    public float jawEmphasis = 1;

    private SkinnedMeshRenderer smr;
    private Mesh mesh;
    private int blendShapeCount;

    // Start is called before the first frame update
    void Start()
    {
        smr = GetComponent<SkinnedMeshRenderer>();
        mesh = smr.sharedMesh;
        blendShapeCount = smr.sharedMesh.blendShapeCount;
    }

	private void LateUpdate() {
        for (int i = 0; i < blendShapeCount; i++) {
            string name = mesh.GetBlendShapeName(i);
            if (name.Contains("Brow")) smr.SetBlendShapeWeight(i, smr.GetBlendShapeWeight(i) * browEmphasis);
            if (name.Contains("Eye")) smr.SetBlendShapeWeight(i, smr.GetBlendShapeWeight(i) * eyeEmphasis);
            if (name.Contains("Cheek")) smr.SetBlendShapeWeight(i, smr.GetBlendShapeWeight(i) * cheekEmphasis);
            if (name.Contains("Nose")) smr.SetBlendShapeWeight(i, smr.GetBlendShapeWeight(i) * noseEmphasis);
            if (name.Contains("Mouth")) smr.SetBlendShapeWeight(i, smr.GetBlendShapeWeight(i) * mouthEmphasis);
            if (name.Contains("Jaw")) smr.SetBlendShapeWeight(i, smr.GetBlendShapeWeight(i) * jawEmphasis);
        }
    }
}
