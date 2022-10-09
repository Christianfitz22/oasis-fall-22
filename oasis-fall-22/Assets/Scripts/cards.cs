class card{
    
    private string color;
    private statAffects whenCardPlayed;
    private boolean isActive;
    private boolean isAttack;

    /**
    Constructor for a support card.
    */
    public card(string c, statAffects s){
        if(c == null || s == null){
            throw new IllegalArgumentException("Cannot be null");
        }
        if(!(String.Equals(c, "red") && String.Equals(c, "blue") && String.Equals(c, "green") && String.Equals(c, "neutral"))){
            throw new IllegalArgumentException("Color must be red, blue, green, or neutral.");
        }
        color = c;
        whenCardPlayed = s;
        isActive = false;
    }
    /**
    Constructor for an active card.
    */
    public card(string c, boolean isATK){
        if(c == null || isATK == null){
            throw new IllegalArgumentException("Cannot be null");
        }
        color = c;
        isActive = true;
        isAttack = isATK;
    }

    public string getColor(){
        return color;
    }

    /**
    Called when you want to play the card.
    */
    public void playCard(playerStats player, playerStats target){
        if(!isActive){
            target.addAffect(statAffects);
        }
        else if(!isAttack){
            int healed = player.getATK();
            target.changeHealth(healed);
        }
        else{
            //getting attacked
        }
    }
}