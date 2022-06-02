module Tests

open System
open Xunit
open DataAlley
[<Fact>]
let ``Test creating a Node`` () =
    let labels : string List = ["Testing Node"]
    let testNode = DBEngine.newNode labels
    let Nodelabels = testNode.Labels
    Assert.Equal<string List>(labels,Nodelabels)
    0