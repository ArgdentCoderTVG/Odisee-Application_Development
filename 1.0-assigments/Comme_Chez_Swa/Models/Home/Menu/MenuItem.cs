namespace Comme_Chez_Swa.Models.Home.Menu
{
    public class MenuItem
    {
        // Entity properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsMarketPrice { get; set; }
        public decimal Price { get; set; }
        public decimal? PromotionalPrice { get; set; }
        public string MenuItemPhotoSource { get; set; }

        // Availability
        public bool? IsAvailable { get; set; }
        public bool? IsSeasonal { get; set; }
        public string? Season { get; set; }  // Candidate for enum

        // Cuisine Type
        public string? CuisineType { get; set; }  // Candidate for enum
        public bool? IsChefSpecial { get; set; }

        // Lifestyles
        public bool IsCaffeinated { get; set; }
        public bool IsAlcoholic { get; set; }
        public bool? IsPescitarian { get; set; }
        public bool? IsVegetarian { get; set; }
        public bool? IsVegan { get; set; }
        public bool? IsLocallySourced { get; set; }

        // Allergens
        public bool? TracesOfGluten { get; set; }
        public bool? TracesOfSeafood { get; set; }
        public bool? TracesOfNuts { get; set; }
        public bool? TracesOfLactose { get; set; }
        public bool? TracesOfSoy { get; set; }

        // Taste & Texture
        public bool? IsSpicy { get; set; }
        public bool? HasFishBones { get; set; }

        // Serving Information
        public string? ServingSize { get; set; }  // Candidate for enum
        public bool? LongerThanUsualCookingTime { get; set; }
    }
}
