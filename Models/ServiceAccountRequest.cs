using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyMemberServices.Models
{
    public class ServiceAccountRequest
    {
        public int RequestID { get; set; }
        public string ServiceAccountName { get; set; }
        public string NonProdOrProdRequest { get; set; }
        public string RequestStatus { get; set; }
        public string ClientAppName { get; set; }
        public string ContactName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string ContactEmail { get; set; }
        public string ContactPhoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

    }
}
