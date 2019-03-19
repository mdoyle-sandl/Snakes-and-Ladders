using NUnit.Framework;
using SnakesAndLaddersLib;

namespace SnakesAndLaddersTests
{
	/// <summary>Unit tests for Snakes and Ladders lib.</summary>
	/// <remarks>Based on <see cref="http://agilekatas.co.uk/katas/SnakesAndLadders-Kata"/></remarks>
	public class Tests
	{
		[Test]
		public void AssertNewToeknIsOnSquareOne()
		{
			var board = new Board("Player 1");
			Assert.AreEqual(1, board.Position("Player 1"), "Token should start on position 1.");
			Assert.IsNull(board.Winner, "Winner should be null");
		}

		[Test]
		public void AssertDiceIsUsually1To6()
		{
			var dice = new Dice();
			for (int ii = 0; ii++ < 100;) //roll the dice 100 times, hopefully it never returns -1 or e^pi!
			{
				dice.Roll();
				Assert.IsTrue(dice.Value <= 6 && dice.Value >= 1, "Invalid dice value:{0}", dice.Value);
			}
		}

		[Test]
		public void AssertMovesTokenToCorrectPositions()
		{
			var board = new Board("Player 1");

			var result1 = board.Move("Player 1", 3);
			Assert.AreEqual(MoveResult.Ok, result1);
			Assert.AreEqual(4, board.Position("Player 1"), "Incorrect position after 1st move.");

			var result2 = board.Move("Player 1", 4);
			Assert.AreEqual(MoveResult.Ok, result2);
			Assert.AreEqual(8, board.Position("Player 1"), "Incorrect position after 2nd move.");
		}

		[Test]
		public void AssertMoveTokenIsLimitedToMax6()
		{
			var board = new Board("Player 1");
			var result = board.Move("Player 1", 7);
			Assert.AreEqual(MoveResult.InvalidMove, result);
		}

		[Test]
		public void AssertMoveTokenIsLimitedToMin1()
		{
			var board = new Board("Player 1");
			var result = board.Move("Player 1", 0);
			Assert.AreEqual(MoveResult.InvalidMove, result);
		}

		[Test]
		public void AssertRollAndMoveToTheCorrectPosition()
		{
			var board = new Board("Player 1");
			var result = board.RollAndMove("Player 1");
			Assert.AreEqual(MoveResult.Ok, result, "Ok was not returned");
			Assert.AreEqual(1 + board.Dice.Value, board.Position("Player 1"), "Wrong end position");
		}

		[Test]
		public void AssertIsWonAt100()
		{
			var board = new Board("Player 1");
			for (int i = 0; i < 96; i++)
			{
				board.Move("Player 1", 1);
			}
			//now at position 97.
			Assert.AreEqual(97, board.Position("Player 1"), "Player should be at 97.");

			var result = board.Move("Player 1", 3);
			Assert.AreEqual(MoveResult.YouWon, result, "YouWon was not returned.");
			Assert.AreEqual("Player 1", board.Winner, "Winner was not set.");
		}

		[Test]
		public void AssertPositionOfInvalidTokenIsMinusOne()
		{
			var board = new Board("Player 1");
			Assert.AreEqual(-1, board.Position("Player 999"), "Position of invaliad token should return -1");
		}

		[Test]
		public void AssertToeknEndsGameOn100()
		{
			var board = new Board("Player 1");
			for (int i = 0; i < 96; i++)
			{
				board.Move("Player 1", 1);
			}
			Assert.AreEqual(97, board.Position("Player 1"), "Player should be at 97.");
			board.Move("Player 1", 4);
			Assert.AreEqual(100, board.Position("Player 1"), "Player should be at 100.");
		}
	}
}