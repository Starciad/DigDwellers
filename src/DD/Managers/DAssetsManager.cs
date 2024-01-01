using DD.Objects;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;
using System.IO;

namespace DD.Managers
{
    internal sealed class DAssetsManager : DGameObject
    {
        private readonly ContentManager _cm;

        private readonly Dictionary<string, Texture2D> textures = [];

        internal DAssetsManager(ContentManager contentManager)
        {
            this._cm = contentManager;
        }

        protected override void OnAwake()
        {
            LoadTextures();
        }

        private void LoadTextures()
        {
            string char_path = Path.Combine("graphics", "characters");
            string blocks_path = Path.Combine("graphics", "blocks");

            const int char_length = 1;
            const int blocks_length = 3;

            // Characters
            int targetId;
            for (int i = 0; i < char_length; i++)
            {
                targetId = i + 1;
                this.textures.Add($"char_{targetId}", this._cm.Load<Texture2D>(Path.Combine(char_path, $"char_{i}")));
            }

            // Blocks
            for (int i = 0; i < blocks_length; i++)
            {
                targetId = i + 1;
                this.textures.Add($"block_{targetId}", this._cm.Load<Texture2D>(Path.Combine(blocks_path, $"block_{targetId}")));
            }
        }
    }
}
