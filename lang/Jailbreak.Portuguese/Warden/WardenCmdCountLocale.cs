using CounterStrikeSharp.API.Modules.Utils;
using Jailbreak.Formatting.Base;
using Jailbreak.Formatting.Logistics;
using Jailbreak.Formatting.Views.Warden;

namespace Jailbreak.Portuguese.Warden;

public class WardenCmdCountLocale : IWardenCmdCountLocale,
  ILanguage<Formatting.Languages.Portuguese> {
  public IView PrisonersInMarker(int prisoners) {
    return new SimpleView {
      WardenLocale.PREFIX,
      ChatColors.Grey + "Há " + (prisoners == 1 ? "apenas" : ""),
      prisoners,
      ChatColors.Grey + "prisioneiro" + (prisoners == 1 ? "" : "s")
      + " no marcador."
    };
  }

  public IView CannotCountYet(int seconds) {
    return new SimpleView {
      WardenLocale.PREFIX,
      "Você deve esperar",
      seconds,
      "segundos antes de contar os prisioneiros."
    };
  }

  public IView NoMarkerSet
    => new SimpleView { WardenLocale.PREFIX, "Não há marcador." };
}