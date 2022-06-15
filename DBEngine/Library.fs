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

  let newNode labels : Node = 
    let Node = { Id = Guid.NewGuid() ; Labels = labels ; Properties = Map.empty }
    Node

  let newEdge labels left right : Edge =
    let Edge = 
      {
        Id = Guid.NewGuid() ;
        Labels = labels ;
        LeftNode = left ;
        RightNode = right ;
        Properties = Map.empty
      }
    Edge