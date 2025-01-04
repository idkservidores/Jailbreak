using CounterStrikeSharp.API.Modules.Utils;
using Jailbreak.Formatting.Base;
using Jailbreak.Formatting.Logistics;
using Jailbreak.Formatting.Views;

namespace Jailbreak.Portuguese.Rebel;

public class C4Locale : IC4Locale, ILanguage<Formatting.Languages.Portuguese> {
  public IView JihadC4Pickup
    => new SimpleView {
      RebelLocale.PREFIX,
      $"Você pegou um {ChatColors.Red}Jihad C4{ChatColors.Grey}!"
    };

  public IView JihadC4Received
    => new SimpleView {
      RebelLocale.PREFIX,
      $"Você recebeu um {ChatColors.Red}Jihad C4{ChatColors.Grey}!"
    };

  public IView JihadC4Usage1
    => new SimpleView {
      RebelLocale.PREFIX,
      $"Para detonar, segure e aperte {ChatColors.Yellow + "E" + ChatColors.Grey}."
    };
}