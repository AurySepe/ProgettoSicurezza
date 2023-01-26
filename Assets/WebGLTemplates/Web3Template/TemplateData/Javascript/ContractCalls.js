
async function GetMyMonsters() {
    return await Contract.methods.GetMyTokens().call();
}

async function EncounterMonster() {
    let result = await Contract.methods.EncounterMonster().send({from: account,gas : gas});
    return result.events.Risultato.returnValues.value;
}
