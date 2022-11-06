using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

class deck{
    //the deck
    private List<card> deckOfCards;

    //create the deck
    public deck(){
        deckOfCards = new List<card>();
        deckOfCards.Add(new card(chooseRandomColor(), true)); //an attacking card :D
        deckOfCards.Add(new card(chooseRandomColor(), true)); //an attacking card :D
        deckOfCards.Add(new card(chooseRandomColor(), true)); //an attacking card :D
        deckOfCards.Add(new card(chooseRandomColor(), false)); //a healing card :D
        //swapped speed buff cards for attack and healing
        deckOfCards.Add(new card(chooseRandomColor(), true)); //an attacking card :D
        deckOfCards.Add(new card(chooseRandomColor(), false)); //a healing card :D
        //deckOfCards.Add(new card(chooseRandomColor(), createNewStatAffect("spd", true))); //movement buff card
        //deckOfCards.Add(new card(chooseRandomColor(), createNewStatAffect("spd", false))); //movement debuff card
        deckOfCards.Add(new card(chooseRandomColor(), createNewStatAffect("atk", true))); //atk buff
        deckOfCards.Add(new card(chooseRandomColor(), createNewStatAffect("atk", false))); //atk debuff
        deckOfCards.Add(new card(chooseRandomColor(), createNewStatAffect("def", true))); //def buff
        deckOfCards.Add(new card(chooseRandomColor(), createNewStatAffect("def", false))); //def debuff
    }

    private statAffects createNewStatAffect(string str, bool buff){
        if(buff){
            return new statAffects(3, str, 2);
        }
        else if(str == "spd"){
            return new statAffects(1, str, 0);
        }
        else{
            return new statAffects(3, str, 0.5f);
        }
    }

    /**
    Choose a random color for our cards.
    */
    private string chooseRandomColor(){
        System.Random rnd = new System.Random();
        int random = rnd.Next(1, 5);
        if(random == 1){
            return "red";
        }
        else if(random == 2){
            return "green";
        }
        else if(random == 3){
            return "blue";
        }
        else{
            return "neutral";
        }
    }

    //choose three random cards
    public List<card> chooseCards(){
        System.Random rnd = new System.Random();
        List<card> returnCards = new List<card>();
        for(int i = 0; i < 3; i++){
            int random = rnd.Next(0, deckOfCards.Count);
            returnCards.Add(deckOfCards[random]);
        }
        return returnCards;
    }
}