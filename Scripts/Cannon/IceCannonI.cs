using UnityEngine;
using System.Collections;

public class IceCannonI : HeavyCannon {
    public override void initialize()
    {
        Level = 4;
        Type = CannonType.IceCannonI;
        CannonName = "Ice Cannon I";
        Range = 80;
        Frequency = 4;
        TimeBeforeShoot = 0;
        Cost = 400;
        Speed = 4;
        Damage = 1;
        target = null;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.IceCannonII;
        gradeTree[1] = CannonType.Nothing;
        gradeTree[2] = CannonType.Nothing;
        gradeTree[3] = CannonType.Degrade;
        prefabs = new GameObject[4];
        prefabs[0] = Resources.Load("Prefabs/IceCannonII") as GameObject;
        prefabs[1] = null;
        prefabs[2] = null;
        prefabs[3] = Resources.Load("Prefabs/ImpactCannonI") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }
   
}
