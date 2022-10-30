class deck{
    //the deck
    private List<cards> deckOfCards;

    //create the deck
    public deck(){
        deckOfCards = new List<cards>();
        deckOfCards.Add(new card(chooseRandomColor(), true)); //an attacking card :D
        deckOfCards.Add(new card(chooseRandomColor(), true)); //an attacking card :D
        deckOfCards.Add(new card(chooseRandomColor(), true)); //an attacking card :D
        deckOfCards.Add(new card(chooseRandomColor(), false)); //a healing card :D
        deckOfCards.Add(new card(chooseRandomColor(), createNewStatAffect("spd", true))); //movement buff card
        deckOfCards.Add(new cards(chooseRandomColor(), createNewStatAffect("spd", false))); //movement debuff card
        deckOfCards.Add(new cards(chooseRandomColor(), createNewStatAffect("atk", true))); //atk buff
        deckOfCards.Add(new cards(chooseRandomColor(), createNewStatAffect("atk", false))); //atk debuff
        deckOfCards.Add(new cards(chooseRandomColor(), createNewStatAffect("def", true))); //def buff
        deckOfCards.Add(new cards(chooseRandomColor(), createNewStatAffect("def", false))); //def debuff
    }

    private statAffects createNewStatAffect(string str, boolean buff){
        if(buff){
            return new statAffects(3, str, 2);
        }
        else if(str == "spd"){
            return new statAffects(1, str, 0);
        }
        else{
            return new statAffects(3, str, 0.5);
        }
    }

    /**
    Choose a random color for our cards.
    */
    private string chooseRandomColor(){
        Random rnd = new Random();
        int random = rnd.Next(1, 5);
        if(random == 1){
            return "red";
        }
        else if(random == 2){
            return "green";
        }
        else if(random == 3){
            return "blue";
        }
        else{
            return "neutral";
        }
    }

    //choose five random cards
    public List<cards> chooseCards(){
        Random rnd = new Random();
        List<cards> returnCards = new List<cards>();
        for(int i = 0; i < 5; i++){
            int random = rnd.next(1, deckOfCards.Count);
            returnCards.Add(deckOfCards.ElementAt(random));
            deckOfCards.removeAt(random);
        }
        return returnCards;
    }
}