using CounterStrikeSharp.API.Modules.Utils;
using Jailbreak.Formatting.Base;
using Jailbreak.Formatting.Logistics;
using Jailbreak.Formatting.Views.Warden;

namespace Jailbreak.Portuguese.Warden;

public class WardenCmdSoccerLocale : IWardenCmdSoccerLocale,
  ILanguage<Formatting.Languages.Portuguese> {
  public IView SoccerSpawned
    => new SimpleView {
      WardenLocale.PREFIX,
      ChatColors.Blue + "O xerife" + ChatColors.Grey
      + " spawnou uma bola de futebol."
    };

  public IView SpawnFailed
    => new SimpleView {
      WardenLocale.PREFIX, ChatColors.Red + "Falha ao spawnar bola de futebol."
    };

  public IView TooManySoccers
    => new SimpleView { WardenLocale.PREFIX, "Bolas de futebol demais." };
}