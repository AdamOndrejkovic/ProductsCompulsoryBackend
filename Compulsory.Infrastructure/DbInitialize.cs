namespace Compulsory.Infrastructure
{
    public class DbInitialize
    {
        public static void InitData(CompulsoryContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}