using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCItemChecker
{
    public static class RecipeCalculator
    {
        private static void CalculateItemRecipe(Item item, double amount, bool isBaseItem, Dictionary<Item, double> craftingRecipe, int recursionCount)
        {
            if (++recursionCount >= Settings.MaxRecursionCount)
                return;

            foreach (var pair in item.Recipe)
            {
                if (isBaseItem)
                {
                    if (pair.Key.Recipe.Count <= 0)
                    {
                        AddToRecipe(pair);
                        continue;
                    }
                }
                else
                {
                    AddToRecipe(pair);

                    if (pair.Key.Recipe.Count <= 0)
                        continue;
                }

                double tempAmount = amount * pair.Value;
                CalculateItemRecipe(pair.Key, tempAmount, isBaseItem, craftingRecipe, recursionCount);
            }

            void AddToRecipe(KeyValuePair<Item, double> recipeItem)
            {
                if (craftingRecipe.ContainsKey(recipeItem.Key))
                    craftingRecipe[recipeItem.Key] += recipeItem.Value * amount;
                else
                    craftingRecipe.Add(recipeItem.Key, recipeItem.Value * amount);
            }
        }

        /// <summary>
        /// Collects all the required items and their amounts to craft the requested item.
        /// </summary>
        /// <param name="item">The item to find the required items for.</param>
        /// <param name="amount">The start amount</param>
        /// <param name="returnbase">TRUE if only the last items in the chain should be collected.</param>
        public static Dictionary<Item, double> CalculateRecipe(Item item, double amount = 1, bool returnbase = false)
        {
            var recipe = new Dictionary<Item, double>();

            CalculateItemRecipe(item, amount, returnbase, recipe, 0);

            return recipe;
        }
    }
}
