using CommunityToolkit.Maui.Markup;
using MauiApp7.Pages;
using MauiApp7.ViewModels;
using Microsoft.Maui.Controls;

namespace MauiApp7;

class MainPage : BaseContentPage<MainViewModel>
{
    public MainPage(MainViewModel mainViewModel) : base(mainViewModel)
    {
        Content = new ScrollView
        {
            Content = new VerticalStackLayout
            {
                Spacing = 25,
                Padding = 30,

                Children =
                {
                    new Label()
                        .Text("Swipe to Delete Example")
                        .Font(size: 32)
                        .CenterHorizontal(),

                    // CollectionView with Swipe to Delete
                    new CollectionView
                    {
                        ItemTemplate = new DataTemplate(() =>
                        {
                            var swipeView = new SwipeView { Threshold = 100 };

                            // Right Swipe to Delete
                            var deleteRightSwipeItem = new SwipeItem
                            {
                                Text = "Delete",
                                BackgroundColor = Colors.Red,
                                IconImageSource = "delete_icon.png",
                                Command = ((MainViewModel)BindingContext).DeleteCommand
                            };
                            deleteRightSwipeItem.SetBinding(SwipeItem.CommandParameterProperty, new Binding("."));

                            swipeView.RightItems = new SwipeItems { deleteRightSwipeItem };
                            swipeView.RightItems.Mode = SwipeMode.Execute;

                            // Left Swipe to Delete
                            var deleteLeftSwipeItem = new SwipeItem
                            {
                                Text = "Delete",
                                BackgroundColor = Colors.Red,
                                IconImageSource = "delete_icon.png",
                                Command = ((MainViewModel)BindingContext).DeleteCommand
                            };
                            deleteLeftSwipeItem.SetBinding(SwipeItem.CommandParameterProperty, new Binding("."));

                            swipeView.LeftItems = new SwipeItems { deleteLeftSwipeItem };
                            swipeView.LeftItems.Mode = SwipeMode.Execute;

                            // Frame with Note Content
                            var frame = new Frame
                            {
                                Padding = 25,
                                Margin = 10,
                                CornerRadius = 8,
                                BackgroundColor = Colors.White
                            };

                            var label = new Label()
                                .Font(size: 18)
                                .TextColor(Colors.Black)
                                .Bind(Label.TextProperty, "Text");

                            frame.Content = label;
                            swipeView.Content = frame;

                            return swipeView;
                        })
                    }
                    .Bind(CollectionView.ItemsSourceProperty, nameof(MainViewModel.Notes))
                }
            }
        };
    }
}
