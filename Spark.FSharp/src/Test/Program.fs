// For more information see https://aka.ms/fsharp-console-apps
open Spark.Library.FSharp

let login_true = new Login(12, "phillip", "1234")

printfn "User credential %b" (login_true :> ILogin).IsValid

let login_false = new Login(12, "johannes", "1234")

assert ((login_false :> ILogin).IsValid = false)

printfn "User credential %b" (login_false :> ILogin).IsValid
