# MCItemChecker

(Partial) rewrite of an old project that can be used to iteratively calculate the required items to make some item. The context of these items is completely up to the user, meaning that an item can be a "multi-block", fluids, timings, power etc. The application can also be used for other resource/crafting based games, such as Factorio for example.


# Usage
Items and relevant information can be added/edited under the "Item Database" menu option.

Relevant keyboard actions are:
- E to edit items
- Del to delete items
- Return for various confirmation actions.


**Avoid recipes that both requires, and outputs the same item**. This can lead to detrimental performance when used often.

# Examples

![Creating Recipes](https://i.imgur.com/IYIHnF5.png)

An Iron Ingot requires an Iron Ore to smelt as well as some coal. A coal can smelt 8 items, so we add 1/8, meaning that 1 (coal) will produce 8 (iron ingot).


After closing the Item Database screen, the main screen will be updated with the new information.

- The **Item Info** tab will list all the direct information of an item. Double-clicking an entry will display the chosen entry's information.
- The **Calculate** tab will list all items required to make the selected item.
- The option **Base Items** under the Calculate tab will result in only the very last items of the crafting chain being listed. All immediate items (such as "Iron Ingot" in the example) will be omited.

![Viewing Recipes](https://i.imgur.com/V6PLGRw.png)

Above is an example of all the materials required to craft an "Iron Pickaxe".

![Viewing Recipes](https://i.imgur.com/FFIh5Pd.png)

Example of when the option "Base Items" is checked for the same recipe as the previous image.

# New Features
## 1.7
- Added option to mark calculated items using **return** or **double click**
