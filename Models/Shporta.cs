namespace Projekti.Models
{
    public class Shporta
    {
        private List<neShporte> items = new List<neShporte>();
        public IEnumerable<neShporte> Items => items;

        public void AddItem(Libra libra, int quantity)
        {
            var existingItem = items.FirstOrDefault(i => i.libra.Id == libra.Id);

            if (existingItem == null)
            {
                items.Add(new neShporte { libra = libra, NumriLibrave = quantity });
            }
            else
            {
                existingItem.NumriLibrave += quantity;
            }
        }

        public void RemoveItem(Libra libra)
        {
            items.RemoveAll(i => i.libra.Id == libra.Id);
        }

        public void Clear()
        {
            items.Clear();
        }

        public decimal ComputeTotalValue()
        {
            return items.Sum(e => e.libra.Cmimi * e.NumriLibrave);
        }
    }
}
