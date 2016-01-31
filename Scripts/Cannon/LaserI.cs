using UnityEngine;
using System.Collections;

public class LaserI : Cannon {
    float CurrentLaserTime;
    float MaxLaserTime = 0.4f;
    bool isShooting;

    public LineRenderer Line;
    public Transform EndOfBeam;

    public override void initialize()
    {
        Level = 4;
        Type = CannonType.LaserI;
        CannonName = "Laser I";
        Range = 150;
        Frequency = 1;
        TimeBeforeShoot = 0;
        Cost = 460;
        Speed = 1;
        Damage = 12;
        target = null;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.LaserII;
        gradeTree[1] = CannonType.Nothing;
        gradeTree[2] = CannonType.Nothing;
        gradeTree[3] = CannonType.Degrade;
        prefabs = new GameObject[4];
        prefabs[0] = Resources.Load("Prefabs/LaserII") as GameObject;
        prefabs[1] = null;
        prefabs[2] = null;
        prefabs[3] = Resources.Load("Prefabs/SniperCannonI") as GameObject;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;

        Line = this.transform.FindChild("PivotPoint").GetComponent<LineRenderer>() as LineRenderer;
        EndOfBeam = this.transform.FindChild("PivotPoint").transform.FindChild("EndOfBeam");
        
        Line.SetWidth(0, 0);
    }

    protected override void generateBullet()
    {
        TimeBeforeShoot = CannonReloadTime;
        CurrentLaserTime = MaxLaserTime;
        isShooting = true;
        LineActivate();
        this.transform.FindChild("PivotPoint").transform.FindChild("LaserCollider").SendMessage("attackAll");
        
    }
    void Update()
    {
        base.Update();
        if (isShooting)
        {
            checkShoot();
        }
    }
    void checkShoot()
    {
        if (CurrentLaserTime > 0)
        {
            CurrentLaserTime -= Time.deltaTime;
        }
        else
        {
            isShooting = false;
            LineDeactivate();
        }
    }
    void LineActivate()
    {
        Line.SetVertexCount(2);
        Line.SetPosition(0, EndOfBeam.transform.position);
        Line.SetPosition(1, this.transform.position);
        Line.SetWidth(3,3);

    }

    void LineDeactivate()
    {
        Line.SetWidth(0, 0);
    }
    protected override void rotate(Transform pivot)
    {
        if (!isShooting)
        {
            base.rotate(pivot);
        }
    }
}
