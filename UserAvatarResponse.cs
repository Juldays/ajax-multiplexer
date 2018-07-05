using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Domain
{
    public class UserAvatarResponse
    {
        public int Id { get; set; }
        public string AvatarUrl { get; set; }
        public int UserTypeId { get; set; }
        public string FullName { get; set; }
    }
}
