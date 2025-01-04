using Jailbreak.Formatting.Base;

namespace Jailbreak.Portuguese.SpecialDay;

public class WardayInstanceLocale() : TeamDayLocale("Warday",
  "CTs vs TRs! CTs escolhem uma sala, TRs devem ir lutar contra eles!",
  "CTs DEVEM permanecer na mesma sala até o tempo de expansão.") {
  public IView ExpandNow => new SimpleView { PREFIX, "CTs podem expandir sua área agora!" };

  public IView ExpandIn(int seconds) {
    return new SimpleView {
      { PREFIX, "CTs podem expandir em", seconds, "segundos." },
      SimpleView.NEWLINE,
      { PREFIX, "Será dada vida, armadura, e velocidade." }
    };
  }
}