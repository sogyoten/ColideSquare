using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreResult : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int result_score = PlayerPrefs.GetInt("SCORE");
        GetComponent<Text>().text = result_score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            SceneManager.LoadScene("MainMenu");
        }
    }
}
