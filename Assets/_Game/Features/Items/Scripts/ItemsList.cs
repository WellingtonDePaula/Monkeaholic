using Features.Items;
using System.Collections.Generic;
using UnityEngine;

namespace Features.Items {
    [CreateAssetMenu(fileName = "DefaultItemsList", menuName = "Monkeaholic/Items/Items List", order = 1)]
    public class ItemsList : ScriptableObject {
        public List<ItemData> items;
    }
}