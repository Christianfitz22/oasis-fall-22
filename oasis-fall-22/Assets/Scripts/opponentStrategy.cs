using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface opponentStrategy{
    move chooseMove();
}

class move{
    private bool playCard;
    private string moveDirection;
    private cards cardPlayed;

    public move(String move){
        playCard = false;
        moveDirection = move;
    }

    public move(cards card){
        playCard = true;
        cardPlayed = card;
    }
}