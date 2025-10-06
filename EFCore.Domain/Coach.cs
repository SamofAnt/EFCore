namespace EFCore.Domain;

 
    public class Coach : BaseDomainModel
    {
        public string Name { get; set; }
        public int? TeamId { get; set; }
    }

