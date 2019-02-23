using DAL.Enums;

namespace SwaggerConferenceTask.Models
{
    public class PizzaVM
    {
        public int Id { get; set; }

        public Pizza Code { get; set; }

        public string Name { get; set; }
    }
}
