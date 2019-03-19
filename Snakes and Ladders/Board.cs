using System.Collections.Generic;
using System.Linq;

namespace SnakesAndLaddersLib
{

	/// <summary>Possible outcomes of moving a token.</summary>
	public enum MoveResult
	{
		Ok,
		YouWon,
		GameOver,
		InvalidMove,
		InvalidToken,
		Error
	}

	/// <summary>The game board</summary>
	public class Board
	{
		/// <summary>Number of squares on the board;</summary>
		public int Length { get; } = 100;

		/// <summary>Position of the tokens on the board.</summary>
		private Dictionary<string, int> Positions { get; }

		/// <summary>Set to the winner token once a player wins, Otehrwise null.</summary>
		public string Winner { get; private set; }

		/// <summary>The dice used on this board.</summary>
		public Dice Dice { get; } = new Dice();

		/// <summary>Contructor</summary>
		/// <param name="tokens">List of token names to play on this board.</param>
		public Board(params string[] tokens)
		{
			Positions = tokens.ToDictionary(p => p, p => 1);
		}

		/// <summary>Get the position of a token on the board.</summary>
		/// <param name="token">The token.</param>
		/// <returns>The position or -1 if token is invalid.</returns>
		public int Position(string token)
		{
			if (Positions.TryGetValue(token, out int position))
				return position;

			return -1;
		}

		/// <summary>Basic move.</summary>
		/// <param name="token">The token to move.</param>
		/// <param name="moves">How many places to move.</param>
		/// <returns>The outcome of the move.</returns>
		public MoveResult Move(string token, int moves)
		{
			try
			{
				if (Winner != null)
					return MoveResult.GameOver;

				if (moves > Dice.DiceMax || moves < Dice.DiceMin)
					return MoveResult.InvalidMove;

				if (Position(token) == -1)
					return MoveResult.InvalidToken;

				Positions[token] += moves;

				if (Positions[token] >= Length)
				{
					Positions[token] = 100;
					Winner = token;
					return MoveResult.YouWon;
				}

				return MoveResult.Ok;
			}
			catch
			{
				return MoveResult.Error;
			}
		}

		/// <summary>Rolls the dice and moves the token.</summary>
		/// <param name="token">The token to move.</param>
		/// <returns>A MoveResult.</returns>
		public MoveResult RollAndMove(string token)
		{
			Dice.Roll();
			return Move(token, Dice.Value);
		}
	}


}