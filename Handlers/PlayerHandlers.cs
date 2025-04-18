﻿using Exiled.Events.EventArgs.Player;
using Exiled.API.Features;
using PlayerRoles;

namespace SelectiveTeslas.Handlers
{
    public class PlayerHandlers
    {
        private readonly Config _config;

        public PlayerHandlers(Config config) => _config = config;

        public void OnTriggeringTesla(TriggeringTeslaEventArgs ev)
        {
            if (ev.Player == null)
            {
                if (_config.Debug)
                    Log.Debug($"log");
                return;
            }

            Team playerTeam = ev.Player.Role.Team;

            if (_config.ActivatingTeams.Contains(playerTeam))
            {
                ev.IsAllowed = true;
                if (_config.Debug)
                    Log.Debug($"{ev.Player.Nickname} ({playerTeam}) aktywuje Teslę. Zezwolono.");
            }
            else
            {
                ev.IsAllowed = false;
                if (_config.Debug)
                    Log.Debug($"{ev.Player.Nickname} ({playerTeam}) próbuje aktywować Teslę. Zablokowano.");
            }
        }
    }
}