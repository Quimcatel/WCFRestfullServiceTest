using System.Runtime.Serialization;

namespace Services
{
    [DataContract(Namespace = "")]
    public class InvoiceDto
    {
        //DESPUES DEL EJEMPLO YA NO SE USA
        //public InvoiceDto(int id, string receiver)
        //{
        //    Id = id;
        //    Receiver = receiver;
        //}

        //[DataMember]
        //public int Id { get; set; }
        //[DataMember]
        //public string Receiver { get; set; }
    }
}
