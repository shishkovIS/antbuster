using UnityEngine;
using System.Collections;

public class DoubleCannonIV : DoubleCannon {
    public override void initialize()
    {
        Level = 5;
        Type = CannonType.DoubleCannonIV;
        CannonName = "Double Cannon IV";
        Range = 150;
        Frequency = 2;
        TimeBeforeShoot = 0;
        Cost = 1164;
        Speed = 8;
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
        prefabs[3] = Resources.Load("Prefabs/DoubleCannonIII") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }
}
