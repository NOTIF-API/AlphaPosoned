using Exiled.API.Interfaces;
using PlayerRoles;
using System.ComponentModel;
using System.Collections.Generic;
using System;

namespace AlphaPoisoned
{
    public class Config: IConfig
    {
        [Description("will the plugin be enabled")]
        public bool IsEnabled { get; set; } = true;
        [Description("will debug messages be visible?")]
        public bool Debug { get; set; } = false;
        [Description("roles that will not take damage after the explosion")]
        public List<RoleTypeId> IgnoredRoles { get; set; } = new List<RoleTypeId>()
        { 
            RoleTypeId.ChaosConscript,
            RoleTypeId.ChaosMarauder,
            RoleTypeId.ChaosRepressor,
            RoleTypeId.ChaosRifleman
        };
        [Description("maximum poison damage over time [default=5]")]
        public int MaxPoisonDamage { get; set; } = 5;
        [Description("period of time before the next warren")]
        public List<int> CertainDamageTime { get; set; } = new List<int>() { 10, 30 };
        [Description("a message that the player will see after death")]
        public string DeathMessage { get; set; } = "you were killed by radiation after the explosion";
    }
}
