namespace CarShop.Models.Entityes
{
    public enum Category
    {
        Electo,
        Disel,
        Fuel
    }

    public static class CategoryExtions
    {
        public static string ToDisplayName(this Category category) => category switch
        {
            Category.Electo => "Electro",
            Category.Disel => "Disel",
            Category.Fuel => "Fuel",
            _ => throw new NotImplementedException()
        };
    }
}
