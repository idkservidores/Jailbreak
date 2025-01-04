using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using Jailbreak.Formatting.Base;
using Jailbreak.Public.Utils;

namespace Jailbreak.Portuguese.SpecialDay;

public class InfectionDayLocale() : TeamDayLocale("Infection",
  "CTs estão infectados e estão tentando infectar os TRs!",
  "TRs podem procurar por quaisquer armas, mas CTs só podem usar pistolas!") {
  public override IView SpecialDayEnd() {
    var winner = PlayerUtil.GetAlive().FirstOrDefault()?.Team
      ?? CsTeam.Spectator;
    return new SimpleView {
      PREFIX,
      Name,
      "finalizou.",
      (winner == CsTeam.CounterTerrorist ? ChatColors.Blue : ChatColors.Red)
      + (winner == CsTeam.CounterTerrorist ? "Zumbis" : "Prisioneiros"),
      "venceram!"
    };
  }

  public IView YouWereInfectedMessage(CCSPlayerController? player) {
    return player == null || !player.IsValid ?
      new SimpleView {
        PREFIX,
        $"{ChatColors.Red}Você foi {ChatColors.DarkRed}infectado{ChatColors.Red}!"
      } :
      new SimpleView {
        PREFIX,
        $"{ChatColors.Red}Você foi {ChatColors.DarkRed}infectado{ChatColors.Red} por",
        player,
        "!"
      };
  }

  public IView InfectedWarning(CCSPlayerController player) {
    return new SimpleView {
      PREFIX,
      player,
      $"foi {ChatColors.DarkRed}infectado{ChatColors.Default}! {ChatColors.Red}Tome cuidado!"
    };
  }

  public IView DamageWarning(int seconds) {
    return new SimpleView {
      PREFIX,
      "Dano será habilitado para o time",
      CsTeam.Terrorist,
      "em",
      seconds,
      "segundos."
    };
  }
}