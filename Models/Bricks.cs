namespace Legoland.Models
{
    public class Brick
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
    }


    public class KitBrick : Brick
    {
        public int KitBrickId { get; set; }
    }
}