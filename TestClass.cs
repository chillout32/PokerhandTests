using Xunit;
using CardGame;

namespace Pokerhands;

public class TestClass
{

    [Fact]
    public void TestMethodSameHandLowerFirst()
    {
        // Arrange
        var lowerHand = new Hand(
        [
            new Card('♣', '5'),
            new Card('♠', '5'),
            new Card('♠', '5'),
            new Card('♣', 'K'),
            new Card('♠', 'K')
        ]);

        var higherHand = new Hand(
        [
            new Card('♠', 'A'),
            new Card('♣', 'A'),
            new Card('♠', 'A'),
            new Card('♠', 'K'),
            new Card('♣', 'K')
        ]);

        // Act

        var (winningHand, handType) = CompareHands.CheckHands(lowerHand, higherHand);

        // Assert

        Assert.True(winningHand == higherHand);
        Assert.Equal("Full House", handType);
    }

    [Fact]
    public void TestMethodSameHandHigherFirst()
    {
        // Arrange
        var lowerHand = new Hand(
        [
            new Card('♣', '5'),
            new Card('♠', '5'),
            new Card('♠', '5'),
            new Card('♣', 'K'),
            new Card('♠', 'K')
        ]);

        var higherHand = new Hand(
        [
            new Card('♠', 'A'),
            new Card('♣', 'A'),
            new Card('♠', 'A'),
            new Card('♠', 'K'),
            new Card('♣', 'K')
        ]);

        // Act

        var (winningHand, handType) = CompareHands.CheckHands(higherHand, lowerHand);

        // Assert

        Assert.True(winningHand == higherHand);
        Assert.Equal("Full House", handType);
    }

    [Fact]
    public void TestMethodIsPair()
    {
        // Arrange
        var pairHand = new Hand(
        [
            new Card('♣', '5'),
            new Card('♠', '5'),
            new Card('♠', '4'),
            new Card('♣', '7'),
            new Card('♠', '9')
        ]);


        // Act

        var (hand1Result, handType) = CompareHands.IsPair(pairHand);

        // Assert
        // Example of types of asserts
        Assert.NotNull(hand1Result);
        Assert.NotNull(handType);
        Assert.True(hand1Result == pairHand);
        Assert.Equal("Pair", handType);
    }

    [Fact]
    public void TestMethodIsFlush()
    {
        var flushHand = new Hand(
        [
            new Card('♣', '5'),
            new Card('♣', '7'),
            new Card('♣', '9'),
            new Card('♣', 'K'),
            new Card('♣', 'A')
        ]);
        
        var (hand1Result, handType) = CompareHands.IsFlush(flushHand);
        Assert.NotNull(hand1Result);
        Assert.Equal("Flush", handType);
    }

    [Fact]
    public void TestMethodIsStraight()
    {
        var straightHand = new Hand(
        [
            new Card('♠', '5'),
            new Card('♣', '6'),
            new Card('♦', '7'),
            new Card('♠', '8'),
            new Card('♣', '9')
        ]);

        var (hand1Result, handType) = CompareHands.IsStraight(straightHand);
        Assert.NotNull(hand1Result);
        Assert.Equal("Straight", handType);
    }

    [Fact]
    public void TestMethodIsFullHouse()
    {
        var fullHouseHand = new Hand(
        [
            new Card('♠', 'K'),
            new Card('♣', 'K'),
            new Card('♦', 'K'),
            new Card('♠', '5'),
            new Card('♣', '5')
        ]);

        var (hand1Result, handType) = CompareHands.IsFullHouse(fullHouseHand);
        Assert.NotNull(hand1Result);
        Assert.Equal("Full House", handType);
    }

    [Fact]
    public void TestMethodIsFourOfAKind()
    {
        var fourOfAKindHand = new Hand(
        [
            new Card('♠', 'Q'),
            new Card('♣', 'Q'),
            new Card('♦', 'Q'),
            new Card('♥', 'Q'),
            new Card('♣', '3')
        ]);

        var (hand1Result, handType) = CompareHands.IsFourOfAKind(fourOfAKindHand);
        Assert.NotNull(hand1Result);
        Assert.Equal("Four of a Kind", handType);
    }

    [Fact]
    public void TestMethodCheckHandsRoyalFlushVsFourOfAKind()
    {
        var royalFlushHand = new Hand(
        [
            new Card('♠', 'T'),
            new Card('♠', 'J'),
            new Card('♠', 'Q'),
            new Card('♠', 'K'),
            new Card('♠', 'A')
        ]);

        var fourOfAKindHand = new Hand(
        [
            new Card('♠', 'Q'),
            new Card('♣', 'Q'),
            new Card('♦', 'Q'),
            new Card('♥', 'Q'),
            new Card('♣', '3')
        ]);

        var (winningHand, handType) = CompareHands.CheckHands(royalFlushHand, fourOfAKindHand);
        Assert.True(winningHand == royalFlushHand);
        Assert.Equal("Royal Straight Flush", handType);
    }

    [Fact]
    public void TestMethodCheckHandsPairVsTwoPair()
    {
        var pairHand = new Hand(
        [
            new Card('♣', '5'),
            new Card('♠', '5'),
            new Card('♠', '4'),
            new Card('♣', '7'),
            new Card('♠', '9')
        ]);

        var twoPairHand = new Hand(
        [
            new Card('♣', '5'),
            new Card('♠', '5'),
            new Card('♠', '7'),
            new Card('♣', '7'),
            new Card('♠', '9')
        ]);

        var (winningHand, handType) = CompareHands.CheckHands(pairHand, twoPairHand);
        Assert.True(winningHand == twoPairHand);
        Assert.Equal("Two Pair", handType);
    }

    [Fact]
    public void TestMethodCheckHandsHighCard()
    {
        var lowerHand = new Hand(
        [
            new Card('♣', '2'),
            new Card('♦', '5'),
            new Card('♠', '7'),
            new Card('♥', '9'),
            new Card('♠', 'J')
        ]);

        var higherHand = new Hand(
        [
            new Card('♣', '3'),
            new Card('♦', '6'),
            new Card('♠', '8'),
            new Card('♥', 'T'),
            new Card('♠', 'Q')
        ]);

        var (winningHand, handType) = CompareHands.CheckHands(lowerHand, higherHand);

        Assert.True(winningHand == higherHand);
        Assert.Equal("High Card", handType);
}

}