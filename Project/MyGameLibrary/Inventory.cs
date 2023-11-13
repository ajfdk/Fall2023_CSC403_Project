using System.Collections.Generic;

namespace Fall2020_CSC403_Project.code {
    public class Inventory {
        private List<Item> items;

        public Inventory() {
            items = new List<Item>();
        }

        public List<Item> GetItems() {
            return this.items;
        }

        public void AddItem(Item item) {
            this.items.Add(item);
        }

        public void RemoveItem(Item item) {
            this.items.Remove(item);
        }
    }
}