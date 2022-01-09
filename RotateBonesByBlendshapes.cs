using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBonesByBlendshapes : MonoBehaviour
{

    public Transform leftEyeBone;
    public Transform rightEyeBone;
    public Transform jawBone;

    SkinnedMeshRenderer smr;

    int lookUpLeft;
    int lookUpRight;
    int lookDownLeft;
    int lookDownRight;
    int lookOutLeft;
    int lookInLeft;
    int lookInRight;
    int lookOutRight;
    int jawOpen;
    int jawForward;
    int jawLeft;
    int jawRight;

    Vector3 leftStartingRotation;
    Vector3 rightStartingRotation;
    Vector3 jawStartingRotation;

    [Header("Eyes settings")]
    public Vector3 leftEyeMinRotations = new Vector3 (-30, 0, 30);
    public Vector3 leftEyeMaxRotations = new Vector3(30, 0, -30);
    public Vector3 rightEyeMinRotations = new Vector3(-30, 0, 30);
    public Vector3 rightEyeMaxRotations = new Vector3(30, 0, -30);

    [Header("Jaw settings")]
    public Vector3 jawMinRotations = new Vector3 (-10, 0, 0);
    public Vector3 jawMaxRotations = new Vector3 (10, 0, -30);


    // Start is called before the first frame update
    void Start() {

        

        smr = GetComponent<SkinnedMeshRenderer>();
        lookUpLeft = smr.sharedMesh.GetBlendShapeIndex("A06_Eye_Look_Up_Left");
        lookUpRight = smr.sharedMesh.GetBlendShapeIndex("A07_Eye_Look_Up_Right");
        lookDownLeft = smr.sharedMesh.GetBlendShapeIndex("A08_Eye_Look_Down_Left");
        lookDownRight = smr.sharedMesh.GetBlendShapeIndex("A09_Eye_Look_Down_Right");
        lookOutLeft = smr.sharedMesh.GetBlendShapeIndex("A10_Eye_Look_Out_Left");
        lookInLeft = smr.sharedMesh.GetBlendShapeIndex("A11_Eye_Look_In_Left");
        lookInRight = smr.sharedMesh.GetBlendShapeIndex("A12_Eye_Look_In_Right");
        lookOutRight = smr.sharedMesh.GetBlendShapeIndex("A13_Eye_Look_Out_Right");
        jawOpen = smr.sharedMesh.GetBlendShapeIndex("A25_Jaw_Open");
        jawForward = smr.sharedMesh.GetBlendShapeIndex("A26_Jaw_Forward");
        jawLeft = smr.sharedMesh.GetBlendShapeIndex("A27_Jaw_Left");
        jawRight = smr.sharedMesh.GetBlendShapeIndex("A28_Jaw_Right");


        leftStartingRotation = leftEyeBone.localRotation.eulerAngles;
        rightStartingRotation = rightEyeBone.localRotation.eulerAngles;
        jawStartingRotation = jawBone.localRotation.eulerAngles;
    }


	private void LateUpdate() {

        /////// LEFT EYE /////
        // mix the oppsing values of blendshapes to one single value
        float leftUpDown = smr.GetBlendShapeWeight(lookUpLeft)  + smr.GetBlendShapeWeight(lookDownLeft) * -1;
        float leftLeftRight = smr.GetBlendShapeWeight(lookInLeft) + smr.GetBlendShapeWeight(lookOutLeft) * -1;

        // Transform the value in a 0 to 1 floating value
        float leftUpDowninverseLerped = Mathf.InverseLerp(-1, +1, leftUpDown / 100);
        float leftLeftRightInverseLerped = Mathf.InverseLerp(-1, +1, leftLeftRight / 100);

        // Use the floating value to calculate the eye angles based upon mix and max values in inspector
        float leftVertical = Mathf.Lerp(leftEyeMinRotations.x, leftEyeMaxRotations.x, leftUpDowninverseLerped);
        float leftHorizontal = Mathf.Lerp(leftEyeMinRotations.z, leftEyeMaxRotations.z, leftLeftRightInverseLerped);

        // Apply the values as a rotation modifier
        leftEyeBone.localRotation = Quaternion.Euler(leftStartingRotation.x + leftVertical, leftStartingRotation.y, leftStartingRotation.z + leftHorizontal);

        /////// RIGHT EYE/////
        float rightUpDown = smr.GetBlendShapeWeight(lookUpRight) + smr.GetBlendShapeWeight(lookDownRight) *-1;
        float rightLeftRight = smr.GetBlendShapeWeight(lookInRight) *-1+ smr.GetBlendShapeWeight(lookOutRight) ;
        float rightUpDowninverseLerped = Mathf.InverseLerp(-1, +1, rightUpDown / 100);
        float rightLeftRightInverseLerped = Mathf.InverseLerp(-1, +1, rightLeftRight / 100);
        float rightVertical = Mathf.Lerp(rightEyeMinRotations.x, rightEyeMaxRotations.x, rightUpDowninverseLerped);
        float rightHorizontal = Mathf.Lerp(rightEyeMinRotations.z, rightEyeMaxRotations.z, rightLeftRightInverseLerped);
        rightEyeBone.localRotation = Quaternion.Euler(rightStartingRotation.x + rightVertical, rightStartingRotation.y, rightStartingRotation.z + rightHorizontal);


        // JAW
        float jawOpenWeight = smr.GetBlendShapeWeight(jawOpen);
        float jawUpDownInverseLerped = Mathf.InverseLerp(0, 1, jawOpenWeight / 100);
        float jawUpDown = Mathf.Lerp(jawMinRotations.z, jawMaxRotations.z, jawUpDownInverseLerped); ;

        //float jawLeftRight= smr.GetBlendShapeWeight(jawRight) * -1 + smr.GetBlendShapeWeight(jawLeft)*+1;
        float jawLeftRight = 0;
        Debug.Log(jawLeftRight);
        float jawLeftRightInverseLerped = Mathf.InverseLerp(-1, +1, jawLeftRight);
        float jawHorizontal = Mathf.Lerp(jawMinRotations.x, jawMaxRotations.x, jawLeftRightInverseLerped);
        jawBone.localRotation = Quaternion.Euler(jawStartingRotation.x + jawHorizontal, jawStartingRotation.y, jawStartingRotation.z + jawUpDown);

    }

}
