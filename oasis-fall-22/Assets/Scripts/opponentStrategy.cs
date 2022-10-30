using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface opponentStrategy{
    move chooseMove();
}

class move{
    private boolean playCard;
    private String moveDirection;
    private cards cardPlayed;

    public move(String move){
        playCard = false;
        moveDirection = move;
        
    }
}