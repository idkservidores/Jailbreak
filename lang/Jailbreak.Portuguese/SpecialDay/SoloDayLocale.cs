using Jailbreak.Formatting.Base;
using Jailbreak.Formatting.Views.SpecialDay;
using Jailbreak.Public.Extensions;
using Jailbreak.Public.Utils;

namespace Jailbreak.Portuguese.SpecialDay;

public class SoloDayLocale(string name, params string[] description)
  : SDLocale, ISDInstanceLocale {
  public string Name => name;
  public string[] Description => description;

  public virtual IView SpecialDayStart => GenerateStartMessage();

  IView ISDInstanceLocale.SpecialDayEnd
    => new SimpleView { PREFIX, Name, "encerrou." };

  public virtual IView BeginsIn(int seconds) {
    return seconds == 0 ?
      new SimpleView { PREFIX, Name, "começa agora now!" } :
      new SimpleView {
        PREFIX,
        Name,
        "começa em",
        seconds,
        "segundos."
      };
  }

  public IView GenerateStartMessage() {
    var result = new SimpleView {
      PREFIX, { "Hoje é um dia" + (Name[0].IsVowel() ? "n" : ""), Name, "!" }
    };

    if (description.Length == 0) return result;

    result.Add(description[0]);

    for (var i = 1; i < description.Length; i++) {
      result.Add(SimpleView.NEWLINE);
      result.Add(PREFIX);
      result.Add(description[i]);
    }

    return result;
  }

  public IView SpecialDayEnd() {
    var lastAlive = PlayerUtil.GetAlive().FirstOrDefault();
    if (lastAlive == null)
      return new SimpleView { PREFIX, Name, "encerrou. Ninguém venceu!" };
    return new SimpleView {
      PREFIX,
      Name,
      "encerrou.",
      lastAlive,
      "venceu!"
    };
  }
}