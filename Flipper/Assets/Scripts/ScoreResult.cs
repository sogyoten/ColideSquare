using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreResult : MonoBehaviour
{
    public string score_key = "SCORE";
    string scene_name = "";
    

    private void Awake() {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        scene_name = PlayerPrefs.GetString("SCENE_NAME");
        int result_score = PlayerPrefs.GetInt(score_key);
        GetComponent<Text>().text = result_score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            SceneManager.LoadScene("MainMenu");
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(scene_name);
        }
    }
}
