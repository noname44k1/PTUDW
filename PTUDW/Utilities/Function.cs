namespace PTUDW.Utilities
{
    public class Function
    {
        public static string TitleSlugGeneration(string type, string title, int id)
        {
            string url = string.Empty;
            if(type == string.Empty)
                url = SlugGenerator.SlugGenerator.GenerateSlug(title) + "-" + id.ToString() + ".html";
            else
                url = type + "-" + SlugGenerator.SlugGenerator.GenerateSlug(title) + "-" + id.ToString() + ".html";
            return url;
        }
    }
}
