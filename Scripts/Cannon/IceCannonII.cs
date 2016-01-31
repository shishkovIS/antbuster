using UnityEngine;
using System.Collections;

public class IceCannonII : HeavyCannon {

    public override void initialize()
    {
        Level = 5;
        Type = CannonType.IceCannonII;
        CannonName = "Ice Cannon II";
        Range = 100;
        Frequency = 4;
        TimeBeforeShoot = 0;
        Cost = 1304;
        Speed = 4;
        Damage = 3;
        target = null;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.Nothing;
        gradeTree[1] = CannonType.Nothing;
        gradeTree[2] = CannonType.Nothing;
        gradeTree[3] = CannonType.Degrade;
        prefabs = new GameObject[4];
        prefabs[0] = null;
        prefabs[1] = null;
        prefabs[2] = null;
        prefabs[3] = Resources.Load("Prefabs/IceCannonI") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }
}
