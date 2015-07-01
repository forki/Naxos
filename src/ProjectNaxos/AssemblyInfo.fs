namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("ProjectNaxos")>]
[<assembly: AssemblyProductAttribute("ProjectNaxos")>]
[<assembly: AssemblyDescriptionAttribute("Project Naxos")>]
[<assembly: AssemblyVersionAttribute("1.0")>]
[<assembly: AssemblyFileVersionAttribute("1.0")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.0"
