using UnityEngine;
using System.Collections;

public class BoxManager : MonoBehaviour {
     RaycastHit hit;

     public  int[] BasicCannonCost = new int []{30,45,67,100,150,225,337,505,757,1135,1702,2553,3829,5743,8614,12921,19381,29071,43606,65409,98113,147619,220753,331129,496693,745039,1117558}; 
     public Texture right;
     public Texture wrong; 

     public Transform prefab;
     public Transform ghostPrefab;
     public Transform cannonPrefab;

     Transform Ghost;

     Vector3 generPosition;
     public int boxCount;
     public int cannonCount;
     int boxMax = 10;
     bool isPaused = false;
     public int Score = 0;
     public int Credits = 50000;
     int CurrentLevel = 1;
     int ColsByLevel = 5;
     int CurrentCols = 0;
     Transform selected = null;
     bool CreateCannon = false;

     Vector3 GhostPosition;

     float[] CannonParameters = new float[4] { 0, 0, 0, 0 };
     

     bool canCreate = true;


	void Start () {
    
    }

    void Update()
    {   
        if (isPaused)
            return;
        if (CreateCannon)
        {
            CreationProcess();
        }
        else
            if (Input.GetMouseButtonDown(0))
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 400f))
                {

                    if (hit.transform.tag == "cannon")
                    {
                        if ((selected == null) || ((selected != null) && (selected != hit.transform.parent)))
                        {
                       
                            string name = hit.transform.parent.GetComponent<Shoot>().CannonName;

                            if (selected != null) 
                            {
                                CancelSelection();
                               
                            }
                            selected = hit.transform.parent;
                            GameObject.Find("CannonMenu").SendMessage("Generate", hit.transform.parent);
                            GameObject.Find("Menu").SendMessage("changeName", name);
                            CannonParameters[0] = selected.GetComponent<Shoot>().Frequency;
                            CannonParameters[1] = selected.GetComponent<Shoot>().Damage;
                            CannonParameters[2] = selected.GetComponent<Shoot>().Range;
                            CannonParameters[3] = selected.GetComponent<Shoot>().Speed;

                            GameObject.Find("Menu").SendMessage("changeInfo", CannonParameters);
                            GameObject.Find("Menu").SendMessage("changeLevel",selected.GetComponent<Shoot>().Level);
                        }


                    }
                    else
                    {
                       
                        if (selected != null)
                            CancelSelection();
                        GameObject.Find("Menu").SendMessage("changeName", "");
                        GameObject.Find("Menu").SendMessage("changeInfo", new float [4]{0,0,0,0});
                    }
                }

            }

    }


    /*void  Generate()
    {
        if (boxCount < boxMax)
         {
             boxCount++; 
             Transform newBox = Instantiate(prefab, generPosition, Quaternion.identity) as Transform;
             newBox.transform.SendMessage("setLevel", CurrentLevel);
         } 
    }*/
    void MobDeath(int level)
    {
        Score += level;
        Credits += 30 * level;

        GameObject.Find("Menu").SendMessage("changeScore",Score);
        GameObject.Find("Menu").SendMessage("changeCredits", Credits);

    }
   

    void CancelSelection()
    {
        GameObject.Find("CannonMenu").SendMessage("Destroy");
        GameObject.Find("Menu").SendMessage("Deselect");
        selected = null;
        
    }

    void Creation()
    {
        if (!CreateCannon)
        {
            CreateCannon = true;
            canCreate = true;
        }
     
    }



    void CreationProcess()
    {  
        if (Ghost == null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
           
            Ghost = Instantiate(ghostPrefab, ray.origin, Quaternion.identity) as Transform;
 
        }

    
            Ray ray1 = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            GhostPosition = ray1.origin;
            GhostPosition.y = 10;
            Ghost.position = GhostPosition;

            if (Physics.Raycast(ray1, out hit, 400f))
            {
                if ((canCreate == true) && ((hit.transform.tag == "anticreation") || (hit.transform.tag == "cannon")))
                {
                    canCreate = false;
                    Ghost.transform.renderer.material.mainTexture = wrong;
                }
                else
                    if ((canCreate == false) && (hit.transform.tag != "anticreation") && (hit.transform.tag != "cannon"))
                    {
                        canCreate = true;
                        Ghost.transform.renderer.material.mainTexture = right;
                    }

            }
       
        
        if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {   
            Destroy(Ghost.gameObject);
            Ghost = null;
            if ((canCreate) && (BasicCannonCost[cannonCount]<=Credits))
            {
                Transform newCannon = Instantiate(cannonPrefab, GhostPosition, Quaternion.identity) as Transform;
                newCannon.transform.FindChild("VisibleRange").gameObject.SetActive(false);
                Credits -= BasicCannonCost[cannonCount];
                cannonCount++;
                GameObject.Find("Menu").SendMessage("changeCredits", Credits);
            }
            CreateCannon = false;
        } 

        
       
    }

    void PauseClick()
    {

        if (!isPaused)
        {
            Time.timeScale = 0.0f;
            GameObject.Find("PauseMenu").SendMessage("Activate");
        }
        else
        {
            Time.timeScale = 1.0f;
            GameObject.Find("PauseMenu").SendMessage("Deactivate");
        }
        isPaused = !isPaused;
    }

    void DecreaseCredits(int Cost)
    {
        Credits -= Cost;
        GameObject.Find("Menu").SendMessage("changeCredits", Credits);
    }
       
}
