//Made by Ninjazz & nassemRB
using System;
using MCGalaxy;
using MCGalaxy.Economy;
using MCGalaxy.Commands;

namespace MCGalaxy {
    public sealed class Gamble : Plugin 
    {
        public override string name { get { return "Gamble";}}
        public override string creator { get { return "Ninjazz";}}
        public override string MCGalaxy_Version { get { return "1.9.4.9";}}
        
        public override void Load(bool startup) 
        {
            foreach (Player p in PlayerInfo.Online.Items) 
            {
            	p.Message("Gamble Plugin has been loaded !");
            }
            	Command.Register(new CmdGamble());
		}
        
        public override void Unload(bool shutdown) 
        {
            foreach (Player p in PlayerInfo.Online.Items) 
            {
            	p.Message("Gamble Plugin has been unloaded !");
            }
            Command.Unregister(Command.Find("Gamble"));
        }
    }
    
    public class CmdGamble : Command 
    {
        public override string name { get { return "Gamble"; } }
        public override string type { get { return "economy"; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Banned; } }
        
        public override void Use(Player p, string message) {
             string[] args = message.SplitSpaces();
            
             if (args[0] == "XP") {
                 
                //We don't have xp on our server, so nothing here :P
             }
             
            else if (args[0] == "money") {
                if (p.money > 10) {
                
               Chat.MessageGlobal(p.color + p.truename + " %ahas rolled the a dice, they have gambled their %3Money!");
                Random random = new Random();
                int num = random.Next(1, 7);
                if (num < 3) {
                    Chat.MessageGlobal("%aDice rolled a %b" + num + " %aand with that " + p.color + p.truename + " %alost %f" + num + " %3money%a.");
                    p.Message("%aYou lost %f" + num +  " %3money%a!");
                    p.SetMoney(p.money - num);
                }
                else if (num > 3) {
                    Chat.MessageGlobal("%aDice rolled a %b" + num + " %aand with that " + p.color + p.truename + " %aearned %f3 %3money%a.");
                    p.Message("%aYou won %f3 %3money%a!");
                    p.SetMoney(p.money + 3);
                }
            }
       
            else if (p.money < 10) {
                p.Message("%aYou need at least %f10 %3Money %ato gamble.");
            }
        }   
            else { Help(p); }
            
            
            
        } 
        
        public override void Help(Player p) {
            p.Message("%a/Gamble xp - %7Gambles your xp.");
             p.Message("%a/Gamble money - %7Gambles your money.");
            p.Message("%aWhen you use this command it roles a dice, if the value is greater than 3 you earn, if the value is less than 3 you loss.");
        }
    }
}