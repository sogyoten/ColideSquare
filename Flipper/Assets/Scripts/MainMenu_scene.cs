using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu_scene : MonoBehaviour
{
    public int scene_num = 0;
    public int max_scene_num = 1;

    string tutorial_inst = "Tutorial\nNow Learning...";
    string sec60_inst = "60sec\nonly 60sec!";
    // Start is called before the first frame update
    void Start()
    {
        Refresh_Text(scene_num);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if(scene_num == max_scene_num) {
                scene_num = 0;
            } else {
                ++scene_num;
            }
            Refresh_Text(scene_num);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (scene_num == 0) {
                scene_num = max_scene_num;
            } else {
                --scene_num;
            }
            Refresh_Text(scene_num);
        }

        if (Input.GetKeyDown(KeyCode.Return)){
            SceneMove(scene_num);
        }

        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }

    }

    void Refresh_Text(int scene_num) {
        string scene_txt = tutorial_inst;

        switch (scene_num) {
            case 0:
                scene_txt = tutorial_inst;
                break;
            case 1:
                scene_txt = sec60_inst;
                break;
        }


        GetComponent<Text>().text = scene_txt.ToString();
    }

    void SceneMove(int scene_num) {
        string to_scene = "tutorial";

        switch (scene_num) {
            case 0:
                to_scene = "tutorial";
                break;
            case 1:
                to_scene = "60sec";
                break;
        }

        SceneManager.LoadScene(to_scene);

    }
}
