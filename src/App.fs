module App

open Fable.Core
open Elmish

type Model = { Count: int }

type Msg =
    | Increment
    | Decrement

let init () = { Count = 0 }

let update msg model =
    match msg with
    | Increment -> { model with Count = model.Count + 1 }
    | Decrement -> { model with Count = model.Count - 1 }


open Feliz

let view model dispatch =
    Html.div [
        Html.h1 "Elmish Counter"
        Html.p (sprintf "Count: %d" model.Count)
        Html.button [
            prop.onClick (fun _ -> dispatch Increment)
            prop.text "+1"
        ]
        Html.button [
            prop.onClick (fun _ -> dispatch Decrement)
            prop.text "-1"
        ]
    ]


open Elmish.React
open Elmish.Debug
open Elmish.HMR

JsInterop.importSideEffects "./styles.scss"

Program.mkSimple init update view
|> Program.withReactSynchronous "elmish-app"
|> Program.withDebugger
|> Program.run

