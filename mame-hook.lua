
local cpu = manager.machine.devices[':maincpu']
local mem = cpu.spaces['program']
local outputManager = manager.machine.output;

local prevGameState = 0x00
local prevSubGameState = 0x00
local prevPlayerPosition = 0x00
local gameState = 'unknown'
local led0On = 0
local led1On = 0

-- Run with: mame.exe tempest -autoboot_script mame-hook.lua
emu.register_frame_done(function()
    local nextGameState = mem:read_i8(0x00)
    local nextSubGameState = mem:read_i8(0x01)

    -- For testing high score explosion and initials entry
    -- mem:write_i8(0x42, 0x08)
    -- mem:write_i8(0x41, 0x00)
    -- mem:write_i8(0x40, 0x85)

    -- For testing jump to a specific level (zero indexed)
    -- mem:write_i8(0x46, 0x0F)

    UpdateStartButtonLeds()

    local stateWasTheSame = prevGameState == nextGameState and prevSubGameState == nextSubGameState

    -- TODO: Detect player death, zapper
    if not stateWasTheSame then
        if nextGameState == 0x0A and nextSubGameState == 0x0A then
            gameState = 'high-scores'
            print('Game State: High Scores')
        elseif nextGameState == 0x0A and nextSubGameState == 0x12 then
            gameState = 'title-screen'
            print('Game State: Tempest Logo (Color Box)')
        elseif nextGameState == 0x0A and nextSubGameState == 0x14 then
            print('Game State: Tempest Logo')
        elseif nextGameState == 0x18 then
            gameState = 'level-transition'
            print('Game State: Transition to next level')
        elseif nextGameState == 0x20 then
            gameState = 'tube-decent'
            print('Game State: Tube decent')
        -- Set briefly on player death... but set after death animation occurs
        -- elseif nextGameState == 0x06 then
        --     gameState = 'player-death'
        --     print('Game State: Player death')
        elseif nextGameState == 0x24 then
            gameState = 'high-score-explosion'
            print('Game State: High score explosion')
        elseif nextGameState == 0x12 then
            gameState = 'enter-initials'
            print('Game State: Enter initials for high score')
        elseif nextGameState == 0x16 then
            gameState = 'level-selection'
            print('Game State: Level selection')
        elseif nextSubGameState == 0x00 then
            gameState = 'game-play'
            print('Game State: game play')
        else
            gameState = 'unknown'
            print('Game State: (unknown transition)')
        end

        prevGameState = nextGameState
        prevSubGameState = nextSubGameState
    end

    if gameState == 'game-play' then
        local nextPlayerPosition = mem:read_i8(0x200)

        local positionWasTheSame = prevPlayerPosition == nextPlayerPosition

        if not positionWasTheSame then
            prevPlayerPosition = nextPlayerPosition
            print('Player Position: ' .. nextPlayerPosition)
        end
    end
end)

function UpdateStartButtonLeds()

    -- 00 - attract
    -- C0 - playing
    -- 80 - high score entry
    local playerInputMode = mem:read_u8(0x05)

    -- Grab the emulated machine's reported LED states
    local nextLed0State = outputManager:get_value('led0')
    local nextLed1State = outputManager:get_value('led1')

    -- Overridden behavior; during gameplay have the start button illuminated based
    -- on which player is currently playing.
    if playerInputMode == 0xC0 then

        -- 00 - Player 1
        -- 01 - Player 2
        local currentPlayer = mem:read_i8(0x003D)

        if currentPlayer == 0 then
            nextLed0State = 1
            nextLed1State = 0
        end
        
        if currentPlayer == 1 then
            nextLed0State = 0
            nextLed1State = 1
        end
    end

    if led0On ~= nextLed0State then
        led0On = nextLed0State
        print('LED 0 State: ' .. led0On)
        if led0On == 1 then
            os.execute('xset led named \'Caps Lock\'')
        else
            os.execute('xset -led named \'Caps Lock\'')
        end
    end

    if led1On ~= nextLed1State then
        led1On = nextLed1State
        print('LED 1 State: ' .. led1On)
        if led0On == 1 then
            os.execute('xset led named \'Scroll Lock\'')
        else
            os.execute('xset -led named \'Scroll Lock\'')
        end
    end
end