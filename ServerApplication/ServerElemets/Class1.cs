using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerElemets
{
    public enum TypeOfRequest
    {
        Unknown=0,
        CreateNewUser = 1,
        MakeRoom = 2,
        GetRoomCollection = 3,
        GetUserByID = 4,

    }
    public interface IViewer
    {

        TypeOfRequest TypeOfRequest { get; set; }
      int RequestNumber { get; set; }
        string Body { get; }
    }

    public class Room :ViewerData, IViewer
    {
        public Room(string roomName)
        {
            Player1 = new ConnectedUser();
            Player2 = new ConnectedUser();
            Watchers = new List<ConnectedUser>();
            TypeOfRequest = TypeOfRequest.MakeRoom;
            this.RoomName = roomName;
            this.RequestNumber = (int)TypeOfRequest;
        }
        public Room()
        {
            TypeOfRequest = TypeOfRequest.MakeRoom;
            this.RequestNumber = (int)TypeOfRequest.MakeRoom;
        }
         [JsonProperty("RoomName")]
        public string RoomName { get; set; }

         [JsonProperty("ID")]
         public Guid ID { get; set; }
        [JsonProperty("Player1")]
        public ConnectedUser Player1 { get; set; }
         [JsonProperty("Player2")]
        public ConnectedUser Player2 { get; set; }
          [JsonProperty("Watchers")]
        public List<ConnectedUser> Watchers { get; set; }




          [JsonIgnore]
        public string Body
        {
            get { return JsonConvert.SerializeObject(this); }
        }
    }
    public class RoomCollection : ViewerData , IViewer 
    {
        public RoomCollection()
        {
            Rooms = new List<Room>();
            this.TypeOfRequest = ServerElemets.TypeOfRequest.GetRoomCollection;
           
        }
         [JsonProperty("Rooms")]
        public List<Room> Rooms { get; set; }


          [JsonIgnore]
        public string Body
        {
            get { return JsonConvert.SerializeObject(this.Rooms); }
        }
    }
    public class ConnectedUser :ViewerData, IViewer
    {
        public ConnectedUser(Guid ID)
        {
            this.ID = ID;

        }
        public ConnectedUser()
        {

        }

      [JsonProperty("RequestNumber")]
        public int RequestNumber { get; set; }
      [JsonProperty("ID")]
        public Guid ID { get; set; }
         [JsonProperty("Name")]
        public string Name { get; set; }
         [JsonProperty("IPAddress")]
        public string IPAddress { get; set; }
         [JsonProperty("Port")]
        public string Port { get; set; }
        [JsonProperty("TypeOfRequest")]
        public TypeOfRequest TypeOfRequest { get; set; }
        [JsonIgnore]
        public string Body
        {
            get
            {
                return JsonConvert.SerializeObject(this);
            }
        }
    }
    public class ViewerData:IViewer
    {
        [JsonProperty("RequestNumber")]
        public int RequestNumber { get; set; }
        [JsonProperty("TypeOfRequest")]
        public TypeOfRequest TypeOfRequest { get; set; }
        [JsonProperty("Body")]
        public string Body { get; set; }



       
    }
    

}
