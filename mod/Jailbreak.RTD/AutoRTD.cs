﻿using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Admin;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Cvars;
using Jailbreak.Formatting.Extensions;
using Jailbreak.Formatting.Views;
using Jailbreak.Formatting.Views.RTD;
using Jailbreak.Public;
using Jailbreak.Public.Behaviors;
using Jailbreak.Public.Mod.RTD;
using Jailbreak.Public.Utils;
using MAULActainShared.plugin.models;

namespace Jailbreak.RTD;

public class AutoRTD(IRTDRewarder rewarder, IAutoRTDLocale locale,
  IRTDLocale rtdLocale, IGenericCmdLocale generic) : IPluginBehavior {
  private static readonly Dictionary<ulong, bool> cachedCookies = new();

  public static readonly FakeConVar<string> CV_AUTORTD_FLAG =
    new("css_autortd_flag", "Permission flag required to enable auto-RTD",
      "@ego/dssilver");

  private ICookie? cookie;

  public void Start(BasePlugin basePlugin) {
    Server.NextFrameAsync(async () => {
      if (API.Actain != null)
        cookie = await API.Actain.getCookieService()
         .RegClientCookie("jb_rtd_auto");
    });
  }

  [GameEventHandler]
  public HookResult OnRoundEnd(EventRoundEnd @event, GameEventInfo info) {
    if (RoundUtil.IsWarmup()) return HookResult.Continue;

    if (cookie == null) return HookResult.Continue;

    Server.NextFrame(() => {
      foreach (var player in Utilities.GetPlayers()
       .Where(player
          => AdminManager.PlayerHasPermissions(player, CV_AUTORTD_FLAG.Value))
       .Where(player => !rewarder.HasReward(player))) {
        var steam = player.SteamID;
        if (!cachedCookies.ContainsKey(steam)) {
          Server.NextFrameAsync(async () => await populateCache(player, steam));
        }

        if (cachedCookies.TryGetValue(player.SteamID, out var value) && value)
          player.ExecuteClientCommandFromServer("css_rtd");
      }
    });

    return HookResult.Continue;
  }

  private async Task populateCache(CCSPlayerController player, ulong steam) {
    if (cookie == null) return;
    var val = await cookie.Get(steam);
    cachedCookies[steam] = val is null or "Y";
    if (!cachedCookies[steam]) return;
    await Server.NextFrameAsync(() => {
      if (!player.IsValid) return;
      player.ExecuteClientCommandFromServer("css_rtd");
    });
  }

  [ConsoleCommand("css_autortd")]
  public void Command_AutoRTD(CCSPlayerController? executor, CommandInfo info) {
    if (executor == null) return;

    if (!RTDCommand.CV_RTD_ENABLED.Value) {
      rtdLocale.RollingDisabled().ToChat(executor);
      return;
    }

    if (!AdminManager.PlayerHasPermissions(executor, CV_AUTORTD_FLAG.Value)) {
      generic.NoPermissionMessage(CV_AUTORTD_FLAG.Value).ToChat(executor);
      return;
    }

    if (cookie == null) {
      locale.TogglingNotEnabled.ToChat(executor);
      return;
    }

    var steam = executor.SteamID;
    Server.NextFrameAsync(async () => {
      var value  = await cookie.Get(steam);
      var enable = value is not (null or "Y");
      await cookie.Set(steam, enable ? "Y" : "N");
      await Server.NextFrameAsync(() => {
        if (!executor.IsValid) return;
        locale.AutoRTDToggled(enable).ToChat(executor);
        cachedCookies[steam] = enable;
      });
    });
  }
}