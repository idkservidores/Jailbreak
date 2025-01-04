using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using Jailbreak.Formatting.Base;
using Jailbreak.Formatting.Views.SpecialDay;

namespace Jailbreak.Portuguese.SpecialDay;

public class GunDayLocale() : SoloDayLocale("Gun Game",
  "Free for all! Mate jogadores para progredir entre as armas.",
  "Jogadores vão respawnar aleatoriamente.",
  "Se você morrer, perderá progresso!",
  "Matar alguém na faca faz você pular um nível!"), IGunDayLocale {
  public IView DemotedDueToSuicide
    => new SimpleView { PREFIX, "Você perdeu um nivel por se matar." };

  public IView DemotedDueToKnife
    => new SimpleView { PREFIX, "Você perdeu um nivel por morrer na faca." };

  public IView PromotedTo(string weapon, int weaponsLeft) {
    if (weaponsLeft == 1)
      return new SimpleView {
        PREFIX, "Chegou em", weapon + ".", ChatColors.Green + "ULTIMA ARMA!"
      };

    return new SimpleView {
      PREFIX,
      "Chegou em",
      weapon + ".",
      weaponsLeft,
      "armas restantes."
    };
  }

  public IView PlayerOnLastPromotion(CCSPlayerController player) {
    return new SimpleView {
      PREFIX,
      player,
      "está na ultima arma!",
      ChatColors.LightRed + "Cuidado!"
    };
  }

  public IView PlayerWon(CCSPlayerController player) {
    var view = new SimpleView { PREFIX, player, "venceu o jogo!" };
    return view;
  }
}