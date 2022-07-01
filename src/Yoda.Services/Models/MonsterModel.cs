namespace Yoda.Services.Models
{
    public class MonsterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public string Sprite { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public float RespawnTime { get; set; }
    }
}
