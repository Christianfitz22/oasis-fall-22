class statAffects{

    private int turnsLeft;
    /**
    "atk", "def", "spd"
    */
    private string statAffected;
    private int affectedBy;   

    public statAffects(int t, string s, int num){
        if(t < 0){
            throw new IllegalArgumentException("what the fuck");
        }
        if(t == null || s == null|| int == null){
            throw new IllegalArgumentException("cannot be null");
        }
        if(num <= 0){
            throw new IllegalArgumentException("Cannot be nonpositive");
        }
        turnsLeft = t;
        statAffected = s;
        affectedBy = num;
    }

    public void turnPass(){
        turnsLeft = turnsLeft - 1;
    }

    public boolean noMoreTurns(){
        if(turnsLeft <= 0){
            return true;
        }
        return false;
    }

    public int getTurn(){
        return turnsLeft;
    }

    public string statAffected(){
        return statAffected;
    }

    public int changeStats(int originalStat){
        return originalStat * affectedBy;
    }
}