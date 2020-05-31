using System;
namespace Core.Entities
{
    public class Point:BaseEntity
    {
        public int point { get; set; }
        public DateTime Dop { get; set; }
        public int MemberId { get; set; }    
        public int TeamLeadId { get; set; }    
        
    }
}