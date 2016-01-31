using UnityEngine;
using System.Collections;

public class DoubleHeavyCannonII : DoubleCannon {

    public override void initialize()
    {
        Level = 4;
        Type = CannonType.DoubleHeavyCannonII;
        CannonName = "Double Heavy Cannon II";
        Range = 120;
        Frequency = 1.6f;
        TimeBeforeShoot = 0;
        Cost = 324;
        Speed = 5;
        Damage = 8;
        target = null;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.DoubleHeavyCannonIII;
        gradeTree[1] = CannonType.Nothing;
        gradeTree[2] = CannonType.Nothing;
        gradeTree[3] = CannonType.Degrade;
        prefabs = new GameObject[4];
        prefabs[0] = Resources.Load("Prefabs/DoubleHeavyCannonIII") as GameObject;
        prefabs[1] = null;
        prefabs[2] = null;
        prefabs[3] = Resources.Load("Prefabs/DoubleHeavyCannonI") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }
}
