namespace app_frontEnd.Models
{
    public class listTaskModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string _id { get; set; } = string.Empty; // El campo "_id" en JSON se mapea a "Id" en C#
        public int V { get; set; } // El campo "__v" en JSON se mapea a "V" en C#
    }
    
}
