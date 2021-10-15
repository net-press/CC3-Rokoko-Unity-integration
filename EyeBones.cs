using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBones : MonoBehaviour
{

    public Transform leftEye;
    public Transform rightEye;

    SkinnedMeshRenderer smr;

    int lookUpLeft;
    int lookUpRight;
    int lookDownLeft;
    int lookDownRight;
    int lookOutLeft;
    int lookInLeft;
    int lookInRight;
    int lookOutRight;

    Vector3 leftStartingRotation;
    Vector3 rightStartingRotation;

    public Vector3 LeftMinRotations = new Vector3 (-30, 0, 45);
    public Vector3 LeftMaxRotations = new Vector3(30, 0, -45);
    public Vector3 rightMinRotations = new Vector3(-30, 0, 45);
    public Vector3 rightMaxRotations = new Vector3(30, 0, -45);


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

        leftStartingRotation = leftEye.localRotation.eulerAngles;
        rightStartingRotation = rightEye.localRotation.eulerAngles;
    }


	private void LateUpdate() {

        /////// LEFT /////
        // mix the oppsing values of blendshapes to one single value
        float leftUpDown = smr.GetBlendShapeWeight(lookUpLeft)  + smr.GetBlendShapeWeight(lookDownLeft) * -1;
        float leftLeftRight = smr.GetBlendShapeWeight(lookInLeft) + smr.GetBlendShapeWeight(lookOutLeft) * -1;

        // Transform the value in a 0 to 1 floating value
        float leftUpDowninverseLerped = Mathf.InverseLerp(-1, +1, leftUpDown / 100);
        float leftLeftRightInverseLerped = Mathf.InverseLerp(-1, +1, leftLeftRight / 100);

        // Use the floating value to calculate the eye angles based upon mix and max values in inspector
        float leftVertical = Mathf.Lerp(LeftMinRotations.x, LeftMaxRotations.x, leftUpDowninverseLerped);
        float leftHorizontal = Mathf.Lerp(LeftMinRotations.z, LeftMaxRotations.z, leftLeftRightInverseLerped);

        // Apply the values as a rotation modifier
        leftEye.localRotation = Quaternion.Euler(leftStartingRotation.x + leftVertical, leftStartingRotation.y, leftStartingRotation.z + leftHorizontal);


        /////// RIGHT /////
        float rightUpDown = smr.GetBlendShapeWeight(lookUpRight) + smr.GetBlendShapeWeight(lookDownRight) *-1;
        float rightLeftRight = smr.GetBlendShapeWeight(lookInRight) *-1+ smr.GetBlendShapeWeight(lookOutRight) ;
        float rightUpDowninverseLerped = Mathf.InverseLerp(-1, +1, rightUpDown / 100);
        float rightLeftRightInverseLerped = Mathf.InverseLerp(-1, +1, rightLeftRight / 100);
        float rightVertical = Mathf.Lerp(rightMinRotations.x, rightMaxRotations.x, rightUpDowninverseLerped);
        float rightHorizontal = Mathf.Lerp(rightMinRotations.z, rightMaxRotations.z, rightLeftRightInverseLerped);
        rightEye.localRotation = Quaternion.Euler(rightStartingRotation.x + rightVertical, rightStartingRotation.y, rightStartingRotation.z + rightHorizontal);

    }

}
