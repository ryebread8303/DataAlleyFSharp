module Tests

open System
open Xunit
open DataAlley

let createBob =
    let bob = DBEngine.newNode ["person"]
    fst(bob).Properties.Add("name","Bob") |> ignore
    bob

let createAlice =
    let alice = DBEngine.newNode ["person"]
    fst(alice).Properties.Add("name","Alice") |> ignore
    alice

[<Fact>]
let ``Creating a Node`` () =
    let labels : string List = ["Testing Node"]
    let testNode = DBEngine.newNode labels
    let Nodelabels = fst(testNode).Labels
    Assert.Equal<string List>(labels,Nodelabels)
    Assert.IsType<DBEngine.Atom>(testNode) |> ignore
    0

[<Fact>]
let ``listing edges in an atom`` () =
    let bob = createBob
    let alice = createAlice
    let bobsFriendship = DBEngine.joinAtoms bob alice ["Friendship"] |> DBEngine.listEdges
    Assert.Equal<int>(1,bobsFriendship.Length)
    0

[<Fact>]
let ``creating a new graph`` () = 
    let bob = createBob
    let alice = createAlice
    let testGraph = DBEngine.newGraph([bob;alice])
    Assert.IsType<DBEngine.Graph>(testGraph) |> ignore
    0
