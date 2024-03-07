using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLib.DTOs
{
    public class UserDataDTO
    {
        public UserDataDTO(int userId, string userName, string token)
        {
            UserId = userId;
            UserName = userName;
            Token = token;
        }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Token { get; set; }
    }
}
