using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class DeckRandomizer
{
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public static void Shuffle<T>(this IList<T> list, int minIndex, int maxIndex)
    {
        int n = maxIndex;
        while (n > minIndex + 1)
        {
            n--;
            int k = Random.Range(minIndex, n);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}

public class Deck
{
    const int maxArgumentCardId = 12;
    public const int defaultHandSize = 3;
    public const int deckSize = 8;
    Queue<Card> cards;
    public static List<Card> extraCards;
    public static List<Card> currentDeck;
    public static AvailableCards availableCards;

    public Deck(List<Card> cards)
    {
        DeckRandomizer.Shuffle(cards);
        new Deck(new Queue<Card> (cards));
    }

    public Deck(Queue<Card> cards)
    {
        this.cards = cards;
    }

    public static Deck GenerateSafeDeck(CharacterType characterType)
    {
        int safeCardsNumber = characterType.victoriesRequired;
        Nature nature = characterType.SelectedNature;
        List<int> victoryCardsIds = nature.VictoryCardIds();
        DeckRandomizer.Shuffle(victoryCardsIds);

        List<Card> safeDeck = new List<Card>();
        for (int i = 0; i < safeCardsNumber; i++)
        {
            safeDeck.Add(availableCards.GetCard(victoryCardsIds[i]));
        }
        for (int cardId = 1; cardId <= maxArgumentCardId; cardId++)
        {
            Card c = availableCards.GetCard(cardId);
            if (!safeDeck.Contains(c))
            {
                safeDeck.Add(c);
            }
        }
        DeckRandomizer.Shuffle(safeDeck, safeCardsNumber, safeDeck.Count);
        DeckRandomizer.Shuffle(safeDeck, 0, defaultHandSize);

        Deck.extraCards = safeDeck.GetRange(deckSize, safeDeck.Count - deckSize);
        for (int cardId = maxArgumentCardId + 1; cardId < availableCards.cards.Count; cardId++)
        {
            if ((ActionCards) cardId != ActionCards.Meme)
            {
                Deck.extraCards.Add(availableCards.GetCard(cardId));
            }
        }
        Deck.currentDeck = safeDeck.GetRange(0, deckSize);

        return new Deck(new Queue<Card> (Deck.currentDeck));
    }

    public static Deck ShuffleNewDeck()
    {
        DeckRandomizer.Shuffle(Deck.currentDeck);
        return new Deck(Deck.currentDeck);
    }

    public int Size
    {
        get { return cards.Count; }
    }

    public bool CanDrawCard()
    {
        return (Size > 0);
    }

    public Card DrawNewCard()
    {
        return cards.Dequeue();
    }
}
