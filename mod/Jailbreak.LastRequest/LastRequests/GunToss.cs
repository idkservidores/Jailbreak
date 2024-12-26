using CounterStrikeSharp.API.Core;
using Jailbreak.Public.Extensions;
using Jailbreak.Public.Mod.LastRequest;
using Jailbreak.Public.Mod.LastRequest.Enums;
using Jailbreak.Public.Mod.Weapon;

namespace Jailbreak.LastRequest.LastRequests;

public class GunToss(BasePlugin plugin, ILastRequestManager manager,
  CCSPlayerController prisoner, CCSPlayerController guard)
  : TeleportingRequest(plugin, manager, prisoner, guard), IDropListener,
    IUseBlocker {
  public override LRType Type => LRType.GUN_TOSS;
  private bool guardThrew, prisonerThrew;

  public override void Setup() {
    base.Setup();

    Prisoner.RemoveWeapons();
    Guard.RemoveWeapons();

    Plugin.AddTimer(3, Execute);
    Plugin.AddTimer(5, () => {
      if (State != LRState.ACTIVE) return;
      Guard.SetHealth(100);
      Guard.SetArmor(100);
    });
  }

  public override void Execute() {
    Prisoner.GiveNamedItem("weapon_knife");
    Guard.GiveNamedItem("weapon_knife");
    Prisoner.GiveNamedItem("weapon_deagle");
    Guard.GiveNamedItem("weapon_deagle");

    Guard.SetHealth(250);
    Guard.SetArmor(500);

    Prisoner.GetWeaponBase("weapon_deagle").SetAmmo(2, 0);

    State = LRState.ACTIVE;
  }

  public override void OnEnd(LRResult result) { State = LRState.COMPLETED; }

  public void OnWeaponDrop(CCSPlayerController player, CCSWeaponBase weapon) {
    if (State != LRState.ACTIVE) return;

    if (player == Guard) guardThrew       = true;
    if (player == Prisoner) prisonerThrew = true;
  }

  public bool PreventUse(CCSPlayerController player, CBasePlayerWeapon weapon) {
    if (State != LRState.ACTIVE) return false;
    return player.Slot == Prisoner.Slot && !guardThrew;
  }
}