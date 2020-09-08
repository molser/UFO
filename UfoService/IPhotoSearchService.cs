using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace UfoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.

    [ServiceContract(SessionMode = SessionMode.Required,
        CallbackContract = typeof(IPhotoSearchServiceCallback))]
    public interface IPhotoSearchService
    {
        [OperationContract(IsOneWay = true)]
        void SearchPersonByPhoto(SearchPersonByPhotoParams searchPersonByPhotoParams);

        [OperationContract(IsOneWay = true)]
        void CancelSearchPersonByPhoto();

        [OperationContract]
        [FaultContractAttribute(typeof(string))]
        PhotoSearchServiceResult GetFhotoFromKaskad(GetPhotoFromKaskadParams getPhotoFromDbParams);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }

    public interface IPhotoSearchServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void PhotoSearchServiceCallback(PhotoSearchServiceResult photoSearchServiceResult);
    }


    [DataContract]
    public class SearchPersonByPhotoParams
    {
        //[DataMember]
        //public Guid JobId;// { get; set; }
        [DataMember]
        public byte[] PhotoArray;// { get; set; }
        [DataMember]
        public string PhotoFileExtention;// { get; set; }
        [DataMember]
        public string Sex;// { get; set; }
        [DataMember]
        public string Years;// { get; set; }
        [DataMember]
        public string Natinality;// { get; set; }
        [DataMember]
        public string MashineName;// { get; set; }
        [DataMember]
        public bool IsSupressed;// { get; set; }
    }

    [DataContract]
    public enum PhotoSearchServiceResultType
    {
        [EnumMember]
        OK,
        [EnumMember]
        Error,
        [EnumMember]
        Cancel,
        [EnumMember]
        Confirmation
    }

    [DataContract]
    public class PhotoSearchServiceResult
    {
        [DataMember]
        public PhotoSearchServiceResultType Type;
        [DataMember]
        public object Data;
    }

    

    [DataContract]
    public class GetPhotoFromKaskadParams
    {
        [DataMember]
        public string Family;
        [DataMember]
        public string Name;
        [DataMember]
        public DateTime Birthday;
        [DataMember]
        public DateTime OperationDateStart;
        [DataMember]
        public DateTime OperationDateEnd;
        [DataMember]
        public string MashineName;
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}

}
