namespace PetProjHeroesGame
{
    abstract class GameCharacter 
    {
        public abstract int Health { get; set; }
        public abstract int Damage { get; }

        public bool isDead = false;

        public void GetDamage(int damage) 
        {
            Health -= damage;
            if (Health <= 0) 
            {
                isDead = true;
            }
        }
    }
}
