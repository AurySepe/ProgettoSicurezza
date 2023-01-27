function SendResponse(responseJson)
{
    try
    {
        UnityInstance.SendMessage("RequestHandler","ReciveResponse",responseJson);
    }
    catch (e)
    {
        console.log("se da errore non so esattamente come risolvere ne perchè lo da, ma così funziona comunque: " + e);
    }
}

function RaiseEvent(eventJson)
{
    UnityInstance.SendMessage("EventHandler","ReciveEvent",eventJson);
}