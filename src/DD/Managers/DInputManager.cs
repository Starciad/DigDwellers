using DD.Objects;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DD.Managers
{
    internal sealed class DInputManager : DGameObject
    {
        /// <summary>
        /// Current state the player's mouse is in.
        /// </summary>
        internal MouseState Mouse => this._mouseState;

        /// <summary>
        /// Current state the player's keyboard is in.
        /// </summary>
        internal KeyboardState Keyboard => this._keyboardState;

        /// <summary>
        /// Mouse state captured in the previous frame.
        /// </summary>
        internal MouseState PreviousMouse => this._previousMouseState;

        /// <summary>
        /// Keyboard status captured in the previous frame.
        /// </summary>
        internal KeyboardState PreviousKeyboard => this._previousKeyboardState;

        private MouseState _previousMouseState;
        private KeyboardState _previousKeyboardState;

        private MouseState _mouseState;
        private KeyboardState _keyboardState;

        protected override void OnUpdate(GameTime gameTime)
        {
            base.OnUpdate(gameTime);

            this._previousMouseState = this._mouseState;
            this._previousKeyboardState = this._keyboardState;

            this._mouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();
            this._keyboardState = Microsoft.Xna.Framework.Input.Keyboard.GetState();
        }

        /// <summary>
        /// Calculates the change in the scroll wheel value between the previous and current states of the mouse input.
        /// </summary>
        /// <returns>The difference in scroll wheel value.</returns>
        internal int GetDeltaScrollWheel()
        {
            return this._previousMouseState.ScrollWheelValue - this._mouseState.ScrollWheelValue;
        }

        /// <summary>
        /// Determines whether the specified key was just pressed in the current frame.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns>True if the key was just pressed, false otherwise.</returns>
        internal bool Started(Keys key)
        {
            return !this.PreviousKeyboard.IsKeyDown(key) && this.Keyboard.IsKeyDown(key);
        }

        /// <summary>
        /// Determines whether the specified key is currently being held down.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns>True if the key is being held down, false otherwise.</returns>
        internal bool Performed(Keys key)
        {
            return this.PreviousKeyboard.IsKeyDown(key) && this.Keyboard.IsKeyDown(key);
        }

        /// <summary>
        /// Determines whether the specified key was just released in the current frame.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns>True if the key was just released, false otherwise.</returns>
        internal bool Canceled(Keys key)
        {
            return this.PreviousKeyboard.IsKeyDown(key) && !this.Keyboard.IsKeyDown(key);
        }
    }
}
