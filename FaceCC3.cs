using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rokoko.Inputs;
using Rokoko.Helper;
using Rokoko.Core;

public class FaceCC3 : Face {

    public float mouthEmphasis = 1;
    public float browEmphasis = 1;
    public float cheekEmphasis = 1;
    public float noseEmphasis = 1;

    SkinnedMeshRenderer smr;

     public enum CC3BlendShapeNames {
        A01_Brow_Inner_Up, 
        A02_Brow_Down_Left,
        A03_Brow_Down_Right, 
        A04_Brow_Outer_Up_Left, 
        A05_Brow_Outer_Up_Right, 
        A06_Eye_Look_Up_Left, 
        A07_Eye_Look_Up_Right, 
        A08_Eye_Look_Down_Left, 
        A09_Eye_Look_Down_Right, 
        A10_Eye_Look_Out_Left,    
        A11_Eye_Look_In_Left,     
        A12_Eye_Look_In_Right, 
        A13_Eye_Look_Out_Right, 
        A14_Eye_Blink_Left,   
        A15_Eye_Blink_Right, 
        A16_Eye_Squint_Left, 
        A17_Eye_Squint_Right, 
        A18_Eye_Wide_Left, 
        A19_Eye_Wide_Right, 
        A20_Cheek_Puff, 
        A21_Cheek_Squint_Left, 
        A22_Cheek_Squint_Right, 
        A23_Nose_Sneer_Left, 
        A24_Nose_Sneer_Right, 
        A25_Jaw_Open, 
        A26_Jaw_Forward, 
        A27_Jaw_Left, 
        A28_Jaw_Right, 
        A29_Mouth_Funnel, 
        A30_Mouth_Pucker, 
        A31_Mouth_Left, 
        A32_Mouth_Right, 
        A33_Mouth_Roll_Upper, 
        A34_Mouth_Roll_Lower, 
        A35_Mouth_Shrug_Upper, 
        A36_Mouth_Shrug_Lower, 
        A37_Mouth_Close, 
        A38_Mouth_Smile_Left, 
        A39_Mouth_Smile_Right, 
        A40_Mouth_Frown_Left, 
        A41_Mouth_Frown_Right, 
        A42_Mouth_Dimple_Left, 
        A43_Mouth_Dimple_Right, 
        A44_Mouth_Upper_Up_Left, 
        A45_Mouth_Upper_Up_Right, 
        A46_Mouth_Lower_Down_Left, 
        A47_Mouth_Lower_Down_Right, 
        A48_Mouth_Press_Left, 
        A49_Mouth_Press_Right, 
        A50_Mouth_Stretch_Left, 
        A51_Mouth_Stretch_Right, 
        A52_Tongue_Out,
        Merged_Open_Mouth,
    };

    Dictionary<CC3BlendShapeNames, int> CC3BlendShapeNamesDict;

    protected override void Start() {
        smr = GetComponent<SkinnedMeshRenderer>();

        // Find the blendshape index for each given blendshape name
        CC3BlendShapeNamesDict = new Dictionary<CC3BlendShapeNames, int>();
        foreach(CC3BlendShapeNames bsn  in System.Enum.GetValues(typeof(CC3BlendShapeNames))) {
            CC3BlendShapeNamesDict.Add(bsn, smr.sharedMesh.GetBlendShapeIndex(bsn.ToString()));
		}

    }

