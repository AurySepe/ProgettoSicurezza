
let account;

async function Inizialize()
{
    if (!window.ethereum) {
        console.log("non hai metamask")
        return;
    }
    console.log("Inizializzazione")
    web3 = new Web3(window.ethereum);
    window.ethereum.on("accountsChanged", function (accounts) {
        account=accounts[0];
        ActivateGame();
    });
    fetchedAccounts = await web3.eth.getAccounts()
    if(fetchedAccounts.length === 0)
    {
        document.getElementById("buttonConnect").style.display = "block";
    }
    else
    {
        account=fetchedAccounts[0];
        await ActivateGame()
    }
}


async function InizializeUpload()
{
    if (!window.ethereum) {
        console.log("non hai metamask")
        return;
    }
    console.log("Inizializzazione")
    web3 = new Web3(window.ethereum);
    window.ethereum.on("accountsChanged", function (accounts) {
        account=accounts[0];
        ShowForm();
    });
    fetchedAccounts = await web3.eth.getAccounts()
    if(fetchedAccounts.length === 0)
    {
        document.getElementById("buttonConnect").style.display = "block";
    }
    else
    {
        account=fetchedAccounts[0];
        await ShowForm();
    }
}


async function ShowForm() {
    document.getElementById("buttonConnect").style.display = "none";
    document.getElementById("UploadForm").style.display = "block";
    SetContract();
    //Test();
}



async function ActivateGame() {
    document.getElementById("buttonConnect").style.display = "none";
    startGame();
    SetContract();
    SetEventListeners();
    //Test();
}


async function Test()
{
    let result = await GetMonstersById(0);
    console.log("il risultato di GetMonsterById è :" + result);
}
