class card{
    
    private string color;
    private statAffects whenCardPlayed;
    private boolean isActive;
    //replace with an array so that you can do ranged attacks
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

    private int weaponTriangle(string targetColor){
        if(String.Equals(this.color, "red")){
            if(String.Equals(targetColor, "green")){
                return 1.5;
            }
            if(String.Equals(targetColor, "blue")){
                return 0.5;
            }
        }
        if(String.Equals(this.color, "green")){
            if(String.Equals(targetColor, "blue")){
                return 1.5;
            }
            if(String.Equals(targetColor, "red")){
                return 0.5;
            }
        }
        if(String.Equals(this.color, "blue")){
            if(String.Equals(targetColor, "red")){
                return 1.5;
            }
            if(String.Equals(targetColor, "green")){
                return 0.5;
            }
        }
        return 1;
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
            //fix so ranged attacks work
            int atk = player.getATK();
            int def = target.getDEF();
            int damage = def - atk;
            damage = damage * this.weaponTriangle(target.getColor());
            if(def < atk){
                target.changeHealth(damage);
            }
        }
    }
}