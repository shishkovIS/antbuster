using UnityEngine;
using System.Collections;
using pumpkin.display;
using pumpkin.events;
using pumpkin.ui;
using pumpkin.text;


public class PauseMenu : MonoBehaviour
{
    const int ButtonCount = 4;
    
    Stage PauseStage;
    MovieClip BackGround;
    MovieClip[] Buttons = new MovieClip[ButtonCount];
    string [] names = new string[ButtonCount];
    TextField [] MenuFields = new TextField[ButtonCount];
  


    void Start()
    {
        names[0] = "Resume";
        names[1] = "Restart";
        names[2] = "Shop";
        names[3] = "Quit";
    }



    void Activate()
    {
        if (GameObject.Find("Main Camera").GetComponent<MovieClipOverlayCameraBehaviour>() == null)
        {
            return;
        }
        PauseStage = Camera.main.GetComponent<MovieClipOverlayCameraBehaviour>().stage;

        BackGround = new MovieClip("swf/PauseField.swf:FadeBackground");
        BackGround.gotoAndStop(1);
        BackGround.x = Screen.width / 2;
        BackGround.y = Screen.height / 2;
        BackGround.scaleX = (float)Screen.width / 2048;
        BackGround.scaleY = BackGround.scaleX;
        PauseStage.addChild(BackGround);

        for (int i = 0; i < ButtonCount; i++)
        {
            Buttons[i] = new MovieClip("swf/PauseField.swf:PauseField");
            Buttons[i].gotoAndStop(1);
            Buttons[i].x = Screen.width/2;
            Buttons[i].y = Screen.height * 0.3f + (float)Screen.height/2048 * 220 * i;
            Buttons[i].scaleX = (float)Screen.width / 2048;
            Buttons[i].scaleY = Buttons[i].scaleX;

            MenuFields[i] = Buttons[i].getChildByName<TextField>("Text");
            MenuFields[i].text = names[i];

            PauseStage.addChild(Buttons[i]);
        }

        Buttons[0].addEventListener(MouseEvent.CLICK, Resume);
        Buttons[1].addEventListener(MouseEvent.CLICK, Reload);
        Buttons[3].addEventListener(MouseEvent.CLICK, Quit);
    }

    void Deactivate()
    {
        for (int i = 0; i < ButtonCount; i++)
        {
            PauseStage.removeChild(Buttons[i]);
        }
        PauseStage.removeChild(BackGround);
    }

    void Resume(CEvent e)
    {
        GameObject.Find("Menu").SendMessage("OnPauseClick", e);
    }

    void Reload(CEvent e)
    {
        Time.timeScale = 1.0f;
        Application.LoadLevel(0);
    }

    void Quit(CEvent e)
    {
        Application.Quit();
    }
}
