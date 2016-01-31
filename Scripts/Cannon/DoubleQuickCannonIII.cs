using UnityEngine;
using System.Collections;

public class DoubleQuickCannonIII : DoubleCannon {

    public override void initialize()
    {
        Level = 5;
        Type = CannonType.DoubleQuickCannonIII;
        CannonName = "Double Quick Cannon III";
        Range = 110;
        Frequency = 2;
        TimeBeforeShoot = 0;
        Cost = 1092;
        Speed = 10;
        Damage = 11;
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
        prefabs[3] = Resources.Load("Prefabs/DoubleQuickCannonII") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }
}
