class playerStats{
    sealed int totalHP;
    private int HP;
    sealed int baseATK;
    private int ATK;
    sealed int baseDEF;
    private int DEF;
    private int SPD;
    private string color;
    private boolean hasMoved;
    private boolean isAlive;

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
    }

    public int getCurrentHealth(){
        return HP;
    }

    public int getATK(){
        return ATK;
    }

    public int getDEF(){
        return DEF;
    }

    public int getMovementSpeed(){
        return SPD;
    }

    public string getColor(){
        return color;
    }

    public void endRound(){
        hasMoved = false;
        //reset stats, consider buffs
    }

    public void isDead(){
        return isDead;
    }

    /**
    Called if the player chooses the defend option.
    */
    public void defend(){
        if(hasMoved){
            throw new IllegalArgumentException("Player has already moved.");
        }
        DEF = DEF + 2;
        hasMoved = true;
    }

    /**
    Generic method to be called if the player makes a move.
    */
    public void makeMove(){
        if(hasMoved){
            throw new IllegalArgumentException("Player has already moved.");
        }
        hasMoved = true;
    }

    /**
    Methods to be implemented:
    endRound
    getAttacked
    getSupported
    checkIsDead? - maybe
    */
}