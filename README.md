# Battleships

# Models

First of all, the work began with modeling classes to meet expectations. Project contains Cell, Player and Ship models with some predifiend variables. Ship have definition of 5 constant ships. Player get info about simple things like Name, Placed Ships or Board.
Cell is just a X, Y properties.

# Helpers

Extensions class was build to get methods used frequently and make them static. To meet Battleships behavior, with extensions you can check if target is outside of map or iterate around shoting cell to find out more info about board simulatiton.

# Logic

Board Logic only defines drawing boards in console. Cell logic was designed to mark random shots on board or generate random shot. Ship generations focuses on placing predifiend ships on board with logic that supports longer ships by generating their direction. In order to create shooting mechanic, there was simple UML prepared and implented. If target is hitted there is recursion to plan next position to shot. All sinked ships, misses or hits mark board with given number to distinc actions.


# Run

In order to start the project, you have to open Battleships.View.exe file. Program class that starts defines only object initialization of Simulation class. Simulation beha as simpple as possible with basic methods to navigate behavior like Drawing ships, then simulating fighting.
