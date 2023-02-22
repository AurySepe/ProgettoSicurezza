let options = {
    fromBlock: 'latest'
};

let eventsAreSetted = false;

let Events = ["PropostaScambio", "ScambioAccettato"];

let PropostaScambioListener;
let ScambioAccettatoListener;

function SetEventListeners() {

    if (!eventsAreSetted) {


        Contract.events.allEvents(options).on('data', evento => {

            if(Events.includes(evento.event))
            {
                let result = {EventName: evento.event, ReturnValue: JSON.stringify(evento.returnValues)};
                RaiseEvent(JSON.stringify(result));
            }
            

        });

        eventsAreSetted = true;
    }


}



