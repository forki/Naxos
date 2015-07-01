module Naxos.Tests

open Naxos
open NUnit.Framework

[<Test>]
let IsNullTest () =
  let x = null
  let y = "abc"
  Assert.IsTrue(Utils.IsNull(x))
  Assert.IsFalse(Utils.IsNull(y))

[<Test>]
let IsNotNullTest () =
  let x = null
  let y = "abc"
  Assert.IsFalse(Utils.IsNotNull(x))
  Assert.IsTrue(Utils.IsNotNull(y))
