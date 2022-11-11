using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

interface opponentStrategy{
    move chooseMove();
}

class randomMoveStrategy : opponentStrategy{
    private EnemyController c;

    public randomMoveStrategy(EnemyController controller){
        c = controller;
    }

    public move chooseMove() {
        playerStats stats = c.getStats();
        int speed = stats.getMovementSpeed();
        System.Random rnd = new System.Random();
        int random = rnd.Next(1, 5);
        move chosenMove = null;
        Debug.Log(c.getXPos() + ", " + c.getYPos() + " " + speed);
        if(random == 1){
            if(c.getYPos() - speed >= 0){
                Debug.Log(c.getYPos() - speed);
                chosenMove = new move("up");
            } else {
                chosenMove = new move("down");
            }
        } else if(random == 2){
            if(c.getXPos() - speed >= 0){
                chosenMove = new move("left");
            }
            else
            {
                chosenMove = new move("right");
            }
        } else if(random == 3){
            if (c.getYPos() + speed < Board.boardHeight){
                chosenMove = new move("down");
            }
            else
            {
                chosenMove = new move("up");
            }
        } else{
            if (c.getXPos() + speed < Board.boardWidth)
            {
                chosenMove = new move("right");
            }
            else
            {
                chosenMove = new move("left");
            }
        }
        return chosenMove;
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
        playerStats target = c.getTargetLine("up");
        if(target != null && target.getTeam() != c.getStats().getTeam()){
            System.Random rnd = new System.Random();
            int random = rnd.Next(1, 5);
            string color = "neutral";
            if(random == 1){
                color = "red";
            }
            else if(random == 2){
                color = "green";
            }
            else if(random == 3){
                color =  "blue";
            }
            card card = new card(color, true);
            return new move(card, target);
        }
        target = c.getTargetLine("down");
        if(target != null && target.getTeam() != c.getStats().getTeam()){
            System.Random rnd = new System.Random();
            int random = rnd.Next(1, 5);
            string color = "neutral";
            if(random == 1){
                color = "red";
            }
            else if(random == 2){
                color = "green";
            }
            else if(random == 3){
                color =  "blue";
            }
            card card = new card(color, true);
            return new move(card, target);
        }
        target = c.getTargetLine("right");
        if(target != null && target.getTeam() != c.getStats().getTeam()){
            System.Random rnd = new System.Random();
            int random = rnd.Next(1, 5);
            string color = "neutral";
            if(random == 1){
                color = "red";
            }
            else if(random == 2){
                color = "green";
            }
            else if(random == 3){
                color =  "blue";
            }
            card card = new card(color, true);
            return new move(card, target);
        }
        target = c.getTargetLine("left");
        if(target != null && target.getTeam() != c.getStats().getTeam()){
            System.Random rnd = new System.Random();
            int random = rnd.Next(1, 5);
            string color = "neutral";
            if(random == 1){
                color = "red";
            }
            else if(random == 2){
                color = "green";
            }
            else if(random == 3){
                color =  "blue";
            }
            card card = new card(color, true);
            return new move(card, target);
        }
        return null;
    }
}

class injuredFleeStrategy : opponentStrategy{
    private EnemyController c;

    public injuredFleeStrategy(EnemyController controller){
        c = controller;
    }

    public move chooseMove(){
        if(c.getStats().getCurrentHealth() >= c.getStats().getTotalHP()){
            return null;
        }
        playerStats target = c.getTargetLine("up");
        int speed = c.getStats().getMovementSpeed();
        if(target != null && target.getTeam() != c.getStats().getTeam()){
            if(c.getXPos() - speed >= 0){
                return new move("left");
            } else if(c.getXPos() + speed < Board.boardWidth){
                return new move("right");
            }
        }
        target = c.getTargetLine("down");
        if(target != null && target.getTeam() != c.getStats().getTeam()){
            if(c.getXPos() - speed >= 0){
                return new move("left");
            } else if(c.getXPos() + speed < Board.boardWidth){
                return new move("right");
            }
        }
        target = c.getTargetLine("right");
        if(target != null && target.getTeam() != c.getStats().getTeam()){
            if(c.getYPos() - speed >= 0){
                return new move("up");
            } else if (c.getYPos() + speed < Board.boardHeight){
                return new move("down");
            }
        }
        target = c.getTargetLine("left");
        if(target != null && target.getTeam() != c.getStats().getTeam()){
            if(c.getYPos() - speed >= 0){
                return new move("up");
            } else if (c.getYPos() + speed < Board.boardHeight){
                return new move("down");
            }
        }
        return null;
    }
}

class healTeammatesStrategy : opponentStrategy{
    private EnemyController c;

    public healTeammatesStrategy(EnemyController controller){
        c = controller;
    }

