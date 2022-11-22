using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreOnMain : MonoBehaviour
{
    public GameObject master;

    MainMenu_scene script;

    int highscore = 0;
    int scene = 0;

    public string highscore_key = "Tutorial_SCORE";
    // Start is called before the first frame update
    void Start() {
        script = master.GetComponent<MainMenu_scene>();

    }

    void Update() {
        
        scene = script.scene_num;
        switch (scene) {
            case 0:
                highscore_key = "Tutorial_SCORE";
                break;
            case 1:
                highscore_key = "60SEC_SCORE";
                break;
        }
        highscore = PlayerPrefs.GetInt(highscore_key);
        GetComponent<Text>().text = highscore.ToString();
        
    }
}
