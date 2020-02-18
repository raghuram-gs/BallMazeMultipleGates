# BallMaze

Solution for Ball maze tree problem 

*****************************************************************
## Approach to the problem
*****************************************************************

### 1. Prediction

My first assumption here was to pick a random of the containers and make a prediction

Later after some thought I took the following approach:

* Traverse the tree from the root

* Take the opposite direction of the gate

* Find the leaf node which leads with this traversal 

It worked :)

The prediction works under following conditions:

 * Predicts only one container
 
 * Works for Level 4 and above (Passing 15 balls to level 3 will fill all the containers)
 
 * Assuming we are always passing 15 balls.
 
If the balls used are controlled for e.g. If balls are ((2 Power of level) - 1) or (leaf nodes - 1) then the prediction can be made to work with different levels

### 2. Passing of ball 

I approached to solve the problem by using a composite pattern in combination with a binary tree behaviour
Additionally a builder was used to build the Tree maze with a specified level.

Please refer the **BallMazeApproachDesign.png** to have a rough look at the design

****************************************************************

*****************************************************************
## Time spent details
*****************************************************************

### 1. Prediction

* Approach thought - 1 Hour

* Coding - 10 mins

### 2. Passing of ball

* Approach thought and undestanding the problem - 1 Hour

* Coding - 1 Hour 40 mins

* Console display formatting - 30 mins

* Design documentation - 20 mins

**Total - 4 Hr 40 mins** 

*****************************************************************
