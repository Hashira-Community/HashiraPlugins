using System;
using MCGalaxy;
using MCGalaxy.Events;
using MCGalaxy.Events.PlayerEvents;

namespace MCGalaxy
{
    public sealed class Kickonconnect : Plugin 
    {
    	public override string name { get { return "Kickonconnect";}}
        public override string creator { get { return "Ninjazz";}}
        public override string MCGalaxy_Version { get { return "1.9.5.1";}}
        
        public override void Load(bool startup)
        {
        	OnPlayerFinishConnectingEvent.Register(KickClient, Priority.High);
        }
        
        public override void Unload(bool startup)
        {
        	OnPlayerFinishConnectingEvent.Unregister(KickClient);
        }
        
        void KickClient(Player p) {
        // Put playername between "".
	        if (p.truename == ""){
                p.Leave("Get outta here you stinky poo!", true);
		p.cancelconnecting = true;
	    }
    	}
    }
}
