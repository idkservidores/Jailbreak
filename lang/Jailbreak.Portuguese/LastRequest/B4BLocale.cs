using CounterStrikeSharp.API.Core;
using Jailbreak.Formatting.Base;
using Jailbreak.Formatting.Views.LastRequest;

namespace Jailbreak.Portuguese.LastRequest;

public class B4BLocale : LastRequestLocale, ILRB4BLocale {
  public IView PlayerGoesFirst(CCSPlayerController player) {
    return new SimpleView {
      PREFIX, "O jogador", player, "foi escolhido aleatoriamente para ir primeiro."
    };
  }

  public IView WeaponSelected(CCSPlayerController player, string weapon) {
    return new SimpleView { PREFIX, player, "escolheu", weapon };
  }
}