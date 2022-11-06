using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statAffects{

    private int turnsLeft;
    /**
    "atk", "def", "spd"
    */
    private string statAffected;
    private float affectedBy;   

    public statAffects(int t, string s, float num){
        if(t < 0){
            //throw new IllegalArgumentException("what the fuck");
            Debug.Log("turn time less than 0");
        }
        else if(t == null || s == null){
            //throw new IllegalArgumentException("cannot be null");
            Debug.Log("time or string name was null");
        }
        else if (num < 0){
            //throw new IllegalArgumentException("Cannot be nonpositive");
            Debug.Log("modifier cannot be negative");
        }
        else
        {
            turnsLeft = t;
            statAffected = s;
            affectedBy = num;
        }
    }

    public void turnPass(){
        turnsLeft = turnsLeft - 1;
    }

    public bool noMoreTurns(){
        if(turnsLeft <= 0){
            return true;
        }
        return false;
    }

    public int getTurn(){
        return turnsLeft;
    }

    public string getStatAffected(){
        return statAffected;
    }

    public int changeStats(int originalStat){
        return (int) (originalStat * affectedBy);
    }

    public float GetEffectBy()
    {
        return affectedBy;
    }
}