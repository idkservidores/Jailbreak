using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using Jailbreak.Formatting.Base;
using Jailbreak.Formatting.Views.LastRequest;

namespace Jailbreak.Portuguese.LastRequest;

public class CoinflipLocale : LastRequestLocale, ILRCFLocale {
  public IView FailedToChooseInTime(bool choice) {
    return new SimpleView {
      PREFIX,
      "Você não escolheu a tempo, escolhendo automaticamente" + ChatColors.Green,
      choice ? "Cara" : "Coroa"
    };
  }

  public IView GuardChose(CCSPlayerController guard, bool choice) {
    return new SimpleView {
      PREFIX,
      guard,
      "escolheu" + ChatColors.Green,
      choice ? "Cara" : "Coroa",
      ChatColors.Default + ", jogando a moeda..."
    };
  }

  public IView CoinLandsOn(bool heads) {
    return new SimpleView {
      PREFIX,
      "A moeda caiu em" + ChatColors.Green,
      heads ? "Cara" : "Coroa" + ChatColors.White + "."
    };
  }
}