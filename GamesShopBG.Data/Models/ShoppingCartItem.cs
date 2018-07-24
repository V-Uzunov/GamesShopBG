﻿namespace GamesShopBG.Data.Models
{
    using GamesShopBG.Data.Common.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ShoppingCartItem : IAuditInfo, IDeletableEntity
    {
        public ShoppingCartItem()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        [Key]
        public int Id { get; set; }

        public string CartId { get; set; }
        public int GameId { get; set; }
        public string Title { get; set; }
        public int Amount { get; set; }
        public virtual Game Game { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
