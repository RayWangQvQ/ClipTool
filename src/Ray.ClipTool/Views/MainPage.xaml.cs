using Ray.ClipTool.AppService;
using Ray.ClipTool.ViewModels;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Alerts;
using Volo.Abp.DependencyInjection;
using System.Threading;

namespace Ray.ClipTool;

public partial class MainPage : ContentPage, ISingletonDependency
{
    public MainPage(MainViewModel mainViewModel)
    {
        InitializeComponent();

        BindingContext = mainViewModel;

        ResultLayout.IsVisible = false;
        WebViewLayout.IsVisible = false;

        MessagingCenter.Subscribe<MainViewModel>(this, "success", vm =>
        {
            //DisplayAlert("Success!", "The video url are shown below, you can check it out and try to download it.", "OK");
            var toast = Toast.Make("successfully");
            toast.Show();

            ResultLayout.IsVisible = true;
            WebViewLayout.IsVisible = true;
        });

        MessagingCenter.Subscribe<MainViewModel>(this, "cleared", vm =>
        {
            ResultLayout.IsVisible = false;

            WebViewLayout.IsVisible = false;

            var toast= Toast.Make("successfully");
            toast.Show();
        });

        MessagingCenter.Subscribe<MainViewModel>(this, "copied", vm =>
        {
            var toast = Toast.Make("successfully");
            toast.Show();
        });
    }
}
