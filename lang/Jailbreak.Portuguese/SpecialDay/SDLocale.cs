using CounterStrikeSharp.API.Modules.Utils;
using Jailbreak.Formatting.Base;
using Jailbreak.Formatting.Core;
using Jailbreak.Formatting.Logistics;
using Jailbreak.Formatting.Objects;
using Jailbreak.Formatting.Views.SpecialDay;

namespace Jailbreak.Portuguese.SpecialDay;

public class SDLocale : ISDLocale, ILanguage<Formatting.Languages.Portuguese> {
  public static readonly FormatObject PREFIX =
    new HiddenFormatObject($" {ChatColors.DarkBlue}Jogo>") {
      //	Hide in panorama and center text
      Plain = false, Panorama = false, Chat = true
    };

  public IView SpecialDayRunning(string name) {
    return new SimpleView {
      PREFIX,
      "O dia atual é",
      ChatColors.BlueGrey + name + ChatColors.Grey + "."
    };
  }

  public IView InvalidSpecialDay(string name) {
    return new SimpleView {
      PREFIX,
      ChatColors.Red + name,
      ChatColors.Grey + "não é um dia especial válido."
    };
  }

  public IView SpecialDayCooldown(int rounds) {
    return new SimpleView {
      PREFIX,
      "Você deve esperar mais",
      rounds,
      "round" + (rounds == 1 ? "" : "s")
      + " antes de iniciar um dia especial."
    };
  }

  public IView TooLateForSpecialDay(int maxTime) {
    return new SimpleView {
      PREFIX,
      "Você deve começar um round especial nos primeiros",
      maxTime,
      "segundo" + (maxTime == 1 ? "" : "s") + " do começo do round."
    };
  }
}