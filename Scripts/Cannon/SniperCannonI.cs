using UnityEngine;
using System.Collections;

public class SniperCannonI : Cannon {
    public override void initialize()
    {
        Level = 3;
        Type = CannonType.SniperCannonI;
        CannonName = "Sniper Cannon I";
        Range = 100;
        Frequency = 4;
        TimeBeforeShoot = 0;
        Cost = 80;
        Speed = 12;
        Damage = 1;
        target = null;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.SniperCannonII;
        gradeTree[1] = CannonType.LaserI;
        gradeTree[2] = CannonType.Nothing;
        gradeTree[3] = CannonType.QuickCannon;
        prefabs = new GameObject[4];
        prefabs[0] = Resources.Load("Prefabs/SniperCannonII") as GameObject;
        prefabs[1] = Resources.Load("Prefabs/LaserI") as GameObject;
        prefabs[2] = null;
        prefabs[3] = Resources.Load("Prefabs/QuickCannon") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }
}
