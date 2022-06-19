using System.Collections.Generic;
using System.Linq;
using Recipe = System.Collections.Generic.Dictionary<MCItemChecker.Item, double>;

namespace MCItemChecker.Utils
{
    /// <summary>
    /// Recipes are represented as a <see cref="Dictionary{Item, double}"/>.
    /// </summary>
    internal static class RecipeExtensions
    {
        public static void SubtractItem(this Recipe recipe, KeyValuePair<Item, double> subtraction)
        {
            if (!recipe.TryGetValue(subtraction.Key, out double oldValue))
                return;

            var newValue = oldValue - subtraction.Value;
            if (newValue <= 0)
                recipe.Remove(subtraction.Key);
            else
                recipe[subtraction.Key] = newValue;
        }

        public static void SubtractRecipes(this Recipe recipe, Recipe subtraction)
        {
            foreach (var item in subtraction)
                recipe.SubtractItem(item);
        }

        public static void AddItem(this Recipe recipe, KeyValuePair<Item, double> addition)
        {
            if (recipe.TryGetValue(addition.Key, out double oldValue))
            {
                var newValue = oldValue + addition.Value;
                recipe[addition.Key] = newValue;
            }
            else
            {
                recipe.Add(addition.Key, addition.Value);
            }
        }

        public static void AddRecipes(this Recipe recipe, Recipe addition)
        {
            foreach (var item in addition)
                recipe.AddItem(item);
        }

        public static Recipe Copy(this Recipe recipe) 
            => recipe.ToDictionary(x => x.Key, x => x.Value);
    }
}
