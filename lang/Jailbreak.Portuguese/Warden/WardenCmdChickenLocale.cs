using CounterStrikeSharp.API.Modules.Utils;
using Jailbreak.Formatting.Base;
using Jailbreak.Formatting.Logistics;
using Jailbreak.Formatting.Views.Warden;

namespace Jailbreak.Portuguese.Warden;

public class WardenCmdChickenLocale : IWardenCmdChickenLocale,
  ILanguage<Formatting.Languages.Portuguese> {
  public IView ChickenSpawned
    => new SimpleView {
      WardenLocale.PREFIX,
      ChatColors.Blue + "O xerife" + ChatColors.Grey + " spawnou uma galinha."
    };

  public IView SpawnFailed
    => new SimpleView {
      WardenLocale.PREFIX, ChatColors.Red + "Falha ao spawnar galinha."
    };

  public IView TooManyChickens
    => new SimpleView { WardenLocale.PREFIX, "Galinhas demais." };
}