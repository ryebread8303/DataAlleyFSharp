namespace DataAlley
open System
module DBEngine =

  ///<summary>The Node type holds data objects in the database</summary>
  /// <remarks>Nodes contain three properties, the ID: Guid, the Lables : String list, and the Properties: Map sring,object</remarks> 
  type Node =
    {
      Id : Guid;
      Labels : string list ;
      Properties : Map<string,Object>
    }

  ///Edges record the links or relationships between Nodes.
  type Edge = 
    {
      Id : Guid;
      Labels : string list ;
      LeftNode : Node ;
      RightNode : Node ;
      Properties : Map<string,Object>
    }

  ///Atoms are one Node and a list of all Edges leading from that Node to other Nodes.
  type Atom = Node * Edge list

  ///<summary>newNode creates a new Node object.</summary>
  /// <param name="labels">A list of strings to set as the labels for the Node.</param>
  /// <returns>a new Atom object</returns>
  let newNode labels : Atom = 
    let Node = { Id = Guid.NewGuid() ; Labels = labels ; Properties = Map.empty }
    ( Node , List<Edge>.Empty )

  ///<summary>Add a new Edge, or relationship, between two Nodes.</summary>
  /// <param name="labels">A list of strings to set as the labels for the Edge.</param>
  /// <param name="left">The left hand, or originating, Node.</param>
  /// <param name="right">The right hand, or destination, Node.</param>
  /// <returns>an Edge object</returns>
  let newEdge labels left right : Edge =
    let edge = 
      {
        Id = Guid.NewGuid() ;
        Labels = labels ;
        LeftNode = left ;
        RightNode = right ;
        Properties = Map.empty
      }
    edge

  ///<summary>create a relation between Atoms by adding an Edge to the left one</summary>
  /// <param name="leftAtom">the originating Atom</param>
  /// <param name="rightAtom">the target Atom</param>
  /// <param name="labels">a string list of labels to apply to the new Edge</param>
  /// <returns>an Atom with an updated Edge list</returns>
  let joinAtoms (leftAtom : Atom) (rightAtom : Atom) (labels : string list ) : Atom =
    let (leftNode, leftEdges) = leftAtom
    let (rightNode, rightEdges) = rightAtom
    let join = newEdge labels leftNode rightNode
    let newEdges = join :: leftEdges
    (leftNode, newEdges)

  ///given an Atom, return a list of it's Edges.
  let listEdges (atom : Atom) : Edge list =
    let ( _ , edges) = atom
    edges