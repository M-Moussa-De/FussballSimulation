namespace FußballSimulation
{
    public class Begegnung
    {
        private Mannschaft mannschaft_1, mannschaft_2;
        private int mannschaft_1_tore, mannschaft_2_tore;
        
        public Begegnung(Mannschaft mannschaft_1, Mannschaft mannschaft_2)
        {
            this.mannschaft_1 = mannschaft_1;
            this.mannschaft_2 = mannschaft_2;
        }
      
        public void SimuliereSpiel()
        {
            for (int i = 0; i < 9; i++)
            {
                this.SimuliereSpielrund();
            }

            this.mannschaft_1.MacheHalbzeitPause();
            this.mannschaft_2.MacheHalbzeitPause();

            Console.WriteLine("================== Pause ==================");

            for (int i = 0; i < 9; i++)
            {
                this.SimuliereSpielrund();
            }
        }

        private void SimuliereSpielrund()
        {
            // Manschaft 1
            for(int i = 0; i < this.mannschaft_1.GetAufstellung().Length; i++)
            {
                if (this.mannschaft_1.GetAufstellung()[i].BekommtTorGelegenheit(this.mannschaft_2.GetSpielstärke()))
                {
                    bool kannHalten = false;
                    for (int j = 0; j < this.mannschaft_2.GetAufstellung().Length; j++)
                    {
                        if (this.mannschaft_2.GetAufstellung()[j].KannBallHalten(this.mannschaft_1.GetSpielstärke()))
                        {
                            kannHalten = true;
                        }

                        if (!kannHalten)
                        {
                            this.mannschaft_1_tore++;
                            Console.WriteLine($"{this.GetManschaftOneName()} hat ein Tor geschossen. stunning!!");
                        }
                    }
                }
            }

            // Manschaft 2
            for (int i = 0; i < this.mannschaft_2.GetAufstellung().Length; i++)
            {
                if (this.mannschaft_2.GetAufstellung()[i].BekommtTorGelegenheit(this.mannschaft_1.GetSpielstärke()))
                {
                    bool kannHalten = false;
                    for (int j = 0; j < this.mannschaft_1.GetAufstellung().Length; j++)
                    {
                        if (this.mannschaft_1.GetAufstellung()[j].KannBallHalten(this.mannschaft_2.GetSpielstärke()))
                        {
                            kannHalten = true;
                        }

                        if (!kannHalten)
                        {
                            this.mannschaft_2_tore++;
                            Console.WriteLine($"{this.GetManschaftTwoName()} hat ein Tor geschossen. stunning!!");
                        }
                    }

                }
            }
        }

        public string GetManschaftOneName()
        {
            return this.mannschaft_1.GetName();
        }

        public string GetManschaftTwoName()
        {
            return this.mannschaft_2.GetName();
        }

        override
         public string ToString()
        {
            return $"=============== Final Ergebnis ===============\n {this.mannschaft_1.GetName()} {this.mannschaft_1_tore} VS {this.mannschaft_2_tore} {this.mannschaft_2.GetName()}";
        }

    }
}
