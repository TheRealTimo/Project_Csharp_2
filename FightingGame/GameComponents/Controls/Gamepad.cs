using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Text;

namespace FightingGame
{
    class Gamepad
    {
        static GamePadState currentGamePadState;
        static GamePadState previousGamePadState;

        public Gamepad()
        {
        }

        public static GamePadState GetState(PlayerIndex index)
        {
            previousGamePadState = currentGamePadState;
            currentGamePadState = GamePad.GetState(index);
            return currentGamePadState;
        }

        public static bool IsPressed(Buttons button)
        {
            return currentGamePadState.IsButtonDown(button);
        }

        public static bool HasNotBeenPressed(Buttons button)
        {
            return currentGamePadState.IsButtonDown(button) && !previousGamePadState.IsButtonDown(button);
        }
    }
}