using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalAccount.Models
{
    public class OneTimeToken
    {
        public string Id { get; set; }

        public string ClientId { get; set; }

        public string UserId { get; set; }

        public string Data { get; set; }
    }
}
