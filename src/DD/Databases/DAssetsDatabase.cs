using DD.Constants;
using DD.Map.Serialization;
using DD.Objects;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.IO;

namespace DD.Databases
{
    internal sealed class DAssetsDatabase : DGameObject
    {
        private readonly ContentManager _cm;

        private readonly Dictionary<string, Texture2D> textures = [];
        private readonly Dictionary<string, DMapxData> mapxFiles = [];

        internal DAssetsDatabase(ContentManager contentManager)
        {
            this._cm = contentManager;
        }

        protected override void OnAwake()
        {
            LoadTextures();
            LoadMapxFiles();
        }

        #region LOAD
        private void LoadTextures()
        {
            string char_path = Path.Combine(DDirectoryConstants.GRAPHICS_DIRECTORY, "characters");
            string blocks_path = Path.Combine(DDirectoryConstants.GRAPHICS_DIRECTORY, "blocks");

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
        private void LoadMapxFiles()
        {
            // PATHS
            string mapx_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DDirectoryConstants.ASSETS_DIRECTORY, DDirectoryConstants.MAPX_DIRECTORY);
            string specials_path = Path.Combine(mapx_path, "specials");

            // SPECIALS (LOAD)
            this.mapxFiles.Add("home", DMapxSerializer.Deserialize(Path.Combine(specials_path, "home.mapx")));

            // CHUNKS (LOAD)
            // [ ... ]
        }
        #endregion

        #region GET
        internal Texture2D GetTexture(string name)
        {
            return this.textures[name];
        }
        internal DMapxData GetMapxData(string name)
        {
            return this.mapxFiles[name];
        }
        #endregion
    }
}