    public move chooseMove(){
        playerStats target = c.getTargetLine("up");
        if(target != null && target.getTeam() == c.getStats().getTeam()){
            System.Random rnd = new System.Random();
            int random = rnd.Next(1, 5);
            string color = "neutral";
            if(random == 1){
                color = "red";
            }
            else if(random == 2){
                color = "green";
            }
            else if(random == 3){
                color =  "blue";
            }
            card card = new card(color, false);
            return new move(card, target);
        }
        target = c.getTargetLine("down");
        if(target != null && target.getTeam() == c.getStats().getTeam()){
            System.Random rnd = new System.Random();
            int random = rnd.Next(1, 5);
            string color = "neutral";
            if(random == 1){
                color = "red";
            }
            else if(random == 2){
                color = "green";
            }
            else if(random == 3){
                color =  "blue";
            }
            card card = new card(color, false);
            return new move(card, target);
        }
        target = c.getTargetLine("right");
        if(target != null && target.getTeam() == c.getStats().getTeam()){
            System.Random rnd = new System.Random();
            int random = rnd.Next(1, 5);
            string color = "neutral";
            if(random == 1){
                color = "red";
            }
            else if(random == 2){
                color = "green";
            }
            else if(random == 3){
                color =  "blue";
            }
            card card = new card(color, false);
            return new move(card, target);
        }
        target = c.getTargetLine("left");
        if(target != null && target.getTeam() == c.getStats().getTeam()){
            System.Random rnd = new System.Random();
            int random = rnd.Next(1, 5);
            string color = "neutral";
            if(random == 1){
                color = "red";
            }
            else if(random == 2){
                color = "green";
            }
            else if(random == 3){
                color =  "blue";
            }
            card card = new card(color, false);
            return new move(card, target);
        }
        return null;
    }
}

class findInjuredStrategy : opponentStrategy{
    private EnemyController c;

    public findInjuredStrategy(EnemyController controller){
        c = controller;
    }

    public move chooseMove(){
        bool team = c.getStats().getTeam();
        GameObject closest = null;
        int xDist = 10000;
        int yDist = 10000;
        bool isPlayer = false;
        foreach (GameObject piece in Board.allPieces){
            EnemyController subConEnemy = piece.GetComponent<EnemyController>();
            PlayerTest01 subConPlayer = piece.GetComponent<PlayerTest01>();
            if(subConEnemy != null){
                if(team == subConEnemy.getStats().getTeam()){
                    int xDis = subConEnemy.getXPos() - c.getXPos();
                    xDis = Math.Abs(xDis);
                    int yDis = subConEnemy.getYPos() - c.getYPos();
                    yDis = Math.Abs(yDis);
                    if(xDist + yDist > xDis + yDis){
                        xDist = xDis;
                        yDist = yDis;
                        closest = piece;
                        isPlayer = false;
                    }
                }
            } else {
                if(team){
                    int xDis = subConPlayer.GetXPos() - c.getXPos();
                    xDis = Math.Abs(xDis);
                    int yDis = subConPlayer.GetYPos() - c.getYPos();
                    yDis = Math.Abs(yDis);
                    if(xDist + yDist > xDis + yDis){
                        xDist = xDis;
                        yDist = yDis;
                        closest = piece;
                        isPlayer = true;
                    }
                }
            }
        }
        if(isPlayer){
            PlayerTest01 player = closest.GetComponent<PlayerTest01>();
            if(xDist != 0){
                if(player.GetXPos() > c.getXPos()){
                    return new move("right");
                }
                return new move("left");
            }
            if(yDist != 0){
                if(player.GetYPos() > c.getYPos()){
                    return new move("down");
                }
                return new move("up");
            }
        } else {
            EnemyController enemy = closest.GetComponent<EnemyController>();
            if(xDist != 0){
                if(enemy.getXPos() > c.getXPos()){
                    return new move("right");
                }
                return new move("left");
            }
            if(yDist != 0){
                if(enemy.getYPos() > c.getYPos()){
                    return new move("down");
                }
                return new move("up");
            }
        }
        return null;
    }
}

class buffAllyStrategy : opponentStrategy{
    private EnemyController c;

    public buffAllyStrategy(EnemyController controller){
        c = controller;
    }

