namespace React___server.Models
{
    public class Ingredient
    {
        private int id;
        private string name;
        private string image;
        private int calories;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Image { get => image; set => image = value; }
        public int Calories { get => calories; set => calories = value; }

        private static List<Ingredient> IngredientsList = new List<Ingredient>();
       

        public static List<Ingredient> Read()
        {
            DBservices dbs = new DBservices();
            return dbs.ReadIngredients();
        }

        public static List<Ingredient> ReadRecipeIngredients(int recipeId)
        {
            DBservices dbs = new DBservices();
            return dbs.ReadIngredientsInRecipes(recipeId);
        }

        public int InsertIngredientByRecipe(int recipeId, int ingredientId)
        {
            DBservices dbs = new DBservices();
            return dbs.InsertIngredientByRecipe(recipeId, ingredientId);
        }
        public int Insert()
        {
            DBservices dbs = new DBservices();
            return dbs.InsertIngredient(this);
        }
    }
}
