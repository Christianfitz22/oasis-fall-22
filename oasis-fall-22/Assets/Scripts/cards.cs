/**
The interface that represents a generic card.
*/
interface card{
    /**
    An enum that represents the types of cards there are.
    */
    enum Type{
        Active,
        Support
    }

    string color;
    Type cardType;
    /**
    Generic constructor for the card.
    */
    public card();

    /**
    Constructor for the card. Takes in the color for the card.
    */
    public card(string color);

    /**
    Called when you want to play the card.
    */
    void playCard(playerStats player, playerStats target);
}
/**
An Active card class.
*/
class activeCard : card{
    
    //Can only be attack or heal at the moment.
    string action;

    public card(){
        color = "neutral";
        cardType = Type.Active;
        action = "attack";
    }

    public card(string color, string type){
        if(!(String.Equals(type, "attack") && String.Equals(type, "heal"))){
            throw new IllegalArgumentException("Invalid action type.");
        }
        if(!(String.Equals(color, "red") && String.Equals(color, "blue") && String.Equals(color, "green") && String.Equals(color, "neutral"))){
            throw new IllegalArgumentException("Color must be red, blue, green, or neutral.");
        }
        color = color;
        action = type;
        cardType = Type.Active;
    }

    /**
    The method you use when you want to play a card.
    */
    public void playCard(playerStats player, playerStats target){
        //what happens when you play a card
    }
}
/**
A Support Card class.
*/
class supportCard : card{

    //The stat that is being supported.
    string statSupported;

    public card(){
        color = "neutral";
        cardType = Type.Support;
        statSupported = "ATK";
    }

    public card(string color, string stat){
        if(!(String.Equals(color, "red") && String.Equals(color, "blue") && String.Equals(color, "green") && String.Equals(color, "neutral"))){
            throw new IllegalArgumentException("Color must be red, blue, green, or neutral.");
        }
        if(!(String.Equals(stat, "ATK") && String.Equals(stat, "DEF") && String.Equals(stat, "SPD"))){
            throw new IllegalArgumentException("Not a stat.");
        }
        color = color;
        cardType = Type.Support;
        statSupported = stat;
    }

    /**
    The method you use when you want to play a card.
    */
    public void playCard(playerStats player, playerStats target){
        //what happens when you play a card
    }
}