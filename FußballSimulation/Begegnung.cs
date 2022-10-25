namespace FußballSimulation
{
    public class Begegnung
    {
        private Mannschaft mannschaft_1, mannschaft_2;
        private int mannschaft_1_tore, mannschaft_2_tore;
        private readonly int spielrounde;
        
        public Begegnung(Mannschaft mannschaft_1, Mannschaft mannschaft_2)
        {
            this.mannschaft_1 = mannschaft_1;
            this.mannschaft_2 = mannschaft_2;
            this.spielrounde = 18;
        }
      
        public void SimuliereSpiel()
        {
            for (int i = 0; i < 9; i++)
            {
                SimuliereSpielrund();
            }

            mannschaft_1.MacheHalbzeitPause();
            mannschaft_2.MacheHalbzeitPause();

            for (int i = 0; i < 9; i++)
            {
                SimuliereSpielrund();
            }
        }

        private void SimuliereSpielrund()
        {
            // Manschaft 1
            foreach (Spieler mannschaftOneSpieler in mannschaft_1.GetAufstellung())
            {
                if (mannschaftOneSpieler.BekommtTorGelegenheit(mannschaft_2.GetSpielstärke()))
                {
                    bool kannHalten = false;
                    foreach (Spieler spieler2 in mannschaft_2.GetAufstellung())
                    {
                        if (spieler2.KannBallHalten(mannschaft_2.GetSpielstärke()))
                        {
                            kannHalten = true;
                        }
                    }

                    if (!kannHalten)
                    {
                        mannschaft_1_tore++;
                        Console.WriteLine($"Manschaft {mannschaft_1} hat ein Tor geschossen. stunning!!") ;
                    }
                }

            }

            // Manschaft 2
            foreach (Spieler mannschaftTwoSpieler in mannschaft_2.GetAufstellung())
            {
                if (mannschaftTwoSpieler.BekommtTorGelegenheit(mannschaft_1.GetSpielstärke()))
                {
                    bool kannHalten = false;
                    foreach (Spieler spieler1 in mannschaft_1.GetAufstellung())
                    {
                        if (spieler1.KannBallHalten(mannschaft_1.GetSpielstärke()))
                        {
                            kannHalten = true;

                        }
                    }

                    if (!kannHalten)
                    {
                        mannschaft_2_tore++;
                        Console.WriteLine($"Manschaft {mannschaft_2} hat ein Tor geschossen. Spectacular!!");
                    }
                }

            }

        }

        override
        public string ToString()
        {
            return $"{mannschaft_1.Name()} {mannschaft_1_tore} VS {mannschaft_2_tore} {mannschaft_2.Name()}";

        }

    }
}
