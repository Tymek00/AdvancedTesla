using System;
using Exiled.API.Features;
using Exiled.API.Enums;

using SelectiveTeslas.Handlers;
using PlayerEvents = Exiled.Events.Handlers.Player;

namespace SelectiveTeslas
{
    public class SelectiveTeslasPlugin : Plugin<Config>
    {
        public override string Name => "TeslaAdvanced";
        public override string Author => "Tymek";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(9, 5, 1); 

        public static SelectiveTeslasPlugin Instance { get; private set; }

        private PlayerHandlers _playerHandlers;

        public override PluginPriority Priority => PluginPriority.Low;

        public override void OnEnabled()
        {
            Instance = this;
            _playerHandlers = new PlayerHandlers(Config);

            RegisterEvents();

            Log.Info($"{Name} v{Version} by {Author} został włączony. Tesle aktywują się tylko dla: {string.Join(", ", Config.ActivatingTeams)}.");
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            _playerHandlers = null;
            Instance = null;

            Log.Info($"{Name} został wyłączony. Tesle działają normalnie.");
            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            PlayerEvents.TriggeringTesla += _playerHandlers.OnTriggeringTesla;
            if (Config.Debug) Log.Debug($"{Name}: Zarejestrowano event TriggeringTesla.");
        }

        private void UnregisterEvents()
        {
            PlayerEvents.TriggeringTesla -= _playerHandlers.OnTriggeringTesla;
            if (Config.Debug) Log.Debug($"{Name}: Wyrejestrowano event TriggeringTesla.");
        }
    }
}