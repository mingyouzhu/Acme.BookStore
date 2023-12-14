using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Acme.BookStore;

public interface IHelloWorldService : IApplicationService
{
    Task<ResponsePage<Person>> Hi(RequestPage param);
}
