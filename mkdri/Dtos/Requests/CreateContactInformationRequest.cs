using MKDRI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MKDRI.Dtos.Requests
{
    public class CreateContactInformationRequest
    {
        public string Type { get; set; }
        public string Content { get; set; }

        public string Validate()
        {
            ContactInformationType type;
            if (!Enum.TryParse(Type, out type))
            {
                return "Type not valid";
            }
            switch (type)
            {
                case ContactInformationType.Email:
                    if (!Regex.Match(Content, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$").Success)
                    {
                        return "Email not valid";
                    }
                    break;
            }
            return "";
        }
    }
}
