using UnityEngine;
using System.Collections;

public class ImpactCannonI : HeavyCannon {
    public override void initialize()
    {
        Level = 3;
        Type = CannonType.ImpactCannonI;
        CannonName = "Impact Cannon";
        Range = 100;
        Frequency = 2.4f;
        TimeBeforeShoot = 0;
        Cost = 48;
        Speed = 6;
        Damage = 3;
        target = null;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.ImpactCannonII;
        gradeTree[1] = CannonType.IceCannonI;
        gradeTree[2] = CannonType.Nothing;
        gradeTree[3] = CannonType.Degrade;
        prefabs = new GameObject[4];
        prefabs[0] = Resources.Load("Prefabs/ImpactCannonII") as GameObject;
        prefabs[1] = Resources.Load("Prefabs/IceCannonI") as GameObject;
        prefabs[2] = null;
        prefabs[3] = Resources.Load("Prefabs/HeavyCannon") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }
}