    public override void UpdateFace(FaceFrame faceFrame) {

        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A01_Brow_Inner_Up], faceFrame.browInnerUp * browEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A02_Brow_Down_Left], faceFrame.browDownLeft * browEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A03_Brow_Down_Right], faceFrame.browDownRight * browEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A04_Brow_Outer_Up_Left], faceFrame.browOuterUpLeft * browEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A05_Brow_Outer_Up_Right], faceFrame.browOuterUpRight * browEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A06_Eye_Look_Up_Left], faceFrame.eyeLookUpLeft);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A07_Eye_Look_Up_Right], faceFrame.eyeLookUpRight);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A08_Eye_Look_Down_Left], faceFrame.eyeLookDownLeft);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A09_Eye_Look_Down_Right], faceFrame.eyeLookDownRight);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A10_Eye_Look_Out_Left], faceFrame.eyeLookOutLeft);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A11_Eye_Look_In_Left], faceFrame.eyeLookInLeft);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A12_Eye_Look_In_Right], faceFrame.eyeLookInRight);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A13_Eye_Look_Out_Right], faceFrame.eyeLookOutRight);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A14_Eye_Blink_Left], faceFrame.eyeBlinkLeft);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A15_Eye_Blink_Right], faceFrame.eyeBlinkRight);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A16_Eye_Squint_Left], faceFrame.eyeSquintLeft);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A17_Eye_Squint_Right], faceFrame.eyeSquintRight);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A18_Eye_Wide_Left], faceFrame.eyeWideLeft);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A19_Eye_Wide_Right], faceFrame.eyeWideRight);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A20_Cheek_Puff], faceFrame.cheekPuff * cheekEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A21_Cheek_Squint_Left], faceFrame.cheekSquintLeft * cheekEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A22_Cheek_Squint_Right], faceFrame.cheekSquintRight * cheekEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A23_Nose_Sneer_Left], faceFrame.noseSneerLeft * noseEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A24_Nose_Sneer_Right], faceFrame.noseSneerRight * noseEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A25_Jaw_Open], faceFrame.jawOpen);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A26_Jaw_Forward], faceFrame.jawForward);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A27_Jaw_Left], faceFrame.jawLeft * mouthEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A28_Jaw_Right], faceFrame.jawRight * mouthEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A29_Mouth_Funnel], faceFrame.mouthFunnel * mouthEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A30_Mouth_Pucker], faceFrame.mouthPucker * mouthEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A31_Mouth_Left], faceFrame.mouthLeft * mouthEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A32_Mouth_Right], faceFrame.mouthRight * mouthEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A33_Mouth_Roll_Upper], faceFrame.mouthRollUpper * mouthEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A34_Mouth_Roll_Lower], faceFrame.mouthRollLower * mouthEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A35_Mouth_Shrug_Upper], faceFrame.mouthShrugUpper * mouthEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A36_Mouth_Shrug_Lower], faceFrame.mouthShrugLower * mouthEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A37_Mouth_Close], faceFrame.mouthClose * mouthEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A38_Mouth_Smile_Left], faceFrame.mouthSmileLeft * mouthEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A39_Mouth_Smile_Right], faceFrame.mouthSmileRight * mouthEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A40_Mouth_Frown_Left], faceFrame.mouthFrownLeft * mouthEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A41_Mouth_Frown_Right], faceFrame.mouthFrownRight * mouthEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A42_Mouth_Dimple_Left], faceFrame.mouthDimpleLeft * mouthEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A43_Mouth_Dimple_Right], faceFrame.mouthDimpleRight * mouthEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A44_Mouth_Upper_Up_Left], faceFrame.mouthUpperUpLeft * mouthEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A45_Mouth_Upper_Up_Right], faceFrame.mouthUpperUpRight * mouthEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A46_Mouth_Lower_Down_Left], faceFrame.mouthLowerDownLeft * mouthEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A47_Mouth_Lower_Down_Right], faceFrame.mouthLowerDownRight * mouthEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A48_Mouth_Press_Left], faceFrame.mouthPressLeft * mouthEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A49_Mouth_Press_Right], faceFrame.mouthPressRight * mouthEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A50_Mouth_Stretch_Left], faceFrame.mouthStretchLeft * mouthEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A51_Mouth_Stretch_Right], faceFrame.mouthStretchRight * mouthEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.A52_Tongue_Out], faceFrame.tongueOut * mouthEmphasis);
        smr.SetBlendShapeWeight(CC3BlendShapeNamesDict[CC3BlendShapeNames.Merged_Open_Mouth], faceFrame.jawOpen * mouthEmphasis);
    }
}