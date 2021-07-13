namespace ExecutablesLibrary
{
    public class ShortFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"Имя: {Name}, ИД: {Id}";          
        }
        public override bool Equals(object other)
        {
            if (Name == ((ShortFile)other).Name && Id == ((ShortFile)other).Id)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            int hashFileName = Name == null ? 0 : Name.GetHashCode();
            int hashFileId = Id.GetHashCode();

            return hashFileName ^ hashFileId;
        }
        ~ShortFile()
        {
            //Console.WriteLine("File was deleted.");
        }
    }
}