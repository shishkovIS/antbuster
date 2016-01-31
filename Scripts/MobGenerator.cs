using UnityEngine;
using System.Collections;

public class MobGenerator : MonoBehaviour {
   public Transform Mob;
   bool BossLevel = false;
   public Transform Boss;
   Transform generMob;
   public int Level  = 0;
    int MobsInWave;
    bool LevelComplete = false;
    float DeltaGenerationTime = 1;
    float CurrentGenerationTime;
    int CurrentMobsInWave;
    int GeneratedInCurrentWave;
    public int MobsHP;
    int MobsQueue=0;

    int KilledInCurrentWave = 0;
    Vector3 generPosition;

	void Start () {
        Level = 0;
        newWave();
	}
	
	void Update () {

       
        
            checkGenerateQueue();
        
	}
    
    void checkGenerateQueue()
    {
        if (MobsQueue > 0)
        {
            if (CurrentGenerationTime < 0)
            {
                MobsQueue--;
                Vector3 r1 = new Vector3(-351.028f, -10, 206.8316f);
                CurrentGenerationTime = DeltaGenerationTime;
                if (BossLevel)
                {
                    generMob = Boss;
                }
                else
                {
                    generMob = Mob;
                }
                Transform newBox = Instantiate(generMob, r1, Quaternion.identity) as Transform;
              
            }
            else
            {
                CurrentGenerationTime -= Time.deltaTime;
            }
        }
    }

    void MobDeath()
    {
       
        KilledInCurrentWave++;
        if (KilledInCurrentWave == MobsInWave)
        {
            
            newWave();
        }
    }

    void newWave()
    {

        KilledInCurrentWave = 0;
        Level++;

        if (Level % 5 == 0)
        {
            BossLevel = true;
            MobsInWave = 1;
            MobsHP = (Level / 5) * 200;
        }
        else
        {
            BossLevel = false;
           MobsInWave = 5 * Level;
          //  MobsInWave = 1;
            MobsHP = (int)(Level*Mathf.Log(Level+2)); // NLogN
        
        }



        InitCurrentWave();
        ShowLevelComplete();
    }

    void InitCurrentWave()
    {
        MobsQueue = MobsInWave;
    }

    void ShowLevelComplete()
    {
       GameObject.Find("Menu").SendMessage("ShowLevelComplete",Level);
    }

}
