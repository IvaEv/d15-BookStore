using System.ComponentModel.Composition;
using System.Windows.Input;
using BookStore.DataAccess;
using BookStore.DataAccess.Models;
using IkitMita;
using IkitMita.Mvvm.ViewModels;
using Microsoft.Practices.ServiceLocation;

namespace BookStore.ViewModels
{
    [Export]
    public class LoginViewModel : ChildViewModelBase
    {
        private ICommand _makeLoginCommand;
        private string _login;
        private string _password;
        private string _message;

        public LoginViewModel()
        {
            Title = "Авторизация";
        }

        [Import]
        private IGetUserOperation GetUserOperation { get; set; }

        [Import]
        private IServiceLocator ServiceLocator { get; set; }

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        [DependsOn(nameof(IsFree))]
        [DependsOn(nameof(Login))]
        [DependsOn(nameof(Password))]
        public ICommand MakeLoginCommand
        {
            get
            {
                return _makeLoginCommand ??
                       (_makeLoginCommand = new DelegateCommand(MakeLoginAsync,
                       () => !Login.IsNullOrEmpty() && !Password.IsNullOrEmpty() && IsFree));
            }
        }

        private async void MakeLoginAsync()
        {
            using (StartOperation())
            {
                GetUserModel user = await GetUserOperation.ExecuteAsync(Login, Password);

                if (user != null)
                {
                    var mainViewModel = ServiceLocator.GetInstance<MainViewModel>();
                    mainViewModel.InitializeAsync(user);
                    mainViewModel.Show();
                    await Close();
                }
                else
                {
                    Message = "Логин или пароль введены неправильно";
                }
            }
        }
    }
}
