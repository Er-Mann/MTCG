
namespace MonsterCardGame.Models.Cards;

public class Card
{
    public Card(ElementType elementType, string cardName, int baseDamage)
    {
        ElementType = elementType;
        CardName = cardName;
        BaseDamage = baseDamage;
    }



    public string CardName { get; protected set; }

    public int BaseDamage { get; protected set; }
    public ElementType ElementType { get; protected set; }

}

public enum ElementType
{
    Water,
    Fire,
    Normal
}