using System.ServiceModel;
namespace ObjectWCF
{
    [ServiceContract]
    interface IService:IAuto,IClient,IComanda,IDetaliuComanda,IImagine,IMaterial,IMecanic,IOperatie,ISasiu
    {
    }
}
