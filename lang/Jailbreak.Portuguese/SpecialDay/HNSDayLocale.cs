using Jailbreak.Formatting.Base;

namespace Jailbreak.Portuguese.SpecialDay;

public class HNSDayLocale() : TeamDayLocale("Hide and Seek",
  "CTs devem se esconder enquanto os TRs procuram!", "TRs tem mais HP!") {
  public IView StayInArmory
    => new SimpleView { PREFIX, "Hoje é", Name, ", fique na sala de armas!" };

  public override IView BeginsIn(int seconds) {
    if (seconds == 0)
      return new SimpleView { PREFIX, "Lá vamos nós!" };
    return new SimpleView {
      PREFIX,
      Name,
      "começa em",
      seconds,
      "segundo" + (seconds == 1 ? "" : "s") + "."
    };
  }

  public IView DamageWarning(int seconds) {
    return new SimpleView {
      PREFIX,
      "Você estará vunerável em",
      seconds,
      "segundo" + (seconds == 1 ? "" : "s") + "."
    };
  }
}