# Introduction

This project provides detailed steps on how to create a dual C#/F# project IN VSCode with C# funtionality based on Azure functions.

# Steps

1. In VScode open a new terminal and create a new C# azure function based on dotnet runtine

   func init

2. Create a new HttpTrigger function

   func new

3. Open a command prompt/terminal and use the dotnet new command to create a new solution file called Spark.FSharp

   dotnet new sln -o Spark.FSharp

4. To create a new F# project, open a command line and create a new project with the .NET CLI:

   dotnet new console -lang "F#" -o Spark.FSharp

5. In Spark.FSharp use the dotnet new command to create a class library project in the src folder named Library

   dotnet new classlib -lang "F#" -o src/Library

6. Replace the contents of Library.fs with the following code

   ```fsharp
   namespace Library

   open System.Text.Json

   module GetJson =
       let getJson value =
           let json = System.Text.Json.JsonSerializer.Serialize(value)
           value, json
   ```

7. Add the Library project to the Spark.FSharp solution using the dotnet sln add command

   dotnet sln add src/Library/Library.fsproj

8. Use the dotnet new command to create a console unit test in the src folder named Test

   dotnet new console -lang "F#" -o src/Test

9. Replace the contents of the Program.fs file with the following code

   ```fsharp

   ```

10. Add a reference to the Library project using dotnet add reference

    dotnet add src/Test/Test.fsproj reference src/Library/Library.fsproj

11. Add the App project to the Spark.FSharp solution using the dotnet sln add command

    dotnet sln add src/Test/Test.fsproj

12. Restore the NuGet dependencies with **dotnet restore** and run **dotnet build** to build the project

13. Add library reference dependencies to **CSharpFSharpTemplateProject.csproj**

    ```html
    <ProjectReference Include="./Spark.FSharp/src/Library/Library.fsproj" />
    <Reference Include="Library">
      <HintPath
        >./Spark.FSharp/src/Library/bin/Debug/net6.0/Library.dll</HintPath
      >
    </Reference>
    ```

14. Call FSharp function from **FunctionTriggerHttp.cs** by

    ```csharp

    using Spark.Library.FSharp

    string username = req.Query["username"];
    string password = req.Query["password"];

    Login login = new Login(42, username, password);
    Console.WriteLine(String.Format("Login state:{0}", ((ILogin)login).IsValid));

    string responseMessage = ((ILogin)login).IsValid
            ? String.Format("Login credentials for user:{0} is valid", username)
            : String.Format("Login credentials for user:{0} is invalid", username);

    ```

15. To test, run F5 and feed the following url

    ```url
    http://localhost:7071/api/FunctionTriggerHttp?username=phillip&password=1234
    ```
