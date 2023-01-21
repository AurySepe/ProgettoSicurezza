// contracts.jslib

mergeInto(LibraryManager.library, {
    GetMyMonsters: function ()
    {
        Contract.methods.GetMyTokens().call().then(function(result){
            console.log("i miei mostri sono: " + result);
        }).catch(function(error){
            console.log("errore nella chiamata: " + error);
        })
    },
    
    EncounterMonster: function (){
    
        Contract.methods.EncounterMonster().send({from:account}).then(function(result){
           
            return result.events.Risultato.returnValues.value;
        }).catch(function(error){
            console.log("errore nella chiamata: " + error);
        })
    },

});