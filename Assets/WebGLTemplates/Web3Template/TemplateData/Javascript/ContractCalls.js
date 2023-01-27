
async function GetMyMonsters() {
    return await Contract.methods.GetMyTokens().call();
}

async function EncounterMonster() {
    let result = await Contract.methods.EncounterMonster().send({from: account});
    return result.events.Risultato.returnValues.value;
}


async function GetMonstersById(id) {
    let result =  await Contract.methods.getMonsterByToken(id).call()
    return {Nome: result[0], ImageBase64 : result[1]};
}

