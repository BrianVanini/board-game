using UnityEngine;

public class Stage : MonoBehaviour{
    public int stageNumber;
    public Unit[] units;

    void Start(){
        initializeStage();
    }

    bool initializeStage(){
        //get stage info from sql
        //spawn each enemy
        return true;
    }
}