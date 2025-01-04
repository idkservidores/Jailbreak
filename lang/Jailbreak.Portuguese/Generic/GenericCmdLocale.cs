using CounterStrikeSharp.API.Modules.Utils;
using Jailbreak.Formatting.Base;
using Jailbreak.Formatting.Core;
using Jailbreak.Formatting.Logistics;
using Jailbreak.Formatting.Objects;
using Jailbreak.Formatting.Views;
using Jailbreak.Public.Extensions;

namespace Jailbreak.Portuguese.Generic;

public class GenericCmdLocale : IGenericCmdLocale,
  ILanguage<Formatting.Languages.Portuguese> {
  private static readonly FormatObject PREFIX =
    new HiddenFormatObject($" {ChatColors.DarkBlue}Seridor>") {
      //	Hide in panorama and center text
      Plain = false, Panorama = false, Chat = true
    };

  public IView PlayerNotFound(string query) {
    return new SimpleView {
      PREFIX,
      $"Jogador '{ChatColors.BlueGrey}{query}{ChatColors.Grey}' não encontrado."
    };
  }

  public IView PlayerFoundMultiple(string query) {
    return new SimpleView {
      PREFIX,
      $"Múltiplos jogadores encontrados para '{ChatColors.BlueGrey}{query}{ChatColors.Grey}'."
    };
  }

  public IView CommandOnCooldown(DateTime cooldownEndsAt) {
    var seconds = (int)(cooldownEndsAt - DateTime.Now).TotalSeconds;
    return new SimpleView {
      PREFIX,
      "Este comando está em cooldown por mais",
      seconds,
      "segundo" + (seconds == 1 ? "" : "s") + "."
    };
  }

  public IView InvalidParameter(string parameter, string expected) {
    return new SimpleView {
      PREFIX,
      $"Parâmetro inválido '{ChatColors.BlueGrey}{parameter}{ChatColors.Grey}',",
      "espera-se um" + (expected[0].IsVowel() ? "n" : ""),
      $"{ChatColors.BlueGrey}{expected}{ChatColors.Grey}."
    };
  }

  public IView NoPermissionMessage(string permission) {
    return new SimpleView {
      PREFIX,
      $"Isso requer a permissão {ChatColors.BlueGrey}{permission}{ChatColors.Grey}"
    };
  }

  public IView Error(string message) {
    return new SimpleView {
      PREFIX, $"Um erro ocorreu: {ChatColors.Red}{message}{ChatColors.Grey}."
    };
  }
}