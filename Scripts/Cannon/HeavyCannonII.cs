using UnityEngine;
using System.Collections;

public class HeavyCannonII : HeavyCannon {

	// Use this for initialization
    public override void initialize()
    {
        Level = 3;
        Type = CannonType.HeavyCannonII;
        CannonName = "Heavy Cannon II";
        Range = 100;
        Frequency = 3;
        TimeBeforeShoot = 0;
        Cost = 60;
        Speed = 4;
        Damage = 4;
        target = null;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.HeavyCannonIII;
        gradeTree[1] = CannonType.MissileLauncherI;
        gradeTree[2] = CannonType.Nothing;
        gradeTree[3] = CannonType.Degrade;
        prefabs = new GameObject[4];
        prefabs[0] = Resources.Load("Prefabs/HeavyCannonIII") as GameObject;
        prefabs[1] = Resources.Load("Prefabs/MissileLauncher") as GameObject;
        prefabs[2] = null;
        prefabs[3] = Resources.Load("Prefabs/HeavyCannon") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }
}
