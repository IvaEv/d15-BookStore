using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Security;
using BookStore.BusinessLogic;
using BookStore.DataAccess;
using BookStore.DataAccess.Models;
using IkitMita.Mvvm.ViewModels;

namespace BookStore.ViewModels
{
    [Export]
    public class CreateOrderViewModel: ChildViewModelBase
    {
        private GetEmployeeModel _currentEmployee;
        private DelegateCommand<string> _searchBooksCommand;
        private ICollection<GetClientModel> _clients;
        private ICollection<SearchBookModel> _foundBooks;
        private ObservableCollection<SaveOrderedBookModel> _orderedBooks;

        public CreateOrderViewModel()
        {
            Title = "Создание заказов";
        }

        public ICollection<GetClientModel> Clients
        {
            get { return _clients; }
            set
            {
                _clients = value; 
                OnPropertyChanged();
            }
        }

        public GetClientModel SelectedClient { get; set; }

        public ICollection<SearchBookModel> FoundBooks
        {
            get { return _foundBooks; }
            set
            {
                _foundBooks = value; 
                OnPropertyChanged();
            }
        }

        public ObservableCollection<SaveOrderedBookModel> OrderedBooks
        {
            get { return _orderedBooks; }
            set
            {
                _orderedBooks = value; 
                OnPropertyChanged();
            }
        }

        public async void InitializeAsync()
        {
            using (StartOperation())
            {
                Clients = await GetClientOperation.ExecuteAsync();
                _currentEmployee = await GetEmployeeOperation.ExecuteAsync(SecurityManager.GetCurrentUser().Id);
                OrderedBooks = new ObservableCollection<SaveOrderedBookModel>();
            }
        }

        public DelegateCommand<string> SearchBooksCommand
            => _searchBooksCommand ?? (_searchBooksCommand = new DelegateCommand<string>(SearchBooksAsync));

        private async void SearchBooksAsync(string searchString)
        {
            using (StartOperation())
            {
                FoundBooks = await SearchBoksOperation.ExecuteAsync(searchString,_currentEmployee.BranchId);
            }
        }

        [Import]
        private IGetClientOperation GetClientOperation { get; set; }
        [Import]
        private ISearchBooksOperation SearchBoksOperation { get; set; }
        [Import]
        private ISecurityManager SecurityManager { get; set; }
        [Import]
        private IGetEmployeeOperation GetEmployeeOperation { get; set; }

    }


}

