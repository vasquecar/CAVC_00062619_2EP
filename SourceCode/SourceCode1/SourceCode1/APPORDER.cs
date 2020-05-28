using System;

namespace SourceCode1
{
    public class APPORDER
    {
        public int idOrder { get; set; }
        public DateTime createDate { get; set; }
        public int idProduct { get; set; }
        public int idAddress { get; set; }

        public APPORDER()
        {
            idOrder = 0;
            createDate = DateTime.Now;
            idProduct = 0;
            idAddress = 0;
        }
    }
}