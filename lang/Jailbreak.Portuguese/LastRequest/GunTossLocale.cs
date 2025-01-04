using CounterStrikeSharp.API.Core;
using Jailbreak.Formatting.Base;
using Jailbreak.Formatting.Views.LastRequest;

namespace Jailbreak.Portuguese.LastRequest;

public class GunTossLocale : LastRequestLocale, ILRGunTossLocale {
  public IView PlayerThrewGunDistance(CCSPlayerController player, float dist) {
    return new SimpleView {
      { PREFIX, player, "arremessou sua arma a", dist, "unidades." }
    };
  }
}