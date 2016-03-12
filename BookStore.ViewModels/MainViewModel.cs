using System.ComponentModel.Composition;
using BookStore.DataAccess;
using BookStore.DataAccess.Models;
using IkitMita.Mvvm.ViewModels;

namespace BookStore.ViewModels
{
    [Export]
    public class MainViewModel : ChildViewModelBase
    {
        private GetEmployeeModel _currentEmployee;

        public GetEmployeeModel CurrentEmployee
        {
            get { return _currentEmployee; }
            set
            {
                _currentEmployee = value;
                OnPropertyChanged();
            }
        }

        [Import]
        private IGetEmployeeOperation GetEmployeeOperation { get; set; }

        public async void InitializeAsync(GetUserModel user)
        {
            using (StartOperation())
            {
                CurrentEmployee = await GetEmployeeOperation.ExecuteAsync(user.Id);
            }
        }
    }
}
