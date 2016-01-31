using UnityEngine;
using System.Collections;

public class DoubleCannonIII : DoubleCannon {


    public override void initialize()
    {
        Level = 4;
        Type = CannonType.DoubleCannonIII;
        CannonName = "Double Cannon III";
        Range = 100;
        Frequency = 2;
        TimeBeforeShoot = 0;
        Cost = 420;
        Speed = 8;
        Damage = 6;
        target = null;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.DoubleCannonIV;
        gradeTree[1] = CannonType.Nothing;
        gradeTree[2] = CannonType.Nothing;
        gradeTree[3] = CannonType.Degrade;
        prefabs = new GameObject[4];
        prefabs[0] = Resources.Load("Prefabs/DoubleCannonIV") as GameObject;
        prefabs[1] = null;
        prefabs[2] = null;
        prefabs[3] = Resources.Load("Prefabs/DoubleCannonII") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }
}
