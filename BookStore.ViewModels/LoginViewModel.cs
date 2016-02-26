using System.ComponentModel.Composition;
using System.Windows.Input;
using IkitMita;
using IkitMita.Mvvm.ViewModels;

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

        [DependsOn(nameof(Login))]
        [DependsOn(nameof(Password))]
        public ICommand MakeLoginCommand
        {
            get
            {
                return _makeLoginCommand ??
                       (_makeLoginCommand = new DelegateCommand(MakeLogin, 
                       () => !Login.IsNullOrEmpty() && !Password.IsNullOrEmpty()));
            }
        }

        private void MakeLogin()
        {
            if (Login == Password)
            {
                Message = "Авторизация успешна";
            }
            else
            {
                Message = "Логин или пароль введены неправильно";
            }
        }
    }
}
