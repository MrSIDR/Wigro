using System.Collections.Generic;
using UnityEngine;

namespace View
{
    public class ViewController
    {
        private readonly Dictionary<string, IView> _viewsMap = new();
        private readonly List<IView> _previousViews = new();
        
        private IView _currentView;

        public void AddView(string name, IView view)
        {
            if (_viewsMap.TryAdd(name, view))
            {
                return;
            }
            
            Debug.LogError($"View with name {name} already exist!");
        }

        public void Show(string name)
        {
            if (!_viewsMap.TryGetValue(name, out var view))
            {
                Debug.LogError($"View with name {name} doesn't exist!");
                return;
            }

            if (_currentView == view)
            {
                return;
            }
            
            if (_currentView != null)
            {
                _currentView.SetActive(false);
                _previousViews.Add(_currentView);
            }

            _currentView = view;
            _currentView.SetActive(true);
        }
        
        public void Hide(string name)
        {
            if (!_viewsMap.TryGetValue(name, out var view))
            {
                Debug.LogError($"View with name {name} doesn't exist!");
                return;
            }

            if (_currentView == view)
            {
                _currentView.SetActive(false);
                _currentView = null;
                if (_previousViews.Count <= 0)
                {
                    return;
                }
                
                var lastIndex = _previousViews.Count - 1;
                _currentView = _previousViews[lastIndex];
                _currentView.SetActive(true);
                _previousViews.RemoveAt(lastIndex);
                return;
            }

            _previousViews.Remove(view);
        }
    }
}