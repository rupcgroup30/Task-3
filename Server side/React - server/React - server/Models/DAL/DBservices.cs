using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using React___server.Models;
using System.Data.SqlClient;

public class DBservices
{
    public SqlDataAdapter da;
    public DataTable dt;

    public DBservices()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //--------------------------------------------------------------------------------------------------
    // This method creates a connection to the database according to the connectionString name in the web.config 
    //--------------------------------------------------------------------------------------------------
    public SqlConnection connect(String conString)
    {

        // read the connection string from the configuration file
        IConfigurationRoot configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        string cStr = configuration.GetConnectionString("myProjDB");
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }


   

    //--------------------------------------------------------------------------------------------------
    // This method inserts a recipe to the recipe table 
    //--------------------------------------------------------------------------------------------------
    public int InsertRecipe(Recipes recipe)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }


        cmd = CreateInsertRecipeCommandWithStoredProcedure("spInsertRecipe", con, recipe);             // create the command

        try
        {
            int id = Convert.ToInt32(cmd.ExecuteScalar()); // execute the command
            return id;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    //--------------------------------------------------------------------------------------------------
    // This method reads all the recipes
    //--------------------------------------------------------------------------------------------------
    public List<Recipes> ReadRecipes()
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        //String cStr = BuildUpdateCommand(recipe);      // helper method to build the insert string

        cmd = CreateCommandWithStoredProcedureRead("spGetRecipes", con);             // create the command


        List<Recipes> list = new List<Recipes>();

        try
        {


            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {

                Recipes recipe = new Recipes();
                recipe.Id = Convert.ToInt32(dataReader["Id"]);
                recipe.Name = dataReader["Name"].ToString();
                recipe.Image = dataReader["Image"].ToString();
                recipe.CookingMethod = dataReader["cookingMethod"].ToString();
                recipe.Time = Convert.ToInt32(dataReader["Time"]);

                list.Add(recipe);
            }

            return list;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }


    //--------------------------------------------------------------------------------------------------
    // This method inserts a ingredient to the ingredient table 
    //--------------------------------------------------------------------------------------------------
    public int InsertIngredient(Ingredient ingredient)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }


        cmd = CreateInsertIngredientCommandWithStoredProcedure("spInsertIngredient", con, ingredient);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //--------------------------------------------------------------------------------------------------
    // This method reads all the ingredients
    //--------------------------------------------------------------------------------------------------

    public List<Ingredient> ReadIngredients()
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        //String cStr = BuildUpdateCommand(recipe);      // helper method to build the insert string

        cmd = CreateCommandWithStoredProcedureRead("spGetIngredients", con);             // create the command


        List<Ingredient> list = new List<Ingredient>();

        try
        {


            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {

                Ingredient ingredient = new Ingredient();
                ingredient.Id = Convert.ToInt32(dataReader["Id"]);
                ingredient.Name = dataReader["Name"].ToString();
                ingredient.Image = dataReader["Image"].ToString();
                ingredient.Calories = Convert.ToInt32(dataReader["Calories"]);

                list.Add(ingredient);
            }

            return list;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }


    private SqlCommand CreateCommandWithStoredProcedureRead(string spName, SqlConnection con)
    {
        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be stored procedure

        return cmd;
    }

    //--------------------------------------------------------------------------------------------------
    // This method reads all the ingredients in a recipe
    //--------------------------------------------------------------------------------------------------

    public List<Ingredient> ReadIngredientsInRecipes(int recipeId)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        //String cStr = BuildUpdateCommand(recipe);      // helper method to build the insert string

        cmd = CreateReadIngredientsInRecipeCommandWithStoredProcedure("spGetIngredientsByRecipe", con, recipeId);             // create the command


        List<Ingredient> list = new List<Ingredient>();

        try
        {


            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {

                Ingredient ingredient = new Ingredient();
                ingredient.Id = Convert.ToInt32(dataReader["Id"]);
                ingredient.Name = dataReader["Name"].ToString();
                ingredient.Image = dataReader["Image"].ToString();
                ingredient.Calories = Convert.ToInt32(dataReader["Calories"]);

                list.Add(ingredient);
            }

            return list;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }



    public int InsertIngredientByRecipe(int recipeId, int ingredientId)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }


        cmd = CreateInsertIngredientInRecipeCommandWithStoredProcedure("spInsertIngredientsByRecipe", con, recipeId, ingredientId);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }


    //---------------------------------------------------------------------------------
    // Create the insert SqlCommand using a stored procedure
    //---------------------------------------------------------------------------------
    private SqlCommand CreateInsertRecipeCommandWithStoredProcedure(String spName, SqlConnection con, Recipes recipe)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be stored procedure

        cmd.Parameters.AddWithValue("@Name", recipe.Name);

        cmd.Parameters.AddWithValue("@Image", recipe.Image);

        cmd.Parameters.AddWithValue("@cookingMethod", recipe.CookingMethod);

        cmd.Parameters.AddWithValue("@Time", recipe.Time);

        return cmd;
    }

    private SqlCommand CreateInsertIngredientCommandWithStoredProcedure(String spName, SqlConnection con, Ingredient ingredient)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be stored procedure

        cmd.Parameters.AddWithValue("@Name", ingredient.Name);

        cmd.Parameters.AddWithValue("@Image", ingredient.Image);

        cmd.Parameters.AddWithValue("@Calories", ingredient.Calories);

        return cmd;
    }

    private SqlCommand CreateReadIngredientsInRecipeCommandWithStoredProcedure(string spName, SqlConnection con, int id)
    {
        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be stored procedure
       
        cmd.Parameters.AddWithValue("@recipeId", id);

        return cmd;
    }

    private SqlCommand CreateInsertIngredientInRecipeCommandWithStoredProcedure(String spName, SqlConnection con, int recipeId, int ingredientId)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be stored procedure

        cmd.Parameters.AddWithValue("@recipeId", recipeId);

        cmd.Parameters.AddWithValue("@ingredientId", ingredientId);

        return cmd;
    }



}
