using UnityEngine;
using System.Collections;
using pumpkin.display;
using pumpkin.events;
using pumpkin.ui;
using pumpkin.text;


public class CannonElipse : MonoBehaviour
{
    
    Stage stage;
    MovieClip Ellipse;
    MovieClip [] UButtons = new MovieClip[4];
    MovieClip InfoField;
    TextField CannonName;
    TextField Cost;
    TextField Info;

    Vector3 GeneratePosition;

    GameObject ButtonField;
    public Transform SelectedCannon;

    GameObject CurrentField;
    int ScaleY = 480;
    int ScaleX = 840;

    int ScaleParameter = 2500;
    int ButtonScale = 1800;

    int[] clicked = new int[4]{0,0,0,0};
    bool infoIsAddedToStage = false;
    void Start()
    {
        ButtonField = Resources.Load("Prefabs/ButtonField") as GameObject;
        InfoField = new MovieClip("swf/Ellipse.swf:InfoField");
        InfoField.gotoAndStop(1);
        CannonName = InfoField.getChildByName<TextField>("CannonName");
        Cost = InfoField.getChildByName<TextField>("Cost");
        Info = InfoField.getChildByName<TextField>("Info");
    }

    void Generate(Transform Cannon)
    {
        SelectedCannon = Cannon;
        GeneratePosition = Cannon.position;
        if (Camera.main.GetComponent<MovieClipOverlayCameraBehaviour>() == null)
        {
            return;
        }
        stage = Camera.main.GetComponent<MovieClipOverlayCameraBehaviour>().stage;
       
        CurrentField = Instantiate(ButtonField, GeneratePosition, Quaternion.identity)as GameObject;
        CurrentField.transform.parent = SelectedCannon.transform;
        SelectedCannon.transform.FindChild("VisibleRange").gameObject.SetActive(true);
        GenerateButtons();

      
 
    }
    
    void GenerateEllipse()
    {
        Ellipse = new MovieClip("swf/Ellipse.swf:Elipse");


        Ellipse.gotoAndStop(1);

        Ellipse.x = (GeneratePosition.x + 405) * Screen.width / ScaleX;
        Ellipse.y = -1 * (GeneratePosition.z - 242) * Screen.height / ScaleY;
        Ellipse.scaleX = (float)Screen.width / ScaleParameter;
        Ellipse.scaleY = Ellipse.scaleX;

        stage.addChild(Ellipse);
    }
    
    void Destroy()
    {
        SelectedCannon.transform.FindChild("VisibleRange").gameObject.SetActive(false);
        CannonType[] leaves = SelectedCannon.GetComponent<Shoot>().gradeTree;
        for (int i = 0; i < 4; i++)
        {
            if (leaves[i] != CannonType.Nothing)
                stage.removeChild(UButtons[i]);
        }
        DestroyImmediate(CurrentField,true);
        
        if (infoIsAddedToStage)
        {
            stage.removeChild(InfoField);
            for (int i = 0; i < 4; i++)
                clicked[i] = 0;
        }
        infoIsAddedToStage = false;
    }


    void GenerateButtons()
    {
        CannonType[] leaves = SelectedCannon.GetComponent<Shoot>().gradeTree;
        
        for (int i = 0; i < 4; i++)
        {
            UButtons[i] = new MovieClip("swf/Ellipse.swf:Icon1");
            UButtons[i].gotoAndStop((int)leaves[i]);
            UButtons[i].scaleX = (float)Screen.width / ButtonScale;
            UButtons[i].scaleY = UButtons[i].scaleX;

        }

        int shuffle = 100;
       
       
            UButtons[0].x = (GeneratePosition.x+285+shuffle)*Screen.width/ScaleX;
            UButtons[0].y = -1*(GeneratePosition.z-210)*Screen.height/ScaleY;

            UButtons[1].x = (GeneratePosition.x + 355+shuffle) * Screen.width / ScaleX;
            UButtons[1].y = -1 * (GeneratePosition.z - 210) * Screen.height / ScaleY;
        
            UButtons[2].x = (GeneratePosition.x + 285+shuffle) * Screen.width / ScaleX;
            UButtons[2].y = -1 * (GeneratePosition.z - 274) * Screen.height / ScaleY;

            UButtons[3].x = (GeneratePosition.x + 355+shuffle) * Screen.width / ScaleX;
            UButtons[3].y = -1 * (GeneratePosition.z - 274) * Screen.height / ScaleY;

            UButtons[0].addEventListener(MouseEvent.CLICK, Clicked0);
            UButtons[1].addEventListener(MouseEvent.CLICK, Clicked1);
            UButtons[2].addEventListener(MouseEvent.CLICK, Clicked2);
            UButtons[3].addEventListener(MouseEvent.CLICK, Clicked3);

            for (int i = 0; i < 4; i++)
            {
                if (leaves[i] != CannonType.Nothing)
                {
                    stage.addChild(UButtons[i]);
                }
            }



            
    }

