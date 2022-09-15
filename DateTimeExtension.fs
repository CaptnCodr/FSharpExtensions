namespace Extensions

module DateTimeExtension =

    let ofUnixTime (timestamp: decimal) =
        let localTime (x: System.DateTimeOffset) = x.LocalDateTime
        timestamp |> int64 |> System.DateTimeOffset.FromUnixTimeSeconds |> localTime

    type System.Decimal with
        member x.ofUnixTimeToDateTime =
            x |> ofUnixTime
