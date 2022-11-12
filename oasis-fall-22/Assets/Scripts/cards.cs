using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class card{
    
    private string color;
    private statAffects whenCardPlayed;
    private bool isActive;
    //replace with an array so that you can do ranged attacks
    private bool isAttack;

    private string description;

    /**
    Constructor for a support card.
    */
    public card(string c, statAffects s){

        if (c == null || s == null)
        {
            //throw new IllegalArgumentException("Cannot be null");
            Debug.Log("c or s was null");
        }
        else if (!(c.Equals("red") || c.Equals("blue") || c.Equals("green") || c.Equals("neutral")))
        {
            // throw new IllegalArgumentException("Color must be red, blue, green, or neutral.");
            Debug.Log("color was wrong");
        }
        else
        {
            color = c;
            whenCardPlayed = s;
            isActive = false;
        }

        SetDesc();
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

        SetDesc();
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
    public void playCard(playerStats player, playerStats target)
    {
        if (player != null && target != null)
        {
            if (!isActive)
            {
                Debug.Log(whenCardPlayed.GetString());
                target.addAffect(whenCardPlayed);
            }
            else if (!isAttack)
            {
                //int healed = player.getATK();
                int healed = 50;
                target.changeHealth(healed);
            }
            else
            {
                //fix so ranged attacks work
                int atk = player.getATK();
                int def = target.getDEF();
                int damage = def - atk;
                damage = (int)(damage * this.weaponTriangle(target.getColor()));
                if (def < atk)
                {
                    target.changeHealth(damage);
                }
            }
        }
    }

    public bool getIsActive()
    {
        return isActive;
    }

    public bool getIsAttack()
    {
        return isAttack;
    }

    public void SetDesc()
    {
        string desc = "";
        if (isActive)
        {
            if (isAttack)
            {
                desc += "Attack";
            }
            else
            {
                desc += "Heal";
            }
        }
        else
        {
            desc += "Effect";
            float multiplyer = whenCardPlayed.GetEffectBy();
            if (multiplyer == 2f)
            {
                desc += "\nBuff ";
            }
            else if (multiplyer == 0f || multiplyer == 0.5f)
            {
                desc += "\nDebuff ";
            }
            string statAffected = whenCardPlayed.getStatAffected();
            if (statAffected == "spd")
            {
                desc += "Speed";
            }
            else if (statAffected == "atk")
            {
                desc += "Attack";
            }
            else if (statAffected == "def")
            {
                desc += "Defense";
            }
        }
        desc += "\n" + color;
        description = desc;
    }

    public string GetDesc()
    {
        return description;
    }

    public card DeepCopy()
    {
        card target = null;
        if (!isActive)
        {
            target = new card(color, whenCardPlayed.DeepCopy());
        }
        else if (!isAttack)
        {
            target = new card(color, false);
        }
        else
        {
            target = new card(color, true);
        }
        return target;
    }
}