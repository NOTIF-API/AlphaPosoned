using Exiled.API.Features;
using Exiled.API.Enums;
using Exiled.Events.EventArgs.Warhead;
using Exiled.Events.EventArgs.Server;
using System.Collections.Generic;
using MEC;
using System.Linq;
using Exiled.API.Features.DamageHandlers;
using System;

namespace AlphaPoisoned
{
    public class EventHandler
    {
        private CoroutineHandle coroutineHandle;

        public void OnDetonated(DetonatingEventArgs e)
        {
            coroutineHandle = Timing.RunCoroutine(Damager(), "idamager");
        }
        public void OnRoundStarted()
        {
            Timing.KillCoroutines(coroutineHandle);
        }
        public void OnRoundEnded(RoundEndedEventArgs e)
        {
            Timing.KillCoroutines(coroutineHandle);
        }
        private IEnumerator<float> Damager()
        {
            for (; ; )
            {
                float wait = 1f;
                if (Warhead.IsDetonated)
                {
                    float damage = (float)new Random().Next(1, main.Instance.Config.MaxPoisonDamage);
                    foreach (Player player in Player.List.Where(x => x != null & x.IsAlive & !main.Instance.Config.IgnoredRoles.Contains(x.Role.Type)))
                    {
                        player.Hurt(player, damage, DamageType.Warhead, deathText: main.Instance.Config.DeathMessage);
                    }
                    wait = new Random().Next(main.Instance.Config.CertainDamageTime[0], main.Instance.Config.CertainDamageTime[1]);
                }
                yield return Timing.WaitForSeconds(wait);
            }
        }
    }
}
