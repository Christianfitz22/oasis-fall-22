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
            } else if(c.getXPos() + speed >= 9){
                return new move("right");
            }
        }
        target = c.getTargetLine("down");
        if(target != null && target.getTeam() != c.getStats().getTeam()){
            if(c.getXPos() - speed >= 0){
                return new move("left");
            } else if(c.getXPos() + speed >= 9){
                return new move("right");
            }
        }
        target = c.getTargetLine("right");
        if(target != null && target.getTeam() != c.getStats().getTeam()){
            if(c.getYPos() - speed >= 0){
                return new move("up");
            } else if (c.getYPos() + speed >= 7){
                return new move("down");
            }
        }
        target = c.getTargetLine("left");
        if(target != null && target.getTeam() != c.getStats().getTeam()){
            if(c.getYPos() - speed >= 0){
                return new move("up");
            } else if (c.getYPos() + speed >= 7){
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
        //TODO: fix
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
            } else if(c.getXPos() + speed >= 9){
                return new move("right");
            }
        }
        target = c.getTargetLine("down");
        if(target != null && target.getTeam() != c.getStats().getTeam()){
            if(c.getXPos() - speed >= 0){
                return new move("left");
            } else if(c.getXPos() + speed >= 9){
                return new move("right");
            }
        }
        target = c.getTargetLine("right");
        if(target != null && target.getTeam() != c.getStats().getTeam()){
            if(c.getYPos() - speed >= 0){
                return new move("up");
            } else if (c.getYPos() + speed >= 7){
                return new move("down");
            }
        }
        target = c.getTargetLine("left");
        if(target != null && target.getTeam() != c.getStats().getTeam()){
            if(c.getYPos() - speed >= 0){
                return new move("up");
            } else if (c.getYPos() + speed >= 7){
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
        //TODO: fix
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
        int random = rnd.Next(1,4);
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
        strat = new combineStrategy(new attackEnemyStrategy(c), new findEnemyStrategy(c));
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