using Ray.ClipTool.AppService;
using Ray.ClipTool.ViewModels;
using Volo.Abp.DependencyInjection;

namespace Ray.ClipTool;

public partial class MainPage : ContentPage, ISingletonDependency
{
	public MainPage(MainViewModel mainViewModel)
	{
		InitializeComponent();
		BindingContext= mainViewModel;
    }
}
