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

        public string GetName() { return this.name; }
        public string GetLand() { return this.land; }
        public Spieler[] GetAufstellung() 
        {
            return this.aufstellung;
        }

        public bool HinzufügenSpieler(Spieler spieler)
        {
            if (HatAufstellungNochPlätze(this.aufstellung))
            {
                for (int i = 0; i < this.aufstellung.Length; i++)
                {
                    if (this.aufstellung[i] == null)
                    {
                        this.aufstellung[i] = spieler;
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
                if(aufstellung[i] != null)
                { 
                    if (aufstellung[i].GetName().ToLower() == name.ToLower())
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
                if (sp.GetSpielposition() == Spielposition.Tor)
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
            for (int i = 0; i < aufstellung.Length; i++)
            {
                aufstellung[i].MacheSpielrunde();
            }
        }

        public void MacheHalbzeitPause()
        {
            for (int i = 0; i < aufstellung.Length; i++)
            {
                aufstellung[i].MacheHalbzeitPause();
            }
        }

        public void Ruhetag()
        {
            for(int i =0; i < aufstellung.Length; i++)
            {
                aufstellung[i].Ruhetag();
            }
        }

        override
        public string ToString()
        {
            string output = $"\nManschaftsname: {GetName()},\nManschaftsland: {GetLand()}\n\n";

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