    public move chooseMove(){
        playerStats target = c.getTargetLine("up");
        System.Random rnd = new System.Random();
        int random = rnd.Next(1,4);
        statAffects st;
        if(random == 1){
            st = new statAffects(3, "atk", 2);
            
        } else if(random == 2){
            st = new statAffects(3, "def", 2);
        } else {
            st = new statAffects(1, "spd", 2);
        }
        if(target != null && target.getTeam() == c.getStats().getTeam()){
            random = rnd.Next(1, 5);
            string color = "neutral";
            if(random == 1){
                color = "red";
            }
            else if(random == 2){
                color = "green";
            }
            else if(random == 3){
                color =  "blue";
            }
            card card = new card(color, st);
            return new move(card, target);
        }
        target = c.getTargetLine("down");
        if(target != null && target.getTeam() == c.getStats().getTeam()){
            random = rnd.Next(1, 5);
            string color = "neutral";
            if(random == 1){
                color = "red";
            }
            else if(random == 2){
                color = "green";
            }
            else if(random == 3){
                color =  "blue";
            }
            card card = new card(color, st);
            return new move(card, target);
        }
        target = c.getTargetLine("right");
        if(target != null && target.getTeam() == c.getStats().getTeam()){
            random = rnd.Next(1, 5);
            string color = "neutral";
            if(random == 1){
                color = "red";
            }
            else if(random == 2){
                color = "green";
            }
            else if(random == 3){
                color =  "blue";
            }
            card card = new card(color, st);
            return new move(card, target);
        }
        target = c.getTargetLine("left");
        if(target != null && target.getTeam() == c.getStats().getTeam()){
            random = rnd.Next(1, 5);
            string color = "neutral";
            if(random == 1){
                color = "red";
            }
            else if(random == 2){
                color = "green";
            }
            else if(random == 3){
                color =  "blue";
            }
            card card = new card(color, st);
            return new move(card, target);
        }
        return null;
    }
}

class escapeEnemyStrategy : opponentStrategy{
    private EnemyController c;

    public escapeEnemyStrategy(EnemyController controller){
        c = controller;
    }

    public move chooseMove(){
        int speed = c.getStats().getMovementSpeed();
        playerStats target = c.getTargetLine("up");
        if(target != null && target.getTeam() != c.getStats().getTeam()){
            if(c.getXPos() - speed >= 0){
                return new move("left");
            } else if(c.getXPos() + speed < Board.boardWidth){
                return new move("right");
            }
        }
        target = c.getTargetLine("down");
        if(target != null && target.getTeam() != c.getStats().getTeam()){
            if(c.getXPos() - speed >= 0){
                return new move("left");
            } else if(c.getXPos() + speed < Board.boardWidth){
                return new move("right");
            }
        }
        target = c.getTargetLine("right");
        if(target != null && target.getTeam() != c.getStats().getTeam()){
            if(c.getYPos() - speed >= 0){
                return new move("up");
            } else if (c.getYPos() + speed < Board.boardHeight){
                return new move("down");
            }
        }
        target = c.getTargetLine("left");
        if(target != null && target.getTeam() != c.getStats().getTeam()){
            if(c.getYPos() - speed >= 0){
                return new move("up");
            } else if (c.getYPos() + speed < Board.boardHeight){
                return new move("down");
            }
        }
        return null;
    }
}

class findEnemyStrategy : opponentStrategy{
    private EnemyController c;

    public findEnemyStrategy(EnemyController controller){
        c = controller;
    }

    public move chooseMove(){
        bool team = c.getStats().getTeam();
        GameObject closest = null;
        int xDist = 10000;
        int yDist = 10000;
        bool isPlayer = false;
        foreach (GameObject piece in Board.allPieces){
            EnemyController subConEnemy = piece.GetComponent<EnemyController>();
            //EnemyController subConEnemy = null;
            PlayerTest01 subConPlayer = piece.GetComponent<PlayerTest01>();
            if(subConEnemy != null){
                if(team != subConEnemy.getStats().getTeam()){
                    int xDis = subConEnemy.getXPos() - c.getXPos();
                    xDis = Math.Abs(xDis);
                    int yDis = subConEnemy.getYPos() - c.getYPos();
                    yDis = Math.Abs(yDis);
                    if(xDist + yDist > xDis + yDis){
                        xDist = xDis;
                        yDist = yDis;
                        closest = piece;
                        isPlayer = false;
                    }
                }
            } else {
                if(!team){
                    int xDis = subConPlayer.GetXPos() - c.getXPos();
                    xDis = Math.Abs(xDis);
                    int yDis = subConPlayer.GetYPos() - c.getYPos();
                    yDis = Math.Abs(yDis);
                    if(xDist + yDist > xDis + yDis){
                        xDist = xDis;
                        yDist = yDis;
                        closest = piece;
                        isPlayer = true;
                    }
                }
            }
        }
        if(isPlayer){
            PlayerTest01 player = closest.GetComponent<PlayerTest01>();
            if(xDist != 0){
                if(player.GetXPos() > c.getXPos()){
                    return new move("right");
                }
                return new move("left");
            }
            if(yDist != 0){
                if(player.GetYPos() > c.getYPos()){
                    return new move("down");
                }
                Debug.Log("player's up");
                return new move("up");
            }
        } else {
            EnemyController enemy = closest.GetComponent<EnemyController>();
            if(xDist != 0){
                if(enemy.getXPos() > c.getXPos()){
                    return new move("right");
                }
                return new move("left");
            }
            if(yDist != 0){
                if(enemy.getYPos() > c.getYPos()){
                    return new move("down");
                }
                Debug.Log("enemy's up");
                return new move("up");
            }
        }
        return null;
    }
}

