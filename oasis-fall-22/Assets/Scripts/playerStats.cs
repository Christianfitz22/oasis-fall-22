class playerStats{
    sealed int totalHP;
    sealed int baseATK;
    sealed int baseDEF;
    sealed int SPD;
    private string color;
    private boolean hasMoved;
    private boolean isAlive;
    private boolean hasDefended;
    private List<statAffects> buffs;

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
        q = new Queue();
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
        //go through q
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
        hasDefended = true;
        hasMoved = true;
    }

    /**
    Called if the player chooses the move option.
    */
    public void moveSpot(){
        if(hasMoved){
            throw new IllegalArgumentException("Player has already moved.");
        }
        hasMoved = true;
    }

    public List<statAffects> returnList(){
        return buffs;
    }

    /**
    Called if the player plays a card.
    */
    public void playCard(card card, playerStats target){
        if(hasMoved){
            throw new IllegalArgumentException("Player has already moved.");
        }
        hasMoved = true;
        card.playCard(this, target);
    }

    public void endRound(){
        foreach (statAffect a in this.buffs){
            a.turnPass();
            if(a.noMoreTurns){
                this.buffs.Remove(a);
            }
        }
        hasMoved = false;
        hasDefended = false;
    }
    
    public void addAffect(statAffects new){
        this.buffs.Add(new);
    }
}