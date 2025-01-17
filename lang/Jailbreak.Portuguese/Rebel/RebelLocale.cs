﻿using CounterStrikeSharp.API.Modules.Utils;
using Jailbreak.Formatting.Base;
using Jailbreak.Formatting.Core;
using Jailbreak.Formatting.Logistics;
using Jailbreak.Formatting.Objects;
using Jailbreak.Formatting.Views;

namespace Jailbreak.Portuguese.Rebel;

public class RebelLocale : IRebelLocale,
  ILanguage<Formatting.Languages.Portuguese> {
  public static readonly FormatObject PREFIX =
    new HiddenFormatObject($" {ChatColors.DarkBlue}Jogo>") {
      //	Hide in panorama and center text
      Plain = false, Panorama = false, Chat = true
    };

  public IView NoLongerRebel
    => new SimpleView { PREFIX, "Você não está mais vermelho." };
}