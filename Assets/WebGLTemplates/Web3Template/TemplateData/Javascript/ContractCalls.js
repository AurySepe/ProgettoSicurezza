
async function GetMyMonsters() {
    return await Contract.methods.GetMyTokens().call();
}

async function GetMonsters(address) {
    return await Contract.methods.tokensOfOwner(address).call();
}
async function EncounterMonster() {
    let result = await Contract.methods.EncounterMonster().send({from: account});
    return result.events.Encounter.returnValues.value;
}

async function ObtainMonster(id) {
    let result = await Contract.methods.ObtainMonster(id).send({from: account});
}

async function GetMonstersById(id) {
    let result =  await Contract.methods.getMonsterByToken(id).call()
    return {Nome: result[0], ImageBase64 : result[1]};
}


async function ProposeTrade(input) {
    let result =  await Contract.methods.proposeTrade(input.Item1,input.Item2).send({from: account});
}



