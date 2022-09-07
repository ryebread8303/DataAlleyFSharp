namespace DataAlley
open System
module DBEngine =

 
  type Node =
    {
      Id : Guid;
      Labels : string list ;
      Properties : Map<string,Object>
    }

  type Edge = 
    {
      Id : Guid;
      Labels : string list ;
      LeftNode : Node ;
      RightNode : Node ;
      Properties : Map<string,Object>
    }

  type Atom = Node * Edge list

  let newNode labels : Atom = 
    let Node = { Id = Guid.NewGuid() ; Labels = labels ; Properties = Map.empty }
    ( Node , List<Edge>.Empty )

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

  let joinAtoms (leftAtom : Atom) (rightAtom : Atom) (labels : string list ) : Atom =
    let (leftNode, leftEdges) = leftAtom
    let (rightNode, rightEdges) = rightAtom
    let join = newEdge labels leftNode rightNode
    let newEdges = join :: leftEdges
    (leftNode, newEdges)

  let listEdges (atom : Atom) : Edge list =
    let ( _ , edges) = atom
    edges