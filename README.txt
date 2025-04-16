Assignment 2 - "John Lemon" by Robert Wilson and Foster Hobbs

Features Added:
Adjustable Enemy Line of Sight (Dot Product) - Robert Wilson
	Used dot product to calculate whether player is in view
	of enemies. Vision cones and vision distance are now 
	adjustable. As set, gargoyles are able to see farther
	but in a more narrow angle, while ghosts are able to 
	see in a wider angle but not nearly as far.

Linear Interpolation - Foster Hobbs
	I wanted the Gargoyles to rotate to "search" for the player
	when they "heard" or sensed that they were nearby. Initially
	tried doing this by directly working on tranform.rotation, but
	I need to study up on Quaternions and Slerp. Implemented feature
	using other methods and used Lerp to adjust the speed of the "searching"
	relative to the amount of time the player is nearby. Robert worked out
	a raycasting method for making this not work through walls and I
	debugged it.

Particle Effect -
	Added smoke particle effect triggered by nearby player. Smoke billows as the
	Gargoyle gets more and more worked up about sensing the nearby player and the
	speed of the search increases.

Gargoyle Alerted (Sound Effect) - Robert Wilson
	Added a sound effect where if player enters
	a gargoyle's suspicion range, a sound 
	effect plays of a voice saying "What's that?"
