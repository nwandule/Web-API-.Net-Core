namespace Demo_App.Model.Domain
{
    public class Cart
    {
        public  Guid Id { get; set; }
        public  int quatity { get; set; }
        public  double total { get; set; }
        public Guid ProductId { get; set; }
        public Product product { get; set; }
    }
}
