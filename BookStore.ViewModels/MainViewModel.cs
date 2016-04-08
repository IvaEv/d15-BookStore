using System.Collections.Generic;
using System.ComponentModel.Composition;
using BookStore.BusinessLogic;
using BookStore.DataAccess;
using BookStore.DataAccess.Models;
using IkitMita;
using IkitMita.Mvvm.ViewModels;

namespace BookStore.ViewModels
{
    [Export]
    public class MainViewModel : ChildViewModelBase
    {
        private GetEmployeeModel _currentEmployee;
        private ICollection<SearchBookModel> _foundBooks;
        private string _searchString;
        private DelegateCommand _searchBooksCommand;

        public GetEmployeeModel CurrentEmployee
        {
            get { return _currentEmployee; }
            set
            {
                _currentEmployee = value;
                OnPropertyChanged();
            }
        }

        public ICollection<SearchBookModel> FoundBooks
        {
            get { return _foundBooks; }
            set
            {
                _foundBooks = value;
                OnPropertyChanged();
            }
        }

        public string SearchString
        {
            get { return _searchString; }
            set
            {
                _searchString = value; 
                OnPropertyChanged();
            }
        }

        public DelegateCommand SearchBooksCommand 
            => _searchBooksCommand 
                 ?? (_searchBooksCommand = new DelegateCommand(SearchBooksAsync));

        private async void SearchBooksAsync()
        {
            using (StartOperation())
            {
                if (SearchString.IsNullOrWhiteSpace())
                {
                    FoundBooks = new List<SearchBookModel>();
                }
                else
                {
                    FoundBooks = await SearchBooksOperation.ExecuteAsync(SearchString, CurrentEmployee.BranchId);
                }
            }
        }

        [Import]
        private IGetEmployeeOperation GetEmployeeOperation { get; set; }

        [Import]
        private ISearchBooksOperation SearchBooksOperation { get; set; }

        [Import]
        private ISecurityManager SecurityManager { get; set; }

        public async void InitializeAsync()
        {
            using (StartOperation())
            {
                CurrentEmployee = await GetEmployeeOperation.ExecuteAsync(SecurityManager.GetCurrentUser().Id);
            }
        }
    }
}
