using CounterStrikeSharp.API.Modules.Utils;
using Jailbreak.Formatting.Base;
using Jailbreak.Formatting.Core;
using Jailbreak.Formatting.Logistics;
using Jailbreak.Formatting.Objects;
using Jailbreak.Formatting.Views.Warden;

namespace Jailbreak.Portuguese.Mute;

public class WardenPeaceLocale : IWardenPeaceLocale,
  ILanguage<Formatting.Languages.Portuguese> {
  private static readonly FormatObject PREFIX =
    new HiddenFormatObject($" {ChatColors.DarkBlue}Voz>") {
      Plain = false, Panorama = false, Chat = true
    };

  public IView PeaceEnactedByAdmin(int seconds) {
    return new SimpleView {
      PREFIX,
      "Um administrador ativou a paz por",
      seconds,
      "segundos" + (seconds == 1 ? "" : "s") + "."
    };
  }

  public IView WardenEnactedPeace(int seconds) {
    return new SimpleView {
      PREFIX, "O xerife ativou a paz por", seconds, "segundos."
    };
  }

  public IView GeneralPeaceEnacted(int seconds) {
    return new SimpleView {
      PREFIX,
      "A paz foi ativada por",
      seconds,
      "segundos" + (seconds == 1 ? "" : "s") + "."
    };
  }

  public IView UnmutedGuards
    => new SimpleView { PREFIX, CsTeam.CounterTerrorist, "foram desmutados." };

  public IView UnmutedPrisoners
    => new SimpleView { PREFIX, CsTeam.Terrorist, "Prisioneiros foram desmutados." };

  public IView MuteReminder
    => new SimpleView { PREFIX, ChatColors.Red + "Você está atualmente mutado." };

  public IView PeaceReminder
    => new SimpleView {
      PREFIX,
      $"Paz está atualmente ativa. {ChatColors.Red}Você só deve falar em caso de muita necessidade!"
    };

  public IView DeadReminder
    => new SimpleView {
      PREFIX, $"{ChatColors.Red}Você está morto e não pode falar."
    };

  public IView AdminDeadReminder
    => new SimpleView {
      PREFIX,
      "Você está morto.",
      $"{ChatColors.Red}Você só deveria estar falando em casos de necessidade!"
    };

  public IView PeaceActive
    => new SimpleView { PREFIX, "Paz está atualmente ativa." };
}