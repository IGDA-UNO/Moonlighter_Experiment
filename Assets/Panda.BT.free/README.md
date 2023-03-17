# Panda BT

copyright (c) 2015 Eric Begue

## OVERVIEW
Panda BT is a script-based Behaviour Tree engine for Unity, available as a GameObject component.

The behaviour of a GameObject is defined by writing BT scripts, using a minimalist built-in language to describe the Behaviour Tree structure and its execution flow. A Behaviour Tree consists of a hierarchy of nodes where the deepest node are tasks, which are implemented in C# and invoked from the BT scripts.

The Behaviour Tree is compactly display as a colour coded text directly within the Inspector. A Life View allows visualization and debugging of the Behaviour Tree at run-time, providing relevant information at a glance.


## GETTING STARTED 

A good starting point is to open the sample scenes, play them and observe the running Behaviour Trees in the Inspector by selecting a GameObject of interest. In the inspector, you can double click on a task in the Code Viewer to open the corresponding C# implementation. The samples are ordered from simple to more elaborated.

The Panda Behaviour component can be added to any game object from the Inspector by clicking on "Add Component" then by selecting `Scripts > Panda > Panda Behaviour`.

The Panda Behaviour component requires BT scripts to be functional. You can create a new BT script by right clicking in a asset folder in the Project tab then by selecting `Create > Panda BT Script`.

A BT script can invoke tasks defined in any MonoBehaviour attached to the GameObject. A task can be:

- a boolean field
- a boolean property
- a method returning void 

A task is recognized with the `[Task]` attribute. 


## LINK 

For more documentations and examples please visit:

[http://www.pandabehaviour.com](http://www.pandabehaviour.com)

