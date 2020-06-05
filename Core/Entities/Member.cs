using System;
namespace Core.Entities
{
    public class Member
    {  
        public int Id { get; set; }
        public string Name { get; set; }    
        public int TeamLeadId { get; set; } 
        public string TeamLeadName { get; set; }
        public DateTime Doj { get; set; }
        public string  Address { get; set; }
    }
}