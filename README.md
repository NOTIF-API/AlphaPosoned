# AlphaPosoned
[![Sponsor on Patreon](https://img.shields.io/badge/sponsor-patreon-orange.svg)](https://www.patreon.com/NOTIF247)
[![Download letest version](https://img.shields.io/badge/download-latest-red.svg)](https://github.com/NOTIF-API/AlphaPosoned/releases)

adds the possibility of radiation after a warhead explodes
# Configs
```yaml
alpha_poisoned:
# will the plugin be enabled
  is_enabled: true
  # will debug messages be visible?
  debug: false
  # roles that will not take damage after the explosion
  ignored_roles:
  - ChaosConscript
  - ChaosMarauder
  - ChaosRepressor
  - ChaosRifleman
  # maximum poison damage over time [default=5]
  max_poison_damage: 5
  # period of time before the next warren
  certain_damage_time:
    item1: 10
    item2: 30
```
