
let account;

function Inizialize()
{
    if (!window.ethereum) {
        console.log("non hai metamask")
        return;
    }
    console.log("Inizializzazione")
    web3 = new Web3(window.ethereum);
    window.ethereum.on("accountsChanged", function (accounts) {
        account=accounts[0];
        ActivateGame()
    });
    web3.eth.getAccounts()
        .then(fetchedAccounts=>{
            if(fetchedAccounts.length === 0)
            {
                document.getElementById("buttonConnect").style.display = "block";
            }
            else
            {
                account=fetchedAccounts[0];
                ActivateGame()
            }
        });
}



function ActivateGame()
{
    document.getElementById("buttonConnect").style.display = "none";
    startGame();
    SetContract();
    GetMyMonsters();
}

