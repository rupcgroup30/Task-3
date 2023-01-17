namespace React___server.Models
{
    public class Recipes
    {

        private int id;
        private string name;
        private string image;
        private string cookingMethod;
        private int time;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Image { get => image; set => image = value; }
        public string CookingMethod { get => cookingMethod; set => cookingMethod = value; }
        public int Time { get => time; set => time = value; }

        private static List<Recipes> RecipesList = new List<Recipes>();
      


        public static List<Recipes> Read()
        {
            DBservices dbs = new DBservices();
            return dbs.ReadRecipes();
        }

     
        public int Insert()
        {
            DBservices dbs = new DBservices();
            return dbs.InsertRecipe(this);
        }
    }
}
