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

        public static GamePadState GetState(PlayerIndex playerindex)
        {
            previousGamePadState = currentGamePadState;
            currentGamePadState = GamePad.GetState(playerindex);
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

        //Checks if a button has been pressen and then released
        public static bool HasBeenPressed(Buttons button)
        {
            return currentGamePadState.IsButtonUp(button) && previousGamePadState.IsButtonDown(button);
        }
    }
}
