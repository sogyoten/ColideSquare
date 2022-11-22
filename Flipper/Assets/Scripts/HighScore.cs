using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public string highscore_key = "HIGH_SCORE";
    public string score_key = "SCORE";
    public bool higher_better = true;
    // Start is called before the first frame update
    void Start() {
        int result_score = PlayerPrefs.GetInt(score_key);
        int high_score = PlayerPrefs.GetInt(highscore_key);

        if ((higher_better && result_score > high_score) || (!higher_better && result_score < high_score)) {
            high_score = result_score;
            PlayerPrefs.SetInt(highscore_key, high_score);

        }
        GetComponent<Text>().text = high_score.ToString();
    }

}
