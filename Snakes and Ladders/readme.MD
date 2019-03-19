Snakes and ladders library
> How did you approach the problem?
May main goal is to capture the game-rules in this library so that the UI coder doesn't have to, while at the same time allowing for a flexiable UI.

> How did you make key design decisions and what alternatives did you consider?
* I decided to return status-codes from my "Action" methods and limit exceptions; makes the lib easier to use.
* Expose Move(token, moves) so UI can optionally show dice roll before moving, and to simplify testing.
* Used methods to act on the board, properties are read only, again for ease-of-use.
* Decided to use a basic types (sting,int,dict) to store most of internal state, instead of something more complex, this could be improved later if needed.
* The implemenation is not thread safe.
* I couldn't come up with a good way to unit test the Dice class.

>How do you envision your solution evolving in the future?
In addition to the features in the source URL.
* Would be useful to have a method to serialize/derialize the board.
* Add a reset method to the board.
* A move counter or leader board functionality.
* As this is a game of pure chance, once snakes and ladders are implemented, might be interesting to calculate the odds of winning from a given board setup.

Usage notes
* Instantiate a new Board class for each game, passing one or move token names (strings).
* Use Move(token, moves) to move an arbirtray number of moved (but limited to number of options on the dice.)
* Use RollAndMove(token) to roll the dice and move accordingly.
* Check Dice.Value for the last dice roll
* Check the result of functions that return MoveResult to check for win-condition, erros, etc.
* Game is over when the Winner field is set or MoveResult = YouWon.