// base lr class
using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Cvars;
using CounterStrikeSharp.API.Modules.Entities;
using CounterStrikeSharp.API.Modules.Events;
using CounterStrikeSharp.API.Modules.Memory;
using CounterStrikeSharp.API.Modules.Menu;
using CounterStrikeSharp.API.Modules.Utils;
using CounterStrikeSharp.API.Modules.Entities.Constants;
using CSTimer = CounterStrikeSharp.API.Modules.Timers;


public class SDHeadshotOnly : SDBase
{
    public override void setup()
    {
        announce("Headshot only started");
        announce("Please 15 seconds for damage be enabled");
    }

    public override void start()
    {
        announce("Fight!");
    }

    public override void end()
    {
        announce("Headshot only is over");
    }

    public override void setup_player(CCSPlayerController player)
    {
        player.strip_weapons(true);
        player.GiveNamedItem("weapon_deagle");
        weapon_restrict = "deagle";
    }

    public override void player_hurt(CCSPlayerController? player,int health,int damage, int hitgroup) 
    {
        if(player == null || !player.is_valid_alive())
        {
            return;
        }

        // dont allow damage when its not to head
        if(hitgroup != Lib.HITGROUP_HEAD)
        {
            Lib.restore_hp(player,damage,health);
        }
    }
}