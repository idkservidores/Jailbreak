using CounterStrikeSharp.API.Core;
using Jailbreak.Formatting.Base;
using Jailbreak.Formatting.Views.LastRequest;

namespace Jailbreak.Portuguese.LastRequest;

public class RPSLocale : LastRequestLocale, ILRRPSLocale {
  public IView PlayerMadeChoice(CCSPlayerController player) {
    return new SimpleView { PREFIX, player, "fez sua escolha." };
  }

  public IView BothPlayersMadeChoice() {
    return new SimpleView {
      PREFIX, "Ambos jogadores fizeram sua escolha!"
    };
  }

  public IView Tie() {
    return new SimpleView { PREFIX, "Deu empate! Vamos jogar novamente!" };
  }

  public IView Results(CCSPlayerController guard, CCSPlayerController prisoner,
    int guardPick, int prisonerPick) {
    return new SimpleView {
      PREFIX,
      "Resultados:",
      guard,
      "escolheu",
      toRPS(guardPick),
      "e",
      prisoner,
      "escolheu",
      toRPS(prisonerPick)
    };
  }

  private string toRPS(int pick) {
    return pick switch {
      0 => "Pedra",
      1 => "Papel",
      2 => "Tesoura",
      _ => "Desconhecido"
    };
  }
}