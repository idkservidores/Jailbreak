using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using Jailbreak.Formatting.Base;
using Jailbreak.Formatting.Core;
using Jailbreak.Formatting.Logistics;
using Jailbreak.Formatting.Objects;
using Jailbreak.Formatting.Views.Warden;

namespace Jailbreak.Portuguese.Warden;

public class WardenLocale : IWardenLocale,
  ILanguage<Formatting.Languages.Portuguese> {
  public static readonly FormatObject PREFIX =
    new HiddenFormatObject($" {ChatColors.DarkBlue}Guarda>") {
      //	Hide in panorama and center text
      Plain = false, Panorama = false, Chat = true
    };

  public IView PickingShortly
    => new SimpleView {
      PREFIX,
      $"Escolhendo um xerife em breve, escreva {ChatColors.BlueGrey}!warden{ChatColors.Grey} para entrar na fila."
    };

  public IView NoWardens
    => new SimpleView {
      PREFIX,
      $"Ninguém na fila. Próximo guarda que digitar {ChatColors.BlueGrey}!warden{ChatColors.Grey} será o xerife."
    };

  public IView WardenLeft
    => new SimpleView { PREFIX, "O xerife saiu do jogo." };

  public IView WardenDied
    => new SimpleView {
      PREFIX,
      $"O xerife {ChatColors.Red}morreu{ChatColors.Grey}. CTs devem usar {ChatColors.BlueGrey}!warden{ChatColors.Grey}."
    };

  public IView BecomeNextWarden
    => new SimpleView {
      PREFIX,
      $"Digite {ChatColors.BlueGrey}!warden{ChatColors.Grey} para se tornar o xerife."
    };

  public IView JoinRaffle
    => new SimpleView {
      PREFIX,
      $"Você {ChatColors.White}entrou {ChatColors.Grey}no sorteio de xerife."
    };

  public IView LeaveRaffle
    => new SimpleView {
      PREFIX, $"Você {ChatColors.Red}saiu {ChatColors.Grey}do sorteio de xerife."
    };

  public IView NotWarden
    => new SimpleView {
      PREFIX, $"{ChatColors.LightRed}Você não é o xerife."
    };

  public IView FireCommandFailed
    => new SimpleView {
      PREFIX, "O comando fire falhou por algum motivo..."
    };

  public IView PassWarden(CCSPlayerController player) {
    return new SimpleView { PREFIX, player, "desistiu de ser xerife." };
  }

  public IView FireWarden(CCSPlayerController player) {
    return new SimpleView { PREFIX, player, "foi demitido de xerife." };
  }

  public IView
    FireWarden(CCSPlayerController player, CCSPlayerController admin) {
    return new SimpleView {
      PREFIX,
      admin,
      "demitiu",
      player,
      "de xerife."
    };
  }

  public IView NewWarden(CCSPlayerController player) {
    return new SimpleView { PREFIX, player, "agora é o xerife." };
  }

  public IView CurrentWarden(CCSPlayerController? player) {
    return player is not null ?
      new SimpleView { PREFIX, "O xerife é", player, "." } :
      new SimpleView { PREFIX, "Não há xerife." };
  }

  public IView CannotWardenDuringWarmup
    => new SimpleView { PREFIX, "Você não pode se tornar xerife durante o aquecimento." };

  public IView FireCommandSuccess(CCSPlayerController player) {
    return new SimpleView {
      PREFIX, player, "foi demitido e não é mais o xerife."
    };
  }
}