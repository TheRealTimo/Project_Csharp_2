using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Text;

namespace ConflictGame
{
    class Gamepad
    {
        static GamePadState currentGamePadState;
        static GamePadState previousGamePadState;

        public Gamepad()
        {
        }

        public static GamePadState GetState()
        {
            previousGamePadState = currentGamePadState;
            currentGamePadState = GamePad.GetState(PlayerIndex.One); //Alter to have any player index
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
