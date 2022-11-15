using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerCountDown : MonoBehaviour
{
    bool in_game_flag = true;
    public float max_time = 60;
    float count_time;

    public GameObject master;

    GameMaster script;

    // Start is called before the first frame update
    void Start()
    {
        count_time = max_time;
        script = master.GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        if(in_game_flag){
            count_time -= Time.deltaTime;
        }
        
        if(count_time > 0){
            GetComponent<Text>().text = count_time.ToString("F2");
        }
        if(count_time <= 0){
            int now_score = script.score;
            PlayerPrefs.SetInt("SCORE", now_score);
            SceneManager.LoadScene("Result");
        }
    }
}
