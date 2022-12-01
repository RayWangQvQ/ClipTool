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
    public class MainViewModel : INotifyPropertyChanged,ISingletonDependency
    {
        private readonly DouYinAppService _douYinAppService;

        public MainViewModel(DouYinAppService douYinAppService)
        {
            _douYinAppService = douYinAppService;

            ButtonText = "Click me";
            ClickCommand = new Command(DoClick);
        }

        public int ClickTimes { get; set; }

        public string ButtonText { get; set; }

        public string InputShareLink { get; set; }

        public string Result { get; set; }

        public Command ClickCommand { get; set; }

        private void DoClick()
        {
            ClickTimes++;

            ButtonText = $"Clicked {ClickTimes} time";

            OnPropertyChanged(nameof(ButtonText));

            Result = _douYinAppService.Do(InputShareLink);
            OnPropertyChanged(nameof(Result));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
