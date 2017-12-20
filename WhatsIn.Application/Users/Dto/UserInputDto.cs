using System.ComponentModel.DataAnnotations;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.AutoMapper;

namespace WhatsIn.Users.Dto
{
    [AutoMap(typeof(User))]
    public class UserInputDto
    {
        public long Id { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxUserNameLength)]
        public string UserName { get; set; }

        [Required]
        [StringLength(User.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(User.MaxSurnameLength)]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        //[Required]
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public bool IsEditMode { get; set; }

        public UserRole[] Roles { get; set; }
    }
}