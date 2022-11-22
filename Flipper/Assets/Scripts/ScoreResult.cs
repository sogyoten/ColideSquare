using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreResult : MonoBehaviour
{
    public string score_key = "SCORE";
    // Start is called before the first frame update
    void Start()
    {
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
            SceneManager.LoadScene("60sec");
        }
    }
}
