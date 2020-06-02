using NSSFLIPobj.ApplicationServices.GetDistrictListUseCase;
using NSSFLIPobj.ApplicationServices.Ports;
using NSSFLIPobj.DomainObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace NSSFLIPobj.DesktopClient.InfrastructureServices.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IGetNSSFLIPobjListUseCase _getNSSFLIPobjListUseCase;

        public MainViewModel(IGetNSSFLIPobjListUseCase getNSSFLIPobjListUseCase)
            => _getNSSFLIPobjListUseCase = getNSSFLIPobjListUseCase;

        private Task<bool> _loadingTask;
        private nssflipobj _currentNSSFLIPobj;
        private ObservableCollection<nssflipobj> _nssflipobjs;

        public event PropertyChangedEventHandler PropertyChanged;

        public nssflipobj CurrentNSSFLIPobj
        {
            get => _currentNSSFLIPobj; 
            set
            {
                if (_currentNSSFLIPobj != value)
                {
                    _currentNSSFLIPobj = value;
                    OnPropertyChanged(nameof(CurrentNSSFLIPobj));
                }
            }
        }

        private async Task<bool> LoadNSSFLIPobjs()
        {
            var outputPort = new OutputPort();
            bool result = await _getNSSFLIPobjListUseCase.Handle(GetNSSFLIPobjListUseCaseRequest.CreateAllNSSFLIPobjsRequest(), outputPort);
            if (result)
            {
                NSSFLIPobjs = new ObservableCollection<nssflipobj>(outputPort.NSSFLIPobjs);
            }
            return result;
        }

        public ObservableCollection<nssflipobj> NSSFLIPobjs
        {
            get 
            {
                if (_loadingTask == null)
                {
                    _loadingTask = LoadNSSFLIPobjs();
                }
                
                return _nssflipobjs; 
            }
            set
            {
                if (_nssflipobjs != value)
                {
                    _nssflipobjs = value;
                    OnPropertyChanged(nameof(NSSFLIPobjs));
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private class OutputPort : IOutputPort<GetNSSFLIPobjListUseCaseResponse>
        {
            public IEnumerable<nssflipobj> NSSFLIPobjs { get; private set; }

            public void Handle(GetNSSFLIPobjListUseCaseResponse response)
            {
                if (response.Success)
                {
                    NSSFLIPobjs = new ObservableCollection<nssflipobj>(response.NSSFLIPobjs);
                }
            }
        }
    }
}
