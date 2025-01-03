using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using Microsoft.Extensions.Logging;

namespace ServerAnalyticsPlugin;

public class ServerAnalyticsPlugin : BasePlugin
{
    public override string ModuleName => "ServerAnalyticsPlugin";

    public override string ModuleVersion => "0.0.1";

    public override void Load(bool hotReload)
    {
        Console.WriteLine($"{ModuleName} {ModuleVersion} loaded!");
    }

    [GameEventHandler]
    public HookResult OnPlayerConnect(EventPlayerConnect @event, GameEventInfo info)
    {
        // Userid will give you a reference to a CCSPlayerController class.
        // Before accessing any of its fields, you must first check if the Userid
        // handle is actually valid, otherwise you may run into runtime exceptions.
        // See the documentation section on Referencing Players for details.
        if (@event.Userid?.IsValid ?? false)
        {
            Logger.LogInformation("Player {Name} has connected!", @event.Userid.PlayerName);
        }

        return HookResult.Continue;
    }

    [GameEventHandler]
    public HookResult OnRoundEnd(EventRoundEnd @event, GameEventInfo info)
    {
        return HookResult.Continue;
    }

    [GameEventHandler]
    public HookResult HandlePlayerHurt(EventPlayerHurt @event, GameEventInfo eventInfo)
    {
        return HookResult.Continue;
    }
}
