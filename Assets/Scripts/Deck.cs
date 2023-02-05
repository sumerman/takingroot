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
    const int defaultHandSize = 3;
    Queue<Card> cards;

    public Deck(List<Card> cards)
    {
        DeckRandomizer.Shuffle(cards);
        new Deck(new Queue<Card> (cards));
    }

    public Deck(Queue<Card> cards)
    {
        this.cards = cards;
    }

    public static Deck GenerateSafeDeck(AvailableCards availableCards, CharacterType characterType)
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
            if (!victoryCardsIds.Contains(cardId))
            {
                safeDeck.Add(availableCards.GetCard(cardId));
            }
        }
        DeckRandomizer.Shuffle(safeDeck, safeCardsNumber, safeDeck.Count);
        DeckRandomizer.Shuffle(safeDeck, 0, defaultHandSize);

        return new Deck(new Queue<Card> (safeDeck));
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


    private Queue<Card> ShuffleDeck(List<Card> cards)
    {
        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n);
            Card value = cards[k];
            cards[k] = cards[n];
            cards[n] = value;
        }

        return new Queue<Card>(cards);
    }
}
