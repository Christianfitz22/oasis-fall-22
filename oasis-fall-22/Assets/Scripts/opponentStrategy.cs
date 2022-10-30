using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface opponentStrategy{
    move chooseMove();
}

class randomMoveStrategy : opponentStrategy{
    private EnemyController c;

    public randomMoveStrategy(EnemyController controller){
        c = controller;
    }

    public move chooseMove(){
        playerStats stats = c.getStats();
        int speed = stats.getMovementSpeed();
        if(c.getYPos() - speed >= 0){
            return new move("up");
        } else if(c.getXPos() - speed >= 0){
            return new move("left");
        } else if (c.getYPos() + speed >= 7){
            return new move("down");
        } else if(c.getXPos() + speed >= 9){
            return new move("right");
        }
        return null;
    }
}

class combineStrategy : opponentStrategy{
    private opponentStrategy first;
    private opponentStrategy second;

    public combineStrategy(opponentStrategy f, opponentStrategy s){
        first = f;
        second = s;
    }

    public move chooseMove(){
        move m = first.chooseMove();
        if(m != null){
            return m;
        }
        return second.chooseMove();
    }
}

class attackEnemyStrategy : opponentStrategy{
    private EnemyController c;

    public attackEnemyStrategy(EnemyController controller){
        c = controller;
    }

    public move chooseMove(){
        return null;
    }
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
        if(!playCard){
            return moveDirection;
        }
        return "card";
    }

    public card getCard(){
        return cardPlayed;
    }
}