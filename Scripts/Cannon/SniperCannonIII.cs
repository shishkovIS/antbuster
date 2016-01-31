using UnityEngine;
using System.Collections;

public class SniperCannonIII :Cannon {

    public override void initialize()
    {
        Level = 5;
        Type = CannonType.SniperCannonIII;
        CannonName = "Sniper Cannon III";
        Range = 150;
        Frequency = 4.8f;
        TimeBeforeShoot = 0;
        Cost = 1100;
        Speed = 16;
        Damage = 12;
        target = null;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.Nothing;
        gradeTree[1] = CannonType.Nothing;
        gradeTree[2] = CannonType.Nothing;
        gradeTree[3] = CannonType.SniperCannonII;
        prefabs = new GameObject[4];
        prefabs[0] = null;
        prefabs[1] = null;
        prefabs[2] = null;
        prefabs[3] = Resources.Load("Prefabs/SniperCannonII") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }
}
