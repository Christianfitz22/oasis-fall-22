using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface opponentStrategy{
    move chooseMove();
}

class move{
    private bool playCard;
    private string moveDirection;
    private card cardPlayed;

    public move(string move){
        playCard = false;
        moveDirection = move;
    }

    public move(card card){
        playCard = true;
        cardPlayed = card;
    }

    public string getMove(){
        if(moveDirection != null){
            return moveDirection;
        }
        return "card";
    }

    public card getCard(){
        return cardPlayed;
    }
}