using UnityEngine;
using System.Collections;

public class BossBehaviour : BoxBehaviour {

    public Transform AttackCannon;
    public bool CannonUnderAttack = false;
  
    void Start()
    {
        this.generPosition = new Vector3(-346, 10, 208);
        this.cakePosition = new Vector3(152, 10, -191);
        this.currentDirectionVector = new Vector3();
        this.center = new Vector3(0, 10, 0);


        this.DeathTime = 2;
        this.hasCake = false;
        this.Destroyed = false;
        this.SlowTime = 0;
        this.MaxSlowTime = 2;


        this.normalChangeDirectionTime = 1;
        this.maxSpeedFactor = 60;
        this.normalSpeedFactor = 40;
        this.deltaSpeedFactor = 5;
        this.deltaChangeDirectionTime = .1f;
        this.minSpeedFactor = 15;





        this.destroyDistance = 20;

        this.numberOfVectors = 7;

        this.PositionY = 10;
        this.boxIsOutside = false;


        this.randomDistribution = new float[] {
            0, .16f, .29f, .36f, .43f, .56f, .72f, 1
        };
    





        this.normalChangeDirectionTime = 2;
        this.maxSpeedFactor = 20;
        this.normalSpeedFactor = 20;
        this.deltaSpeedFactor = 0;
        this.deltaChangeDirectionTime = 0;
        this.minSpeedFactor = 20;

        startMoving();
    }
    void Update()
    {
        base.Update();
       // Debug.Log(this.HealthPoint);
    }

    protected override void transformation()
    {
        if (CannonUnderAttack)
        {
            Vector3 LookPosition = AttackCannon.transform.position;
            LookPosition.y = this.transform.position.y;
            this.transform.rotation = Quaternion.LookRotation(LookPosition - this.transform.position); 
        }
        else
        {

            base.transformation();
        }
    }
        protected override void nearCannon(Transform Cannon)
        {
             AttackCannon = Cannon;
             CannonUnderAttack = true;
             this.transform.FindChild("Zombak").GetComponent<Animator>().SetBool("Attack", true);
             AttackCannon.transform.SendMessage("BossAttack",this.transform);
        }

        void cannonIsDestroyed()
        {
            CannonUnderAttack = false;
            this.transform.FindChild("Zombak").GetComponent<Animator>().SetBool("Attack", false);
        }
}
