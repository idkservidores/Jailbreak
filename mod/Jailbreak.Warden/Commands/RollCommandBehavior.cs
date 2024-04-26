﻿using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Utils;
using Jailbreak.Formatting.Extensions;
using Jailbreak.Formatting.Views;
using Jailbreak.Public.Behaviors;
using Jailbreak.Public.Mod.Warden;

namespace Jailbreak.Warden.Commands;

public class RollCommandBehavior : IPluginBehavior
{
		private IWardenService _warden;
    
    	private IRollCommandNotications _notifications;
    
    	public RollCommandBehavior(IWardenService warden, IRollCommandNotications notifications)
    	{
    		_warden = warden;
    		_notifications = notifications;
    	}
    
    	[ConsoleCommand("css_roll", "Roll a number between min and max. If no min and max are provided, it will default to 0 and 10.")]
    	[CommandHelper(1, "[min] [max]", CommandUsage.CLIENT_ONLY)]
    	public void Command_Toggle(CCSPlayerController? player, CommandInfo command)
    	{
    		if (player == null)
    			return;
    
    		if (!_warden.IsWarden(player))
    			//	You're not that warden, blud
    			return;

		    var min = 0;
		    var max = 10;
		    
		    if (command.ArgCount != 3)
		    {
			    _notifications.Roll(new Random().Next(min, max)).ToAllChat();	
			    return;
		    }
		    
		    int.TryParse(command.GetArg(1), out min);
		    int.TryParse(command.GetArg(2), out max);

		    _notifications.Roll(new Random().Next(min, max)).ToAllChat();


	    }
    
}