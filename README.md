# Tempest RGB Cabinet

This repository contains documentation on my Atari Tempest cabaret arcade cabinet, which I've converted to use non-standard hardware, including an array of RGB LEDs surrounding the monitor which are driven by the game state.

This is currently a work in progress.

## Repository Contents

### MAME Hook

The [mame-hook.lua] script is intended to be used with MAME as an autoboot script:

```
mame tempest -autoboot_script mame-hook.lua
```

It is used to inspect memory locations and report the following:

* Game state change (attract mode, gameplay, etc)
* Game sub-state change (high score screen, title screen, etc)
* LED state (1 player and 2 player buttons blink when credits are inserted)
* Player position

### RGB Driver

This takes the state information provided by the MAME hook script and uses it to update the state of the RGB LEDs that surround the monitor.

TODO

### Level Maps

The [level-maps] directory includes screenshots of each of the 16 level layouts annotated with the player position of each segment.

This was obtained by using the MAME debugger and inspecting the value of memory location `0x200`.

## Cabinet Documentation

A reference of how all the hardware was wired and how the software was configured to run the cabinet.

### Hardware

TODO

### OS configuration

TODO

## Web Resources

* Source code etc
  * [Tempest Code Project](https://web.archive.org/web/20190926012737/https:/ionpool.net/arcade/tempest_code_project/tempest_code_project.html)
    * [Disassembly with comments](https://web.archive.org/web/20190926012737/https:/ionpool.net/arcade/tempest_code_project/136002.txt)
    * [Memory locations 1](https://web.archive.org/web/20190926020054/http://www.ionpool.net/arcade/tempest_code_project/memory.html)
    * [Memory locations 2](https://web.archive.org/web/20041223160804/http://216.46.5.1:18804/)
* List of levels (shapes and colors)
 * https://www.arcade-history.com/?n=tempest-upright-model&page=detail&id=2865
* Reference gameplay video
 * https://www.youtube.com/watch?v=AiTgA3ZOoSo