﻿using DuongAppFirst.Application.ViewModels.Common;
using DuongAppFirst.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DuongAppFirst.Application.ViewModels.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }

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

        public int MyProperty { get; set; }
        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        public bool? PrizeFlag { get; set; }
        public int? ViewCount { get; set; }

        [StringLength(255)]
        public string Tags { get; set; }

        [StringLength(255)]
        public string Unit { get; set; }

        public ProductCategoryViewModel ProductCategory { get; set; }

        public Status Status { get; set; }
        public string SeoPageTitle { get; set; }

        [StringLength(255)]
        public string SeoAlias { get; set; }

        [StringLength(255)]
        public string SeoKeywords { get; set; }

        [StringLength(255)]
        public string SeoDescription { get; set; }

        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public Style Style { get; set; }
        public int TotalRate { get; set; } = 0;
    }
}
