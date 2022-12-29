using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Ekleme işlemi başarılı.";
        public static string Deleted = "Silme işlemi başarılı.";
        public static string Updated = "Güncelleme işlemi başarılı.";

        public static string InvalidAdd = "Ekleme işlemi başarısız.";
        public static string InvalidUpdate = "Güncelleme işlemi başarısız.";
        public static string InvalidDelete = "Silme işlemi başarısız.";

        public static string NameInvalid = "Geçersiz isim.";
        public static string IdInvalid = "Geçersiz ID.";

        public static string MaintananceTime = "Sistem bakımda.";
        public static string Listed = "Listelendi.";
    }
}
