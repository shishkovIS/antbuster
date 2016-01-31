using UnityEngine;
using System.Collections;

public class MissileLauncherII : MissileLauncher {

	// Use this for initialization
    public override void initialize()
    {
        Level = 5;
        Type = CannonType.MissileLauncherI;
        CannonName = "Missile Launcher II";
        Range = 180;
        Frequency = 0.5f;
        TimeBeforeShoot = 0;
        Cost = 772;
        Speed = 4;
        Damage = 36;
        target = null;
        gradeTreeSize = 3;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.Nothing;
        gradeTree[1] = CannonType.Nothing;
        gradeTree[2] = CannonType.Nothing;
        gradeTree[3] = CannonType.Degrade;

        prefabs = new GameObject[4];
        prefabs[0] = null;
        prefabs[1] = null;
        prefabs[2] = null;
        prefabs[3] = Resources.Load("Prefabs/MissileLauncher") as GameObject;

        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }
}
