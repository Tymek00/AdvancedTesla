using Exiled.API.Interfaces;
using System.ComponentModel;
using System.Collections.Generic;
using PlayerRoles;

namespace SelectiveTeslas
{
    public class Config : IConfig
    {
        [Description("Włącza lub wyłącza plugin.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Debug Mode.")]
        public bool Debug { get; set; } = false;

        [Description("Lista teamow, które POWINNY aktywować bramki Tesli.")]
        public HashSet<Team> ActivatingTeams { get; set; } = new HashSet<Team>
        {
            Team.ChaosInsurgency,
            Team.ClassD,
            Team.SCPs
        };
    }
}