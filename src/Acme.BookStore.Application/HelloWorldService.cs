using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acme.BookStore;
public class HelloWorldService : BookStoreAppService, IHelloWorldService
{
    public async Task<ResponsePage<Person>> Hi(RequestPage param)
    {
        var p = new List<Person>()
        {
            new Person
            {
                Id = 1,
                Name = "Test",
            }
        };
        return await Task.FromResult(new ResponsePage<Person>(p));
    }
}
