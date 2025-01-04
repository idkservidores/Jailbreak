using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using Jailbreak.Formatting.Base;
using Jailbreak.Formatting.Core;
using Jailbreak.Formatting.Logistics;
using Jailbreak.Formatting.Objects;
using Jailbreak.Formatting.Views.RTD;
using Jailbreak.Public.Mod.RTD;

namespace Jailbreak.Portuguese.RTD;

public class RTDLocale : IRTDLocale, ILanguage<Formatting.Languages.Portuguese> {
  public static readonly FormatObject PREFIX =
    new HiddenFormatObject($" {ChatColors.DarkBlue}RTD>") {
      Plain = false, Panorama = false, Chat = true
    };

  public IView RewardSelected(IRTDReward reward) {
    var view = new SimpleView {
      PREFIX,
      "Você rolou " + ChatColors.BlueGrey + reward.Name + ChatColors.Grey + "."
    };

    if (reward.Description == null) return view;

    view.Add(SimpleView.NEWLINE);
    view.Add(PREFIX);
    view.Add(ChatColors.Grey + reward.Description);

    return view;
  }

  public IView AlreadyRolled(IRTDReward reward) {
    return new SimpleView {
      PREFIX,
      "Você já rolou " + ChatColors.Red + reward.Name + ChatColors.Grey
      + "."
    };
  }

  public IView CannotRollYet() {
    return new SimpleView {
      PREFIX, "Você só pode rolar após o fim de round ou quando está morto."
    };
  }

  public IView RollingDisabled() {
    return new SimpleView { PREFIX, "Rolar está desabilitado." };
  }

  public IView JackpotReward(CCSPlayerController winner, int credits) {
    return new SimpleView {
      PREFIX,
      winner,
      "ganhou o jackpot de ",
      credits,
      " creditos!"
    };
  }
}