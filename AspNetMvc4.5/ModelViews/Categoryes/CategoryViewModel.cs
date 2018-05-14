namespace AspNetMvc4._5.Models
{
    public class CategoryViewModel
    {
        public int ID { get; set; }

        public string Description { get; set; }

        public CategoryViewModel() { }

        public CategoryViewModel(Category category)
        {
            ID = category.ID;
            Description = category.Description;
        }
    }
}