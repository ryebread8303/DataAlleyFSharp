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

[<Fact>]
let ``Test creating an Edge`` () =
    let bob = DBEngine.newNode ["person"]
    bob.Properties.Add("name","Bob") |> ignore
    let alice = DBEngine.newNode ["person"]
    alice.Properties.Add("name","Alice") |> ignore
    let friendship = DBEngine.newEdge ["Friendship"] bob alice
    0