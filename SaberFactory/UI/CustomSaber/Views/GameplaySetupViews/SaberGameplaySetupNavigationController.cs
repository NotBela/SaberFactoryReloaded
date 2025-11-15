using System;
using BeatSaberMarkupLanguage.GameplaySetup;
using SaberFactory.UI.Lib;
using SiraUtil.Logging;
using Zenject;

namespace SaberFactory.UI.CustomSaber.Views.GameplaySetupViews
{
    internal class SaberGameplaySetupNavigationController : NavigationView, IInitializable, IDisposable
    {
        [Inject] private readonly GameplaySetup _gameplaySetup = null;
        
        [Inject] private readonly 
        
        public void Initialize()
        {
            _gameplaySetup.AddTab("Sabers (SFRL)", _resourceName, this);
        }

        public void Dispose()
        {
            _gameplaySetup.RemoveTab("Sabers (SFRL)");
        }
    }
}