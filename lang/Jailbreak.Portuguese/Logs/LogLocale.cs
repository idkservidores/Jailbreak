using Jailbreak.Formatting.Base;
using Jailbreak.Formatting.Logistics;
using Jailbreak.Formatting.Views;

namespace Jailbreak.Portuguese.Logs;

public class LogLocale : ILogLocale, ILanguage<Formatting.Languages.Portuguese> {
  public IView BeginJailbreakLogs
    => new SimpleView {
      "********************************",
      SimpleView.NEWLINE,
      "***** COMEÇAR LOGS DO JAIL *****",
      SimpleView.NEWLINE,
      "********************************"
    };

  public IView EndJailbreakLogs
    => new SimpleView {
      "********************************",
      SimpleView.NEWLINE,
      "****** FIM LOGS JAILBREAK ******",
      SimpleView.NEWLINE,
      "********************************"
    };
}