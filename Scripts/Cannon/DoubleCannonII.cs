using UnityEngine;
using System.Collections;

public class DoubleCannonII : DoubleCannon {

    public override void initialize()
    {
        Level = 3;
        Type = CannonType.DoubleCannonII;
        CannonName = "Double Cannon II";
        Range = 100;
        Frequency = 2;
        TimeBeforeShoot = 0;
        Cost = 60;
        Speed = 5;
        Damage = 2;
        target = null;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.DoubleCannonIII;
        gradeTree[1] = CannonType.Nothing;
        gradeTree[2] = CannonType.Nothing;
        gradeTree[3] = CannonType.Degrade;
        prefabs = new GameObject[4];
        prefabs[0] = Resources.Load("Prefabs/DoubleCannonIII") as GameObject;
        prefabs[1] = null;
        prefabs[2] = null;
        prefabs[3] = Resources.Load("Prefabs/DoubleCannon") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }
}
