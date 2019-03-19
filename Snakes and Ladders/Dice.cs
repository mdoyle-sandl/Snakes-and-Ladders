using System;

namespace SnakesAndLaddersLib
{
	/// <summary>A dice</summary>
	public class Dice
	{
		public const int DiceMin = 1;
		public const int DiceMax = 6;

		private readonly Random _random = new Random();

		public Dice()
		{
			Roll();
		}

		/// <summary>Changes the value field to a random value between DiceMin and DiceMax (inclusive) or -1 if something went wrong.</summary>
		public void Roll()
		{
			try
			{
				Value = _random.Next(DiceMin, DiceMax);
			}
			catch
			{
				Value = -1;
			}
		}

		public int Value { get; private set; } = -1;
	}
}