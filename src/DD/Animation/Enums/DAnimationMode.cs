namespace DD.Animation.Enums
{
    /// <summary>
    /// Specifies different modes for playing animations.
    /// </summary>
    internal enum DAnimationMode
    {
        /// <summary>
        /// The animation is disabled and will not play the next frames or interfere with delays.
        /// </summary>
        Disable,

        /// <summary>
        /// Animation plays forward in a loop.
        /// </summary>
        Forward,

        /// <summary>
        /// Animation plays forward once and then disables itself.
        /// </summary>
        Once,
    }
}
