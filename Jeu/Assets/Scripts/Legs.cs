using UnityEngine;

public class Legs : MonoBehaviour
{
    public HingeJoint Os;
    public Transform Obj;
    public bool Invert;

    void Update()
    {
        JointSpring Js = Os.spring;
        Js.targetPosition = Obj.transform.localEulerAngles.x;
        if (Js.targetPosition > 180)
            Js.targetPosition = Js.targetPosition - 360;

        Js.targetPosition = Mathf.Clamp(Js.targetPosition, Os.limits.min + 5, Os.limits.max - 5);

        if (Invert)
            Js.targetPosition = Js.targetPosition * -1;
        Os.spring = Js;
    }
}