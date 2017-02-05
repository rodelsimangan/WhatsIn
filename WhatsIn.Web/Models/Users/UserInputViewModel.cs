using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsIn.Users.Dto;

namespace WhatsIn.Web.Models
{
    [AutoMap(typeof(UserInputDto))]
    public class UserInputViewModel : UserInputDto
    {
        public UserInputViewModel(UserInputDto output)
        {
            output.MapTo(this);
        }
    }
}