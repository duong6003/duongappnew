using DuongAppFirst.Data.Enums;
using DuongAppFirst.Data.Interfaces;
using DuongAppFirst.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DuongAppFirst.Data.Entities
{
    [Table("Products")]
    public class Product : DomainEntity<int>, ISwitchable, IDateTracking, IHasSeoMetadata, IStyle
    {
        public Product()
        {
            ProductTags = new List<ProductTag>();
        }
        public Product(string name, int categoryId, string thumbnailImage,
            decimal price, decimal originalPrice, decimal? promotionPrice,
            string description, string content, bool? homeFlag, bool? hotFlag, bool? prizeFlag,
            string tags, string unit, Status status, string seoPageTitle,
            string seoAlias, string seoMetaKeyword,
            string seoMetaDescription)
        {
            Name = name;
            CategoryId = categoryId;
            Image = thumbnailImage;
            Price = price;
            OriginalPrice = originalPrice;
            PromotionPrice = promotionPrice;
            Description = description;
            Content = content;
            HomeFlag = homeFlag;
            HotFlag = hotFlag;
            PrizeFlag = prizeFlag;
            Tags = tags;
            Unit = unit;
            Status = status;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeywords = seoMetaKeyword;
            SeoDescription = seoMetaDescription;
            ProductTags = new List<ProductTag>();
            Ratings = new List<Rating>();
        }

        public Product(int id, string name, int categoryId, string thumbnailImage,
             decimal price, decimal originalPrice, decimal? promotionPrice,
             string description, string content, bool? homeFlag, bool? hotFlag, bool? prizeFlag,
             string tags, string unit, Status status, string seoPageTitle,
             string seoAlias, string seoMetaKeyword,
             string seoMetaDescription)
        {
            Id = id;
            Name = name;
            CategoryId = categoryId;
            Image = thumbnailImage;
            Price = price;
            OriginalPrice = originalPrice;
            PromotionPrice = promotionPrice;
            Description = description;
            Content = content;
            HomeFlag = homeFlag;
            HotFlag = hotFlag;
            PrizeFlag = prizeFlag;
            Tags = tags;
            Unit = unit;
            Status = status;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeywords = seoMetaKeyword;
            SeoDescription = seoMetaDescription;
            ProductTags = new List<ProductTag>();
            Ratings = new List<Rating>();
        }
        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [Required]
        [DefaultValue(0)]
        public decimal Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        [Required]
        public decimal OriginalPrice { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
        public string Content { get; set; }


        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        public bool? PrizeFlag { get; set; }
        public int? ViewCount { get; set; }

        [StringLength(255)]
        public string Tags { get; set; }

        [StringLength(255)]
        public string Unit { get; set; }
        [ForeignKey("CategoryId")]
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<ProductTag> ProductTags { set; get; }


        public Status Status { get; set; }
        public string SeoPageTitle { get; set; }

        [Column(TypeName = "varchar(255)")]
        [StringLength(255)]
        public string SeoAlias { get; set; }

        [StringLength(255)]
        public string SeoKeywords { get; set; }

        [StringLength(255)]
        public string SeoDescription { get; set; }

        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public Style Style { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public int TotalRate { get; set; } = 0;
    }
}