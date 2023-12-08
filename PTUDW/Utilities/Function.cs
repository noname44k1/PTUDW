namespace PTUDW.Utilities
{
    public class Function
    {
        public static int _AccountId = 0;
        public static string _Username = string.Empty;
        public static string _Email = string.Empty;
        public static string _Message = string.Empty;
        public static string _MessageEmail = string.Empty;

        public static string TitleSlugGenerationAlias(string title)
        {
            return SlugGenerator.SlugGenerator.GenerateSlug(title);
        }
        public static string TitleSlugGeneration(string type, string title, int id)
        {
            string url = string.Empty;
            if(type == string.Empty)
                url = "/" + SlugGenerator.SlugGenerator.GenerateSlug(title) + "-" + id.ToString() + ".html";
            else
                url = "/" + type + "/" + SlugGenerator.SlugGenerator.GenerateSlug(title) + "-" + id.ToString() + ".html";
            return url;
        }

        public static string ToVnd(double donGia)
        {
            return donGia.ToString("#,##0") + " đ";
        }

        public static string ToTitleCase(string str)
        {
            string result = str;
            if (!string.IsNullOrEmpty(str))
            {
                var words = str.Split(' ');
                for (int index = 0; index < words.Length; index++)
                {
                    var s = words[index];
                    if (s.Length > 0)
                    {
                        words[index] = s[0].ToString().ToUpper() + s.Substring(1);
                    }
                }
                result = string.Join(" ", words);
            }
            return result;
        }

        public static bool IsLogin()
        {
            if(string.IsNullOrEmpty(Function._Username) || Function._AccountId <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
