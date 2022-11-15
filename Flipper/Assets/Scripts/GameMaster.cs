using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    // floor size setting
    public int floor_width = 5;
    public int floor_height = 5;

    // floor index setting
    private const int EMPTY = 0;
    private const int WALL = 1;

    // floor define
    private int[,] floor;

    // target define
    private int[] target_cood = new int[] {0,0};
    public GameObject Target;

    // goal define
    private int[] goal_cood = new int[] {0,0};
    public GameObject Goal;
    public int score = 0;

    // wall define
    public List<GameObject> walls = new List<GameObject>();
    Transform[] Stops;
    Transform[] Throughs;
    int[] wall_at = new int[] {0,1,2,3,4};
    int[] rand_wall;
    int[] wall_sit = new int[] {1,1,1,1,1};

    // Start is called before the first frame update
    void Start()
    {

        floor = new int[floor_width, floor_height];
        Stops = new Transform[floor_width];
        Throughs = new Transform[floor_width];

        score = 0;
        
        Setup();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            GoUp();
            MoveTarget();
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            GoDown();
            MoveTarget();
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            GoLeft();
            MoveTarget();
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            GoRight();
            MoveTarget();
        }

        if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)){
            WallSwitch(0);
            WallOnOff(0);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)){
            WallSwitch(1);
            WallOnOff(1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)){
            WallSwitch(2);
            WallOnOff(2);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4)){
            WallSwitch(3);
            WallOnOff(3);
        }
        if(Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5)){
            WallSwitch(4);
            WallOnOff(4);
        }

        if(Input.GetKeyDown(KeyCode.Return)){
            if(target_cood[0] == goal_cood[0] && target_cood[1] == goal_cood[1]){
                score++;
                Setup();
            }
        }
    }

    void Setup(){
        InitializeFloor();
        RandTarget();
        MoveTarget();
        RandGoal();
        MoveGoal();

        rand_wall = wall_at.OrderBy(i => Guid.NewGuid()).ToArray();
        for(int i=0;i<floor_width;i++){
            wall_sit[i] = UnityEngine.Random.Range(0,2);
            WallArrange(walls[i],i);
            Stops[i] = walls[i].transform.GetChild(0);
            Throughs[i] = walls[i].transform.GetChild(1);
            WallOnOff(i);
        }
    }

    /// <summary>
    /// Floorの設定を初期化し、全座標をEMPTYにする。
    /// </summary>
    void InitializeFloor(){
        for(int i=0; i<floor_width; i++){
            for(int j=0; j<floor_height; j++){
                floor[i,j] = EMPTY;
            }
        }
    }

    void RandTarget(){
        target_cood[0] = UnityEngine.Random.Range(0,floor_width);
        target_cood[1] = UnityEngine.Random.Range(0,floor_height);
    }
    void MoveTarget(){
        Vector3 pos = Target.transform.position;
        pos.x = target_cood[0];
        pos.z = target_cood[1];
        Target.transform.position = pos;
    }

    void RandGoal(){
        do{
            int goal_mid = UnityEngine.Random.Range(1, floor_width-1);
            int goal_end = UnityEngine.Random.Range(0, 2) * (floor_width-1);
            if(UnityEngine.Random.Range(0, 2)==0){
                goal_cood[0] = goal_mid;
                goal_cood[1] = goal_end;
            }else{
                goal_cood[1] = goal_mid;
                goal_cood[0] = goal_end;
            }
        }while(target_cood[0] == goal_cood[0] || target_cood[1] == goal_cood[1]);
    }
    void MoveGoal(){
        Vector3 pos = Goal.transform.position;
        pos.x = goal_cood[0];
        pos.z = goal_cood[1];
        Goal.transform.position = pos;
    }

    // about move
    void GoLeft(){//goleft
        int tmp_x = target_cood[0];
        int tmp_z = target_cood[1];
        while(tmp_x > 0 && floor[tmp_x-1,tmp_z]==0){
            tmp_x = tmp_x-1;
        }
        target_cood[0] = tmp_x;
    }
    void GoRight(){//goright
        int tmp_x = target_cood[0];
        int tmp_z = target_cood[1];
        while(tmp_x < floor_height-1 && floor[tmp_x+1,tmp_z]==0){
            tmp_x = tmp_x+1;
        }
        target_cood[0] = tmp_x;
    }
    void GoDown(){//godown
        int tmp_x = target_cood[0];
        int tmp_z = target_cood[1];
        while(tmp_z > 0 && floor[tmp_x,tmp_z-1]==0){
            tmp_z = tmp_z-1;
        }
        target_cood[1] = tmp_z;
    }
    void GoUp(){//goup
        int tmp_x = target_cood[0];
        int tmp_z = target_cood[1];
        while(tmp_z < floor_width-1 && floor[tmp_x,tmp_z+1]==0){
            tmp_z = tmp_z+1;
        }
        target_cood[1] = tmp_z;
    }

    void WallArrange(GameObject wall, int row_index){
        Vector3 pos = wall.transform.position;
        pos.x = row_index;
        pos.z = rand_wall[row_index];
        wall.transform.position = pos;
    }
    void WallOnOff(int row_index){
        Vector3 pos_stop = Stops[row_index].position;
        Vector3 pos_through = Throughs[row_index].position;
        if(wall_sit[row_index]==EMPTY){
            pos_stop.y = 0.1f;
            pos_through.y = 0;
            floor[row_index,rand_wall[row_index]] = EMPTY;
        }else if(wall_sit[row_index]==WALL){
            pos_stop.y = 0;
            pos_through.y = 0.1f;
            floor[row_index,rand_wall[row_index]] = WALL;
        }
        Stops[row_index].position = pos_stop;
        Throughs[row_index].position = pos_through;
    }
    void WallSwitch(int index){
        if(wall_sit[index]==EMPTY){
            wall_sit[index] = WALL;
        }else if(wall_sit[index]==WALL){
            wall_sit[index] = EMPTY;
        }
    }
    
}
