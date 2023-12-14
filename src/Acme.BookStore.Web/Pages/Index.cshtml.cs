using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Acme.BookStore.Web.Pages;

public class IndexModel : BookStorePageModel
{
    readonly IHelloWorldService _helloWorldService;

    public IndexModel(IHelloWorldService helloWorldService)
    {
        _helloWorldService = helloWorldService;
    }

    public IList<Person> Persons { get; set; }

    public async void OnGet()
    {
        // POST https://localhost:44364/api/app/hello-world/hi?api-version=1.0
        var resp = await _helloWorldService.Hi(new RequestPage
        {
            PageNo = 1,
            PageSize = 10
        });
        Debug.Assert(resp.Collection is not null);
    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
