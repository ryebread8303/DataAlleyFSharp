namespace DataAlley
open System
module DBEngine =

  type Node = { Id : Guid ; Labels : string List }

  type Edge = { Left : Node ; Right : Node }

  type GraphObject =
    | Node 
    | Edge 
    | Property

  type Property = { Object : GraphObject ; Data : string}

  let newNode labels : Node = 
    let Node = { Id = Guid.NewGuid() ; Labels = labels }
    Node