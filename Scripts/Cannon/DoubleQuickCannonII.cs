using UnityEngine;
using System.Collections;

public class DoubleQuickCannonII : DoubleCannon {
    public override void initialize()
    {
        Level = 4;
        Type = CannonType.DoubleQuickCannonII;
        CannonName = "Double Quick Cannon II";
        Range = 110;
        Frequency = 2;
        TimeBeforeShoot = 0;
        Cost = 360;
        Speed = 10;
        Damage = 4;
        target = null;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.DoubleQuickCannonIII;
        gradeTree[1] = CannonType.Nothing;
        gradeTree[2] = CannonType.Nothing;
        gradeTree[3] = CannonType.Degrade;
        prefabs = new GameObject[4];
        prefabs[0] = Resources.Load("Prefabs/DoubleQuickCannonIII") as GameObject;
        prefabs[1] = null;
        prefabs[2] = null;
        prefabs[3] = Resources.Load("Prefabs/DoubleQuickCannonI") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }
}
