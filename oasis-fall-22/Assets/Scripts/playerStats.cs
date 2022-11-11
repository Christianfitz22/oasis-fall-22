using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats{
    private int totalHP;
    private int HP;
    private int ATK;
    private int DEF;
    private int SPD;
    private string color;
    private bool hasMoved;
    private bool isAlive;
    private bool hasDefended;
    private bool playerTeam;
    private List<statAffects> buffs;

    /**
    The constructor for a player's stats.
    */
    public playerStats() {
        totalHP = 300;
        HP = 300;
        ATK = 16;
        DEF = 4;
        SPD = 1;
        color = "neutral";
        hasMoved = false;
        isAlive = true;
        hasDefended = false;
        buffs = new List<statAffects>();
        playerTeam = true;
    }

    public playerStats (int hp, int atk, int def, bool team)
    {
        totalHP = hp;
        HP = hp;
        ATK = atk;
        DEF = def;
        SPD = 1;
        color = "neutral";
        hasMoved = false;
        isAlive = true;
        hasDefended = false;
        buffs = new List<statAffects>();
        playerTeam = team;
    }

    public int getTotalHP()
    {
        return totalHP;
    }

    public int getCurrentHealth(){
        return HP;
    }

    public int getATK(){
        return useStatBuffs("atk", ATK);
    }

    public int getDEF(){
        return useStatBuffs("def", DEF);
    }

    public int getMovementSpeed(){
        return useStatBuffs("spd", SPD);
    }

    private int useStatBuffs(string stat, int x){
        foreach (statAffects s in buffs){
            if (stat.Equals(s.getStatAffected()))
            {
                x = s.changeStats(x);
            }
        }
        return x;
    }

    public void TickStatus()
    {
        for (int i = 0; i < buffs.Count; i++)
        {
            statAffects s = buffs[i];
            s.turnPass();
            if (s.noMoreTurns())
            {
                buffs.Remove(s);
                i--;
            }
        }
    }

    public string getColor(){
        return color;
    }

    public bool getIsAlive(){
        return isAlive;
    }

    public bool getHasDefended(){
        return hasDefended;
    }

    public bool getTeam(){
        return playerTeam;
    }

    /**
    Called if the player chooses the defend option.
    */
    public void defend(){
        if (hasMoved)
        {
            // throw new IllegalArgumentException("Player has already moved.");
            Debug.Log("Player has already moved.");
        }
        else
        {
            hasDefended = true;
            hasMoved = true;
        }
    }

    /**
    Called if the player chooses the move option.
    */
    public void moveSpot(){
        if (hasMoved)
        {
            // throw new IllegalArgumentException("Player has already moved.");
            Debug.Log("Player has already moved");
        }
        else
        {
            hasMoved = true;
        }
    }

    public List<statAffects> returnList(){
        return buffs;
    }

    /**
    Called if the player plays a card.
    */
    public void playCard(card card, playerStats target){
        if (hasMoved)
        {
            // throw new IllegalArgumentException("Player has already moved.");
            Debug.Log("Player has already moved.");
        }
        else
        {
            this.color = card.getColor();
            hasMoved = true;
            card.playCard(this, target);
        }
    }

    public void endRound(){
        foreach (statAffects a in this.buffs){
            a.turnPass();
            if(a.noMoreTurns())
            {
                this.buffs.Remove(a);
            }
        }
        hasMoved = false;
        hasDefended = false;
        if(!getIsAlive()){
            //call some function here
        }
    }
    
    /**
    Called when a player gets buffed or debuffed.
    */
    public void addAffect(statAffects newAffect){
        this.buffs.Add(newAffect);
    }

    /**
    Called when the player is attacked or healed
    */
    public void changeHealth(int change){
        this.HP = this.HP + change;
        if (this.HP > totalHP)
        {
            this.HP = totalHP;
        }
        if(this.HP <= 0){
            this.HP = 0;
            this.isAlive = false;
        }
        Debug.Log(HP);
    }

    /**
    Called for when the player needs to be revived.
    */
    public void revive(){
        this.color = "neutral";
        this.HP = 100; //change later
        this.hasMoved = false;
        this.isAlive = true;
        this.hasDefended = false;
        this.buffs.Clear();
    }
}