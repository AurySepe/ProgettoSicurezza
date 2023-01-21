
function GetMyMonsters()
{
    Contract.methods.GetMyTokens().call().then(function(result){
        console.log("i miei mostri sono: " + result);
    }).catch(function(error){
        console.log("errore nella chiamata: " + error);
    })
}

function EncounterMonster()
{
    Contract.methods.EncounterMonster().send({from:account}).then(function(result){
       
        console.log("Mostro incontrato: " +  result.events.Risultato.returnValues.value);
    }).catch(function(error){
        console.log("errore nella chiamata: " + error);
    })
}
