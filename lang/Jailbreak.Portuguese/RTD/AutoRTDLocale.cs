using CounterStrikeSharp.API.Modules.Utils;
using Jailbreak.Formatting.Base;
using Jailbreak.Formatting.Views.RTD;

namespace Jailbreak.Portuguese.RTD;

public class AutoRTDLocale : IAutoRTDLocale {
  public IView TogglingNotEnabled
    => new SimpleView {
      RTDLocale.PREFIX, "Ativar o RTD automático não está habilitado nesse servidor."
    };

  public IView AutoRTDToggled(bool enabled) {
    return new SimpleView {
      RTDLocale.PREFIX,
      ChatColors.Grey + "Você",
      enabled ? ChatColors.Green + "ativou" : ChatColors.Red + "desativou",
      ChatColors.Grey + "Auto-RTD."
    };
  }
}