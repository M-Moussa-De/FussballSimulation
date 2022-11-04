using FußballSimulation;


// -----------------------------------------------------------------------------------------
//                                 Manschaft One
// -----------------------------------------------------------------------------------------

Mannschaft ahly = new Mannschaft("Ahly", "Ägypten");

Spieler a = new Spieler(new Random(), "A", "1-4-1989", Spielposition.Sturm);
Spieler b = new Spieler(new Random(), "B", "14-8-1995", Spielposition.Sturm);
Spieler c = new Spieler(new Random(), "C", "10-11-1997", Spielposition.Sturm);
Spieler d = new Spieler(new Random(), "D", "21-7-1991", Spielposition.Mittelfeld);
Spieler e = new Spieler(new Random(), "E", "1-6-1996", Spielposition.Mittelfeld);
Spieler f = new Spieler(new Random(), "F", "31-8-2004", Spielposition.Mittelfeld);
Spieler g = new Spieler(new Random(), "G", "2-8-2003", Spielposition.Mittelfeld);
Spieler h = new Spieler(new Random(), "H", "15-4-1999", Spielposition.Verteidigung);
Spieler i = new Spieler(new Random(), "I", "18-3-2000", Spielposition.Verteidigung);
Spieler j = new Spieler(new Random(), "J", "9-8-1998", Spielposition.Verteidigung);
Spieler k = new Spieler(new Random(), "K", "5-2-1993", Spielposition.Tor);

ahly.HinzufügenSpieler(a);
ahly.HinzufügenSpieler(b);
ahly.HinzufügenSpieler(c);
ahly.HinzufügenSpieler(d);
ahly.HinzufügenSpieler(e);
ahly.HinzufügenSpieler(f);
ahly.HinzufügenSpieler(g);
ahly.HinzufügenSpieler(h);
ahly.HinzufügenSpieler(i);
ahly.HinzufügenSpieler(j);
ahly.HinzufügenSpieler(k);


// -----------------------------------------------------------------------------------------
//                                 Manschaft Two
// -----------------------------------------------------------------------------------------
Mannschaft bayern = new Mannschaft("Bayern", "Deutschland");

Spieler l = new Spieler(new Random(), "L", "1-4-1989", Spielposition.Sturm);
Spieler m = new Spieler(new Random(), "M", "14-8-1995", Spielposition.Sturm);
Spieler n = new Spieler(new Random(), "N", "10-11-1997", Spielposition.Sturm);
Spieler o = new Spieler(new Random(), "O", "21-7-1991", Spielposition.Mittelfeld);
Spieler p = new Spieler(new Random(), "P", "1-6-1996", Spielposition.Mittelfeld);
Spieler q = new Spieler(new Random(), "Q", "31-8-2004", Spielposition.Mittelfeld);
Spieler r = new Spieler(new Random(), "R", "2-8-2003", Spielposition.Mittelfeld);
Spieler s = new Spieler(new Random(), "S", "15-4-1999", Spielposition.Verteidigung);
Spieler t = new Spieler(new Random(), "T", "18-3-2000", Spielposition.Verteidigung);
Spieler u = new Spieler(new Random(), "U", "9-8-1998", Spielposition.Verteidigung);
Spieler v = new Spieler(new Random(), "V", "5-2-1993", Spielposition.Tor);

bayern.HinzufügenSpieler(l);
bayern.HinzufügenSpieler(m);
bayern.HinzufügenSpieler(n);
bayern.HinzufügenSpieler(o);
bayern.HinzufügenSpieler(p);
bayern.HinzufügenSpieler(q);
bayern.HinzufügenSpieler(r);
bayern.HinzufügenSpieler(s);
bayern.HinzufügenSpieler(t);
bayern.HinzufügenSpieler(u);
bayern.HinzufügenSpieler(v);


// -----------------------------------------------------------------------------------------
//                      ⚽         👨‍👩‍👧‍👦  Begegnung 👨‍👩‍👧‍👦      ⚽    
// -----------------------------------------------------------------------------------------

Begegnung begegnung = new Begegnung(ahly, bayern);

// Die Ergibnisse
begegnung.SimuliereSpiel();
Console.WriteLine(begegnung);

// Über Manschaften
//Console.WriteLine(ahly);
//Console.WriteLine(bayern);

// Über Spieler
//Console.WriteLine(a);
//Console.WriteLine(l);
