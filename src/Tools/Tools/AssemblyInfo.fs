namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("Tools")>]
[<assembly: AssemblyProductAttribute("Naxos")>]
[<assembly: AssemblyDescriptionAttribute("Project Naxos")>]
[<assembly: AssemblyVersionAttribute("0.0.15")>]
[<assembly: AssemblyFileVersionAttribute("0.0.15")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "0.0.15"
