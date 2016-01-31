using UnityEngine;
using System.Collections;

public class DoubleHeavyCannonI : DoubleCannon {
    public override void initialize()
    {
        Level = 3;

        Type = CannonType.DoubleHeavyCannonI;
        CannonName = "Double Heavy Cannon I";
        Range = 100;
        Frequency = 2;
        TimeBeforeShoot = 0;
        Cost = 60;
        Speed = 4;
        Damage = 3;
        target = null;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.DoubleHeavyCannonII;
        gradeTree[1] = CannonType.SonicPulseI;
        gradeTree[2] = CannonType.Nothing;
        gradeTree[3] = CannonType.Degrade;
        prefabs = new GameObject[4];
        prefabs[0] = Resources.Load("Prefabs/DoubleHeavyCannonII") as GameObject;
        prefabs[1] = Resources.Load("Prefabs/SonicPulseI") as GameObject;
        prefabs[2] = null;
        prefabs[3] = Resources.Load("Prefabs/HeavyCannon") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }
}
