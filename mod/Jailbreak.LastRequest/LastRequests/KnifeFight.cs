using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Utils;
using Jailbreak.Public.Mod.LastRequest;
using Jailbreak.Public.Mod.LastRequest.Enums;

namespace Jailbreak.LastRequest.LastRequests;

public class KnifeFight : AbstractLastRequest
{
    public KnifeFight(BasePlugin plugin, CCSPlayerController prisoner, CCSPlayerController guard) : base(plugin,
        prisoner, guard)
    {
    }

    public override LRType type => LRType.KnifeFight;

    public override void Setup()
    {
        // Strip weapons, teleport T to CT
        prisoner.RemoveWeapons();
        guard.RemoveWeapons();
        guard.Teleport(prisoner.Pawn.Value!.AbsOrigin!, prisoner.Pawn.Value.AbsRotation!, new Vector());
        state = LRState.Pending;
        for (var i = 3; i >= 1; i--)
        {
            var copy = i;
            plugin.AddTimer(3 - i, () => { PrintToParticipants($"{copy}..."); });
        }

        plugin.AddTimer(4, Execute);
    }

    public override void Execute()
    {
        PrintToParticipants("Go!");
        prisoner.GiveNamedItem("weapon_knife");
        guard.GiveNamedItem("weapon_knife");
        this.state = LRState.Active;
    }

    public override void End(LRResult result)
    {
        state = LRState.Completed;
    }
}