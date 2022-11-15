using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public GameObject master;

    GameMaster script;
    // Start is called before the first frame update
    void Start()
    {
        script = master.GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        int now_score = script.score;
        GetComponent<Text>().text = now_score.ToString();
    }
}
