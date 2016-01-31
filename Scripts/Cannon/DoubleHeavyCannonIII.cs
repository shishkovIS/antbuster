using UnityEngine;
using System.Collections;

public class DoubleHeavyCannonIII : DoubleCannon {

    public override void initialize()
    {
        Level = 5;
        Type = CannonType.DoubleHeavyCannonIII;
        CannonName = "Double Heavy Cannon III";
        Range = 120;
        Frequency = 1.3f;
        TimeBeforeShoot = 0;
        Cost = 1084;
        Speed = 5;
        Damage = 16;
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
        prefabs[3] = Resources.Load("Prefabs/DoubleHeavyCannonII") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }
}
