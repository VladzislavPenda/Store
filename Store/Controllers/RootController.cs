using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Store.Controllers
{
    public class RootController : ControllerBase
    {
        private readonly LinkGenerator _linkGenerator;
        public RootController(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }
    }
}
