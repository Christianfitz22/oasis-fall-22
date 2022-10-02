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

    string name;
    string color;
    Type cardType;
    /**
    Generic constructor for the card.
    */
    public card(string name);

    /**
    Constructor for the card. Takes in the color for the card.
    */
    public card(string name, string color);

    /**
    What happens when card is played.
    */
    public void playCard();
}
/**
An Active card class.
*/
class activeCard{
    

}