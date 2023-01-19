//SPDX-License-Identifier: MIT
pragma solidity ^0.8.17;

import "@openzeppelin/contracts/utils/Counters.sol";
import "@openzeppelin/contracts/access/Ownable.sol";
import "@openzeppelin/contracts/utils/math/SafeMath.sol";
import "@openzeppelin/contracts/token/ERC721/extensions/ERC721Enumerable.sol";

contract MonsterCollection is ERC721Enumerable, Ownable {
    event Risultato(uint value);
    using SafeMath for uint256;
    using Counters for Counters.Counter;

    Counters.Counter private _tokenIds;

    struct Monster
    {
        string name;
        string image;
    }

    mapping(uint256 => Monster) idToMonster;
    mapping(uint256 => mapping(address => bool)) monsterEncounters;

    constructor() ERC721("LGSNFT", "LGS") {

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
        uint randomToken = tokenOfOwnerByIndex(address(this),block.timestamp % NumberOfFreeMonsters());
        monsterEncounters[randomToken][msg.sender] = true;
        emit Risultato(randomToken);
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

    function GetMyTokens() public view returns(uint[] memory)
    {
        return tokensOfOwner(msg.sender);
    }



    function getMonsterByToken(uint idToken) public view returns (Monster memory)
    {
        _requireMinted(idToken);
        return idToMonster[idToken];
    }
    
    function tokensOfOwner(address _owner) public view returns (uint[] memory) {
        uint tokenCount = balanceOf(_owner);
        uint[] memory tokensId = new uint256[](tokenCount);

        for (uint i = 0; i < tokenCount; i++) {
            tokensId[i] = tokenOfOwnerByIndex(_owner, i);
        }
        return tokensId;
    }

    
  

}