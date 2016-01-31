using UnityEngine;
using System.Collections.Generic;

public class Cannon : Shoot {

    bool Destroyed=false;
    float maxDestroyTime = 2;
    float DestroyTime;
    public int RangeCoefficient = 2;
    float infinity = 220;

    public Transform Boss;
    public float RotationFactor;


    float AdjustRotationZ = 0;
   
    public float CannonReloadTime;
    protected float TimeBeforeShoot;

    void Start () {
        initialize();
        setRange();

	}


   public override void initialize()
    {
        Level = 1;
        Type = CannonType.SimpleCannon;
        CannonName = "Simple Cannon";
        Range = 100;
        Frequency = 3;
        TimeBeforeShoot = 0;
        Cost = 30;
        Speed = 4;
        Damage = 1;
        target = null;
        gradeTreeSize = 3;
        gradeTree = new CannonType[4];
        gradeTree[0] = CannonType.HeavyCannon;
        gradeTree[1] = CannonType.QuickCannon;
        gradeTree[2] = CannonType.DoubleCannon;
        gradeTree[3] = CannonType.Sell;
        
        prefabs = new GameObject[4];
        prefabs[0] = Resources.Load("Prefabs/HeavyCannon") as GameObject;
        prefabs[1] = Resources.Load("Prefabs/QuickCannon") as GameObject;
        prefabs[2] = Resources.Load("Prefabs/DoubleCannon") as GameObject;
        prefabs[3] = null;
        parent = null;
        CannonReloadTime = (float)1 / Frequency;
        RotationFactor = 20;
    }

    protected override void setRange()
    {
        Transform VisibleRange = this.transform.FindChild("VisibleRange") as Transform;
        VisibleRange.localScale = new Vector3(this.Range*RangeCoefficient, 5, this.Range*RangeCoefficient);
    }

	public void Update () {
        if (Destroyed)
        {
            checkDestroyTime();
        }
        else
        {
            changeReloadTime();

            if (target == null)
            {
                setNoTarget();
                target = chooseNewTarget();
            }
            else
            {

                float currentDistance = Vector3.Distance(this.transform.position, target.transform.position);

                if ((currentDistance > Range) || (target.transform.tag != "enemy"))
                {
                    setNoTarget();

                }
                else
                {
                    shootAndTransform();

                }
            }
        }
    }


    protected override void shootAndTransform()
    {
        if (TimeBeforeShoot == 0)
        {
            generateBullet();
        }

        Transform barrel = this.transform.Find("PivotPoint");
        rotate(barrel);
    }


    protected override void rotate(Transform pivot)
    {
        Quaternion beginRotation = pivot.transform.rotation;
        Quaternion endRotation = Quaternion.LookRotation(target.transform.position - this.transform.position);


        beginRotation = adjustRotation(beginRotation);
        endRotation = adjustRotation(endRotation);

        pivot.transform.rotation = Quaternion.Slerp(beginRotation, endRotation, Time.deltaTime * RotationFactor); 
    }

    protected override void generateBullet()
    {
        
            TimeBeforeShoot = CannonReloadTime;

            Transform pivot = this.transform.Find("PivotPoint");
            Transform barrel = pivot.transform.Find("Capsule");

            GameObject NewBullet = (GameObject)Instantiate(bullet, barrel.transform.position + pivot.forward.normalized * 10, barrel.transform.rotation) as GameObject;
            NewBullet.transform.parent = this.transform;
    }


    

    override protected Transform chooseNewTarget()
    {
        List<Transform> ListOfTargets = new List<Transform>();
        Collider[] ItemsInRange = Physics.OverlapSphere(transform.position, Range);

        int cols = 0;
     
        foreach (Collider item in ItemsInRange)
        {
            
            if ((item.tag == "enemy") || (item.tag == "boss"))
            {   
                ListOfTargets.Add(item.transform);
                cols++;
            }
        }


        float minDistance = infinity;
        Transform desiredTarget = null;

        if (cols > 0)
        {
            foreach (Transform potentialTarget in ListOfTargets)
            {

                float currentDistance = Vector3.Distance(this.transform.position, potentialTarget.transform.position);
                if (currentDistance < minDistance)
                {
                    minDistance = currentDistance;
                    desiredTarget = potentialTarget;
                }

            }
        }

        return desiredTarget;
    }

    override protected void changeReloadTime()
    {
        if (TimeBeforeShoot > 0)
        {
            TimeBeforeShoot -= Time.deltaTime;
            
        }
        if (TimeBeforeShoot < 0)
        {
            TimeBeforeShoot = 0;
        }
    }


    override protected void setNoTarget()
    {
        target = null;
    }

    override protected Quaternion adjustRotation(Quaternion inQuaternion)
    {
        Vector3 adjustVector = inQuaternion.eulerAngles;
        adjustVector.x = 0; 
   
        adjustVector.z = AdjustRotationZ;
        inQuaternion = Quaternion.Euler(adjustVector);
        return inQuaternion;
    }


    /* void onTriggerStay(Collider e)
   {
    
       if ((target == null) && (e.gameObject.tag == "enemy"))
       {
           target = e.gameObject.transform;
       }
   }
*/
    /* void onTriggerExit(Collider e)
     {
         if (e.gameObject.Equals(target.gameObject))
         {
             target = null;
         }
     }*/
   public void BossAttack(Transform Boss)
    {
        this.Boss = Boss;
        Destroyed = true;
        DestroyTime = maxDestroyTime;
    }

    void checkDestroyTime()
    {
        if (DestroyTime > 0)
        {
            DestroyTime -= Time.deltaTime;
        }
        else
        {
            Boss.transform.SendMessage("cannonIsDestroyed");
            Transform SelectedCannon = GameObject.Find("CannonMenu").GetComponent<CannonElipse>().SelectedCannon;
            if (SelectedCannon == this.transform)
            {
                GameObject.Find("CannonMenu").SendMessage("Destroy");
            }
            Destroy(this.gameObject);
            
        }
    }
}
