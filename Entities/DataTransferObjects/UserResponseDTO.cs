using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class UserResponseDTO
    {
        public string UserMail { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
