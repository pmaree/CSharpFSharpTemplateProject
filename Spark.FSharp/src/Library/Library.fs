namespace Spark.Library.FSharp

type ILogin =
    abstract member IsValid: bool

type Login(id: int, username: string, password: string) =
    member this.Id = id
    member this.Username = username
    member this.Password = password

    interface ILogin with
        member this.IsValid = this.Username = "phillip" && this.Password = "1234"
