using UnityEngine;
using System.Collections;

public class MissileLauncher : Cannon {


    public override void initialize()
    {
        Level = 4;
        Type = CannonType.MissileLauncherI;
        CannonName = "Missile Launcher I";
        Range = 160;
        Frequency = 0.5f;
        TimeBeforeShoot = 0;
        Cost = 772;
        Speed = 4;
        Damage = 16;
        target = null;
        gradeTreeSize = 3;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.MissileLauncherII;
        gradeTree[1] = CannonType.Nothing;
        gradeTree[2] = CannonType.Nothing;
        gradeTree[3] = CannonType.Degrade;

        prefabs = new GameObject[4];
        prefabs[0] = Resources.Load("Prefabs/MissileLauncherII") as GameObject;
        prefabs[1] = null;
        prefabs[2] = null;
        prefabs[3] = Resources.Load("Prefabs/HeavyCannonII") as GameObject;

        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }

}
