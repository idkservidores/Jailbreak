using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using Jailbreak.Formatting.Base;
using Jailbreak.Formatting.Logistics;
using Jailbreak.Formatting.Views.Warden;

namespace Jailbreak.Portuguese.Warden;

public class WardenCmdOpenLocale : IWardenCmdOpenLocale,
  ILanguage<Formatting.Languages.Portuguese> {
  public IView CannotOpenYet(int seconds) {
    return new SimpleView {
      WardenLocale.PREFIX,
      "Você deve esperar",
      seconds,
      "antes de abrir as celas."
    };
  }

  public IView AlreadyOpened
    => new SimpleView { WardenLocale.PREFIX, "Celas já estão abertas." };

  public IView CellsOpenedBy(CCSPlayerController? player) {
    return player == null ?
      new SimpleView {
        WardenLocale.PREFIX,
        $"{ChatColors.Blue}O xerife {ChatColors.Default}abriu as celas."
      } :
      new SimpleView { WardenLocale.PREFIX, player, "abriu as celas." };
  }

  public IView CellsOpened
    => new SimpleView {
      WardenLocale.PREFIX, ChatColors.Grey + "Celas foram abertas automaticamente."
    };

  public IView CellsOpenedWithPrisoners(int prisoners) {
    return new SimpleView {
      WardenLocale.PREFIX,
      "Detectados",
      prisoners,
      "prisioneiro" + (prisoners == 1 ? "" : "s") + " ainda nas celas, abrindo..."
    };
  }

  public IView CellsOpenedSnitchPrisoners(int prisoners) {
    return new SimpleView {
      WardenLocale.PREFIX,
      ChatColors.Grey + "Detectados",
      prisoners,
      "prisioneiro" + (prisoners == 1 ? "" : "s") + " ainda nas celas..."
    };
  }

  public IView OpeningFailed
    => new SimpleView { WardenLocale.PREFIX, "Falha ao abrir celas." };
}