    void Clicked(int id)
    {
        int Cost=0;
        for (int i = 0; i < 4; i++)
        {
            if (i != id)
            {
                clicked[i] = 0;
            }
        }

        if (clicked[id] == 0)
          {
             ShowInfo(id);
             clicked[id]++;
          }
         else
         if (clicked[id] == 1)
           {

              int Credits = GameObject.Find("BoxManager").GetComponent<BoxManager>().Credits;
              if (id == 3)
              {
                  if (SelectedCannon.GetComponent<Shoot>().gradeTree[id] == CannonType.Degrade)
                  {
                      Cost = -1 * (SelectedCannon.GetComponent<Shoot>().Cost / 2);
                  }
                  else
                  {
                      Cost = -20; //цена пушки на продажу
                  }
              }
              else
              {
                 Cost = SelectedCannon.GetComponent<Shoot>().prefabs[id].GetComponent<Shoot>().Cost;
              }
              if (Credits >= Cost)
                {
                    GameObject.Find("BoxManager").SendMessage("DecreaseCredits", Cost);
                    for (int i = 0; i < 4; i++)
                       clicked[i] = 0;
                    CreateCannon(id);
                }
            }
    }
    void Clicked0(CEvent e)
    {
        Clicked(0);
    }

    void Clicked1(CEvent e)
    {
        Clicked(1);
    }
    void Clicked2(CEvent e)
    {
        Clicked(2);
    }
    void Clicked3(CEvent e)
    {
        Clicked(3);
    }

    void ShowInfo(int id)
    {
        if (infoIsAddedToStage)
        {
            stage.removeChild(InfoField);

        }

        switch (id)
        {
            case 0:
                {
                    InfoField.x = (GeneratePosition.x + 420) * Screen.width / ScaleX;
                    InfoField.y = -1 * (GeneratePosition.z - 160) * Screen.height / ScaleY;
                    break;
                }
            case 1:
                {
                    InfoField.x = (GeneratePosition.x + 420) * Screen.width / ScaleX;
                    InfoField.y = -1 * (GeneratePosition.z - 160) * Screen.height / ScaleY;
                    break;
                }
            case 2:
                {
                    InfoField.x = (GeneratePosition.x + 420) * Screen.width / ScaleX;
                    InfoField.y = -1 * (GeneratePosition.z - 320) * Screen.height / ScaleY;
                    break;
                }
            case 3:
                {
                    InfoField.x = (GeneratePosition.x + 420) * Screen.width / ScaleX;
                    InfoField.y = -1 * (GeneratePosition.z - 320) * Screen.height / ScaleY;
                    break;
                }
        }
        
        InfoField.scaleX = (float)Screen.width / ScaleParameter;
        InfoField.scaleY = InfoField.scaleX;


        if (id == 3)
        {
            if (SelectedCannon.GetComponent<Shoot>().gradeTree[3] == CannonType.Sell)
            {
                CannonName.text = "Sell";
                Cost.text = "";
                Info.text = "";
            }
            if (SelectedCannon.GetComponent<Shoot>().gradeTree[3] == CannonType.Degrade)
            {
                CannonName.text = "Degrade";
                Cost.text = "";
                Info.text = "";
            }

        }
        else
        {
            SelectedCannon.GetComponent<Shoot>().prefabs[id].GetComponent<Cannon>().initialize();
            CannonName.text = SelectedCannon.GetComponent<Shoot>().prefabs[id].GetComponent<Shoot>().CannonName;
            Cost.text = SelectedCannon.GetComponent<Shoot>().prefabs[id].GetComponent<Shoot>().Cost + " $";



            Info.text = "Frequency: " + SelectedCannon.GetComponent<Shoot>().prefabs[id].GetComponent<Shoot>().Frequency + "\n" + "Speed: " +
               SelectedCannon.GetComponent<Shoot>().prefabs[id].GetComponent<Shoot>().Speed + "\n" +
               "Range: " + SelectedCannon.GetComponent<Shoot>().prefabs[id].GetComponent<Shoot>().Range + "\n" + "Damage: " +
               SelectedCannon.GetComponent<Shoot>().prefabs[id].GetComponent<Shoot>().Damage;

        }
        

        stage.addChild(InfoField);

        infoIsAddedToStage = true;
    }

    void CreateCannon(int id)
    {
        Destroy(SelectedCannon.gameObject);
        GameObject prefab = SelectedCannon.GetComponent<Shoot>().prefabs[id];

        if (prefab != null)
        {
            Vector3 pos = SelectedCannon.position;
            GameObject newCannon = Instantiate(prefab, pos, Quaternion.identity) as GameObject;
            newCannon.transform.FindChild("VisibleRange").gameObject.SetActive(false);
        }
        GameObject.Find("BoxManager").SendMessage("CancelSelection");
        GameObject.Find("Menu").SendMessage("changeName", "");
        GameObject.Find("Menu").SendMessage("changeInfo", new float[4] { 0, 0, 0, 0 });
    }
}
