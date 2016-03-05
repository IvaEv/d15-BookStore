using System.ComponentModel.Composition;
using BookStore.DataAccess;
using BookStore.Models;
using IkitMita.Mvvm.ViewModels;

namespace BookStore.ViewModels
{
    [Export]
    public class MainViewModel : ChildViewModelBase
    {
        private Employee _currentEmployee;

        public Employee CurrentEmployee
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

        public async void InitializeAsync(User user)
        {
            using (StartOperation())
            {
                CurrentEmployee = await GetEmployeeOperation.ExecuteAsync(user.Id);
            }
        }
    }
}
