namespace FußballSimulation
{
    public enum Spielposition
    {
        Sturm,
        Mittelfeld,
        Verteidigung,
        Tor
    }

    public class Spieler
    {
        public static Random zufallszahlengenerator = new Random();
        private string name;
        private string geburtsdatum;
        private int offensivtechnik = zufallszahlengenerator.Next(0, 1000);
        private int defensivtechnik = zufallszahlengenerator.Next(0, 1000);
        private double tagesform = zufallszahlengenerator.NextDouble();
        private Spielposition spielposition;

        public Spieler() { }
        public Spieler(Random zufallsgenerator, string name, string geburtsdatum)
        {
            zufallszahlengenerator = zufallsgenerator;
            this.name = name;
            this.geburtsdatum = geburtsdatum;
        }
        public Spieler(Random zufallsgenerator, string name, string geburtsdatum, Spielposition spielposition)
        {
            zufallszahlengenerator = zufallsgenerator;
            this.name = name;
            this.geburtsdatum = geburtsdatum;
            this.spielposition = spielposition;

        }
        public string Name { get { return name; } set { name = value; } }
        public string Geburtsdatum { get { return geburtsdatum; } set { geburtsdatum = value; } }
        public int Offensivtechnik { get { return offensivtechnik; } set { offensivtechnik = value; } }
        public int Defensivtechnik { get { return defensivtechnik; } set { defensivtechnik = value; } }
        public double Tagesform { get { return tagesform; } set { tagesform = value; } }
        public Spielposition Spielposition { get { return spielposition; } set { spielposition = value; } }

        public double GetOffensivstärke()
        {
            double offensivstärke = 0;

            switch (this.spielposition)
            {
                case Spielposition.Sturm:
                    offensivstärke = 3 * this.tagesform * this.offensivtechnik;
                    break;
                case Spielposition.Mittelfeld:
                    offensivstärke = 2 * this.tagesform * this.offensivtechnik;
                    break;
                case Spielposition.Verteidigung:
                    offensivstärke = this.tagesform * this.offensivtechnik;
                    break;
            }

            return offensivstärke;
        }
        public double GetDefensivstärke()
        {
            double defensivstärke = 0;

            switch (this.spielposition)
            {
                case Spielposition.Sturm:
                    defensivstärke = this.tagesform * this.defensivtechnik;
                    break;
                case Spielposition.Mittelfeld:
                    defensivstärke = 2 * this.tagesform * this.defensivtechnik;
                    break;
                case Spielposition.Verteidigung:
                    defensivstärke = 3 * this.tagesform * this.offensivtechnik;
                    break;
                case Spielposition.Tor:
                    defensivstärke = 10 * this.tagesform * (this.offensivtechnik + (3 * this.defensivtechnik));
                    break;
            }

            return defensivstärke;
        }

        public bool BekommtTorGelegenheit(double gegnerMannschaftDefensivstärke)
        {
            double chance = this.offensivtechnik / gegnerMannschaftDefensivstärke;
            double zufallswert = zufallszahlengenerator.NextDouble();

            return zufallswert < chance;  // returns true if cond. is true, and false otherwise
        }
        public bool KannBallHalten(double gegnerMannschaftOffensivstärke)
        {
            if (this.spielposition != Spielposition.Tor) return false; // nur Torhüter kann halten

            double chance = this.defensivtechnik / gegnerMannschaftOffensivstärke;

            double zufallswert = zufallszahlengenerator.NextDouble();

            return zufallswert < chance;
        }

        public void MacheSpielrunde()
        {
            switch (spielposition)
            {
                case Spielposition.Sturm:
                case Spielposition.Mittelfeld:
                    this.tagesform -=  0.4;
                    break;
                case Spielposition.Verteidigung:
                case Spielposition.Tor:
                    this.tagesform -=  0.3;
                    break;
            }
            if(this.tagesform <0)
            {
                this.tagesform = 0;
            }
        }
        public void MacheHalbzeitPause()
        {
            if (this.tagesform + 0.25 <= 1)
            {
                this.tagesform += 0.25;
            }
            else
            {
                this.tagesform = 1;
            }
        }
        public void Ruhetag()
        {
            this.tagesform = 1;
        }

        private int CalcAlter()
        {
            int age = DateTime.Today.Year - DateTime.Parse(geburtsdatum).Year;
            return age;
        }

        override
        public string ToString()
        {
            return $"Spielername: {Name},\nSpieleralter: {CalcAlter()},\nSpielerstärke: {(GetOffensivstärke() + GetDefensivstärke())},\nSpielerposition: {Spielposition}\n";
        }
    }

}
