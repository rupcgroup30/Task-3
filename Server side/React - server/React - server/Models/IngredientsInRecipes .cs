namespace React___server.Models
{
    public class IngredientsInRecipes
    {

        private int recipeId;
        private int ingredientId;

        public int RecipeId { get => recipeId; set => recipeId = value; }
        public int IngredientId { get => ingredientId; set => ingredientId = value; }

        private static List<IngredientsInRecipes> IngredientsInRecipesList = new List<IngredientsInRecipes>();

        public static List<IngredientsInRecipes> Read(int recipeId)
        {
            List<IngredientsInRecipes> recipeIngredientsList = new List<IngredientsInRecipes>();
            foreach (var item in IngredientsInRecipesList)
            {
                if(item.RecipeId == recipeId)
                {
                    recipeIngredientsList.Add(item);
                }
            }
            return recipeIngredientsList;
        }

        public void Insert()
        {
            IngredientsInRecipesList.Add(this);
        }

    }
}
