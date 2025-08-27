using api_cinema_challenge.Models;

namespace api_cinema_challenge.Data
{
    public class Seeder
    {

        List<string> movies = new List<string>
            {
                "The Shawshank Redemption | 9.3 | 142 | Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                "The Godfather | 9.2 | 175 | The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                "The Dark Knight | 9.1 | 252 | When the menace known as the Joker wreaks havoc and chaos on Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
                "Pulp Fiction | 8.8 | 254 | The lives of two mob hitmen, a boxer, a gangster's wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                "Forrest Gump | 8.8 | 242 | The presidencies of Kennedy and Johnson, the Vietnam War, and other history unfold through the perspective of an Alabama man with an IQ of 75.",
                "Inception | 8.8 | 248 | A thief who steals corporate secrets through dream-sharing technology is given the inverse task of planting an idea into the mind of a CEO.",
                "Fight Club | 8.8 | 239 | An insomniac office worker and a devil-may-care soap maker form an underground fight club that evolves into something much more.",
                "The Matrix | 8.7 | 236 | A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
                "Interstellar | 8.7 | 269 | A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.",
                "Parasite | 8.5 | 232 | Greed and class discrimination threaten the newly formed symbiotic relationship between the wealthy Park family and the destitute Kim clan."
            };

        private List<string> _firstnames = new List<string>()
        {
            "Audrey",
            "Donald",
            "Elvis",
            "Barack",
            "Oprah",
            "Jimi",
            "Mick",
            "Kate",
            "Charles",
            "Kate",
            "Messi",
            "Lionel",
            "Taylor",
            "Bill",
            "Cristiano",
            "Serena",
            "Roger",
            "Rafael",
            "Leonardo",
            "Timian"
        };
        private List<string> _lastnames = new List<string>()
        {
            "Hepburn",
            "Trump",
            "Presley",
            "Obama",
            "Winfrey",
            "Hendrix",
            "Jagger",
            "Winslet",
            "Windsor",
            "Middleton",
            "Einstein",
            "Monroe",
            "DiCaprio",
            "Swift",
            "Jackson",
            "Williams",
            "Ronaldo",
            "Messi",
            "Jolie",
            "Freeman",
            "Depp",
            "Gates",
            "Federer",
            "Nadal",
            "Husveg",
            "Clinton"
        };
        private List<string> _domain = new List<string>()
        {
            "bbc.co.uk",
            "google.com",
            "theworld.ca",
            "something.com",
            "tesla.com",
            "nasa.org.us",
            "gov.us",
            "gov.gr",
            "gov.nl",
            "gov.ru",
            "amazon.com",
            "microsoft.com",
            "apple.com",
            "openai.com",
            "wikipedia.org",
            "who.int",
            "un.org",
            "reddit.com",
            "stackoverflow.com",
            "harvard.edu",
            "ox.ac.uk",
            "mit.edu",
            "tokyo.ac.jp",
            "sydney.edu.au",
            "vg.no",
            "nrk.no",
            "dagbladet.no",
            "aftenposten.no",
            "dn.no",
            "uit.no",        
            "uio.no",
            "ntnu.no",
            "nmbu.no", 
            "regjeringen.no",
        };

        private List<Movie> _movies = new List<Movie>();
        private List<Customer> _customers = new List<Customer>();
        private List<Screening> _screenings = new List<Screening>();
        private List<Ticket> _tickets = new List<Ticket>();
        
        private DateTime somedate = new DateTime(2020, 12, 05, 0, 0, 0, DateTimeKind.Utc);

        private int guiditerator = 1;
        public Guid GetNewGuid()
        {
            var r = new Random(guiditerator);
            var guid = new byte[16];
            r.NextBytes(guid);
            guiditerator++;

            return new Guid(guid);
        }

        public Seeder()
        {
            Random DayRandom = new Random(1);
            Random CustomerRandom = new Random(2);
            Random MovieRandom = new Random(3);
            Random TicketRandom = new Random(4);
            foreach (var movie in movies)
            {
                string title = movie.Split("|")[0].Trim();
                _movies.Add(new Movie {
                    Id = GetNewGuid(),
                    Title = title,
                    Rating = movie.Split("|")[1].Trim(),
                    Description = movie.Split("|")[3].Trim(),
                    RuntimeMins = int.Parse(movie.Split("|")[2].Trim()),
                    CreatedAt = somedate.AddDays(DayRandom.Next(0,10)),
                    UpdatedAt = DayRandom.Next(0, 5) == 4 ? null : somedate.AddDays(-DayRandom.Next(10, 1000))
                });
            }

            for (int x = 1; x < 250; x++)
            {
                string name = _firstnames[CustomerRandom.Next(_firstnames.Count)] + " " + _lastnames[CustomerRandom.Next(_lastnames.Count)];
                Customer customer = new Customer();
                customer.Id = GetNewGuid();
                customer.Name = name;
                customer.Email = $"{customer.Name.Split(" ")[0]}.{customer.Name.Split(" ")[1]}@{_domain[CustomerRandom.Next(_domain.Count)]}".ToLower();
                customer.Phone = $"+47{CustomerRandom.Next(10000000, 99999999)}";
                _customers.Add(customer);
            }

            foreach( var movie in _movies)
            {
                int ranLoop = DayRandom.Next(0, 10);
                for (int i = 0; i < ranLoop; i++)
                {
                    if (MovieRandom.Next(0, 5) == 5) continue;
                    Screening screening = new Screening();
                    screening.Id = GetNewGuid();
                    screening.ScreenNumber = MovieRandom.Next(1, 6);
                    screening.Capacity = MovieRandom.Next(20, 400);
                    screening.CreatedAt = somedate.AddDays(DayRandom.Next(0, 10));
                    screening.StartsAt = somedate.AddDays(DayRandom.Next(11, 25));
                    screening.UpdatedAt = somedate.AddDays(DayRandom.Next(11, 25));
                    _screenings.Add(screening);
                }
            }
            foreach (var screening in _screenings)
            {
                for (int i = 0; i < screening.Capacity; i += TicketRandom.Next(1, 10))
                {
                    Ticket ticket = new Ticket();
                    ticket.Id = GetNewGuid();
                    ticket.NumSeats = i;
                    ticket.ScreeningId = screening.Id;
                    ticket.CustomerId = _customers[TicketRandom.Next(_customers.Count())].Id;
                    ticket.CreatedAt = screening.CreatedAt.AddDays(DayRandom.Next(0,10));
                    ticket.UpdatedAt = DayRandom.Next(0, 5) == 4 ? null :ticket.CreatedAt.AddMinutes(DayRandom.Next(5, 900));
                    _tickets.Add(ticket);
                }
            }

        }
        public List<Customer> Customers { get { return _customers; } }
        public List<Movie> Movies { get { return _movies; } }
        public List<Screening> Screenings { get { return _screenings; } }
        public List<Ticket> Tickets { get { return _tickets; } }
    }
}
