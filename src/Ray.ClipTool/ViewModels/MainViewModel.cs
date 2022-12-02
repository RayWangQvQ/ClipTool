using Ray.ClipTool.AppService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Ray.ClipTool.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged, ISingletonDependency
    {
        private readonly DouYinAppService _douYinAppService;

        public MainViewModel(DouYinAppService douYinAppService)
        {
            _douYinAppService = douYinAppService;

            ClickCommand = new Command(DoClickAsync);

            OpenBrowserCommand=new Command(OpenBrowserAsync);
        }

        public string InputShareLink { get; set; }

        public string Result { get; set; }

        public Command ClickCommand { get; set; }

        public Command OpenBrowserCommand { get; set; }

        private async void DoClickAsync()
        {
            Result = await _douYinAppService.DoAsync(InputShareLink);
            MessagingCenter.Send(this, "success");
            OnPropertyChanged(nameof(Result));
        }

        private async void OpenBrowserAsync()
        {
            if (!string.IsNullOrWhiteSpace(Result))
                await Launcher.OpenAsync(Result);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
