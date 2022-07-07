namespace Yoda.Services.MiniGame.Models
{
    public class MonsterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sprite { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Health { get; set; }
        public int RespawnTime { get; set; }
    }
}
