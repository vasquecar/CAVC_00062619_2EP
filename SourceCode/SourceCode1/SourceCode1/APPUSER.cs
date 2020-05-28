namespace SourceCode1
{
    public class APPUSER
    {
        public int idUser { get; set; }
        public string fullname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool userType { get; set; }

        public APPUSER()
        {
            idUser = 0;
            fullname = "";
            username = "";
            password = "";
            userType = false;
        }
    }
}