using UnityEngine;
using System.Collections;

public class BoxBehaviour : UnitBehaviour {

    
    

	public void Start ()
    {
        this.generPosition = new Vector3(-346, 10, 208);
        this.cakePosition = new Vector3(152, 10, -191);
        this.currentDirectionVector = new Vector3();
        this.center = new Vector3(0, 10, 0);


        this.DeathTime = 2;
        this.hasCake = false;
        this.Destroyed= false;
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

        startMoving();





        
   
	}
    protected override void startMoving()
    {
        HealthPoint = GameObject.Find("BoxManager").GetComponent<MobGenerator>().MobsHP;
        MaxHealthPoint = HealthPoint;
        Level = GameObject.Find("BoxManager").GetComponent<MobGenerator>().Level;
        ChangeDirectionTime = normalChangeDirectionTime;
        SpeedFactor = normalSpeedFactor;
        InvokeRepeating("changeVector", 0.0f, ChangeDirectionTime); 
    }
	public void Update () {

        if (!Destroyed)
        {
            checkDestroy();
            checkSlow();
            checkCake();
            transformation();
        }
        else
        {
            checkTotalDestroy();
        }
        this.transform.FindChild("DamageModel").transform.localPosition = new Vector3(0, 0, 0);
      //  this.rigidbody.angularDrag = 0;
    //  this.rigidbody.angularVelocity = new Vector3(0,0,0);
    //  this.rigidbody.velocity = new Vector3(0,0,0);
    //  this.rigidbody.drag = 0;

    }


    override protected void changeVector()
    {
        if (!boxIsOutside)
        {
            Vector3[] directionVector = new Vector3[numberOfVectors];
            Vector3 thisPosition = this.transform.position;
            Vector3 targetPosition;
            if (hasCake)
            {
                targetPosition = generPosition;
            }
            else
            {
                targetPosition = cakePosition;
            }

            Vector3 direction = targetPosition - thisPosition;

            float Alpha;

            directionVector[numberOfVectors - 1] = direction.normalized;

            if (Mathf.Abs(direction.magnitude) <= destroyDistance) destroyBox();
            Alpha = Mathf.Acos(direction.normalized.z);

            for (int i = 0; i < numberOfVectors - 1; i++)
            {
                Alpha -= movingAngleCorrector;
                directionVector[i] = new Vector3(Mathf.Cos(Alpha), direction.normalized.y, Mathf.Sin(Alpha));
            }

            double separator = Random.value;

            Vector3 newVector = new Vector3();

            if ((separator >= randomDistribution[0]) && (separator < randomDistribution[1]))
                newVector = directionVector[0];
            if ((separator >= randomDistribution[1]) && (separator < randomDistribution[2]))
                newVector = directionVector[1];
            if ((separator >= randomDistribution[2]) && (separator < randomDistribution[3]))
                newVector = directionVector[2];
            if ((separator >= randomDistribution[3]) && (separator < randomDistribution[4]))
                newVector = directionVector[3];
            if ((separator >= randomDistribution[4]) && (separator < randomDistribution[5]))
                newVector = directionVector[4];
            if ((separator >= randomDistribution[5]) && (separator < randomDistribution[6]))
                newVector = directionVector[5];
            if ((separator >= randomDistribution[6]) && (separator < randomDistribution[7]))
                newVector = directionVector[6];

            currentDirectionVector = newVector;

        }
    }

    override protected void changeVectorOnEdge()
    {
        boxIsOutside = true;
        Vector3 thisPosition = this.transform.position;
        Vector3 direction = center - thisPosition;
        currentDirectionVector = direction.normalized;
    
    }
    override protected void boxIsInside()
    {
        boxIsOutside = false;
    }

    override protected void destroyBox()
    {
       
        GameObject.Find("BoxManager").SendMessage("MobDeath",Level);
        this.transform.FindChild("Zombak").GetComponent<Animator>().SetBool("isDead", true);
        Destroyed = true;
        this.transform.GetComponent<AudioSource>().Play();
        this.transform.FindChild("DamageModel").transform.tag = "Untagged";
    }

