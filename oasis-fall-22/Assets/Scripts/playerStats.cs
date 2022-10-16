using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class playerStats{
    sealed int totalHP;
    private int HP;
    sealed int ATK;
    sealed int DEF;
    sealed int SPD;
    private string color;
    private bool hasMoved;
    private boolean isAlive;
    private boolean hasDefended;
    private List<statAffects> buffs;

    /**
    The constructor for a player's stats.
    */
    public playerStats(){
        totalHP = 100;
        HP = 100;
        baseATK = 10;
        ATK = 10;
        baseDEF = 10;
        DEF = 10;
        SPD = 1;
        color = "neutral";
        hasMoved = false;
        q = new Queue();
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
        foreach(s in this.buffs){
            if(String.Equals(s.statAffected, stat)){
                x = s.changeStats(x);
            }
        }
        return x;
    }

    public string getColor(){
        return color;
    }

    public boolean isAlive(){
        return isAlive;
    }

    public boolean hasDefended(){
        return hasDefended;
    }

    /**
    Called if the player chooses the defend option.
    */
    public void defend(){
        if(hasMoved){
            throw new IllegalArgumentException("Player has already moved.");
        }
        hasDefended = true;
        hasMoved = true;
    }

    /**
    Called if the player chooses the move option.
    */
    public void moveSpot(){
        if(hasMoved){
            throw new IllegalArgumentException("Player has already moved.");
        }
        hasMoved = true;
    }

    public List<statAffects> returnList(){
        return buffs;
    }

    /**
    Called if the player plays a card.
    */
    public void playCard(card card, playerStats target){
        if(hasMoved){
            throw new IllegalArgumentException("Player has already moved.");
        }
        this.color = card.getColor();
        hasMoved = true;
        card.playCard(this, target);
    }

    public void endRound(){
        foreach (statAffect a in this.buffs){
            a.turnPass();
            if(a.noMoreTurns){
                this.buffs.Remove(a);
            }
        }
        hasMoved = false;
        hasDefended = false;
        if(!isAlive()){
            //call some function here
        }
    }
    
    /**
    Called when a player gets buffed or debuffed.
    */
    public void addAffect(statAffects new){
        this.buffs.Add(new);
    }

    /**
    Called when the player is attacked or healed
    */
    public void changeHealth(int change){
        this.HP = this.HP + change;
        if(this.HP <= 0){
            this.HP = 0;
            this.isAlive = false;
        }
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