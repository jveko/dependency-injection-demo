namespace WebApplicationTest.Services
{
    public interface IPeopleService
    {
        public string AddPrefix(string name);
    }
    public class PeopleService : IPeopleService
    {
        public string AddPrefix(string name)
        {
            if(name == "Bane") {                 
                return "Mr. " + name;
            }
            else if(name == "Joker")
            {
                return "Mr. " + name;
            }
            else if(name == "Harley")
            {
                return "Ms. " + name;
            }
            else if(name == "Ivy")
            {
                return "Ms. " + name;
            }
            else
            {
                return "Unknown";
            }
        }
    }
}