    override protected void checkTotalDestroy()
    {
        if (DeathTime >= 0)
        {
            DeathTime -= Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    override protected void applyDamage(int Damage)
    {
        HealthPoint -= Damage;
        this.transform.SendMessage("ChangeHP");
    }


 
    override protected void applySlow()
    {
        if (SpeedFactor > minSpeedFactor)
        {
            SpeedFactor -= deltaSpeedFactor;
            SlowTime = MaxSlowTime;
           if (SpeedFactor <= normalSpeedFactor) ChangeDirectionTime -= deltaChangeDirectionTime;
        }
        else
        {
            SlowTime = MaxSlowTime;
        }
    }


    override protected void applyFast()
    {
        if (SpeedFactor < maxSpeedFactor)
        {
            SpeedFactor += deltaSpeedFactor;
            SlowTime = MaxSlowTime;
            if (SpeedFactor <= normalSpeedFactor) ChangeDirectionTime += deltaChangeDirectionTime;
        }
        else
        {
            SlowTime = MaxSlowTime;
        }
    }


   /* void getPoison()
    {
        HealthPoint -= OnPoison;
        OnPoison -= DeltaPoison;
        if (OnPoison < 0) OnPoison = 0;
    }*/

    override protected void nearCannon(Transform Cannon)
    {
        Vector3 Direction = Cannon.transform.position - this.transform.position;
        Direction = -Direction.normalized;
        currentDirectionVector = Direction;
    }


    override protected void checkCake()
    {
        Vector3 ThisPosition = this.transform.position;
        Vector3 CakeDifference = ThisPosition - cakePosition;
        Vector3 GenerDifference = ThisPosition - generPosition;
        if ((hasCake==false)&& (Mathf.Abs(CakeDifference.magnitude) <= destroyDistance)) changeBehaviour();
        if ((hasCake == true) && (Mathf.Abs(GenerDifference.magnitude) <= destroyDistance)) destroyBox();
    }

    override protected void checkSlow()
    {
        if (SpeedFactor != normalSpeedFactor)
        {
            if (SlowTime <= 0)
            {
                if (SpeedFactor < normalSpeedFactor)
                {
                    SpeedFactor += deltaSpeedFactor;
                }
                else
                {
                    SpeedFactor -= SpeedFactor;
                }

                if (SpeedFactor <= normalSpeedFactor)
                {
                    ChangeDirectionTime += deltaChangeDirectionTime;
                }
                SlowTime = MaxSlowTime;
            }
            else
            {
                SlowTime -= Time.deltaTime;
            }
        }
    }

 /*   void checkPoison()
    {
        if (OnPoison > 0)
        {
            if (TimeToGetPoison <= 0)
            {
                getPoison();
                TimeToGetPoison = PoisonRecharge;
            }
            else
            {
                TimeToGetPoison -= Time.deltaTime;
            }

        }
    }*/

   /* void checkLaser()
    {
        if (onLaser)
        {
            HealthPoint -= LaserDamage;
           
        }
    } */



    override protected void checkDestroy()
    {
        if (HealthPoint <= 0) destroyBox();  
    }

    override protected void transformation()
    {
        Quaternion boxRotation = Quaternion.FromToRotation(Vector3.forward, currentDirectionVector);
        Vector3 boxPosition = this.transform.position;
        if (boxPosition.y != PositionY)
         {
             boxPosition.y = 12;
         }
        this.transform.position = boxPosition;
       transform.rotation = Quaternion.Slerp(transform.rotation, boxRotation, Time.deltaTime * RotationFactor);

        transform.Translate(Vector3.forward * Time.deltaTime * SpeedFactor);
        
    }

    override protected void changeBehaviour()
    {
        if (!hasCake)
        {
            hasCake = true;
           // this.transform.renderer.material.mainTexture = red;
        }
    }
  
 
}
