// SPDX-License-Identifier: GPL-3.0

pragma solidity ^0.8.17;
import "../contracts/MonsterCollection.sol";
import "truffle/Assert.sol"; 

contract test is IERC721Receiver{
    MonsterCollection mc= new MonsterCollection();
    MonsterCollection.Monster monster = MonsterCollection.Monster("testName", "testImage");
    MonsterCollection.Monster monster2 = MonsterCollection.Monster("testName2", "testImage2");

    function onERC721Received(address operator, address from, uint256 tokenId, bytes memory data) public returns (bytes4) {
        return IERC721Receiver.onERC721Received.selector;
    }

    function testMint () public {
        mc.mintNFTs(monster);
        uint[] memory array= mc.freeMonsters();
        MonsterCollection.Monster memory monsterFound = mc.getMonsterByToken(array[0]);
        Assert.equal(monster.name, monsterFound.name, "Errore Nome mostro");
        Assert.equal(monster.image, monsterFound.image, "Errore Image mostro");
    }

    function testCattura() public{
        uint NFTid = mc.EncounterMonster();
        mc.ObtainMonster(NFTid);
        uint256[] memory NFTarray= mc.GetMyTokens();
         MonsterCollection.Monster memory monsterFound = mc.getMonsterByToken(NFTarray[0]);
        Assert.equal(monster.name, monsterFound.name, "Errore Nome mostro catturato");
        Assert.equal(monster.image, monsterFound.image, "Errore Image mostro catturato");
    }

    function testProponiScambio() public{
        mc.mintNFTs(monster2);
         uint NFTid = mc.EncounterMonster();
        mc.ObtainMonster(NFTid);
         uint256[] memory NFTarray= mc.GetMyTokens();
         mc.proposeTrade(NFTarray[0], NFTarray[1]);
         MonsterCollection.Trade[] memory TradesArray= mc.getTrades();
        Assert.equal(NFTarray[0], TradesArray[0].monsterProposed, "Errore ID mostro proposto");
        Assert.equal(NFTarray[1], TradesArray[0].monsterRequired, "Errore ID Image richiesto");
    }

    function testAccettaScambio() public{
         uint256[] memory NFTarray= mc.GetMyTokens();
         mc.acceptTrade(NFTarray[0], NFTarray[1]);
         MonsterCollection.Trade[] memory TradesArray= mc.getTrades();
        Assert.equal(0, TradesArray[0].monsterProposed, "Errore Trade residuo");
        Assert.equal(0, TradesArray[0].monsterRequired, "Errore Trade residuo");
    }
}