using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Layout;
using EmotionTracker.ui;
using System;

namespace EmotionTracker.ui
{
    /// <summary>
    /// The view locator.
    /// </summary>
    public class ViewLocator : IDataTemplate
    {
        public Control Build(object data)
        {
            var typeVM = data.GetType();

            var name = data.GetType().FullName!.Replace("ViewModel", "View");
            var type = Type.GetType(name, (x) => Resolver.AssemblyResolver(x), (a, str, b) => Resolver.TypeResolver(typeVM.Assembly, str, b));
            if (TryCreateControl(type, out var control))
            {
                return control;
            }
            else
            {
                return new TextBlock
                {
                    Text = "Not Found: " + name,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
            }
        }

        public bool Match(object data)
        {
            return data is ViewModelBase || data is ReactiveViewModelBase;
        }

        /// <summary>
        /// Tries the create control.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="control">The control.</param>
        /// <returns>A bool.</returns>
        private static bool TryCreateControl(Type? type, out Control control)
        {
            if (type != null)
            {
                control = (Control)Activator.CreateInstance(type)!;
                return true;
            }
            control = default;
            return false;
        }
    }
}
