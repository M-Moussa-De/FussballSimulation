namespace FußballSimulation
{
    public class Mannschaft
    {
        private string name;
        private string land;
        Spieler[] aufstellung;

        public Mannschaft(string name, string land)
        {
            this.name = name;
            this.land = land;
            this.aufstellung = new Spieler[11];
        }

        public string Name() { return name; }
        public string Land() { return land; }
        public Spieler[] GetAufstellung() 
        {
            return this.aufstellung;
        }

        public bool HinzufügenSpieler(Spieler spieler)
        {
            if (HatAufstellungNochPlätze(aufstellung))
            {
                for (int i = 0; i < this.aufstellung.Length; i++)
                {
                    if (aufstellung[i] == null)
                    {
                        aufstellung[i] = spieler;
                        break;
                    }
                }

                return true;
            }

            return false;
        }
        private bool HatAufstellungNochPlätze(Spieler[] aufstellung)
        {
            foreach (Spieler spieler in aufstellung)
            {
                if (spieler == null)
                {
                    return true;
                }
            }

            return false;
        }

        public Spieler? EntfernenSpieler(string name)
        {
            return SpielerZumLöschen(aufstellung, name);
        }
        private Spieler? SpielerZumLöschen(Spieler[] aufstellung, string name)
        {
            Spieler? spielerZumLöschen = null;
            bool spielerVorhanden = false;
            int cnt = 0;

            for (int i = 0; i < aufstellung.Length; i++)
            {
                if(aufstellung[i] != null) { 
                    if (aufstellung[i].Name.ToLower() == name.ToLower())
                    {
                       spielerVorhanden = true;
                       spielerZumLöschen = aufstellung[i];
                       break;
                    }
                }

                cnt++;
            }

            if (!spielerVorhanden)
            {
                return null;
            }

            aufstellung[cnt] = null;

            return spielerZumLöschen;
        }

        public double GetSpielstärke()
        {
            if (HatAufstellungNochPlätze(aufstellung)) return 0;

            bool torVorhanden = false;

            foreach (Spieler sp in aufstellung)
            {
                if (sp.Spielposition == Spielposition.Tor)
                {
                    torVorhanden = true;
                    break;
                }
            }

            if (!torVorhanden) return 0;

            double stärke = 0;
            foreach (Spieler sp in aufstellung)
            {
                stärke += sp.GetDefensivstärke() + sp.GetOffensivstärke();
            }

            return stärke;
        }

        public void MacheSpielrunde()
        {
            foreach (Spieler spieler in aufstellung)
            {
                spieler.MacheSpielrunde();
            }
        }

        public void MacheHalbzeitPause()
        {
            foreach (Spieler spieler in aufstellung)
            {
                spieler.MacheHalbzeitPause();
            }
        }

        public void Ruhetag()
        {
            foreach (Spieler spieler in aufstellung)
            {
                spieler.Ruhetag();
            }
        }

        override
        public string ToString()
        {
            string output = $"---------------------------\nManschaftsname: {Name()},\nManschaftsland: {Land()},\n---------------------------\n\n";

            foreach (Spieler spieler in aufstellung)
            {
                if(spieler != null)
                {
                    output += spieler.ToString() + "\n";
                }
            }

            return output;
        }
    }
}
