using System;
using Newtonsoft.Json;

namespace Scenes.TestScene.Scripts.Model
{
    public class Trade
    {
        public Trade(Monster monsterProposed, Monster monsterRequired)
        {
            MonsterProposed = monsterProposed;
            MonsterRequired = monsterRequired;
        }

        public Monster MonsterProposed { get; set; }
        
        public Monster MonsterRequired { get; set; }
        
    }
}