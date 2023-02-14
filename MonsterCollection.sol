//SPDX-License-Identifier: MIT
pragma solidity ^0.8.17;

import "@openzeppelin/contracts/utils/Counters.sol";
import "@openzeppelin/contracts/access/Ownable.sol";
import "@openzeppelin/contracts/utils/math/SafeMath.sol";
import "@openzeppelin/contracts/token/ERC721/extensions/ERC721Enumerable.sol";

contract MonsterCollection is ERC721Enumerable, Ownable {
    event PropostaScambio(uint256 id1, uint256 id2);
    event ScambioAccettato(uint256 id1, uint256 id2);
    event Encounter(uint value);
    using SafeMath for uint256;
    using Counters for Counters.Counter;

    Counters.Counter private _tokenIds;

    struct Monster
    {
        string name;
        string image;
    }

     struct Trade
    {
        uint256 monsterProposed;
        uint256 monsterRequired;
    }

    mapping(uint256 => Monster) idToMonster;
    mapping(uint256 => mapping(address => bool)) monsterEncounters;
    mapping(uint256 => mapping(uint256 => bool)) trades;
    Trade[] tradesArray;

    constructor() ERC721("LGSNFT", "LGS") {

    }


    function getTrades() public view returns (Trade[] memory) {
       return tradesArray;
    }


    function proposeTrade(uint256 monsterProposed, uint256 monsterRequired) public {
        _requireMinted(monsterRequired);
        require(ownerOf(monsterProposed) == msg.sender,"il mostro appartiene ad un altro giocatore");
        if(trades[monsterProposed][monsterRequired]==false){
        trades[monsterProposed][monsterRequired] = true;
        tradesArray.push(Trade(monsterProposed, monsterRequired));
        }
        emit PropostaScambio(monsterProposed, monsterRequired);
    }

    function acceptTrade(uint256 monsterProposed, uint256 monsterRequired) public {
        _requireMinted(monsterProposed);
        require(ownerOf(monsterRequired) == msg.sender,"il mostro appartiene ad un altro giocatore");
        require(trades[monsterProposed][monsterRequired]==true, "scambio non proposto");
        address proprietarioMonsterProposed = ownerOf(monsterProposed);
        trades[monsterProposed][monsterRequired] = false;
        _safeTransfer(proprietarioMonsterProposed,msg.sender,monsterProposed,"");
        _safeTransfer(msg.sender, proprietarioMonsterProposed, monsterRequired,"");
        uint256 j = tradesArray.length;
        for(uint256 i = 0; i<j; i++){
            if(tradesArray[i].monsterProposed==monsterProposed && tradesArray[i].monsterRequired==monsterRequired)
               delete tradesArray[i];
        }
        emit ScambioAccettato(monsterProposed,monsterRequired);
    }

    function mintNFTs(Monster memory monster) public onlyOwner {

        uint newTokenId = _mintSingleNFT();
        idToMonster[newTokenId] = monster;

    }

    function _mintSingleNFT() private returns (uint){
        uint newTokenID = _tokenIds.current();
        _mint(address(this), newTokenID);
        _tokenIds.increment();
        return newTokenID;
    }

    function EncounterMonster() public returns(uint)
    {
    
        require(NumberOfFreeMonsters() > 0, "Nessun mostro disponibile");
        uint randomToken = tokenOfOwnerByIndex(address(this),block.number % NumberOfFreeMonsters());
        monsterEncounters[randomToken][msg.sender] = true;
        emit Encounter(randomToken);
        return randomToken;
    }

    function ObtainMonster(uint idToken) public 
    {
        _requireMinted(idToken);
        require(monsterEncounters[idToken][msg.sender],"non hai incontrato il mostro");
        require(ownerOf(idToken) == address(this),"il mostro appartiene ad un altro giocatore");
        _safeTransfer(address(this),msg.sender,idToken,"");
        

    }

    function freeMonsters() public view returns(uint[] memory)
    {
        return tokensOfOwner(address(this));
    }

    function NumberOfFreeMonsters() public view returns(uint)
    {
        return balanceOf(address(this));
    }

    function GetMyTokens() public view returns(uint256[] memory)
    {
        return tokensOfOwner(msg.sender);
    }



    function getMonsterByToken(uint idToken) public view returns (Monster memory)
    {
        _requireMinted(idToken);
        return idToMonster[idToken];
    }
    
    function tokensOfOwner(address _owner) public view returns (uint256[] memory) {
        uint tokenCount = balanceOf(_owner);
        uint[] memory tokensId = new uint256[](tokenCount);

        for (uint i = 0; i < tokenCount; i++) {
            tokensId[i] = tokenOfOwnerByIndex(_owner, i);
        }
        return tokensId;
    }

    
  

}