using UnityEngine;
using System.Collections;

public class LaserII : LaserI {

    public override void initialize()
    {
        Level = 5;
        Type = CannonType.LaserII;
        CannonName = "Laser II";
        Range = 160;
        Frequency = 1.2f;
        TimeBeforeShoot = 0;
        Cost = 1297;
        Speed = 1;
        Damage = 30;
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
        prefabs[3] = Resources.Load("Prefabs/LaserI") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;

        Line = this.transform.FindChild("PivotPoint").GetComponent<LineRenderer>() as LineRenderer;
        EndOfBeam = this.transform.FindChild("PivotPoint").transform.FindChild("EndOfBeam");
    }
}
