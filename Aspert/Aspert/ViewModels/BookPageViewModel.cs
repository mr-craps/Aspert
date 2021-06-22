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
                    Title="Mi nombre es Khan (Karan Johar, 2010",
                    Image="Khan_movie.jpg",
                    Description="Es una pel�cula india de 2010 dirigida y escrita por Karan Johar, protagonizada por Shahrukh Khan y Kajol. Narra la historia de un hombre musulm�n con S�ndrome de Asperger con su esposa despu�s de los atentados del 11 de septiembre de 2001",
                    Link="https://www.sensacine.com/peliculas/pelicula-175624"
                },
                new Movie
                {
                    Title="Me llaman Radio(Michael Tollin, 2003",
                    Image="Radio_movie.jpg",
                    Description="La pel�cula est� basada en la historia real sobre el entrenador de f�tbol americano Harold Jones (Ed Harris), del Instituto T.L. Hanna High School, y un joven con discapacidad intelectual, James Robert 'Radio' Kennedy (Cuba Gooding, Jr.).  &#10; &#10;Radi",
                    Link="https://www.sensacine.com/peliculas/pelicula-45300"
                },
                new Movie
                {
                    Title="Ben X (Nic Balthazar, 2007",
                    Image="Benx_movie.jpg",
                    Description="Un adolescente autista penetra m�s profundamente en el mundo de los juegos en l�nea despu�s de ser humillado por sus crueles compa�eros.",
                    Link="https://www.sensacine.com/peliculas/pelicula-132087"
                },
                new Movie
                {
                    Title="Mozart y la ballena (Petter N�ss, 2005",
                    Image="Mozart_movie.jpg",
                    Description="Una historia de amor entre dos sabios con s�ndrome de Asperger, una especie de autismo, cuyas condiciones sabotean su incipiente relaci�n.",
                    Link="https://www.imdb.com/title/tt0392465/?ref_=fn_al_tt_"
                },
                new Movie
                {
                    Title="El contador (Gavin O'Connor, 2016",
                    Image="Contador_movie.jpg",
                    Description="Christian Wolff (Ben Affleck) es un contador que tiene Autismo de Alto Funcionamiento, gracias a eso se desenvuelve mejor en matem�ticas que con las personas. Tiene una oficina contable en una peque�a ciudad como tapadera, pues se gana la vida como contable para organizaciones criminales.",
                    Link="https://www.sensacine.com/peliculas/pelicula-232013"
                },
                new Movie
                {
                    Title="Mary and Max (Adam Elliot, 2009",
                    Image="Mary_movie.jpg",
                    Description="Una historia de amistad entre dos ins�litos amigos por correspondencia: Mary, una ni�a solitaria de ocho a�os que vive en los suburbios de Melbourne, y Max, un hombre de cuarenta y cuatro a�os muy obeso que padece s�ndrome de Asperguer y que vive en Nueva York.",
                    Link="https://www.sensacine.com/peliculas/pelicula-139621"
                },
                new Movie
                {
                    Title="Tan fuerte y tan cerca (Adam Elliot, 2009",
                    Image="Extremely_movie.jpg",
                    Description="Un inventor aficionado, franc�filo y pacifista de nueve a�os que padece Asperger busca en la ciudad de Nueva York la cerradura que coincide con una llave misteriosa que dej� su padre, quien muri� en el World Trade Center el 11 de septiembre de 2001.",
                    Link="https://www.sensacine.com/peliculas/pelicula-179838"
                },
                new Movie
                {
                    Title="Misi�n: m�xima seguridad (Harold Becker, 1998",
                    Image="Mercury_movie.jpg",
                    Description="Art Jeffries es un agente del FBI bastante insolente con sus superiores, raz�n por la cual le asignan las escuchas telef�nicas. Por fin, un d�a, le encargan la investigaci�n del caso de un ni�o desaparecido, cuyos padres han sido asesinados. Cuando lo encuentra, resulta ser un autista de nueve a�os que tiene una prodigiosa capacidad para interpretar c�digos del gobierno te�ricamente indescifrables.",
                    Link="https://www.imdb.com/title/tt0120749/?ref_=nv_sr_srsg_"
                }
            };
            Series = new ObservableCollection<Movie>
            {
                new Movie
                {
                    Title="Atypical (Robia Rashid, Netflix 2017",
                    Image="Atypical_movie.jpg",
                    Description="Sam, un joven de 18 a�os en el espectro autista, decide que es hora de encontrar una novia, un viaje que coloca a la madre de Sam en su propio camino que le cambiar� la vida mientras su hijo busca m�s independencia.",
                    Link="https://www.sensacine.com/series/serie-21143"
                },
                new Movie
                {
                    Title="The Good Doctor (David Shore, PrimeVideo 2017",
                    Image="Doctor_movie.jpg",
                    Description="Shaun Murphy, un joven cirujano con autismo y s�ndrome de Savant, es reclutado en la unidad quir�rgica de un prestigioso hospital.",
                    Link="https://www.sensacine.com/series/serie-18045"
                }
            };
        }
    }
}
