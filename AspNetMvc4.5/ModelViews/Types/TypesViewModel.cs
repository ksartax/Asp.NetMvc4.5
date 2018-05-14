namespace AspNetMvc4._5.ModelViews
{
    public class TypesViewModel
    {
        public int ID { get; set; }
        public string Description { get; set; }

        public TypesViewModel() { }

        public TypesViewModel(Models.Type type)
        {
            ID = type.ID;
            Description = type.Description;
        }
    }
}