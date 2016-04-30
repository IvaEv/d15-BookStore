using System.ComponentModel.Composition;
using System.Threading.Tasks;
using BookStore.DataAccess.Models;

namespace BookStore.DataAccess.WebApi.Operations
{
    [Export(typeof(IGetUserOperation))]
    class GetUserOperation : IGetUserOperation
    {
        public Task<GetUserModel> ExecuteAsync(string login)
        {
            return Task.FromResult(new GetUserModel
            {
                Id = 1,
                Login = "zaverden",
                Password = "1000:jKrU+pi6S6K6wSwqk9U/IMq+Zqj8Wpoa:T/XjYI5VKPqnKCYRuXHLrKb5/5ZJ3fj5"
            });
        }
    }
}
