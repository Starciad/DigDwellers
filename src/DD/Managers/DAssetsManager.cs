using DD.Constants;
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

        private const string GRAPHICS_DIRECTORY = "graphics";

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
            string char_path = Path.Combine(GRAPHICS_DIRECTORY, "characters");
            string blocks_path = Path.Combine(GRAPHICS_DIRECTORY, "blocks");

            Loader(DAssetsConstants.TEXTURES_CHARACTERS_LENGTH, "char_", char_path);
            Loader(DAssetsConstants.TEXTURES_BLOCKS_LENGTH, "block_", blocks_path);

            void Loader(int length, string prefix, string path)
            {
                int targetId;
                string targetName;
                string targetPath;

                for (int i = 0; i < length; i++)
                {
                    targetId = i + 1;
                    targetName = string.Concat(prefix, targetId);
                    targetPath = Path.Combine(path, targetName);

                    this.textures.Add(targetName, this._cm.Load<Texture2D>(targetPath));
                }
            }
        }
    }
}
