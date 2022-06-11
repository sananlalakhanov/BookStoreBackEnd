using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Security
{
    public class LoginResultModel
    {
        public int UserId { get; set; }
        public string AuthToken { get; set; }
    }
}
