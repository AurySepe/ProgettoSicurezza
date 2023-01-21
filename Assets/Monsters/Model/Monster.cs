using UnityEngine;

public class Monster
{
    public Sprite Img { get; set; }
    public int Id { get; set; }
    
    public string Nome { get; set; }


    public Monster(Sprite img, int id,string nome)
    {
        Nome = nome;
        Img = img;
        Id = id;
    }
}