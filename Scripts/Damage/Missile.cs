using UnityEngine;
using System.Collections;

public class Missile : Bullet {

    Transform target;
    float RotationFactor = 1.5f;
    protected override void transformation()
    {
        rotation();
        base.transformation();
    }

    protected void rotation()
    {
        if (target != null)
        {
            Quaternion beginRotation = this.transform.rotation;
            Quaternion endRotation = Quaternion.LookRotation( this.transform.position -target.transform.position);
           
           beginRotation = adjustRotation(beginRotation);
            endRotation = adjustRotation(endRotation);

            this.transform.rotation = Quaternion.Slerp(beginRotation, endRotation, Time.deltaTime * RotationFactor);
           
        }
    }


     Quaternion adjustRotation(Quaternion inQuaternion)
    {
        Vector3 adjustVector = inQuaternion.eulerAngles;
        adjustVector.x = 270;

        adjustVector.z = 0;
        inQuaternion = Quaternion.Euler(adjustVector);
        return inQuaternion;
    }


    protected override void initialize()
    {
        base.initialize();
        target = this.transform.parent.GetComponent<Shoot>().target;
    }
}
