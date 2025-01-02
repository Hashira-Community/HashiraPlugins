//Speacial thanks to Goodly.
//Inspired by New Blood's /feeling :p 
//By Ninjazz

using System;
using MCGalaxy;
using System.Threading;
//We need to be using MCGalaxy.Commands.Chatting to have access to the MessageCmd class.
using MCGalaxy.Commands.Chatting;

namespace Hashira {
    public class Feeling : Plugin {
        public override string name { get { return "feeling"; } }
        public override string MCGalaxy_Version { get { return "1.9.4.9"; } }
        public override string welcome { get { return "Loaded Message!"; } }
        public override string creator { get { return "Ninjazz"; } }

        static Command[] cmds = new Command[] {
            new CmdHungry(),
            new CmdFart(),
            new CmdConfused(),
            new CmdBored(),
            new CmdSleepy(),
            new CmdMeditate(),
            new CmdScared(),
            new CmdShiver(),
        };

        public override void Load(bool startup) {
            foreach (Command cmd in cmds) { Command.Register(cmd); }
        }
        public override void Unload(bool shutdown) {
            foreach (Command cmd in cmds) { Command.Unregister(cmd); }
        }
    }

    //Because all of the feeling commands are so similar, let's make a template class to base them on.
    //This template will be based on the MessageCmd template which allowed us to use the TryMessage method.
    //keyword "abstract" means that this class can't be used on its own, but can be used as a template for other classes.
    public abstract class FeelingCmdTemplate : MessageCmd {
        //Since shortcut, type, and museumUseable are the same for all of the commands like this, we can specify them here
        //Then we won't have do specify them again
        public override string shortcut { get { return ""; } }
        public override string type { get { return "fun"; } }
        public override bool museumUsable { get { return false; } }

        public override void Use(Player p, string message, CommandData data) {
            //Since we know every single feeling command is going to call TryMessage, let's just do it in the template.
            //It will display the message that is returned by the method "FeelingMessage(p)"
            TryMessage(p, FeelingMessage(p));
        }

        //Using the abstract keyword again.
        //Because of that, this method has no code in it -- we will need to define what it does outside of this template, for each unique Feeling command.
        public abstract string FeelingMessage(Player p);
    }

    //Let's make CmdHungry based on our new FeelingCmdTemplate.
    public class CmdHungry : FeelingCmdTemplate {
        public override string name { get { return "Hungry"; } }
        //We already defined shortcut, type, and museumUseable in the FeelingCmdTemplate class, so it doesn't need to appear here.

        //We already defined Use in the FeelingCmdTemplate class, so it doesn't need to appear here.

        //Defining the abstract FeelingMessage method from the FeelingCmdTemplate class here.
        public override string FeelingMessage(Player p) {
            //This method gives a string, so we "return" the string we want the message to be.
            return p.color + p.truename + " is hungry!";
        }

        //Help wasn't defined in the FeelingCmdTemplate, so we still have to have it here.
        public override void Help(Player p) {
            p.Message("/Hungry - Use if you are hungry.");
        }
    }
    public class CmdFart : FeelingCmdTemplate {
        public override string name { get { return "Fart"; } }

        public override string FeelingMessage(Player p) {
            return p.color + p.truename + " farted...";
        }

        public override void Help(Player p) {
            p.Message("/Fart - Feels like farting?");
        }
    }

    public class CmdConfused : FeelingCmdTemplate {
        public override string name { get { return "Confused"; } }

        public override string FeelingMessage(Player p) {
            return p.color + p.truename + " is confused...";
        }

        public override void Help(Player p) {
            p.Message("%7/Confused - Confused? Use this command to express your confusion!");
        }
    }

    public class CmdSleepy : FeelingCmdTemplate {
        public override string name { get { return "Sleepy"; } }

        public override string FeelingMessage(Player p) {
            return p.color + p.truename + " is feeling sleepy...";
        }
        public override void Help(Player p) {
            p.Message("%7/Sleepy - Feeling Sleepy? Use this command to express your sleepyness!");
        }
    }

    public class CmdBored : FeelingCmdTemplate {
        public override string name { get { return "Bored"; } }

        public override string FeelingMessage(Player p) {
            return p.color + p.truename + " is bored...";
        }

        //Since Bored has some unique behavior, we can bring back the Use method to add some custom code.
        public override void Use(Player p, string message) {
            //Using the keyword "base" we can call the Use method from the template FeelingCmdTemplate class first.
            base.Use(p, message);
            //Now, we can execute our custom code.
            Thread.Sleep(3000);
            p.Leave(p.color + p.name + "&S WAS BORED !?!?!?! THE HELL ?!!?! ");
        }
        public override void Help(Player p) {
            p.Message("%7/Bored - Feeling Bored? Use this command to express that you are bored!");
            p.Message("%7How can someone be bored on this server!?!");
        }
    }
    	 public class CmdMeditate : FeelingCmdTemplate {
             public override string name { get { return "Meditate"; } } 
             
          public override string FeelingMessage(Player p) {
            return p.ColoredName + " is trying to meditate.";
        }
        public override void Help(Player p) {
            p.Message("%7/Meditate - Use this command to express people that you want to meditate.");
        }
    }
     public class CmdScared : FeelingCmdTemplate {
        public override string name { get { return "Scared"; } }
        //We already defined shortcut, type, and museumUseable in the FeelingCmdTemplate class, so it doesn't need to appear here.

        //We already defined Use in the FeelingCmdTemplate class, so it doesn't need to appear here.

        //Defining the abstract FeelingMessage method from the FeelingCmdTemplate class here.
        public override string FeelingMessage(Player p) {
            //This method gives a string, so we "return" the string we want the message to be.
            return p.color + p.truename + " is Scared 0.0!";
        }

        //Help wasn't defined in the FeelingCmdTemplate, so we still have to have it here.
        public override void Help(Player p) {
            p.Message("/Scared - Who are you scared of  0.0 ?.");
        }
    }
     public class CmdShiver : FeelingCmdTemplate {
        public override string name { get { return "Shiver"; } }
        //We already defined shortcut, type, and museumUseable in the FeelingCmdTemplate class, so it doesn't need to appear here.

        //We already defined Use in the FeelingCmdTemplate class, so it doesn't need to appear here.

        //Defining the abstract FeelingMessage method from the FeelingCmdTemplate class here.
        public override string FeelingMessage(Player p) {
            //This method gives a string, so we "return" the string we want the message to be.
            return p.color + p.truename + " is shivering!";
        }

        //Help wasn't defined in the FeelingCmdTemplate, so we still have to have it here.
        public override void Help(Player p) {
            p.Message("/Shiver - Use if you are shivering");
        }
    }
}
