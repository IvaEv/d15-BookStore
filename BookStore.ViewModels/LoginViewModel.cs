using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using BookStore.DataAccess;
using BookStore.Models;
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
            using (var db = new BookStoreContext())
            {
                User user = await db.Users
                    .Where(u => u.Login == Login)
                    .Where(u => u.Password == Password)
                    .FirstOrDefaultAsync();

                await Task.Delay(2000);

                if (user != null)
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
}
