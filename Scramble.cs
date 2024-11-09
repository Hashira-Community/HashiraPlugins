//reference System.Core.dll

using System;
using System.Linq;
using System.IO;
using MCGalaxy; 
using MCGalaxy.Commands; 

public sealed class Scramble : Plugin {
    
    public override string name { get { return "Scramble";}}
    public override string creator { get { return "Ninjazz";}}
    public override string MCGalaxy_Version { get { return "1.9.5.1";}}
    
    public override void Load(bool startup) {
        Command.Register(new CmdScramble());
    }
    
    public override void Unload(bool shutdown) {
        Command.Unregister(Command.Find("Scramble"));
    }
    
    public class CmdScramble : Command {
        public override string name { get { return "Scramble";}}
        public override string shortcut { get { return "";}}
        public override string type { get { return "other";}}
        public override LevelPermission defaultRank { get { return LevelPermission.Banned; } }
        
    	public override void Use(Player p, string message) { 
        
        	string[] args = message.SplitSpaces();
        
        	string filePath = "scrambledwords.txt";
            string[] lines = File.ReadAllLines(filePath);
            Random random = new Random();
            int index = random.Next(lines.Length); 
        	string randomLine = lines[index];
        
        	string filePath2 = "unscrambledwords.txt";
            string[] lines2 = File.ReadAllLines(filePath2);
            Random random2 = new Random();
            int index2 = random2.Next(lines2.Length); 
        	string randomLine2 = lines2[index2];
        
        	if (args[0] == "") {
				p.Message("Your word is : %a" + randomLine);
            }
        
        	else if (lines2.Contains(args[0])) 
                {
                    p.Message("%aYou UnScrambled the word! :D");
				}
        
            else 
            	{
                	p.Message("%cThe word '" + args[0] + "' is not the UnScrambled word. Please try again.");
            	}
    	}
    	public override void Help(Player p)
    	{
       		p.Message("/Scramble to get a scrambled word.");
            p.Message("%a/Scramble <Your guess> %7to see if you unscrambled the word correctly or not.");
    	}
	}
}
