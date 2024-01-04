using DD.Enums.Animation;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;

namespace DD.Animation
{
    /// <summary>
    /// A helper class for managing and coordinating various sprites and textures to create practical and easy-to-control animations.
    /// </summary>
    internal sealed class DAnimation
    {
        /// <summary>
        /// Get the texture used by the animation.
        /// </summary>
        internal Texture2D Texture => this.texture;

        /// <summary>
        /// Get the coordinates and dimensions of the current sourceFrame in the animation.
        /// </summary>
        internal Rectangle SourceFrame => this.sourceFrame;

        /// <summary>
        /// Get the scale of the sprite based on the current sourceFrame of the animation.
        /// </summary>
        internal float SpriteScale
        {
            get
            {
                float width = this.SourceFrame.Width;
                float height = this.SourceFrame.Height;

                return width == height ? width : (width + height) / 2;
            }
        }

        /// <summary>
        /// Get the current mode in which the animation is currently performing.
        /// </summary>
        internal DAnimationMode Mode => this.mode;

        internal bool IsPaused => this.pause;

        // ======================================= //

        private Texture2D texture;
        private Rectangle sourceFrame;

        private DAnimationMode mode;
        private bool pause;

        private float frameDuration = 1f;
        private float currentFrameDuration = 0f;

        private readonly List<Rectangle> frames = [];
        private int currentFrameIndex = 0;

        // ======================================= //

        /// <summary>
        /// Initializes the initial components of the animation.
        /// </summary>
        internal void Initialize()
        {
            if (this.frames.Count > 0)
            {
                this.sourceFrame = this.frames[0];
            }
        }

        /// <summary>
        /// Updates the animation sourceFrame based on the current mode and timing.
        /// </summary>
        internal void Update()
        {
            if (this.pause)
            {
                return;
            }

            if (this.mode == DAnimationMode.Disable)
            {
                return;
            }

            if (this.currentFrameDuration < this.frameDuration)
            {
                this.currentFrameDuration += 0.1f;
            }
            else
            {
                this.currentFrameDuration = 0;

                if (this.currentFrameIndex < this.frames.Count - 1)
                {
                    this.currentFrameIndex++;
                }
                else
                {
                    this.currentFrameIndex = 0;

                    if (this.mode == DAnimationMode.Once)
                    {
                        this.mode = DAnimationMode.Disable;
                        return;
                    }
                }
            }

            this.sourceFrame = this.frames[this.currentFrameIndex];
        }

        /// <summary>
        /// Resets all animation components to their initial state.
        /// </summary>
        internal void Reset()
        {
            this.mode = DAnimationMode.Disable;

            this.frameDuration = 1f;
            this.currentFrameDuration = 0f;

            this.currentFrameIndex = 0;
        }

        /// <summary>
        /// Clears all registered frames in the animation.
        /// </summary>
        internal void ClearFrames()
        {
            this.frames.Clear();
        }

        /// <summary>
        /// Sets the texture for the animation.
        /// </summary>
        /// <param name="texture">The texture to be used for the animation.</param>
        internal void SetTexture(Texture2D texture)
        {
            this.texture = texture;
        }

        /// <summary>
        /// Sets the animation mode.
        /// </summary>
        /// <param name="mode">The animation playback mode.</param>
        internal void SetMode(DAnimationMode mode)
        {
            this.mode = mode;
        }

        /// <summary>
        /// Sets the duration of each sourceFrame in the animation.
        /// </summary>
        /// <param name="delay">The delay (in seconds) between frames.</param>
        internal void SetDuration(float duration)
        {
            this.frameDuration = duration;
        }

        /// <summary>
        /// Sets the current sourceFrame to be displayed in the animation.
        /// </summary>
        /// <param name="index">The index of the sourceFrame to be set as the current sourceFrame.</param>
        internal void SetFrameIndex(int index)
        {
            this.currentFrameIndex = Math.Clamp(index, 0, this.frames.Count - 1);
        }

        /// <summary>
        /// Adds a new sourceFrame to the animation.
        /// </summary>
        /// <param name="sourceFrame">The rectangle defining the sourceFrame within the texture.</param>
        internal void AddFrame(Rectangle sourceFrame)
        {
            this.frames.Add(sourceFrame);
        }

        internal void Pause()
        {
            this.pause = true;
        }

        internal void Resume()
        {
            this.pause = false;
        }

        /// <summary>
        /// Checks if the animation is empty (has no texture or rectangle).
        /// </summary>
        /// <returns>True if the animation is empty, false otherwise.</returns>
        internal bool IsEmpty()
        {
            return this.Texture == null || this.sourceFrame.IsEmpty;
        }
    }
}
