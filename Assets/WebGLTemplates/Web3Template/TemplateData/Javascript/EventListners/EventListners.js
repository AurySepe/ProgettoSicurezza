let options = {
    fromBlock: 'latest'
};

let Events = ["Risultato","Scambio","Transfer"];

function SetEventLisners()
{
    for(const event of Events)
    {

        Contract.events[event](options)
            .on('data', event =>
            {
                let result = {EventName: event.event, ReturnValue: JSON.stringify(event.returnValues)};
                RaiseEvent(JSON.stringify(result));
            });
    }

}


