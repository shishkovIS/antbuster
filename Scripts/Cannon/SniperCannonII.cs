using UnityEngine;
using System.Collections;

public class SniperCannonII :Cannon {

    public override void initialize()
    {
        Level = 4;
        Type = CannonType.SniperCannonII;
        CannonName = "Sniper Cannon II";
        Range = 120;
        Frequency = 3;
        TimeBeforeShoot = 0;
        Cost = 352;
        Speed = 12;
        Damage = 4;
        target = null;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.SniperCannonIII;
        gradeTree[1] = CannonType.Nothing;
        gradeTree[2] = CannonType.Nothing;
        gradeTree[3] = CannonType.SniperCannonI;
        prefabs = new GameObject[4];
        prefabs[0] = Resources.Load("Prefabs/SniperCannonIII") as GameObject;
        prefabs[1] = null;
        prefabs[2] = null;
        prefabs[3] = Resources.Load("Prefabs/SniperCannonI") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }
}
