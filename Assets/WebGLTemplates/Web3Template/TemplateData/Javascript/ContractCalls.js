
function GetMyMonsters()
{
    Contract.methods.GetMyTokens().call().then(function(result){
        console.log("i miei mostri sono: " + result);
    }).catch(function(error){
        console.log("errore nella chiamata: " + error);
    })
}
