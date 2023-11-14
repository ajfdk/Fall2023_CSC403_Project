using System.Drawing;

namespace Fall2020_CSC403_Project.code {
    public class Item {
        public string Name {  get; set; }
        public string Description { get; set; }
        public Image ItemImage { get; set; }

        public Item(string name, string description, Image itemImage) {
            Name = name;
            Description = description;
            ItemImage = new Bitmap(itemImage);
        }

        public override string ToString() {
            return Name;
        }
    }
}