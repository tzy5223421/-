using System.Runtime.Serialization;
namespace ConsoleApp2
{
    [DataContract]
    public class StudentScore
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Course { get; set; }
        [DataMember]
        public int Score { get; set; }
    }
}
