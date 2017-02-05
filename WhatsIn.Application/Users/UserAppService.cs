using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;

using WhatsIn.Authorization;
using WhatsIn.Users.Dto;
using WhatsIn.Authorization.Roles;
using System;

namespace WhatsIn.Users
{
    /* THIS IS JUST A SAMPLE. */
    [AbpAuthorize(PermissionNames.Pages_Users)]
    public class UserAppService : WhatsInAppServiceBase, IUserAppService
    {
        private readonly IRepository<User, long> _userRepository;
        private readonly IPermissionManager _permissionManager;
        private readonly RoleManager _roleManager;

        public UserAppService(IRepository<User, long> userRepository, IPermissionManager permissionManager, RoleManager roleManager)
        {
            _userRepository = userRepository;
            _permissionManager = permissionManager;
            _roleManager = roleManager;
        }

        public async Task ProhibitPermission(ProhibitPermissionInput input)
        {
            var user = await UserManager.GetUserByIdAsync(input.UserId);
            var permission = _permissionManager.GetPermission(input.PermissionName);

            await UserManager.ProhibitPermissionAsync(user, permission);
        }

        //Example for primitive method parameters.
        public async Task RemoveFromRole(long userId, string roleName)
        {
            CheckErrors(await UserManager.RemoveFromRoleAsync(userId, roleName));
        }

        public async Task<ListResultDto<UserListDto>> GetUsers()
        {
            var users = await _userRepository.GetAllListAsync();

            return new ListResultDto<UserListDto>(
                users.MapTo<List<UserListDto>>()
                );
        }

        public async Task<UserInputDto> GetUser(long id)
        {
            var user = await Task.Run(() => { return _userRepository.GetAll().AsNoTracking().FirstOrDefaultAsync(u => u.Id == id); });
            var dto = user.MapTo<UserInputDto>();
            dto.IsEditMode = true;

            //var roles = UserManager.
            //     CheckErrors(await UserManager.RemoveFromRoleAsync(userId, roleName));
            //_roleManager.


            //dto.Roles 
            return dto;
        }

        public async Task UpsertUser(UserInputDto input)
        {
            try { 
            var user = input.MapTo<User>();
            if (input.Id == 0)
            {
                user.TenantId = AbpSession.TenantId;
                user.Password = new PasswordHasher().HashPassword(input.Password);
                user.IsEmailConfirmed = true;

                CheckErrors(await UserManager.CreateAsync(user));
            }
            else
                CheckErrors(await UserManager.UpdateAsync(user));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}