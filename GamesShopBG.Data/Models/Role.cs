namespace GamesShopBG.Data.Models
{
    using GamesShopBG.Data.Common.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Role : IdentityRole, IAuditInfo, IDeletableEntity
    {
        public Role()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
