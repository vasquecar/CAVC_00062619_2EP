namespace SourceCode1
{
    public class ADDRESS
    {
        public int idAddress { get; set; }
        public int idUser { get; set; }
        public string address { get; set; }

        public ADDRESS()
        {
            idAddress = 0;
            idUser = 0;
            address = "";
        }
    }
}