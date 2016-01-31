using UnityEngine;
using System.Collections;

public class QuickCannonIV : Cannon {

    public override void initialize()
    {
        Level = 5;
        Type = CannonType.QuickCannonIV;
        CannonName = "Quick Cannon IV";
        Range = 120;
        Frequency = 6;
        TimeBeforeShoot = 0;
        Cost = 1123;
        Speed = 7;
        Damage = 9;
        target = null;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.Nothing;
        gradeTree[1] = CannonType.Nothing;
        gradeTree[2] = CannonType.Nothing;
        gradeTree[3] = CannonType.QuickCannonIII;
        prefabs = new GameObject[4];
        prefabs[0] = null;
        prefabs[1] = null;
        prefabs[2] = null;
        prefabs[3] = Resources.Load("Prefabs/QuickCannonIII") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }
}