class debuffEnemyStrategy : opponentStrategy{
    private EnemyController c;

    public debuffEnemyStrategy(EnemyController controller){
        c = controller;
    }

    public move chooseMove(){
        playerStats target = c.getTargetLine("up");
        System.Random rnd = new System.Random();
        int random = rnd.Next(1,3);
        statAffects st;
        if(random == 1){
            st = new statAffects(3, "atk", (float) 0.5);
            
        } else if(random == 2){
            st = new statAffects(3, "def", (float) 0.5);
        } else {
            st = new statAffects(1, "spd", 0);
        }
        if(target != null && target.getTeam() != c.getStats().getTeam()){
            random = rnd.Next(1, 5);
            string color = "neutral";
            if(random == 1){
                color = "red";
            }
            else if(random == 2){
                color = "green";
            }
            else if(random == 3){
                color =  "blue";
            }
            card card = new card(color, st);
            return new move(card, target);
        }
        target = c.getTargetLine("down");
        if(target != null && target.getTeam() != c.getStats().getTeam()){
            random = rnd.Next(1, 5);
            string color = "neutral";
            if(random == 1){
                color = "red";
            }
            else if(random == 2){
                color = "green";
            }
            else if(random == 3){
                color =  "blue";
            }
            card card = new card(color, st);
            return new move(card, target);
        }
        target = c.getTargetLine("right");
        if(target != null && target.getTeam() != c.getStats().getTeam()){
            random = rnd.Next(1, 5);
            string color = "neutral";
            if(random == 1){
                color = "red";
            }
            else if(random == 2){
                color = "green";
            }
            else if(random == 3){
                color =  "blue";
            }
            card card = new card(color, st);
            return new move(card, target);
        }
        target = c.getTargetLine("left");
        if(target != null && target.getTeam() != c.getStats().getTeam()){
            random = rnd.Next(1, 5);
            string color = "neutral";
            if(random == 1){
                color = "red";
            }
            else if(random == 2){
                color = "green";
            }
            else if(random == 3){
                color =  "blue";
            }
            card card = new card(color, st);
            return new move(card, target);
        }
        return null;
    }
}

class aggressiveStrategy : opponentStrategy{
    private opponentStrategy strat;

    public aggressiveStrategy(EnemyController c) {
        combineStrategy st = new combineStrategy(new attackEnemyStrategy(c), new findEnemyStrategy(c));
        strat = new combineStrategy(st, new randomMoveStrategy(c));
    }

    public move chooseMove(){
        return strat.chooseMove();
    }

}

class healerStrategy : opponentStrategy{
    private opponentStrategy strat;

    public healerStrategy(EnemyController c) {
        opponentStrategy s = new combineStrategy(new healTeammatesStrategy(c), new injuredFleeStrategy(c));
        opponentStrategy st = new combineStrategy(s, new attackEnemyStrategy(c));
        opponentStrategy str = new combineStrategy(st, new findInjuredStrategy(c));
        strat = new combineStrategy(str, new randomMoveStrategy(c));
    }

    public move chooseMove(){
        return strat.chooseMove();
    }

}

class supportStrategy : opponentStrategy{
    private opponentStrategy strat;

    public supportStrategy(EnemyController c){
        opponentStrategy s = new combineStrategy(new healTeammatesStrategy(c), new injuredFleeStrategy(c));
        opponentStrategy st = new combineStrategy(s, new buffAllyStrategy(c));
        opponentStrategy str = new combineStrategy(st, new debuffEnemyStrategy(c));
        strat = new combineStrategy(str, new randomMoveStrategy(c));
    }

    public move chooseMove(){
        return strat.chooseMove();
    }
}

class move{
    private bool playCard;
    private string moveDirection;
    private card cardPlayed;
    private playerStats target;

    public move(string move){
        playCard = false;
        moveDirection = move;
    }

    public move(card card, playerStats t){
        playCard = true;
        cardPlayed = card;
        target = t;
    }

    public string getMove(){
        if(!playCard){
            return moveDirection;
        }
        return "card";
    }

    public void doMove(playerStats c){
        cardPlayed.playCard(c, target);
    }
}