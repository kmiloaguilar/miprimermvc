namespace Domain.Entities
{
    public class Clasificado : IEntity
    {
        public Clasificado()
        {
            
        }
        public virtual long Id { get; set; }
        public virtual bool Archived { get; protected set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string ImageUrl1 { get; set; }

        public virtual string ImageUrl2 { get; set; }
        public virtual string ImageUrl3 { get; set; }
        public virtual string ImageUrl4 { get; set; }
        public virtual string ImageUrl5 { get; set; }
        public virtual string YouTubeUrl { get; set; }
        public virtual string Category { get; set; }
        public virtual void Archive()
        {
            Archived = true;
        }

        public virtual void Activate()
        {
            Archived = false;
        }
    }
}