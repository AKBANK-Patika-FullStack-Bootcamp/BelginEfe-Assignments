namespace ClientDataApi.Models
{
    // A client data class created to hold client data

    public class ClientData
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public int GenderId { get; set; }  // 1 : Female , 2 : Male , 3 : do not want to specify

        public DateTime Birthday { get; set; }

        public bool isActive { get; set; } = true;  // true : Client uses her/his account actively, false : Client doesn't use her/his account actively.


    }

}