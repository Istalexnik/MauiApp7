using MauiApp7.ViewModels;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp7.Pages;

abstract class BaseContentPage : ContentPage
{
    protected BaseContentPage(in bool shouldUseSafeArea = false)
    {
        On<iOS>().SetUseSafeArea(shouldUseSafeArea);
        On<iOS>().SetModalPresentationStyle(UIModalPresentationStyle.FormSheet);
    }
}

abstract class BaseContentPage<T> : BaseContentPage where T : BaseViewModel
{
    protected BaseContentPage(in T viewModel, in bool shouldUseSafeArea = false) : base(shouldUseSafeArea)
    {
        base.BindingContext = viewModel;
    }

    protected new T BindingContext => (T)base.BindingContext;
}
