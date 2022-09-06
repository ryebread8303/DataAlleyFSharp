module Tests

open System
open Xunit
open DataAlley
[<Fact>]
let ``Creating a Node`` () =
    let labels : string List = ["Testing Node"]
    let testNode = DBEngine.newNode labels
    let Nodelabels = fst(testNode).Labels
    Assert.Equal<string List>(labels,Nodelabels)
    0

[<Fact>]
let ``listing edges in an atom`` () =
    let bob = DBEngine.newNode ["person"]
    fst(bob).Properties.Add("name","Bob") |> ignore
    let alice = DBEngine.newNode ["person"]
    fst(alice).Properties.Add("name","Alice") |> ignore
    let friendship = DBEngine.joinAtoms bob alice ["Friendship"]
    Assert.Equal<int>(1,(DBEngine.listEdges friendship).Length)