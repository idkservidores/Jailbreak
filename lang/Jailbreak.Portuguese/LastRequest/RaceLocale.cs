using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using Jailbreak.Formatting.Base;
using Jailbreak.Formatting.Views.LastRequest;

namespace Jailbreak.Portuguese.LastRequest;

// ReSharper disable ClassNeverInstantiated.Global
public class RaceLocale : LastRequestLocale, ILRRaceLocale {
  public IView EndRaceInstruction
    => new SimpleView {
      {
        PREFIX,
        $"Escreva {ChatColors.Blue}!endrace{ChatColors.White} para escolher o ponto de término!"
      },
      SimpleView.NEWLINE, {
        PREFIX,
        $"Escreva {ChatColors.Blue}!endrace{ChatColors.White} para escolher o ponto de término!"
      },
      SimpleView.NEWLINE, {
        PREFIX,
        $"Escreva {ChatColors.Blue}!endrace{ChatColors.White} para escolher o ponto de término!"
      }
    };

  public IView RaceStartingMessage(CCSPlayerController prisoner) {
    return new SimpleView {
      {
        PREFIX, prisoner,
        "está em uma corrida contra você. Preste atenção no ponto de término!"
      }
    };
  }

  public IView NotInRaceLR() {
    return new SimpleView {
      {
        PREFIX,
        $"{ChatColors.Red}Você tem que estar numa corrida{ChatColors.Blue + "!lr" + ChatColors.Red} para usar isso."
      }
    };
  }

  public IView NotInPendingState() {
    return new SimpleView {
      {
        PREFIX,
        ChatColors.Red + "Você tem que estar no estado de pendente para usar isso."
      }
    };
  }
}