using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Aspert.ViewModels
{
    public class BookPageViewModel : ViewModel
    {
        public IReadOnlyCollection<Book> Books { get; }
        public IReadOnlyCollection<Movie> Movies { get; }
        public IReadOnlyCollection<Movie> Series { get; }

        public BookPageViewModel()
        {
            Books = new ObservableCollection<Book>
            {
                new Book
                {
                    Title = "El síndrome de Asperger: Intervenciones psicoeducativas (Carmen Cobo, Eva Morán)",
                    Link = "https://drive.google.com/file/d/1UHBSdFV-t9lOTTsaP0VDhBoeH6chSSh4/view?usp=sharing"
                },
                new Book
                {
                    Title = "Síndrome de Asperguer: Guía para padres y educadores (Gena P. Barnhill)",
                    Link = "https://drive.google.com/file/d/1pvmIO5ayBeU_9CY2WHkt79KYqeAx5PL2/view?usp=sharing"
                },
                new Book
                {
                    Title = "Ecucando niños con Síndrome de Asperger: 200 consejos y estrategias (Brenda Boyd)",
                    Link = "https://drive.google.com/file/d/1R3abeUs3rAMdafZiiITmPbqJT7CgBLvC/view?usp=sharing"
                },
                new Book
                {
                    Title = "Personas con Síndrome de Asperger: funcionamiento, detección y necesidades (María Sotillo, Juana Hernández, Mercedes Belinchón)",
                    Link = "https://drive.google.com/file/d/13ljOfnTSedyO_bkgoGPdzGCg8ZV734uT/view?usp=sharing"
                },
                new Book
                {
                    Title = "El Síndrome de Asperguer: Estrategias para prácticas para el aula (George Thomas)",
                    Link = "https://drive.google.com/file/d/1i34MWaC2UMLf69zfHF0vE8jUkSxFoS3a/view?usp=sharing"
                },
                new Book
                {
                    Title = "Descubrir el Asperguer (Ramón Cererols)",
                    Link = "https://drive.google.com/file/d/1X4_3HTYk0USkOeaQ2a6mGqG3HvHDJykU/view?usp=sharing"
                }
            };
            Movies = new ObservableCollection<Movie>
            {
                new Movie
                {
                    Title="Mi nombre es Khan (Karan Johar, 2010)",
                    Image="Khan_movie.jpg",
                    Description="Es una película india de 2010 dirigida y escrita por Karan Johar, protagonizada por Shahrukh Khan y Kajol. Narra la historia de un hombre musulmán con Síndrome de Asperger con su esposa después de los atentados del 11 de septiembre de 2001",
                    Link="https://www.sensacine.com/peliculas/pelicula-175624"
                },
                new Movie
                {
                    Title="Me llaman Radio(Michael Tollin, 2003)",
                    Image="Radio_movie.jpg",
                    Description="La película está basada en la historia real sobre el entrenador de fútbol americano Harold Jones (Ed Harris), del Instituto T.L. Hanna High School, y un joven con discapacidad intelectual, James Robert 'Radio' Kennedy (Cuba Gooding, Jr.).  &#10; &#10;Radi",
                    Link="https://www.sensacine.com/peliculas/pelicula-45300"
                },
                new Movie
                {
                    Title="Ben X (Nic Balthazar, 2007)",
                    Image="Benx_movie.jpg",
                    Description="Un adolescente autista penetra más profundamente en el mundo de los juegos en línea después de ser humillado por sus crueles compañeros.",
                    Link="https://www.sensacine.com/peliculas/pelicula-132087"
                },
                new Movie
                {
                    Title="Mozart y la ballena (Petter Næss, 2005)",
                    Image="Mozart_movie.jpg",
                    Description="Una historia de amor entre dos sabios con síndrome de Asperger, una especie de autismo, cuyas condiciones sabotean su incipiente relación.",
                    Link="https://www.imdb.com/title/tt0392465/?ref_=fn_al_tt_"
                },
                new Movie
                {
                    Title="El contador (Gavin O'Connor, 2016)",
                    Image="Contador_movie.jpg",
                    Description="Christian Wolff (Ben Affleck) es un contador que tiene Autismo de Alto Funcionamiento, gracias a eso se desenvuelve mejor en matemáticas que con las personas. Tiene una oficina contable en una pequeña ciudad como tapadera, pues se gana la vida como contable para organizaciones criminales.",
                    Link="https://www.sensacine.com/peliculas/pelicula-232013"
                },
                new Movie
                {
                    Title="Mary and Max (Adam Elliot, 2009)",
                    Image="Mary_movie.jpg",
                    Description="Una historia de amistad entre dos insólitos amigos por correspondencia: Mary, una niña solitaria de ocho años que vive en los suburbios de Melbourne, y Max, un hombre de cuarenta y cuatro años muy obeso que padece síndrome de Asperguer y que vive en Nueva York.",
                    Link="https://www.sensacine.com/peliculas/pelicula-139621"
                },
                new Movie
                {
                    Title="Tan fuerte y tan cerca (Adam Elliot, 2009)",
                    Image="Extremely_movie.jpg",
                    Description="Un inventor aficionado, francéfilo y pacifista de nueve años que padece Asperger busca en la ciudad de Nueva York la cerradura que coincide con una llave misteriosa que dejó su padre, quien murió en el World Trade Center el 11 de septiembre de 2001.",
                    Link="https://www.sensacine.com/peliculas/pelicula-179838"
                },
                new Movie
                {
                    Title="Misión: máxima seguridad (Harold Becker, 1998)",
                    Image="Mercury_movie.jpg",
                    Description="Art Jeffries es un agente del FBI bastante insolente con sus superiores, razón por la cual le asignan las escuchas telefónicas. Por fin, un día, le encargan la investigación del caso de un niño desaparecido, cuyos padres han sido asesinados. Cuando lo encuentra, resulta ser un autista de nueve años que tiene una prodigiosa capacidad para interpretar códigos del gobierno teóricamente indescifrables.",
                    Link="https://www.imdb.com/title/tt0120749/?ref_=nv_sr_srsg_"
                }
            };
            Series = new ObservableCollection<Movie>
            {
                new Movie
                {
                    Title="Atypical (Robia Rashid, Netflix 2017)",
                    Image="Atypical_movie.jpg",
                    Description="Sam, un joven de 18 años en el espectro autista, decide que es hora de encontrar una novia, un viaje que coloca a la madre de Sam en su propio camino que le cambiará la vida mientras su hijo busca más independencia.",
                    Link="https://www.sensacine.com/series/serie-21143"
                },
                new Movie
                {
                    Title="The Good Doctor (David Shore, PrimeVideo 2017)",
                    Image="Doctor_movie.jpg",
                    Description="Shaun Murphy, un joven cirujano con autismo y síndrome de Savant, es reclutado en la unidad quirúrgica de un prestigioso hospital.",
                    Link="https://www.sensacine.com/series/serie-18045"
                }
            };
        }
    }
}
