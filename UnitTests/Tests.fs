module Tests

open System
open Xunit
open DataAlley
[<Fact>]
let ``Test creating a Node`` () =
    let labels : string List = ["Testing Node"]
    let testNode = DBEngine.newNode labels
    let Nodelabels = fst(testNode).Labels
    Assert.Equal<string List>(labels,Nodelabels)
    0

[<Fact>]
let ``Test creating an Edge`` () =
    let bob = DBEngine.newNode ["person"]
    fst(bob).Properties.Add("name","Bob") |> ignore
    let alice = DBEngine.newNode ["person"]
    fst(alice).Properties.Add("name","Alice") |> ignore
    let friendship = DBEngine.joinAtoms bob alice ["Friendship"]
    0