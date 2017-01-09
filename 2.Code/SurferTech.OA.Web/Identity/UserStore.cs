using Microsoft.AspNet.Identity;
using SurferTech.OA.ServiceClient.Clients;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurferTech.Utils.Common;

namespace SurferTech.OA.Web.Identity
{
    public class UserStore :
        IUserStore<IdentityUser, int>,
        IUserLockoutStore<IdentityUser, int>,
        IUserPasswordStore<IdentityUser, int>,
        IUserTwoFactorStore<IdentityUser,int>
    {
        #region IUserStore<IdentityUser,int> 成员

        public Task CreateAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityUser> FindByIdAsync(int userId)
        {
            var result = await new UsersServiceClient().GetUser(userId);
            return result.Code == 0 && result.ResultObject != null ? result.ResultObject.ConvertTo<IdentityUser>() : null;
        }

        public async Task<IdentityUser> FindByNameAsync(string userName)
        {
            var result = await new UsersServiceClient().GetUser(userName);
            return result.Code == 0 && result.ResultObject != null ? result.ResultObject.ConvertTo<IdentityUser>() : null;
        }

        public Task UpdateAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IDisposable 成员

        public void Dispose()
        {

        }

        #endregion

        #region IUserLockoutStore<IdentityUser,int> 成员

        public Task<int> GetAccessFailedCountAsync(IdentityUser user)
        {
            return Task.FromResult<int>(0);
        }

        public Task<bool> GetLockoutEnabledAsync(IdentityUser user)
        {
            return Task.FromResult<bool>(false);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEnabledAsync(IdentityUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(IdentityUser user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserPasswordStore<IdentityUser,int> 成员

        public Task<string> GetPasswordHashAsync(IdentityUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult<string>(new PasswordHasher().HashPassword(user.Password));
        }

        public Task<bool> HasPasswordAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(IdentityUser user, string passwordHash)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserTwoFactorStore<IdentityUser,int> 成员

        public Task<bool> GetTwoFactorEnabledAsync(IdentityUser user)
        {
            return Task.FromResult<bool>(false);
        }

        public Task SetTwoFactorEnabledAsync(IdentityUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
