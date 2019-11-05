<h1>Nim</h1>

<h2>Description</h2>
Nim is a game where two players take turns removing items from three different piles. On a turn, the player removes any number of items from any same pile, and must at least take one item. The winner is the last person to remove a stone. 
The strategy has been mathematically proven for all initial pile/item combinations and calculated using binary digital sum of the piles, otherwise known as the Nim Sum. The goal is to acheive a Nim Sum of zero at the end of your turn.
A computer does this by summing the binary values of all piles and ignoring the carried digits. This operations is called "exclusive or" represented by a ```^``` character in most languages.

Here is an example of how a simple game play would look like:<br>
![StepByStepGameVisula](https://www.google.com/url?sa=i&source=images&cd=&ved=2ahUKEwi7-JqN4tPlAhUS7J4KHXZJDdYQjRx6BAgBEAQ&url=https%3A%2F%2Fplus.maths.org%2Fcontent%2Fplay-win-nim&psig=AOvVaw185vr3NLUyRCVZTmlOCjMb&ust=1573067195379836 "Step by step game visual")

<h2>Installation</h2>

1. Clone this repository
    * ```git clone https://github.com/MeStock/nim.git```
2. Build and start the program

<h2>How to Play</h2>

1. Select your difficulty:
    * ![WelcomePage](WelcomePage.png "Game Welcome Page")
2. Make a move:
    * Use arrow keys to move from pile to pile
    * Hit enter to select a pile
    * Enter the amount of items you would like to remove from the selected pile
    * ![HowToPlay](MakeAMove.png "How To Play")
3. See the computers move
 * ![ComputerTurn](ComputerTurn.png "See Computers Moves")
4. Continue until the game is over

<h2>Features</h2>

* Difficulties:
    * Easy: 25% chance computer will choose optimal move
    * Medium: 50% chance computer will choose optimal move
    * Hard: Computer will play optimally
* Prediction:
    * Use Grundy Number & Nim sum to calculate winner based on number of stones at start of game

<h2>Resources</h2>
* [Game Theory & Math Proof - Wikipedia](https://en.wikipedia.org/wiki/Nim)
* [Game Theory - Geeks For Geeks](https://www.geeksforgeeks.org/combinatorial-game-theory-set-2-game-nim/)
* [Calculating Winner - Geeks For Geeks](https://www.geeksforgeeks.org/find-winner-nim-game/)
* [Winning Odds - Medium Article](https://medium.com/100-days-of-algorithms/day-90-simple-nim-ai-864b2fdf9e8a)
* [Algorithm - OpenGenius](https://iq.opengenus.org/game-of-nim/)
