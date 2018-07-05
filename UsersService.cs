using Data.Providers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Models.Domain;
using Models.Requests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Data;

namespace Services
{
    public class UsersService : IUsersService
    {
        private IAuthenticationService authenticationService;
        private IDataProvider dataProvider;

        public UsersService(IAuthenticationService authService, IDataProvider dataProvider)
        {
            authenticationService = authService;
            this.dataProvider = dataProvider;
        }

        public Dictionary<int, UserAvatarResponse> GetUserAvatarsByIds(int[] ids)
        {
            Dictionary<int, UserAvatarResponse> result = new Dictionary<int, UserAvatarResponse>();

            dataProvider.ExecuteCmd(
                "UserAvatar_GetByIds",
                inputParamMapper: p =>
                {
                    p.AddWithValue("@Ids", JsonConvert.SerializeObject(ids));
                },
                singleRecordMapper: (reader, resultSetIndex) =>
                {
                    UserAvatarResponse avatar = new UserAvatarResponse();
                    avatar.Id = (int)reader["Id"];
                    avatar.AvatarUrl = reader["AvatarUrl"] as string ?? default(string);
                    avatar.UserTypeId = (int)reader["UserTypeId"];
                    avatar.FullName = (string)reader["FullName"];
                    result.Add(avatar.Id, avatar);
                });

            return result;
        }
    }
}


