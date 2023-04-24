namespace mis_221_pa_5_jirafay
{
    public class Trainer {
        public int ID{ get; set;}
        public string Name {get; set;}
        public string MailingAddress {get; set;}
        public string EmailAddress {get; set;}

        public Trainer(int id, string name, string mailingAddress, string emailAddress){
            ID = id;
            Name = name;
            MailingAddress = mailingAddress;
            EmailAddress = emailAddress;
        }
    }
}