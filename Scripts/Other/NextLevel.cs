using UnityEngine;
using System.Collections;
using pumpkin.display;
using pumpkin.events;
using pumpkin.ui;
using pumpkin.text;
using pumpkin.tweener;

public class NextLevel : MonoBehaviour {
    Stage st;
    MovieClip ChangeLevel;
    TextField Text;
    bool Playing = false;
    void Update()
    {
        if (Playing)
        {
            
            if (ChangeLevel.getCurrentFrame() == 36)
            {
                st.removeChild(ChangeLevel);
            }
        }
    }
	void ShowLevelComplete(int Level) {
        if (GameObject.Find("Main Camera").GetComponent<MovieClipOverlayCameraBehaviour>() == null)
        {
            return;
        }
        st = Camera.main.GetComponent<MovieClipOverlayCameraBehaviour>().stage;
      
        ChangeLevel = new MovieClip("swf/LevelPassed.swf:LevelUP");
        
 
       
        ChangeLevel.x = Screen.width / 2;
        ChangeLevel.y = Screen.height / 2;
        ChangeLevel.scaleX = (float)Screen.width / 2048;
        ChangeLevel.scaleY = ChangeLevel.scaleX;

        Text = ChangeLevel.getChildByName<TextField>("Layer1");
        Text.text = "Level  " + Level.ToString();
        st.addChild(ChangeLevel);
        ChangeLevel.gotoAndPlay(1);
        Playing = true;
	}


}
