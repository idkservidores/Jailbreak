using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using Jailbreak.Formatting.Base;
using Jailbreak.Formatting.Logistics;
using Jailbreak.Formatting.Views.Warden;

namespace Jailbreak.Portuguese.Warden;

public class WardenSTLocale : IWardenSTLocale,
  ILanguage<Formatting.Languages.Portuguese> {
  public IView Granted
    => new SimpleView {
      WardenLocale.PREFIX,
      $"Você agora tem {ChatColors.Green}Tratamento especial{ChatColors.White}!"
    };

  public IView Revoked
    => new SimpleView {
      WardenLocale.PREFIX,
      $"Seu tratamento especial foi {ChatColors.Red}removido{ChatColors.White}."
    };

  public IView GrantedTo(CCSPlayerController player) {
    return new SimpleView {
      WardenLocale.PREFIX,
      player,
      $"agora tem {ChatColors.Green}Tratamento especial{ChatColors.White}!"
    };
  }

  public IView RevokedFrom(CCSPlayerController player) {
    return new SimpleView {
      WardenLocale.PREFIX,
      player,
      $"{ChatColors.Red}não tem mais {ChatColors.Grey}Tratamento Especial."
    };
  }
}