using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

class card{
    
    private string color;
    private statAffects whenCardPlayed;
    private bool isActive;
    //replace with an array so that you can do ranged attacks
    private bool isAttack;

    /**
    Constructor for a support card.
    */
    public card(string c, statAffects s){
        if (c == null || s == null)
        {
            //throw new IllegalArgumentException("Cannot be null");
        }
        else if (!(c.Equals("red") && c.Equals("blue") && c.Equals("green") && c.Equals("neutral")))
        {
            // throw new IllegalArgumentException("Color must be red, blue, green, or neutral.");
        }
        else
        {
            color = c;
            whenCardPlayed = s;
            isActive = false;
        }
    }
    /**
    Constructor for an active card.
    */
    public card(string c, bool isATK){
        if (c == null || isATK == null)
        {
            //throw new IllegalArgumentException("Cannot be null");
        }
        else
        {
            color = c;
            isActive = true;
            isAttack = isATK;
        }
    }

    public string getColor(){
        return color;
    }

    private float weaponTriangle(string targetColor){
        if(String.Equals(this.color, "red")){
            if(String.Equals(targetColor, "green")){
                return 1.5f;
            }
            if(String.Equals(targetColor, "blue")){
                return 0.5f;
            }
        }
        if(String.Equals(this.color, "green")){
            if(String.Equals(targetColor, "blue")){
                return 1.5f;
            }
            if(String.Equals(targetColor, "red")){
                return 0.5f;
            }
        }
        if(String.Equals(this.color, "blue")){
            if(String.Equals(targetColor, "red")){
                return 1.5f;
            }
            if(String.Equals(targetColor, "green")){
                return 0.5f;
            }
        }
        return 1;
    }

    /**
    Called when you want to play the card.
    */
    public void playCard(playerStats player, playerStats target){
        if(!isActive){
            target.addAffect(whenCardPlayed);
        }
        else if(!isAttack){
            int healed = player.getATK();
            target.changeHealth(healed);
        }
        else{
            //fix so ranged attacks work
            int atk = player.getATK();
            int def = target.getDEF();
            int damage = def - atk;
            damage = (int) (damage * this.weaponTriangle(target.getColor()));
            if(def < atk){
                target.changeHealth(damage);
            }
        }
    }
}