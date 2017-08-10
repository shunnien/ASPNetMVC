﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityDbFirst.Models
{
    /// <summary>
    /// edmx IdentityUser 資料表類別對應 Identity 套件的使用者資料
    /// </summary>
    /// <seealso cref="int" />
    public partial class IdentityUser: IUser<int>
    {
        /// <summary>
        /// 非同步產生使用者驗證
        /// </summary>
        /// <param name="manager">Identity 的 UserManager</param>
        /// <returns>Task&lt;ClaimsIdentity&gt;.</returns>
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<IdentityUser, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    /// <summary>
    /// edmx IdentityRole 資料表類別對應 Identity 套件的角色資料
    /// </summary>
    /// <seealso cref="int" />
    public partial class IdentityRole : IRole<int>
    {
    }
}