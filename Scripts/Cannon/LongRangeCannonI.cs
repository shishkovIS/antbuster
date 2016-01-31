using UnityEngine;
using System.Collections;

public class LongRangeCannonI : Cannon {


    public override void initialize()
    {
        Level = 3;
        Type = CannonType.LongRangeCannonI;
        CannonName = "Long Range Cannon I";
        Range = 140;
        Frequency = 3;
        TimeBeforeShoot = 0;
        Cost = 65;
        Speed = 5;
        Damage = 2;
        target = null;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.LongRangeCannonII;
        gradeTree[1] = CannonType.ElectricCannonI;
        gradeTree[2] = CannonType.Nothing;
        gradeTree[3] = CannonType.QuickCannon;
        prefabs = new GameObject[4];
        prefabs[0] = Resources.Load("Prefabs/LongRangeCannonII") as GameObject;
        prefabs[1] = Resources.Load("Prefabs/ElectricCannonI") as GameObject;
        prefabs[2] = null;
        prefabs[3] = Resources.Load("Prefabs/QuickCannon") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }
}
