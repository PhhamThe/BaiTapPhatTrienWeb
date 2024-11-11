namespace Harmic.Utilities
{
    public class Function
    {
        public static string TitleSlugGenerationAlias(string Title)
        {
            return SlugGenerator.SlugGenerator.GenerateSlug(Title);
        }
    }
}
