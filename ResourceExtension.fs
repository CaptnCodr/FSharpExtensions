namespace Extensions

open System.Reflection
open System.Resources

type ResourceExtension (resourceFile) =

    member this.GetResourceString ty = 
        ty |> string |> ResourceManager(resourceFile, Assembly.GetExecutingAssembly()).GetString

    member this.GetFormattedString (ty, [<System.ParamArray>]args : obj array) = 
         (this.GetResourceString ty, args) |> System.String.Format

module ResourceExt =

    let resourceManager (file: string) =
        ResourceManager(file, Assembly.GetExecutingAssembly())

    let getResourceString ty (resourceManager: ResourceManager) =
        ty |> string |> resourceManager.GetString

    let getFormattedString ty ([<System.ParamArray>]args : obj array) (resourceManager: ResourceManager) =
        (ty |> string |> resourceManager.GetString, args) |> System.String.Format
