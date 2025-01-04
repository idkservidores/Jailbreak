using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using Jailbreak.Formatting.Base;
using Jailbreak.Formatting.Views.SpecialDay;

namespace Jailbreak.Portuguese.SpecialDay;

public class SpeedrunDayLocale() : SoloDayLocale("Speedrunners",
    $"Siga o {ChatColors.Blue}jogador{ChatColors.Default} azul!",
    "Ele irá correr para um local do mapa.",
    $"Cada round, os {ChatColors.Red}jogadores mais lentos{ChatColors.Grey} a chegar no destino serão eliminados."),
  ISpeedDayLocale {
  public IView RoundEnded
    => new SimpleView {
      PREFIX, "Fim de round! O próximo começará em breve."
    };

  public IView NoneReachedGoal
    => new SimpleView {
      { PREFIX, "Não houveram jogadores suficientes que terminaram o percurso!" },
      SimpleView.NEWLINE,
      { PREFIX, "Usando distância como forma de escolher os que sobreviverão" }
    };

  public IView NoneEliminated
    => new SimpleView { PREFIX, "Ninguem foi eliminado esse round!" };

  public IView YouAreRunner(int seconds) {
    return new SimpleView {
      { PREFIX, "Você é o speedrunner!" },
      SimpleView.NEWLINE, {
        PREFIX, "Você tem", seconds, "segundos para correr e escolher um local."
      }
    };
  }

  public IView BeginRound(int round, int eliminationCount, int seconds) {
    if (eliminationCount == 1)
      return new SimpleView {
        {
          PREFIX,
          $"Round{ChatColors.Yellow}#{round}{ChatColors.Grey} começou! O jogador mais lento",
          "a chegar no destino será eliminado!"
        },
        SimpleView.NEWLINE,
        { PREFIX, "Você tem", seconds, "segundos para chegar ao destino!" }
      };

    return new SimpleView {
      {
        PREFIX,
        $"Round {ChatColors.Yellow}#{round}{ChatColors.Grey} começou! Os",
        eliminationCount, "jogadores mais lentos a chegar no destino serão eliminados!"
      },
      SimpleView.NEWLINE,
      { PREFIX, "Você tem", seconds, "segundos para chegar ao destino." }
    };
  }

  public IView RuntimeLeft(int seconds) {
    return new SimpleView {
      PREFIX, "Você tem", seconds, "segundos restantes para escolher um destino!"
    };
  }

  public IView RunnerAssigned(CCSPlayerController player) {
    return new SimpleView {
      PREFIX, player, "é o speedrunner! Sigam com atenção!"
    };
  }

  public IView RunnerLeftAndReassigned(CCSPlayerController player) {
    return new SimpleView {
      PREFIX,
      "O speedrunner original saiu, então",
      player,
      "é o speedrunner agora."
    };
  }

  public IView RunnerAFKAndReassigned(CCSPlayerController player) {
    return new SimpleView {
      PREFIX,
      "O speedrunner original não está se movendo, então",
      player,
      "é o speedrunner agora."
    };
  }

  public IView PlayerTime(CCSPlayerController player, int position,
    float time) {
    var place = position switch {
      1 => ChatColors.Green + "PRIMEIRO",
      2 => ChatColors.LightYellow + "Segundo",
      3 => ChatColors.BlueGrey + "3º",
      _ => ChatColors.Grey + "" + position + "º"
    };
    if (time < 0)
      return new SimpleView {
        PREFIX,
        player,
        "terminou em",
        -time,
        "segundos.",
        place,
        "lugar" + (position == 1 ? "!" : ".")
      };

    return new SimpleView {
      PREFIX,
      player,
      "estava",
      time,
      "unidades de distância do destino,",
      place,
      "lugar."
    };
  }

  public IView PlayerEliminated(CCSPlayerController player) {
    return new SimpleView { PREFIX, player, "foi eliminado!" };
  }

  public IView StayStillToSpeedup
    => new SimpleView { PREFIX, "Fique parado para o round começar mais cedo..." };

  public IView PlayerWon(CCSPlayerController player) {
    return new SimpleView { PREFIX, player, "venceu o jogo!" };
  }

  public IView BestTime(CCSPlayerController player, float time) {
    return new SimpleView {
      PREFIX,
      player,
      "venceu o melhor tempo com",
      time,
      $"segundos! {ChatColors.Green}PRIMEIRO LUGAR{ChatColors.Default}!"
    };
  }

  public IView ImpossibleLocation(CsTeam team, CCSPlayerController player) {
    return new SimpleView {
      {
        PREFIX, "Ninguém no time", team,
        "chegou ao destino. Eliminando um jogador de cada time."
      },
      SimpleView.NEWLINE,
      { PREFIX, "Aleatóriamente selecinado caminho para o jogador", player, "." }
    };
  }
}