using System;
using System.Collections.Generic;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.GameplaySetup;
using JetBrains.Annotations;
using SaberFactory.UI.CustomSaber.CustomComponents;
using SaberFactory.UI.Lib;
using SiraUtil.Logging;
using Zenject;

namespace SaberFactory.UI.CustomSaber.Views.GameplaySetupViews
{
    internal class SaberGameplaySetupNavigationController : CustomViewController, IInitializable, IDisposable
    {
        [Inject] private readonly GameplaySetup _gameplaySetup = null;

        [UIValue("nav-buttons")] private List<object> _navButtons;

        private NavButton _currentlySelectedNavButton = null;

        private void Awake()
        {
            _navButtons = new List<object>();
            
            var saberButton = new NavButtonWrapper(
                ENavigationCategory.Saber,
                "SaberFactory.Resources.Icons.customsaber-icon.png",
                ClickedCategory,
                "Select a saber");

            var trailButton = new NavButtonWrapper(
                ENavigationCategory.Trail,
                "SaberFactory.Resources.Icons.trail-icon.png",
                ClickedCategory,
                "Edit the trail");

            var transformButton = new NavButtonWrapper(
                ENavigationCategory.Transform,
                "SaberFactory.Resources.Icons.transform-icon.png",
                ClickedCategory,
                "Transform settings");
            
            _navButtons.Add(saberButton);
            _navButtons.Add(trailButton);
            _navButtons.Add(transformButton);
        }

        [UIAction("#post-parse")]
        private void PostParse()
        {
            if (_navButtons is null || _navButtons.Count <= 0) 
                return;
            
            _currentlySelectedNavButton = ((NavButtonWrapper)_navButtons[0]).NavButton;
            _currentlySelectedNavButton.SetState(true, false);
        }

        private void ClickedCategory(NavButton navButton, ENavigationCategory eNavigationCategory)
        {
            _currentlySelectedNavButton = navButton;
            
            _logger.Info(eNavigationCategory);
        }

        public void Initialize()
        {
            _gameplaySetup.AddTab("Sabers (SFRL)", "SaberFactory.UI.CustomSaber.Views.GameplaySetupViews.SaberGameplaySetupNavigationController.bsml", this);
        }

        public void Dispose()
        {
            _gameplaySetup.RemoveTab("Sabers (SFRL)");
        }
    }
}