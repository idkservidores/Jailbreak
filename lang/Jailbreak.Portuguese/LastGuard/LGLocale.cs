using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using Jailbreak.Formatting.Base;
using Jailbreak.Formatting.Core;
using Jailbreak.Formatting.Logistics;
using Jailbreak.Formatting.Objects;
using Jailbreak.Formatting.Views;

namespace Jailbreak.Portuguese.LastGuard;

public class LGLocale : ILGLocale, ILanguage<Formatting.Languages.Portuguese> {
  private static readonly FormatObject PREFIX =
    new HiddenFormatObject($" {ChatColors.DarkBlue}Guarda>") {
      //	Hide in panorama and center text
      Plain = false, Panorama = false, Chat = true
    };

  public IView
    LGStarted(CCSPlayerController lastGuard, int ctHealth, int tHealth) {
    return new SimpleView {
      SimpleView.NEWLINE, {
        PREFIX,
        $"{ChatColors.Grey}Todos os prisioneiros são rebels! {ChatColors.DarkRed}O ÚLTIMO GUARDA{ChatColors.Grey} deve matar até que sobrem apenas dois prisioneiros ({ChatColors.BlueGrey}LR{ChatColors.Grey})."
      },
      SimpleView.NEWLINE, {
        lastGuard, ChatColors.Grey + "tem", ctHealth,
        $"{ChatColors.Grey}de vida, prisioneiros tem", tHealth,
        $"{ChatColors.Grey}de vida."
      }
    };
  }
}