using UnityEngine;
using System.Collections;
using pumpkin.display;
using pumpkin.events;
using pumpkin.ui;
using pumpkin.text;


public class MenuBar : MonoBehaviour {
    Stage stage;
    MovieClip Menu;
    MovieClip Pause;
    MovieClip Mute;
    MovieClip Create;
    MovieClip Bonus;

    TextField BonusField;
    TextField Level;
    TextField Score;
    TextField Credits;
    TextField Name;
    TextField Info;

    int ScaleParameterX = 2100;
    int ScaleParameterY = 2700;


    bool isPaused = false;
	void Start ()
    {
        if (GameObject.Find("Main Camera").GetComponent<MovieClipOverlayCameraBehaviour>() == null)
        {
            return;
        }
        stage = Camera.main.GetComponent<MovieClipOverlayCameraBehaviour>().stage;

       Menu = new MovieClip("swf/MenuBar.swf:MenuBar");
 
        
        Menu.gotoAndStop(1);
        Menu.x = Screen.width;
        Menu.y = Screen.height;
        Menu.scaleX = (float)Screen.width / ScaleParameterX;
        Menu.scaleY = (float)Screen.width/ScaleParameterY;

        Name = Menu.getChildByName<TextField>("Name");
        Name.text = "";

        Level = Menu.getChildByName<TextField>("Level");
        Level.text = "";

        Score = Menu.getChildByName<TextField>("Score");
        Score.text = "Score: 0";

        Credits = Menu.getChildByName<TextField>("Credits");
        Credits.text = "Credits:0";

        Info = Menu.getChildByName<TextField>("Info");
        Info.text = "";
        
        Pause = new MovieClip("swf/PauseMute.swf:Pause");
        Pause.gotoAndStop(1);
        Pause.x = Screen.width;
        Pause.y = 0;
        Pause.scaleX = (float)Screen.width / ScaleParameterX;
        Pause.scaleY = (float)Screen.width / ScaleParameterY;
        Pause.addEventListener(MouseEvent.CLICK,OnPauseClick);



        Mute = new MovieClip("swf/PauseMute.swf:Mute");
        Mute.gotoAndStop(1);
        Mute.x = Screen.width;
        Mute.y = 0;
        Mute.scaleX = (float)Screen.width / ScaleParameterX;
        Mute.scaleY = (float)Screen.width / ScaleParameterY;
        //Mute.addEventListener(MouseEvent.CLICK, OnMuteClick);

        Create = new MovieClip("swf/MenuBar.swf:CannonCreate");
        Create.gotoAndStop(1);
        Create.x = Screen.width;
        Create.y = Screen.height;
        Create.scaleX = (float)Screen.width / ScaleParameterX;
        Create.scaleY = (float)Screen.width / ScaleParameterY;
        Create.addEventListener(MouseEvent.MOUSE_DOWN, CreationClick);


        Bonus = new MovieClip("swf/Bonus.swf:Bonus1");
        Bonus.gotoAndStop(1);
        Bonus.x = Screen.width - 90;
        Bonus.y = Screen.height / 2 + 20;
        Bonus.scaleX = (float)Screen.width / ScaleParameterX;
        Bonus.scaleY = (float)Screen.width / ScaleParameterY;


        stage.addChild(Menu);
        stage.addChild(Pause);
        stage.addChild(Mute);
        stage.addChild(Create);
        stage.addChild(Bonus);
	}


    void changeScore(int value)
    {
       Score.text = "Score: "+value.ToString();
    }

    void changeCredits(int value)
    {
        Credits.text = "Credits:" + value.ToString();
    }

    void changeInfo(float []CannonParameters)
    {
        
        if (CannonParameters[0] != 0)
        {
            float Frequency = CannonParameters[0];
            float Damage = CannonParameters[1];
            float Range = CannonParameters[2];
            float Speed = CannonParameters[0];
            Info.text = "Frequency: " + Frequency.ToString() + "\n" + "Damage: " + Damage.ToString() + "\n" + "Range: " + Range.ToString() + "\n" + "Speed: " + Speed.ToString();

        }
        else Info.text = "";
    }
    void changeLevel(int value)
    {
        Level.text = "Lvl " + value;
    }

    void changeName(string name)
    {
        Name.text = name;
    }

    void OnPauseClick(CEvent e)
    {
        if (isPaused)
        {
            Pause.gotoAndStop(1);
        }
        else
        {
            Pause.gotoAndStop(2);
        }
        isPaused = !isPaused;
        GameObject.Find("BoxManager").SendMessage("PauseClick");

    }



    void CreationClick(CEvent e)
    {
        int count = GameObject.Find("BoxManager").GetComponent<BoxManager>().cannonCount;
        int price = GameObject.Find("BoxManager").GetComponent<BoxManager>().BasicCannonCost[count];
        int credits = GameObject.Find("BoxManager").GetComponent<BoxManager>().Credits;
        if (price <= credits)
           GameObject.Find("BoxManager").SendMessage("Creation");

    }


    void Deselect()
    {
        Level.text = "";
        Info.text = "";
    }

	void Update () {
	
	}
}
