
async function GetMyMonsters() {
    return await Contract.methods.tokensOfOwner(account).call();
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

async function GetTrades(input) {
    let trades =  await Contract.methods.getTrades().call();
    let result = []

    for (const trade of trades) 
    {
        console.log(JSON.stringify(trade))
        result.push({MonsterProposed: trade[0], MonsterRequired : trade[1]})
    }
    return result;
}

async function AcceptTrade(input) {
    let result =  await Contract.methods.acceptTrade(input.Item1,input.Item2).send({from: account});
}


