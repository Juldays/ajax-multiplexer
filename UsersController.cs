using Newtonsoft.Json.Linq;
using Models.Domain;
using Models.Requests;
using Models.Responses;
using Services;
using Services.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Web.Controllers
{
    public class UsersController : ApiController
    {
        readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [Route("api/users/multiplexed-avatar"), HttpPost]
        public HttpResponseMessage MultiplexedGet(MultiplexedAvatarGetRequest req)
        {
            var result = usersService.GetUserAvatarsByIds(req.Ids);

            var itemResponse = new ItemResponse<Dictionary<int, UserAvatarResponse>>();
            itemResponse.Item = result;

            return Request.CreateResponse(HttpStatusCode.OK, itemResponse);
        }
    }
}


           

            
        