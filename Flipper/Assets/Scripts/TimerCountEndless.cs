using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TimerCountEndless : MonoBehaviour
{
    bool in_game_flag = true;
    public float max_time = 30;
    public float clear_plus_time = 5;
    float count_time;

    public GameObject master;

    GameMaster script;
    int score_cur = 0;
    int score_tmp = 0;

    // Start is called before the first frame update
    void Start() {
        count_time = max_time;
        script = master.GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update() {
        if (in_game_flag) {
            count_time -= Time.deltaTime;
        }

        if (count_time > 0) {
            score_tmp = script.score;
            if (score_cur != score_tmp) {
                score_cur = score_tmp;
                count_time += clear_plus_time;
            }
            GetComponent<Text>().text = count_time.ToString("F2");
        }
        if (count_time <= 0) {
            int now_score = script.score;
            PlayerPrefs.SetInt("SCORE", now_score);
            PlayerPrefs.SetString("SCENE_NAME", "endless");
            SceneManager.LoadScene("Result");
        }
    }
}
