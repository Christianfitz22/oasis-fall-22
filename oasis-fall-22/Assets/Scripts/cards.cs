/**
The class that represents a generic card.
*/
class card{
    
    private string color;
    private statAffects whenCardPlayed;
    private boolean isActive;

    /**
    Constructor for the card.
    */
    public card(string c, statAffects s, boolean a){
        if(c == null || s == null || a == null){
            throw new IllegalArgumentException("Cannot be null");
        }
        if(!(String.Equals(c, "red") && String.Equals(c, "blue") && String.Equals(c, "green") && String.Equals(c, "neutral"))){
            throw new IllegalArgumentException("Color must be red, blue, green, or neutral.");
        }
        
        //something about s
        color = c;
        whenCardPlayed = s;
        isActive = a;
    }

    public string getColor(){
        return color;
    }

    /**
    Called when you want to play the card.
    */
    public void playCard(playerStats player, playerStats target){
        
    }
}