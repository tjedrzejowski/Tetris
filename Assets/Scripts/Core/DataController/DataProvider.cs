using System;
using Core.Configs;
using Core.GameComponentsProvider;
using UnityEngine;

namespace Core.DataController
{
    public class DataProvider
    {
        private readonly ComponentsProvider _componentsProvider;
        
        public GameConfig GameConfig { get; private set; }

        public DataProvider()
        {
            LoadGameConfig();
        }

        private void LoadGameConfig()
        {
            GameConfig = Resources.Load<GameConfig>(nameof(GameConfig));
            if (GameConfig == null)
            {
                throw new Exception("GameConfig could not be loaded. Make sure it's in a 'Resources' folder and named correctly.");
            }
        }
    }
}