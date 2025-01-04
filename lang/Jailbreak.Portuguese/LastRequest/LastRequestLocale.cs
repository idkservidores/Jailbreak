using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using Jailbreak.Formatting.Base;
using Jailbreak.Formatting.Core;
using Jailbreak.Formatting.Logistics;
using Jailbreak.Formatting.Objects;
using Jailbreak.Formatting.Views.LastRequest;
using Jailbreak.Public.Extensions;
using Jailbreak.Public.Mod.LastRequest;
using Jailbreak.Public.Mod.LastRequest.Enums;

namespace Jailbreak.Portuguese.LastRequest;

public class LastRequestLocale : ILRLocale,
  ILanguage<Formatting.Languages.Portuguese> {
  public static readonly FormatObject PREFIX =
    new HiddenFormatObject($" {ChatColors.DarkBlue}LR>") {
      //	Hide in panorama and center text
      Plain = false, Panorama = false, Chat = true
    };

  public IView LastRequestEnabled() {
    return new SimpleView {
      {
        PREFIX,
        $"Last Request ativado. Escreva {ChatColors.BlueGrey}!lr{ChatColors.Grey} para começar o last request."
      }
    };
  }

  public IView LastRequestDisabled() {
    return new SimpleView {
      { PREFIX, $"Last Request {ChatColors.Red}desativado{ChatColors.Grey}." }
    };
  }

  public IView LastRequestNotEnabled() {
    return new SimpleView { PREFIX, "Last Request não está habilitado." };
  }

  public IView InvalidLastRequest(string query) {
    return new SimpleView { PREFIX, "Last Request Inválido: ", query };
  }

  public IView InformLastRequest(AbstractLastRequest lr) {
    return new SimpleView {
      PREFIX,
      lr.Prisoner,
      "está começando um",
      ChatColors.White + lr.Type.ToFriendlyString(),
      "LR contra",
      lr.Guard,
      "."
    };
  }

  public IView AnnounceLastRequest(AbstractLastRequest lr) {
    return InformLastRequest(lr);
  }

  public IView LastRequestDecided(AbstractLastRequest lr, LRResult result) {
    var tNull = !lr.Prisoner.IsReal();
    var gNull = !lr.Guard.IsReal();
    if (tNull && gNull)
      return new SimpleView { PREFIX, "Last Request decidido." };

    if (tNull && result == LRResult.PRISONER_WIN)
      return new SimpleView {
        PREFIX, lr.Guard, "perdeu o LR, mas o prisioneiro saiu da partida?"
      };

    if (gNull && result == LRResult.GUARD_WIN)
      return new SimpleView {
        PREFIX, lr.Prisoner, "perdeu o LR, mas o prisioneiro saiu da partida?"
      };

    return result switch {
      LRResult.TIMED_OUT => new SimpleView {
        PREFIX, ChatColors.Grey.ToString(), "Last Request tomout timeout."
      },
      LRResult.INTERRUPTED => new SimpleView {
        PREFIX, ChatColors.Grey.ToString(), "Last Request interrompido."
      },
      _ => new SimpleView {
        PREFIX, result == LRResult.PRISONER_WIN ? lr.Prisoner : lr.Guard, "ganhou."
      }
    };
  }

  public IView CannotLR(string reason) {
    return new SimpleView {
      PREFIX,
      $"Você não pode dar LR, {ChatColors.BlueGrey + reason + ChatColors.Grey}."
    };
  }

  public IView CannotLR(CCSPlayerController player, string reason) {
    return new SimpleView {
      PREFIX,
      "Você não pode dar LR",
      player,
      ", " + ChatColors.BlueGrey + reason + ChatColors.Red + "."
    };
  }

  public IView LastRequestCountdown(int seconds) {
    return new SimpleView { PREFIX, "Iniciando em", seconds, "..." };
  }

  public IView WinByDefault(CCSPlayerController player) {
    return new SimpleView { PREFIX, player, "venceu por padrão." };
  }

  public IView WinByHealth(CCSPlayerController player) {
    return new SimpleView { PREFIX, player, "venceu por vida." };
  }

  public IView WinByReason(CCSPlayerController player, string reason) {
    return new SimpleView { PREFIX, player, "venceu por", reason + "." };
  }

  public IView Win(CCSPlayerController player) {
    return new SimpleView { PREFIX, player, "venceu." };
  }

  public IView DamageBlockedInsideLastRequest
    => new SimpleView { PREFIX, "Você ou o alvo estão em LR, dano bloqueado." };

  public IView DamageBlockedNotInSameLR
    => new SimpleView {
      PREFIX, "Você não está no mesmo LR que o alvo, dano bloqueado."
    };

  public IView LastRequestRebel(CCSPlayerController player, int tHealth) {
    return new SimpleView {
      PREFIX,
      player,
      $"{ChatColors.LightRed}decidiu {ChatColors.DarkRed}Rebelar {ChatColors.LightRed}com",
      tHealth,
      $"{ChatColors.LightRed}HP!"
    };
  }

  public IView LastRequestRebelDisabled() {
    return new SimpleView {
      PREFIX, "Rebelar durante o LR está desabilitado."
    };
  }

  public IView CannotLastRequestRebelCt() {
    return new SimpleView {
      PREFIX, "Você não pode rebelar como CT no LR."
    };
  }
}