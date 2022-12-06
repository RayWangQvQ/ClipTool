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
            CopyResultCommand = new Command(DoCopyResultAsync);
            ClearCommand = new Command(DoClear);
            OpenBrowserCommand =new Command(OpenBrowserAsync);
        }

        public string InputShareLink { get; set; }

        public string Result { get; set; }

        public Command ClickCommand { get; set; }

        public Command CopyResultCommand { get; set; }

        public Command ClearCommand { get; set; }

        public Command OpenBrowserCommand { get; set; }

        private async void DoClickAsync()
        {
            Result = await _douYinAppService.DoAsync(InputShareLink);
            OnPropertyChanged(nameof(Result));
            MessagingCenter.Send(this, "success");
        }

        private async void DoCopyResultAsync()
        {
            await Clipboard.Default.SetTextAsync(Result);
            MessagingCenter.Send(this, "copied");
        }

        private void DoClear()
        {
            InputShareLink = "";
            Result = "";
            OnPropertyChanged(nameof(InputShareLink));
            OnPropertyChanged(nameof(Result));
            MessagingCenter.Send(this, "cleared");
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
