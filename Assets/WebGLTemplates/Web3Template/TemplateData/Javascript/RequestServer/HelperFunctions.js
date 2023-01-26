function SendResponse(responseJson)
{
    UnityInstance.SendMessage("RequestHandler","ReciveResponse",responseJson);
}

function RaiseEvent(eventJson)
{
    UnityInstance.SendMessage("EventHandler","ReciveEvent",eventJson);
}