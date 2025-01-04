using Jailbreak.Formatting.Base;
using Jailbreak.Formatting.Logistics;
using Jailbreak.Formatting.Views.Warden;

namespace Jailbreak.Portuguese.Warden;

public class WardenCmdRollLocale : IWardenCmdRollLocale,
  ILanguage<Formatting.Languages.Portuguese> {
  public IView Roll(int roll) {
    return new SimpleView {
      WardenLocale.PREFIX, "xerife rolou", roll, "!"
    };
  }
}