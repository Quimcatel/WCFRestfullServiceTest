using System.ServiceModel;
using System.ServiceModel.Web;

namespace Services
{
    [ServiceContract]
    public interface IInvoiceService
    {
        [WebGet(UriTemplate = "/invoices")]
        [OperationContract]
        string GetCounterValue();
        //InvoiceDto[] GetAllInvoices();
    }
}
