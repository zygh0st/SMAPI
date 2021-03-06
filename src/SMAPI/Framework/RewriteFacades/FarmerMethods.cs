using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace StardewModdingAPI.Framework.RewriteFacades
{
    public class FarmerMethods : Farmer
    {
        [SuppressMessage("ReSharper", "CS0109", Justification = "The 'new' modifier applies when compiled on Windows.")]
        public new bool couldInventoryAcceptThisItem(Item item)
        {
            return base.couldInventoryAcceptThisItem(item, true);
        }

        [SuppressMessage("ReSharper", "CS0109", Justification = "The 'new' modifier applies when compiled on Windows.")]
        public new bool addItemToInventoryBool(Item item)
        {
            return base.addItemToInventoryBool(item, false);
        }

        [SuppressMessage("ReSharper", "CS0109", Justification = "The 'new' modifier applies when compiled on Windows.")]
        public new int freeSpotsInInventory()
        {
            return base.freeSpotsInInventory(null);
        }
    }
}
