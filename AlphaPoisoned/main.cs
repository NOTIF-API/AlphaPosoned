using Exiled.API.Features;
using warhead = Exiled.Events.Handlers.Warhead;
using server = Exiled.Events.Handlers.Server;
using System;
using System.Collections.Generic;

namespace AlphaPoisoned
{
    public class main: Plugin<Config>
    {
        public static main Instance { get; private set; }
        private EventHandler eve;

        public override void OnEnabled()
        {
            this.RegisterEvent();
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            this.UnRegisterEvent();
            base.OnDisabled();
        }
        private void CheckSetting()
        {
            List<int> tpl = this.Config.CertainDamageTime;
            if (Config.DeathMessage == string.Empty | Config.DeathMessage == "" | Config.DeathMessage == null)
            {
                Log.Warn("[Config] Timer: Death message is empty");
                Config.DeathMessage = "you were killed by radiation after the explosion";
            }
            if (tpl[0] > tpl[1])
            {
                Log.Warn("[Config] Timer: value 1 cannot be greater than 2");
                this.OnDisabled();
                base.OnDisabled();
            }
        }
        private void RegisterEvent()
        {
            Instance = this;
            eve = new EventHandler();

            server.RoundStarted += eve.OnRoundStarted;
            server.RoundEnded += eve.OnRoundEnded;

            warhead.Detonating += eve.OnDetonated;

            this.CheckSetting();
        }
        private void UnRegisterEvent()
        {

            server.RoundStarted -= eve.OnRoundStarted;
            server.RoundEnded -= eve.OnRoundEnded;

            warhead.Detonating -= eve.OnDetonated;

            eve = null;
            Instance = null;
        }
    }
}
