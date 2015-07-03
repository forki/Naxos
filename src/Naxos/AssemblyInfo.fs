namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("Naxos")>]
[<assembly: AssemblyProductAttribute("Naxos")>]
[<assembly: AssemblyDescriptionAttribute("Project Naxos")>]
[<assembly: AssemblyVersionAttribute("0.0.14")>]
[<assembly: AssemblyFileVersionAttribute("0.0.14")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "0.0.14"
