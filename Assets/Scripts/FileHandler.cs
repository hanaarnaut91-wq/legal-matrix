using System.IO;
using UnityEngine;

public class FileHandler : MonoBehaviour
{
    string path;
    string pathZaSeverity;

    [SerializeField]
    private bool overwriteExistingData;

    void Awake()
    {
        path = Path.Combine(Application.persistentDataPath, "ZakoniData.txt");
        pathZaSeverity = Path.Combine(Application.persistentDataPath, "SeverityData.txt");

        bool dataMissing = !File.Exists(path) || !File.Exists(pathZaSeverity);

        if (overwriteExistingData || dataMissing)
        {
            WriteToFile();
            WriteSeverityToFile();
            overwriteExistingData = false;
        }
        else
        {
            Debug.Log("Postojeći Legal Matrix podaci su sačuvani.");
        }
    }

    [ContextMenu("Reset Legal Matrix Data")]
    public void ResetData()
    {
        path = Path.Combine(Application.persistentDataPath, "ZakoniData.txt");
        pathZaSeverity = Path.Combine(Application.persistentDataPath, "SeverityData.txt");
        WriteToFile();
        WriteSeverityToFile();
    }

    public void WriteSeverityToFile()
    {
        pathZaSeverity = Application.persistentDataPath + "/SeverityData.txt";
        string content = "Zakon o inspekcijama Federacije BiH"+
"\n="+
"\noperational|3|ref. 00.01.00|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|4|ref. 00.01.01|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 00.01.02|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|4|ref. 00.01.03|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|4|ref. 00.01.04|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|5|ref. 00.01.05|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 00.01.06|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 00.01.07|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 00.01.08|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 00.01.09|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 00.01.10|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 00.01.11|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 00.01.12|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 00.01.13|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 00.02.01|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\noperational|3|ref. 00.02.02|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\noperational|3|ref. 00.02.03|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|4|ref. 00.02.04|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 00.02.05|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\n%"+
"\nZakon o privrednim društvima"+
"\n="+
"\nlegal|3|ref. 01.01.01|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|2|ref. 01.01.02|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nlegal|3|ref. 01.01.03|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nlegal|3|ref. 01.01.04|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nlegal|2|ref. 01.01.05|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nlegal|3|ref. 01.01.06|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\n%"+
"\nZakon o unutrašnjoj trgovini Federacije BiH"+
"\n="+
"\nlegal|4|ref. 01.02.01|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|4|ref. 01.02.01|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 01.02.02|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|5|ref. 01.02.03|Obavljanje djelatnosti bez potrebne registracije/odobrenja predstavlja visok regulatorni rizik i osnov za inspekcijske mjere.|Provjeriti registraciju djelatnosti, rješenja/odobrenja i uskladiti stvarno poslovanje prije nastavka rada."+
"\nlegal|5|ref. 01.02.04|Obavljanje djelatnosti bez potrebne registracije/odobrenja predstavlja visok regulatorni rizik i osnov za inspekcijske mjere.|Provjeriti registraciju djelatnosti, rješenja/odobrenja i uskladiti stvarno poslovanje prije nastavka rada."+
"\nlegal|3|ref. 01.02.05|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 01.02.06|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 01.02.07|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|4|ref. 01.02.08|Nepravilno evidentiranje prometa ili nepostupanje s fiskalnim računima može dovesti do prekršajne odgovornosti i finansijskih sankcija.|Uvesti kontrolu izdavanja, evidentiranja i čuvanja fiskalnih računa te obučiti odgovorna lica."+
"\nlegal|3|ref. 01.02.09|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\nlegal|3|ref. 01.02.10|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\nlegal|4|ref. 01.02.11|Nepotpuna ili neažurna dokumentacija otežava dokazivanje zakonitog poslovanja tokom kontrole.|Uspostaviti ažurne evidencije, kontrolnu listu dokumentacije i periodični interni pregled."+
"\nlegal|3|ref. 01.02.12|Nepotpuna ili neažurna dokumentacija otežava dokazivanje zakonitog poslovanja tokom kontrole.|Uspostaviti ažurne evidencije, kontrolnu listu dokumentacije i periodični interni pregled."+
"\nlegal|3|ref. 01.02.13|Nepotpuna ili neažurna dokumentacija otežava dokazivanje zakonitog poslovanja tokom kontrole.|Uspostaviti ažurne evidencije, kontrolnu listu dokumentacije i periodični interni pregled."+
"\nlegal|3|ref. 01.02.14|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\nlegal|3|ref. 01.02.15|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|4|ref. 01.02.16|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\nlegal|3|ref. 01.02.17|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 01.02.18|Neuređena ugovorna ili prava intelektualnog vlasništva mogu izazvati sporove, zabrane i zahtjeve za naknadu štete.|Pregledati ugovore, dozvole/licence i dokaze o pravu korištenja prije stavljanja robe/usluge u promet."+
"\nlegal|5|ref. 01.02.19|Neuređena ugovorna ili prava intelektualnog vlasništva mogu izazvati sporove, zabrane i zahtjeve za naknadu štete.|Pregledati ugovore, dozvole/licence i dokaze o pravu korištenja prije stavljanja robe/usluge u promet."+
"\nlegal|4|ref. 01.02.20|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\nlegal|5|ref. 01.02.21|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 01.02.22|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|4|ref. 01.02.23|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 01.02.24|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|4|ref. 01.02.25|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\nlegal|4|ref. 01.02.26|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\nlegal|3|ref. 01.02.27|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\nlegal|3|ref. 01.02.28|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 01.02.29|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 01.02.30|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 01.02.31|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\nlegal|3|ref. 01.02.32|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\nlegal|3|ref. 01.02.33|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 01.02.34|Nepravilno formiranje, isticanje ili primjena cijena može predstavljati povredu obaveza prema kupcima i inspekciji.|Uskladiti cjenovnike, oznake cijena i interne procedure za promjene cijena."+
"\nlegal|3|ref. 01.02.35|Nepravilno formiranje, isticanje ili primjena cijena može predstavljati povredu obaveza prema kupcima i inspekciji.|Uskladiti cjenovnike, oznake cijena i interne procedure za promjene cijena."+
"\nlegal|3|ref. 01.02.36|Nepravilno formiranje, isticanje ili primjena cijena može predstavljati povredu obaveza prema kupcima i inspekciji.|Uskladiti cjenovnike, oznake cijena i interne procedure za promjene cijena."+
"\nlegal|4|ref. 01.02.37|Nepravilno formiranje, isticanje ili primjena cijena može predstavljati povredu obaveza prema kupcima i inspekciji.|Uskladiti cjenovnike, oznake cijena i interne procedure za promjene cijena."+
"\nlegal|4|ref. 01.02.38|Nepravilno evidentiranje prometa ili nepostupanje s fiskalnim računima može dovesti do prekršajne odgovornosti i finansijskih sankcija.|Uvesti kontrolu izdavanja, evidentiranja i čuvanja fiskalnih računa te obučiti odgovorna lica."+
"\nlegal|3|ref. 01.02.39|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 01.02.40|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 01.02.41|Nepravilno formiranje, isticanje ili primjena cijena može predstavljati povredu obaveza prema kupcima i inspekciji.|Uskladiti cjenovnike, oznake cijena i interne procedure za promjene cijena."+
"\nlegal|4|ref. 01.02.42|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 01.02.43|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|4|ref. 01.02.44|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\nlegal|3|ref. 01.02.45|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\nlegal|3|ref. 01.02.46|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 01.02.47|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 01.02.48|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 01.02.49|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 01.02.50|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 01.02.51|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 01.02.52|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 01.02.53|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 01.02.54|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 01.02.55|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 01.02.56|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 01.02.57|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\n%"+
"\nZakon o kontroli cijena Federacije BiH"+
"\n="+
"\nfinancial|3|ref. 01.03.01|Nepravilno formiranje, isticanje ili primjena cijena može predstavljati povredu obaveza prema kupcima i inspekciji.|Uskladiti cjenovnike, oznake cijena i interne procedure za promjene cijena."+
"\nfinancial|3|ref. 01.03.02|Nepravilno formiranje, isticanje ili primjena cijena može predstavljati povredu obaveza prema kupcima i inspekciji.|Uskladiti cjenovnike, oznake cijena i interne procedure za promjene cijena."+
"\nfinancial|3|ref. 01.03.03|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nfinancial|3|ref. 01.03.04|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\nfinancial|3|ref. 01.03.05|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\n%"+
"\nZakon o kontroli predmeta od plemenitih metala u BiH/FBiH"+
"\n="+
"\nfinancial|3|ref. 01.04.01|Neuređena ugovorna ili prava intelektualnog vlasništva mogu izazvati sporove, zabrane i zahtjeve za naknadu štete.|Pregledati ugovore, dozvole/licence i dokaze o pravu korištenja prije stavljanja robe/usluge u promet."+
"\nfinancial|3|ref. 01.04.02|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nfinancial|3|ref. 01.04.03|Neuređena ugovorna ili prava intelektualnog vlasništva mogu izazvati sporove, zabrane i zahtjeve za naknadu štete.|Pregledati ugovore, dozvole/licence i dokaze o pravu korištenja prije stavljanja robe/usluge u promet."+
"\n%"+
"\nZakon o mjeriteljstvu BiH/FBiH"+
"\n="+
"\nfinancial|3|ref. 01.05.01|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nfinancial|3|ref. 01.05.02|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nfinancial|3|ref. 01.05.03|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nfinancial|3|ref. 01.05.04|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nfinancial|3|ref. 01.05.05|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nfinancial|3|ref. 01.05.06|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nfinancial|3|ref. 01.05.07|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\nfinancial|3|ref. 01.05.08|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\nfinancial|3|ref. 01.05.09|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\nfinancial|3|ref. 01.05.10|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nfinancial|3|ref. 01.05.11|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\n%"+
"\nZakon o mjernim jedinicama BiH"+
"\n="+
"\nfinancial|3|ref. 01.06.01|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nfinancial|3|ref. 01.06.02|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\n%"+
"\nZakon o ograničenoj upotrebi duhanskih prerađevina"+
"\n="+
"\noperational|3|ref. 01.07.01|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 01.07.02|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 01.07.03|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\noperational|3|ref. 01.07.04|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\noperational|3|ref. 01.07.05|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 01.07.06|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 01.07.07|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 01.07.08|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 01.07.09|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\n%"+
"\nPropisi o obilježavanju brašna"+
"\n="+
"\noperational|3|ref. 01.08.01|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 01.08.02|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 01.08.03|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 01.08.04|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 01.08.05|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 01.08.06|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 01.08.07|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\n%"+
"\nZakon o zaštiti potrošača u BiH"+
"\n="+
"\noperational|4|ref. 01.09.01|Nepravilno evidentiranje prometa ili nepostupanje s fiskalnim računima može dovesti do prekršajne odgovornosti i finansijskih sankcija.|Uvesti kontrolu izdavanja, evidentiranja i čuvanja fiskalnih računa te obučiti odgovorna lica."+
"\noperational|4|ref. 01.09.02|Nepravilno evidentiranje prometa ili nepostupanje s fiskalnim računima može dovesti do prekršajne odgovornosti i finansijskih sankcija.|Uvesti kontrolu izdavanja, evidentiranja i čuvanja fiskalnih računa te obučiti odgovorna lica."+
"\noperational|4|ref. 01.09.03|Nepravilno evidentiranje prometa ili nepostupanje s fiskalnim računima može dovesti do prekršajne odgovornosti i finansijskih sankcija.|Uvesti kontrolu izdavanja, evidentiranja i čuvanja fiskalnih računa te obučiti odgovorna lica."+
"\noperational|4|ref. 01.09.04|Nepravilno evidentiranje prometa ili nepostupanje s fiskalnim računima može dovesti do prekršajne odgovornosti i finansijskih sankcija.|Uvesti kontrolu izdavanja, evidentiranja i čuvanja fiskalnih računa te obučiti odgovorna lica."+
"\noperational|4|ref. 01.09.05|Nepravilno evidentiranje prometa ili nepostupanje s fiskalnim računima može dovesti do prekršajne odgovornosti i finansijskih sankcija.|Uvesti kontrolu izdavanja, evidentiranja i čuvanja fiskalnih računa te obučiti odgovorna lica."+
"\noperational|4|ref. 01.09.06|Nepravilno formiranje, isticanje ili primjena cijena može predstavljati povredu obaveza prema kupcima i inspekciji.|Uskladiti cjenovnike, oznake cijena i interne procedure za promjene cijena."+
"\noperational|4|ref. 01.09.07|Nepravilno formiranje, isticanje ili primjena cijena može predstavljati povredu obaveza prema kupcima i inspekciji.|Uskladiti cjenovnike, oznake cijena i interne procedure za promjene cijena."+
"\noperational|4|ref. 01.09.08|Nepravilno formiranje, isticanje ili primjena cijena može predstavljati povredu obaveza prema kupcima i inspekciji.|Uskladiti cjenovnike, oznake cijena i interne procedure za promjene cijena."+
"\noperational|4|ref. 01.09.09|Nepravilno formiranje, isticanje ili primjena cijena može predstavljati povredu obaveza prema kupcima i inspekciji.|Uskladiti cjenovnike, oznake cijena i interne procedure za promjene cijena."+
"\noperational|4|ref. 01.09.10|Nepravilno formiranje, isticanje ili primjena cijena može predstavljati povredu obaveza prema kupcima i inspekciji.|Uskladiti cjenovnike, oznake cijena i interne procedure za promjene cijena."+
"\noperational|4|ref. 01.09.11|Nepravilno formiranje, isticanje ili primjena cijena može predstavljati povredu obaveza prema kupcima i inspekciji.|Uskladiti cjenovnike, oznake cijena i interne procedure za promjene cijena."+
"\noperational|4|ref. 01.09.12|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|4|ref. 01.09.13|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|4|ref. 01.09.14|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|4|ref. 01.09.15|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|4|ref. 01.09.16|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|4|ref. 01.09.17|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.09.18|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.09.19|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.09.20|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.09.21|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.09.22|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|4|ref. 01.09.23|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|4|ref. 01.09.24|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|4|ref. 01.09.25|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.09.26|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|4|ref. 01.09.27|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.09.28|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|4|ref. 01.09.29|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.09.30|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|4|ref. 01.09.31|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.09.32|Nepravilno evidentiranje prometa ili nepostupanje s fiskalnim računima može dovesti do prekršajne odgovornosti i finansijskih sankcija.|Uvesti kontrolu izdavanja, evidentiranja i čuvanja fiskalnih računa te obučiti odgovorna lica."+
"\noperational|4|ref. 01.09.33|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|5|ref. 01.09.34|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|4|ref. 01.09.35|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.09.36|Nepravilno formiranje, isticanje ili primjena cijena može predstavljati povredu obaveza prema kupcima i inspekciji.|Uskladiti cjenovnike, oznake cijena i interne procedure za promjene cijena."+
"\noperational|4|ref. 01.09.37|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.09.38|Nepravilno formiranje, isticanje ili primjena cijena može predstavljati povredu obaveza prema kupcima i inspekciji.|Uskladiti cjenovnike, oznake cijena i interne procedure za promjene cijena."+
"\noperational|4|ref. 01.09.39|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|4|ref. 01.09.40|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.09.41|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\noperational|4|ref. 01.09.42|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.09.43|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\noperational|4|ref. 01.09.44|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|4|ref. 01.09.45|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|4|ref. 01.09.46|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\noperational|4|ref. 01.09.47|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.09.48|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.09.49|Neuređena ugovorna ili prava intelektualnog vlasništva mogu izazvati sporove, zabrane i zahtjeve za naknadu štete.|Pregledati ugovore, dozvole/licence i dokaze o pravu korištenja prije stavljanja robe/usluge u promet."+
"\noperational|4|ref. 01.09.50|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.09.51|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.09.52|Nepravilno evidentiranje prometa ili nepostupanje s fiskalnim računima može dovesti do prekršajne odgovornosti i finansijskih sankcija.|Uvesti kontrolu izdavanja, evidentiranja i čuvanja fiskalnih računa te obučiti odgovorna lica."+
"\noperational|4|ref. 01.09.53|Nepravilno evidentiranje prometa ili nepostupanje s fiskalnim računima može dovesti do prekršajne odgovornosti i finansijskih sankcija.|Uvesti kontrolu izdavanja, evidentiranja i čuvanja fiskalnih računa te obučiti odgovorna lica."+
"\noperational|4|ref. 01.09.54|Nepravilno evidentiranje prometa ili nepostupanje s fiskalnim računima može dovesti do prekršajne odgovornosti i finansijskih sankcija.|Uvesti kontrolu izdavanja, evidentiranja i čuvanja fiskalnih računa te obučiti odgovorna lica."+
"\noperational|4|ref. 01.09.55|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.09.56|Nepravilno evidentiranje prometa ili nepostupanje s fiskalnim računima može dovesti do prekršajne odgovornosti i finansijskih sankcija.|Uvesti kontrolu izdavanja, evidentiranja i čuvanja fiskalnih računa te obučiti odgovorna lica."+
"\noperational|4|ref. 01.09.57|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.09.58|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.09.59|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.09.60|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.09.61|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.09.62|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.09.63|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.09.64|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.09.65|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.09.66|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.09.67|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.09.68|Nepravilno evidentiranje prometa ili nepostupanje s fiskalnim računima može dovesti do prekršajne odgovornosti i finansijskih sankcija.|Uvesti kontrolu izdavanja, evidentiranja i čuvanja fiskalnih računa te obučiti odgovorna lica."+
"\noperational|4|ref. 01.09.69|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.09.70|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.09.71|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\n%"+
"\nZakon o autorskom i srodnim pravima u BiH"+
"\n="+
"\nlegal|2|ref. 01.10.01|Neuređena ugovorna ili prava intelektualnog vlasništva mogu izazvati sporove, zabrane i zahtjeve za naknadu štete.|Pregledati ugovore, dozvole/licence i dokaze o pravu korištenja prije stavljanja robe/usluge u promet."+
"\nlegal|3|ref. 01.10.02|Neuređena ugovorna ili prava intelektualnog vlasništva mogu izazvati sporove, zabrane i zahtjeve za naknadu štete.|Pregledati ugovore, dozvole/licence i dokaze o pravu korištenja prije stavljanja robe/usluge u promet."+
"\nlegal|2|ref. 01.10.03|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nlegal|2|ref. 01.10.04|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nlegal|2|ref. 01.10.05|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nlegal|2|ref. 01.10.06|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nlegal|2|ref. 01.10.07|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nlegal|3|ref. 01.10.08|Neuređena ugovorna ili prava intelektualnog vlasništva mogu izazvati sporove, zabrane i zahtjeve za naknadu štete.|Pregledati ugovore, dozvole/licence i dokaze o pravu korištenja prije stavljanja robe/usluge u promet."+
"\nlegal|3|ref. 01.10.09|Neuređena ugovorna ili prava intelektualnog vlasništva mogu izazvati sporove, zabrane i zahtjeve za naknadu štete.|Pregledati ugovore, dozvole/licence i dokaze o pravu korištenja prije stavljanja robe/usluge u promet."+
"\nlegal|3|ref. 01.10.10|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\nlegal|3|ref. 01.10.11|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\nlegal|3|ref. 01.10.12|Neuređena ugovorna ili prava intelektualnog vlasništva mogu izazvati sporove, zabrane i zahtjeve za naknadu štete.|Pregledati ugovore, dozvole/licence i dokaze o pravu korištenja prije stavljanja robe/usluge u promet."+
"\n%"+
"\nZakon o industrijskom dizajnu u BiH"+
"\n="+
"\nlegal|3|ref. 01.11.01|Neuređena ugovorna ili prava intelektualnog vlasništva mogu izazvati sporove, zabrane i zahtjeve za naknadu štete.|Pregledati ugovore, dozvole/licence i dokaze o pravu korištenja prije stavljanja robe/usluge u promet."+
"\n%"+
"\nZakon o zaštiti oznaka geografskog porijekla u BiH"+
"\n="+
"\nlegal|3|ref. 01.12.01|Neuređena ugovorna ili prava intelektualnog vlasništva mogu izazvati sporove, zabrane i zahtjeve za naknadu štete.|Pregledati ugovore, dozvole/licence i dokaze o pravu korištenja prije stavljanja robe/usluge u promet."+
"\n%"+
"\nZakon o žigu u BiH"+
"\n="+
"\nlegal|3|ref. 01.13.01|Neuređena ugovorna ili prava intelektualnog vlasništva mogu izazvati sporove, zabrane i zahtjeve za naknadu štete.|Pregledati ugovore, dozvole/licence i dokaze o pravu korištenja prije stavljanja robe/usluge u promet."+
"\n%"+
"\nZakon o kolektivnom ostvarivanju autorskog i srodnih prava u BiH"+
"\n="+
"\nlegal|3|ref. 01.14.01|Neuređena ugovorna ili prava intelektualnog vlasništva mogu izazvati sporove, zabrane i zahtjeve za naknadu štete.|Pregledati ugovore, dozvole/licence i dokaze o pravu korištenja prije stavljanja robe/usluge u promet."+
"\nlegal|4|ref. 01.14.02|Nepravilno evidentiranje prometa ili nepostupanje s fiskalnim računima može dovesti do prekršajne odgovornosti i finansijskih sankcija.|Uvesti kontrolu izdavanja, evidentiranja i čuvanja fiskalnih računa te obučiti odgovorna lica."+
"\nlegal|4|ref. 01.14.03|Nepravilno evidentiranje prometa ili nepostupanje s fiskalnim računima može dovesti do prekršajne odgovornosti i finansijskih sankcija.|Uvesti kontrolu izdavanja, evidentiranja i čuvanja fiskalnih računa te obučiti odgovorna lica."+
"\nlegal|4|ref. 01.14.04|Nepravilno evidentiranje prometa ili nepostupanje s fiskalnim računima može dovesti do prekršajne odgovornosti i finansijskih sankcija.|Uvesti kontrolu izdavanja, evidentiranja i čuvanja fiskalnih računa te obučiti odgovorna lica."+
"\n%"+
"\nPropisi o špediciji i obavezama u prometu robe"+
"\n="+
"\nlegal|3|ref. 01.15.01|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nlegal|3|ref. 01.15.02|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nlegal|3|ref. 01.15.03|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\n%"+
"\nZakon o fiskalnim sistemima Federacije BiH"+
"\n="+
"\nfinancial|3|ref. 01.16.01|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nfinancial|3|ref. 01.16.02|Nepravilno evidentiranje prometa ili nepostupanje s fiskalnim računima može dovesti do prekršajne odgovornosti i finansijskih sankcija.|Uvesti kontrolu izdavanja, evidentiranja i čuvanja fiskalnih računa te obučiti odgovorna lica."+
"\nfinancial|5|ref. 01.16.03|Nepravilno evidentiranje prometa ili nepostupanje s fiskalnim računima može dovesti do prekršajne odgovornosti i finansijskih sankcija.|Uvesti kontrolu izdavanja, evidentiranja i čuvanja fiskalnih računa te obučiti odgovorna lica."+
"\n%"+
"\nZakon o građevinskim proizvodima / propisi o građevinskim proizvodima"+
"\n="+
"\noperational|3|ref. 01.17.01|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 01.17.02|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 01.17.03|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 01.17.04|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 01.17.05|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 01.17.06|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 01.17.07|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 01.17.08|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\n%"+
"\nPropisi o kvalitetu/kakvoći proizvoda"+
"\n="+
"\noperational|3|ref. 01.18.01|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 01.18.02|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 01.18.03|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 01.18.04|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 01.18.05|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 01.18.06|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 01.18.07|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 01.18.08|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\n%"+
"\nZakon o federalnim robnim rezervama"+
"\n="+
"\nfinancial|2|ref. 01.19.01|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nfinancial|2|ref. 01.19.02|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nfinancial|3|ref. 01.19.03|Neuređena ugovorna ili prava intelektualnog vlasništva mogu izazvati sporove, zabrane i zahtjeve za naknadu štete.|Pregledati ugovore, dozvole/licence i dokaze o pravu korištenja prije stavljanja robe/usluge u promet."+
"\nfinancial|2|ref. 01.19.04|Neuređena ugovorna ili prava intelektualnog vlasništva mogu izazvati sporove, zabrane i zahtjeve za naknadu štete.|Pregledati ugovore, dozvole/licence i dokaze o pravu korištenja prije stavljanja robe/usluge u promet."+
"\nfinancial|3|ref. 01.19.05|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nfinancial|3|ref. 01.19.06|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\n%"+
"\nZakon o inspekcijama Federacije BiH"+
"\n="+
"\noperational|3|ref. 01.20.01|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 01.20.02|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 01.20.03|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|4|ref. 01.20.04|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 01.20.05|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 01.20.06|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 01.20.07|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 01.20.08|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 01.20.09|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 01.20.10|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 01.20.11|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 01.20.12|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 01.20.13|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\n%"+
"\nPropisi o benzinskim pumpnim stanicama i mjernim uređajima"+
"\n="+
"\noperational|3|ref. 01.21.01|Neuređena ugovorna ili prava intelektualnog vlasništva mogu izazvati sporove, zabrane i zahtjeve za naknadu štete.|Pregledati ugovore, dozvole/licence i dokaze o pravu korištenja prije stavljanja robe/usluge u promet."+
"\noperational|3|ref. 01.21.02|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\noperational|3|ref. 01.21.03|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\noperational|3|ref. 01.21.04|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\noperational|3|ref. 01.21.05|Neuređena ugovorna ili prava intelektualnog vlasništva mogu izazvati sporove, zabrane i zahtjeve za naknadu štete.|Pregledati ugovore, dozvole/licence i dokaze o pravu korištenja prije stavljanja robe/usluge u promet."+
"\n%"+
"\nZakon o općoj sigurnosti proizvoda u BiH"+
"\n="+
"\noperational|3|ref. 01.22.01|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 01.22.02|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|4|ref. 01.22.03|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.22.04|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 01.22.05|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 01.22.06|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 01.22.07|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\n%"+
"\nZakon o udruženjima i fondacijama Federacije BiH"+
"\n="+
"\nlegal|3|ref. 01.23.01|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nlegal|3|ref. 01.23.02|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nlegal|3|ref. 01.23.03|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nlegal|3|ref. 01.23.04|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nlegal|3|ref. 01.23.05|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nlegal|3|ref. 01.23.06|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nlegal|3|ref. 01.23.07|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nlegal|3|ref. 01.23.08|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nlegal|3|ref. 01.23.09|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\n%"+
"\nPropisi o prometu naftnih derivata"+
"\n="+
"\noperational|3|ref. 01.24.01|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|2|ref. 01.24.02|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 01.24.03|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 01.24|Neuređena ugovorna ili prava intelektualnog vlasništva mogu izazvati sporove, zabrane i zahtjeve za naknadu štete.|Pregledati ugovore, dozvole/licence i dokaze o pravu korištenja prije stavljanja robe/usluge u promet."+
"\n%"+
"\nZakon o unutrašnjoj trgovini Federacije BiH"+
"\n="+
"\nlegal|5|ref. 02.01.01|Obavljanje djelatnosti bez potrebne registracije/odobrenja predstavlja visok regulatorni rizik i osnov za inspekcijske mjere.|Provjeriti registraciju djelatnosti, rješenja/odobrenja i uskladiti stvarno poslovanje prije nastavka rada."+
"\nlegal|4|ref. 02.01.02|Nepravilno evidentiranje prometa ili nepostupanje s fiskalnim računima može dovesti do prekršajne odgovornosti i finansijskih sankcija.|Uvesti kontrolu izdavanja, evidentiranja i čuvanja fiskalnih računa te obučiti odgovorna lica."+
"\nlegal|3|ref. 02.01.03|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\nlegal|3|ref. 02.01.04|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\nlegal|4|ref. 02.01.05|Nepotpuna ili neažurna dokumentacija otežava dokazivanje zakonitog poslovanja tokom kontrole.|Uspostaviti ažurne evidencije, kontrolnu listu dokumentacije i periodični interni pregled."+
"\nlegal|3|ref. 02.01.06|Nepotpuna ili neažurna dokumentacija otežava dokazivanje zakonitog poslovanja tokom kontrole.|Uspostaviti ažurne evidencije, kontrolnu listu dokumentacije i periodični interni pregled."+
"\nlegal|3|ref. 02.01.07|Nepotpuna ili neažurna dokumentacija otežava dokazivanje zakonitog poslovanja tokom kontrole.|Uspostaviti ažurne evidencije, kontrolnu listu dokumentacije i periodični interni pregled."+
"\nlegal|3|ref. 02.01.08|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\nlegal|3|ref. 02.01.09|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|4|ref. 02.01.10|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\nlegal|3|ref. 02.01.11|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 02.01.12|Neuređena ugovorna ili prava intelektualnog vlasništva mogu izazvati sporove, zabrane i zahtjeve za naknadu štete.|Pregledati ugovore, dozvole/licence i dokaze o pravu korištenja prije stavljanja robe/usluge u promet."+
"\nlegal|5|ref. 02.01.13|Neuređena ugovorna ili prava intelektualnog vlasništva mogu izazvati sporove, zabrane i zahtjeve za naknadu štete.|Pregledati ugovore, dozvole/licence i dokaze o pravu korištenja prije stavljanja robe/usluge u promet."+
"\nlegal|4|ref. 02.01.14|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\nlegal|5|ref. 02.01.15|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 02.01.16|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|4|ref. 02.01.17|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 02.01.18|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|4|ref. 02.01.19|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\nlegal|3|ref. 02.01.20|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\nlegal|3|ref. 02.01.21|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\nlegal|3|ref. 02.01.22|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 02.01.23|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 02.01.24|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 02.01.25|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\nlegal|3|ref. 02.01.26|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\nlegal|3|ref. 02.01.27|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 02.01.28|Nepravilno formiranje, isticanje ili primjena cijena može predstavljati povredu obaveza prema kupcima i inspekciji.|Uskladiti cjenovnike, oznake cijena i interne procedure za promjene cijena."+
"\nlegal|3|ref. 02.01.29|Nepravilno formiranje, isticanje ili primjena cijena može predstavljati povredu obaveza prema kupcima i inspekciji.|Uskladiti cjenovnike, oznake cijena i interne procedure za promjene cijena."+
"\nlegal|3|ref. 02.01.30|Nepravilno formiranje, isticanje ili primjena cijena može predstavljati povredu obaveza prema kupcima i inspekciji.|Uskladiti cjenovnike, oznake cijena i interne procedure za promjene cijena."+
"\nlegal|4|ref. 02.01.31|Nepravilno formiranje, isticanje ili primjena cijena može predstavljati povredu obaveza prema kupcima i inspekciji.|Uskladiti cjenovnike, oznake cijena i interne procedure za promjene cijena."+
"\nlegal|4|ref. 02.01.32|Nepravilno evidentiranje prometa ili nepostupanje s fiskalnim računima može dovesti do prekršajne odgovornosti i finansijskih sankcija.|Uvesti kontrolu izdavanja, evidentiranja i čuvanja fiskalnih računa te obučiti odgovorna lica."+
"\nlegal|3|ref. 02.01.33|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 02.01.34|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 02.01.35|Nepravilno formiranje, isticanje ili primjena cijena može predstavljati povredu obaveza prema kupcima i inspekciji.|Uskladiti cjenovnike, oznake cijena i interne procedure za promjene cijena."+
"\nlegal|4|ref. 02.01.36|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 02.01.37|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|4|ref. 02.01.38|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\nlegal|3|ref. 02.01.39|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\nlegal|3|ref. 02.01.40|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 02.01.41|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 02.01.42|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 02.01.43|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 02.01.44|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 02.01.45|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 02.01.46|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 02.01.47|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 02.01.48|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 02.01.49|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 02.01.50|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\nlegal|3|ref. 02.01.51|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\n%"+
"\nZakon o kontroli predmeta od plemenitih metala u BiH/FBiH"+
"\n="+
"\nfinancial|3|ref. 02.02.01|Neuređena ugovorna ili prava intelektualnog vlasništva mogu izazvati sporove, zabrane i zahtjeve za naknadu štete.|Pregledati ugovore, dozvole/licence i dokaze o pravu korištenja prije stavljanja robe/usluge u promet."+
"\nfinancial|3|ref. 02.02.02|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nfinancial|3|ref. 02.02.03|Neuređena ugovorna ili prava intelektualnog vlasništva mogu izazvati sporove, zabrane i zahtjeve za naknadu štete.|Pregledati ugovore, dozvole/licence i dokaze o pravu korištenja prije stavljanja robe/usluge u promet."+
"\n%"+
"\nZakon o ograničenoj upotrebi duhanskih prerađevina"+
"\n="+
"\noperational|3|ref. 02.03.01|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 02.03.02|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 02.03.03|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\n%"+
"\nZakon o mjeriteljstvu BiH/FBiH"+
"\n="+
"\nfinancial|3|ref. 02.04.01|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nfinancial|3|ref. 02.04.02|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nfinancial|3|ref. 02.04.03|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\nfinancial|3|ref. 02.04.04|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\nfinancial|3|ref. 02.04.05|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\nfinancial|3|ref. 02.04.06|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nfinancial|3|ref. 02.04.07|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\n%"+
"\nZakon o kontroli cijena Federacije BiH"+
"\n="+
"\nfinancial|3|ref. 02.05.01|Nepravilno formiranje, isticanje ili primjena cijena može predstavljati povredu obaveza prema kupcima i inspekciji.|Uskladiti cjenovnike, oznake cijena i interne procedure za promjene cijena."+
"\nfinancial|3|ref. 02.05.02|Nepravilno formiranje, isticanje ili primjena cijena može predstavljati povredu obaveza prema kupcima i inspekciji.|Uskladiti cjenovnike, oznake cijena i interne procedure za promjene cijena."+
"\nfinancial|3|ref. 02.05.03|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nfinancial|3|ref. 02.05.04|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\n%"+
"\nPropisi o obilježavanju brašna"+
"\n="+
"\noperational|3|ref. 02.06.01|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 02.06.02|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 02.06.03|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 02.06.04|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 02.06.05|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 02.06.06|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\n%"+
"\nZakon o zaštiti potrošača u BiH"+
"\n="+
"\noperational|4|ref. 02.07.01|Nepravilno evidentiranje prometa ili nepostupanje s fiskalnim računima može dovesti do prekršajne odgovornosti i finansijskih sankcija.|Uvesti kontrolu izdavanja, evidentiranja i čuvanja fiskalnih računa te obučiti odgovorna lica."+
"\noperational|4|ref. 02.07.02|Nepravilno evidentiranje prometa ili nepostupanje s fiskalnim računima može dovesti do prekršajne odgovornosti i finansijskih sankcija.|Uvesti kontrolu izdavanja, evidentiranja i čuvanja fiskalnih računa te obučiti odgovorna lica."+
"\noperational|4|ref. 02.07.03|Nepravilno formiranje, isticanje ili primjena cijena može predstavljati povredu obaveza prema kupcima i inspekciji.|Uskladiti cjenovnike, oznake cijena i interne procedure za promjene cijena."+
"\noperational|4|ref. 02.07.04|Nepravilno formiranje, isticanje ili primjena cijena može predstavljati povredu obaveza prema kupcima i inspekciji.|Uskladiti cjenovnike, oznake cijena i interne procedure za promjene cijena."+
"\noperational|4|ref. 02.07.05|Nepravilno formiranje, isticanje ili primjena cijena može predstavljati povredu obaveza prema kupcima i inspekciji.|Uskladiti cjenovnike, oznake cijena i interne procedure za promjene cijena."+
"\noperational|4|ref. 02.07.06|Nepravilno formiranje, isticanje ili primjena cijena može predstavljati povredu obaveza prema kupcima i inspekciji.|Uskladiti cjenovnike, oznake cijena i interne procedure za promjene cijena."+
"\noperational|4|ref. 02.07.07|Nepravilno formiranje, isticanje ili primjena cijena može predstavljati povredu obaveza prema kupcima i inspekciji.|Uskladiti cjenovnike, oznake cijena i interne procedure za promjene cijena."+
"\noperational|4|ref. 02.07.08|Nepravilno formiranje, isticanje ili primjena cijena može predstavljati povredu obaveza prema kupcima i inspekciji.|Uskladiti cjenovnike, oznake cijena i interne procedure za promjene cijena."+
"\noperational|4|ref. 02.07.09|Nepravilno formiranje, isticanje ili primjena cijena može predstavljati povredu obaveza prema kupcima i inspekciji.|Uskladiti cjenovnike, oznake cijena i interne procedure za promjene cijena."+
"\noperational|4|ref. 02.07.10|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|4|ref. 02.07.11|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|4|ref. 02.07.12|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|4|ref. 02.07.13|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|4|ref. 02.07.14|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|4|ref. 02.07.15|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|4|ref. 02.07.16|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|4|ref. 02.07.17|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 02.07.18|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 02.07.19|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 02.07.20|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 02.07.21|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 02.07.22|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|4|ref. 02.07.23|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|4|ref. 02.07.24|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|4|ref. 02.07.25|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 02.07.26|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|4|ref. 02.07.27|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 02.07.28|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|4|ref. 02.07.29|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 02.07.30|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|4|ref. 02.07.31|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 02.07.32|Nepravilno evidentiranje prometa ili nepostupanje s fiskalnim računima može dovesti do prekršajne odgovornosti i finansijskih sankcija.|Uvesti kontrolu izdavanja, evidentiranja i čuvanja fiskalnih računa te obučiti odgovorna lica."+
"\noperational|4|ref. 02.07.33|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|5|ref. 02.07.34|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|4|ref. 02.07.35|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 02.07.36|Nepravilno formiranje, isticanje ili primjena cijena može predstavljati povredu obaveza prema kupcima i inspekciji.|Uskladiti cjenovnike, oznake cijena i interne procedure za promjene cijena."+
"\noperational|4|ref. 02.07.37|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 02.07.38|Nepravilno formiranje, isticanje ili primjena cijena može predstavljati povredu obaveza prema kupcima i inspekciji.|Uskladiti cjenovnike, oznake cijena i interne procedure za promjene cijena."+
"\noperational|4|ref. 02.07.39|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|4|ref. 02.07.40|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 02.07.42|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 02.07.43|Pitanje ukazuje na moguću neusklađenost sa propisom i potrebu provjere dokumentacije, evidencija i stvarne prakse.|Izvršiti internu provjeru usklađenosti, dokumentovati nalaz i odrediti odgovorno lice i rok za korekciju."+
"\noperational|4|ref. 02.07.44|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|4|ref. 02.07.45|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\n%"+
"\nZakon o autorskom i srodnim pravima u BiH"+
"\n="+
"\nlegal|3|ref. 02.08.01|Neuređena ugovorna ili prava intelektualnog vlasništva mogu izazvati sporove, zabrane i zahtjeve za naknadu štete.|Pregledati ugovore, dozvole/licence i dokaze o pravu korištenja prije stavljanja robe/usluge u promet."+
"\nlegal|3|ref. 02.08.02|Neuređena ugovorna ili prava intelektualnog vlasništva mogu izazvati sporove, zabrane i zahtjeve za naknadu štete.|Pregledati ugovore, dozvole/licence i dokaze o pravu korištenja prije stavljanja robe/usluge u promet."+
"\nlegal|2|ref. 02.08.03|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nlegal|2|ref. 02.08.04|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nlegal|2|ref. 02.08.05|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nlegal|2|ref. 02.08.06|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nlegal|2|ref. 02.08.07|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nlegal|3|ref. 02.08.08|Neuređena ugovorna ili prava intelektualnog vlasništva mogu izazvati sporove, zabrane i zahtjeve za naknadu štete.|Pregledati ugovore, dozvole/licence i dokaze o pravu korištenja prije stavljanja robe/usluge u promet."+
"\nlegal|3|ref. 02.08.09|Neuređena ugovorna ili prava intelektualnog vlasništva mogu izazvati sporove, zabrane i zahtjeve za naknadu štete.|Pregledati ugovore, dozvole/licence i dokaze o pravu korištenja prije stavljanja robe/usluge u promet."+
"\nlegal|3|ref. 02.08.10|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\nlegal|3|ref. 02.08.11|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\nlegal|3|ref. 02.08.12|Neuređena ugovorna ili prava intelektualnog vlasništva mogu izazvati sporove, zabrane i zahtjeve za naknadu štete.|Pregledati ugovore, dozvole/licence i dokaze o pravu korištenja prije stavljanja robe/usluge u promet."+
"\n%"+
"\nZakon o industrijskom dizajnu u BiH"+
"\n="+
"\nlegal|3|ref. 02.09.01|Neuređena ugovorna ili prava intelektualnog vlasništva mogu izazvati sporove, zabrane i zahtjeve za naknadu štete.|Pregledati ugovore, dozvole/licence i dokaze o pravu korištenja prije stavljanja robe/usluge u promet."+
"\n%"+
"\nZakon o zaštiti oznaka geografskog porijekla u BiH"+
"\n="+
"\nlegal|3|ref. 02.10.01|Neuređena ugovorna ili prava intelektualnog vlasništva mogu izazvati sporove, zabrane i zahtjeve za naknadu štete.|Pregledati ugovore, dozvole/licence i dokaze o pravu korištenja prije stavljanja robe/usluge u promet."+
"\n%"+
"\nZakon o žigu u BiH"+
"\n="+
"\nlegal|3|ref. 01.11.01|Neuređena ugovorna ili prava intelektualnog vlasništva mogu izazvati sporove, zabrane i zahtjeve za naknadu štete.|Pregledati ugovore, dozvole/licence i dokaze o pravu korištenja prije stavljanja robe/usluge u promet."+
"\n%"+
"\nZakon o kolektivnom ostvarivanju autorskog i srodnih prava u BiH"+
"\n="+
"\nlegal|3|ref. 02.12.01|Neuređena ugovorna ili prava intelektualnog vlasništva mogu izazvati sporove, zabrane i zahtjeve za naknadu štete.|Pregledati ugovore, dozvole/licence i dokaze o pravu korištenja prije stavljanja robe/usluge u promet."+
"\nlegal|4|ref. 02.12.02|Nepravilno evidentiranje prometa ili nepostupanje s fiskalnim računima može dovesti do prekršajne odgovornosti i finansijskih sankcija.|Uvesti kontrolu izdavanja, evidentiranja i čuvanja fiskalnih računa te obučiti odgovorna lica."+
"\nlegal|4|ref. 02.12.03|Nepravilno evidentiranje prometa ili nepostupanje s fiskalnim računima može dovesti do prekršajne odgovornosti i finansijskih sankcija.|Uvesti kontrolu izdavanja, evidentiranja i čuvanja fiskalnih računa te obučiti odgovorna lica."+
"\nlegal|4|ref. 02.12.04|Nepravilno evidentiranje prometa ili nepostupanje s fiskalnim računima može dovesti do prekršajne odgovornosti i finansijskih sankcija.|Uvesti kontrolu izdavanja, evidentiranja i čuvanja fiskalnih računa te obučiti odgovorna lica."+
"\n%"+
"\nZakon o fiskalnim sistemima Federacije BiH"+
"\n="+
"\nfinancial|3|ref. 02.13.01|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\nfinancial|3|ref. 02.13.02|Nepravilno evidentiranje prometa ili nepostupanje s fiskalnim računima može dovesti do prekršajne odgovornosti i finansijskih sankcija.|Uvesti kontrolu izdavanja, evidentiranja i čuvanja fiskalnih računa te obučiti odgovorna lica."+
"\nfinancial|5|ref. 02.13.03|Nepravilno evidentiranje prometa ili nepostupanje s fiskalnim računima može dovesti do prekršajne odgovornosti i finansijskih sankcija.|Uvesti kontrolu izdavanja, evidentiranja i čuvanja fiskalnih računa te obučiti odgovorna lica."+
"\n%"+
"\nZakon o građevinskim proizvodima / propisi o građevinskim proizvodima"+
"\n="+
"\noperational|3|ref. 02.14.01|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 02.14.02|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 02.14.03|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 02.14.04|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 02.14.05|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 02.14.06|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 02.14.07|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 02.14.08|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\n%"+
"\nZakon o inspekcijama Federacije BiH"+
"\n="+
"\noperational|3|ref. 02.15.01|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 02.15.02|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 02.15.03|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|4|ref. 02.15.04|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 02.15.05|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 02.15.06|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 02.15.07|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 02.15.08|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 02.15.09|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 02.15.10|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 02.15.11|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 02.15.12|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|3|ref. 02.15.13|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\n%"+
"\nZakon o općoj sigurnosti proizvoda u BiH"+
"\n="+
"\noperational|3|ref. 02.16.01|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 02.16.02|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\noperational|4|ref. 02.16.03|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 02.16.04|Povreda prava potrošača može izazvati reklamacije, inspekcijske mjere i reputacijski rizik.|Uskladiti informacije za potrošače, reklamacioni postupak, uslove prodaje i vidljiva obavještenja."+
"\noperational|4|ref. 02.16.05|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 02.16.06|Neusklađenost u oblasti sigurnosti, zdravlja ili kvaliteta proizvoda može stvoriti ozbiljan rizik za kupce i poslovanje.|Provjeriti uslove prodaje, deklaracije, zabrane, sigurnosne zahtjeve i dokaze o usklađenosti proizvoda."+
"\noperational|3|ref. 02.16.07|Nepravilno postupanje u inspekcijskom nadzoru može otežati kontrolu i dovesti do dodatnih mjera ili kazni.|Imenovati odgovorno lice za inspekcije, pripremiti dosije dokumentacije i pratiti izvršenje rješenja."+
"\n%"+
"\nZakon o unutrašnjoj trgovini Federacije BiH"+
"\n="+
"\nlegal|4|ref. 03.01.01|Nepotpuna ili neažurna dokumentacija otežava dokazivanje zakonitog poslovanja tokom kontrole.|Uspostaviti ažurne evidencije, kontrolnu listu dokumentacije i periodični interni pregled."+
"\nlegal|5|ref. 03.01.02|Obavljanje djelatnosti bez potrebne registracije/odobrenja predstavlja visok regulatorni rizik i osnov za inspekcijske mjere.|Provjeriti registraciju djelatnosti, rješenja/odobrenja i uskladiti stvarno poslovanje prije nastavka rada."+
"\n%"+
"\nZakon o fiskalnim sistemima Federacije BiH"+
"\n="+
"\nfinancial|5|ref. 03.02.01|Nepravilno evidentiranje prometa ili nepostupanje s fiskalnim računima može dovesti do prekršajne odgovornosti i finansijskih sankcija.|Uvesti kontrolu izdavanja, evidentiranja i čuvanja fiskalnih računa te obučiti odgovorna lica."+
"\n%";


        File.WriteAllText(pathZaSeverity, content);

        Debug.Log("Written to: " + pathZaSeverity);
    }

    public void WriteToFile()
    {
        string content = "Zakon o inspekcijama Federacije BiH"+
"\n="+
"\nDa li subjekt nadzora sprječava i otežava inspektoru vršenje nadzora?"+
"\nDa li subjekt nadzora odbija saradnju sa inspektorom u postupku poduzimanja preventivnih mjera i radnji i ne postupi po rješenju inspektora u postupku poduzimanja preventivnih mjera ?"+
"\nDa li subjekt nadzora odbija sudjeluje u vršenju inspekcijskog nadzora?"+
"\nDa li subjekt nadzora dao na uvid poslovne knjige i drugu službenu dokumentaciju, ažurne i točne podatke, materijale i obavijesti potrebne inspektoru za pravilno utvrđivanje svih činjenica i okolnosti u vršenju nadzora odmah na licu mjesta ili u roku koji inspektor naloži?"+
"\nDa li subjekt nadzora odazovao na pozivu inspektora da u roku koji mu je naložen donese u službene prostorije tijela za inspekcijske poslove tražene podatke i dokumentaciju ili da dođe osobno radi davanja pojašnjenja u svezi s nadzorom"+
"\nDa li je subjekt nadzora obavijestio mjerodavnog inspektora ili policijsku upravu o slučajevima nastanka opasnosti po život i zdravlje građana i materijalnih dobara, na način kako je to propisano zakonom ili drugim propisom"+
"\nDa li subjekt nadzora subjekt nadzora dao uzorke proizvoda radi ispitivanja kod stručne institucije u Federaciji ovlaštene za ispitivanje kvalitete i zdravstvene ispravnosti proizvoda?"+
"\nDa li subjekt nadzora - pravna osoba s javnim ovlastima vrši javne ovlasti sukladno Zakonu i drugim propisima"+
"\nDa li subjekt nadzora subjekt nadzora kojem je povjereno da upravlja i eksploatizira javno dobro postupa u svojstvu dobrog domaćina?"+
"\nDa li subjekt nadzora postupa po rješenju inspektora i izvršava upravnu mjeru koja mu je rješenjem naložena u roku utvrđenom u rješenju?"+
"\nDa li subjekt nadzora u utvrđenom roku izvijestio inspektora o izvršenju upravne mjerea?"+
"\nDa li subjekt nadzora spriječio da se upravna mjera izvrši putem druge osobe?"+
"\nDa li subjekt je nadzora izvršio upravnu mjeru koja se sastoji u nenovčanoj obvezi?"+
"\nDa lije subjekt nadzora izvrši upravnu mjeru koja mu je naložena rješenjem s novim rokom?"+
"\nDa li subjekat obavlja djelatnost bez rješenja o upisu u sudski registar mjerodavnog suda?"+
"\nDa li subjekat obavlja djelatnost bez rješenja mjerodavnog tijela za obavljanje djelatnosti?"+
"\nDa li subjekat obavlja djelatnost u suprotnosti s rješenjem kojim mu je odobreno obavljanje određene djelatnosti?"+
"\nDa li subjekat posjeduje dokumentaciju kojom potvrđuje da ispunjava minimalno-tehničke uvjete za bavljenje tom djelatnošću (rješenje mjerodavnog tijela, zapisnici mjerodavnih inspekcija i sl.)?"+
"\nDa li je inspektor u kontroli kod subjekta nadzora utvrdio postojanje više od dva prekršaja"+
"\n%"+
"\nZakon o privrednim društvima"+
"\n="+
"\nDa li je trgovac izvršio upis promjene podataka u sudski registar ?"+
"\nDa li rješenje o upisu u sudski registar sadrži sve propisane podatke"+
"\nDa li je subjekt nadzora dostavio organu nadležnom za inspekcijski nadzor obavještenje o početku obavljanja djelatnosti, ispunjavanju minimalno-tehničkih uvjeta za obavljanje djelatnosti ili djelatnosti koje obavlja?"+
"\nDa li je subjekt nadzora na poslovnim prostorijama istaknuop firmu na način kako je upisano u sudski registar"+
"\nDa li subjekt nadzora u svom poslovanju koristi puni, odnosno skraćeni naziv firme onako kako je to upisano u registru društva"+
"\nDa li subjekt nadzora ima stvarno sjedište društva onako kako je upisano u sudski registar gospodarskih društava ?"+
"\n%"+
"\nZakon o unutrašnjoj trgovini Federacije BiH"+
"\n="+
"\nDa li je trgovac (pravna osoba) otpočeo raditi u prodajnom objektu, a nadležnom organu nije dostavio ovjerenu pisanu izjavu kojom potvrđeuje da prodajni objekat ispunjava zakonom propisane uvjete."+
"\nDa li je trgovac (pravna osoba) otpočeo raditi u prodajnom objektu, a nadležnom organu nije dostavio ovjerenu pisanu izjavu kojom potvrđeuje da prodajni objekat ispunjava zakonom propisane uvjete."+
"\nDa li je trgovac (pravna osoba) otpočeo raditi u prodajnom objektu, a nadležnom organu prethodno nije podnio obavjest o datumu početka rada"+
"\nDa li je trgovac (pravna osoba) obavlja djelatnost bez registracije. Ili bez odobrenja nadležnog organa ili ne ispunjava minimalno tehničke uvjete"+
"\nDa li je trgovac (pravna osoba) prodavao robu posredstvom fizičkih osoba (akvizitera) na osnovu ugovora o prodaji od vrata do vrata, bez registracije za tu djelatnost i bez pribavljenog odobrenja nadležnog organa na čijem se području obavlja takav vid trgovine."+
"\nDa li je trgovac (pravna osoba) registriran za organizaciju prodaje na daljiinu"+
"\nDa li je trgovac (pravna osoba) otpočeo raditi u prodajnom objektu, a nadležnom organu podnio netočnu izjavu da prodajni objekat ispunjava propisane uvjete"+
"\nDa li je trgovac (pravna osoba) otpočeo raditi u otrkupnoj stanici i otkupnim mjestima, a nadležnom organu podnio netočnu izjavu da prodajni objekat ispunjava propisane uvjete"+
"\nDa li je trgovac (pravna osoba) formirao i istaknuo cijenu robe koju stavlja u promet u domaćoj valuti u apoenima novčanica koje su u opticaju u BiH i izdaje račune za prodatu robu."+
"\nDa li je trgovac (pravna osoba) prodaje alkoholna pića i druga pića koja sadrže alkohol, duhan i duhanske prerađevine osobama mlađim od 18 godina"+
"\nDa li je trgovac (pravna osoba) istakao obavjest o zabrani prodaje alkoholna pića i druga pića koja sadrže alkohol, duhan i duhanske prerađevine osobama mlađim od 18 godina"+
"\nDa li roba prometu posjeduje vjerodostojnu dokumentaciju iz koje se nedvosmisleno može utvrditi podrijetlo i vlasništvo nad istom"+
"\nDa li je trgovac (pravna osoba) drži u prodajnom objektu trgovačku knjigu"+
"\nDa li je trgovac (pravna osoba) ažurno vodi trgovačku knjigu"+
"\nDa li je trgovac reklamiranjem, oglašavanjem ili ponudom robe ili usluga navodeći podatke ili upotrebljavajući izraze sa kojima se iskorištava ugled drugog trgovca, njegovog proizvoda ili usluga odnosno proizvoda drugog vršio nedopušteno trgovanje ."+
"\nDa li je trgovac davao podatke o drugom trgovcu, ako ti podaci štete ili mogu nanijeti štetu ugledu ili poslovanju drugog trgovca"+
"\nDa li je trgovac prodavao robu sa oznakama ili podacima ili izgledom koji stvara ili bi mogao stvoriti zabunu u pogledu izvora, načina proizvodnje, količine, kakvoće ili drugih osobina robe"+
"\nDa li je trgovac poduzima radnje usmjerene na prekid poslovnog odnosa između drugih trgovaca ili koje sprečavaju ili otežavaju poslovne odnose drugih trgovaca"+
"\nDa li je trgovac neopravdano neispunjava ili raskida ugovore sa pojedinim trgovcem kako bi se sklopio isti ili povoljniji ugovor sa drugim trgovcem"+
"\nDa li je trgovac neovlašteno upotrebljava ime, firmu, pečat, marke, industrijski dizajn ili neke druge oznake drugog trgovca"+
"\nDa li je trgovac daje ili obećava darove, imovinsku korist ili druge koristi drugom trgovcu, njegovom djelatniku, ili osobi koja radi za drugog trgovca kako bi se davaocu omogućila pogodnost na štetu drugog trgovca ili potrošača"+
"\nDa li je trgovac neovlašteno upotrebljava usluge trgovačkog putnika, trgovačkog predstavnika ili zastupnika drugog trgovca"+
"\nDa li je trgovac protupravno pribavlja poslovne tajne drugog trgovca ili bespravno iskorištava povjerene poslovne tajne drugog trgovca"+
"\nDa li je trgovac prodavao robu protivno Odluci Vlade Federacije o pribavljanju i prodaji određene vrste i količine robe, te prodaju robe određenim utvrđenim potrošečima po posebnom redosljedu"+
"\nDa li je trgovac po Odluci Vlade Federacije izvršavao obvezu čuvanja određene količine i vrste robe"+
"\nDa li je trgovac stavljao u promet proizvode koji ne ispunjavaju propisane uvjete kakvoće vezano za deklariranje proizvoda"+
"\nDa li je trgovac stavljao u promet proizvode koji ne ispunjavaju propisane uvjete kakvoće u slučajevima kada je labaratorijskim ispitivanjem kakvoće utvrđeno da po svom sastavu ne ispunjava propisane uvjete kakvoće, ali se može staviti u promet za daljnju upotrebu pod uvjetom da u deklaraciji otklone nedostaci i navedu podaci koji odgovaraju uvjetima kakvoće propisanim za tu vrstu proizv"+
"\nDa li je trgovac stavljao u promet proizvode koji ne ispunjavaju propisane uvjete kakvoće u slučajevima kada je labaratorijskim ispitivanjem kakvoće utvrđeno da po svom sastavu ne ispunjava propisane uvjete kakvoće i nije za daljnju upotrebu."+
"\nDa li je trgovac obavljao trgovinu na veliko bez izdavanja fakture."+
"\nDa li je trgovac obavljao trgovinu na malo van prodavnice, a taj način prodaje je zabranjen posebnim propisom"+
"\nDa li je trgovac obavljao trgovinu na malo van prodavnice na mjestu koje svojom odlukom nije odredio nadležni organ kantona, općine ili grada"+
"\nDa li je trgovac prije početka rada u objektu većem od 1000 m2 u kome se obavlja prodaja prehrambenih i neprehrambenih proizvoda pribavio suglasnost Minisatarstva kojim se utvrđeuje ispunjenost uvjeta vezano za zastupljenost domaćih prehrambenih proizvoda u objektu"+
"\nDa li je trgovac prije početka rada u objektu većem od 1000 m2 u kome se obavlja prodaja prehrambenih i neprehrambenih proizvoda uz suglasnost Minisatarstva kojim se utvrđeuje ispunjenost uvjeta vezano za zastupljenost domaćih prehrambenih proizvoda u objektu dostavio pisanu izjavu o obaveznoj zastupljenisti domaćih preh. proiz."+
"\nDa li uposleni u trgovačkom objektu imaju najmanje III stupanj stručne spreme"+
"\nDa li je trgovac utvrdio pisana pravila o uvjetima prodaje (cijene, način plaćanja, i isporuke, bonifikacije i sl.)"+
"\nDa li je trgovac na prikladan način učinio kupcu dostupnim pisana pravila o uvjetima prodaje (cijene, način plaćanja, i isporuke, bonifikacije i sl.)"+
"\nDa li se trgovac pridržava pisanih pravila o uvjetima prodaje (cijene, način plaćanja, i isporuke, bonifikacije i sl.)"+
"\nDa li ugovor na daljinu koji je trgovac sklopio sa potrošačem sadrži cijenu i druge uvjete prodaje"+
"\nDa li je trgovac utvrdio radno vrijeme prodajnog objekta i drugog oblika trgovine u skladu sa ovim zakonom vodeći računa o broju uposlenih radnika poštujući njihova prava uređenih Zakonom o radu, drugim radno-pravnim propisima, kolektivnim ugovorima i ugovoru o radu."+
"\nDa li je trgovac na vidnom mjestu istakao radno vrijeme, raspored dnevnog i tjednog radnog vremena, radno vrijeme u dane državnih praznika i neradne dane, radno vrijeme privremenog načina obavljanja trgovine."+
"\nDa li je trgovac pridržava utvrđenog radnog vremena"+
"\nDa li je trgovac uz oznaku cijene robe za prodaju ili pripremljene za prodaju označio redni broj iz trgovačke knjige na malo i godinu zaduženja na osnovu koje se može istaknuta cijena povezati sa prijemnim listom odnosno sa zapisnikom (evidencioni broj)"+
"\nDa li je trgovac na tržnici na malo prodavao ostalu robu za čiju prodaju nisu ispunjeni uvjeti propisani odgovarajućim podzakonskim aktom"+
"\nDa li je trgovac u prodavnici namjenjenoj trgovačkoj djelatnosti fizički odvojio dio za obavljanje neke druge djelatnosti"+
"\nDa li je trgovac u prodavnici gdje dodatno obrađuje hranu omogućio potrošačima konzumiranje hrane i pića"+
"\nDa li je trgovac u prodavnici istknuo oznaku o besplatnom degustiranju pojednih proizvoda"+
"\nDa li je trgovac na svakom prodajnom objektu kao i pri prodaji robe van prodavnice istakao firmu pod kojom je upisan u registar kod nadležnog organa"+
"\nDa li je trgovac na veliko utvrdio tržni red"+
"\nDa li se trgovac na veliko pridržava utvrđenog tržnog reda"+
"\nDa li je trgovac utvrdio tržni red na tržnici na malo kojim se bliže uređuju tržna pravila za prodaju robe, vrstu robe, način izlaganja robe, te prodaju, održavanje prostora i opreme, uvjeta za obavljanje trgovine na tržnici na malo i sl"+
"\nDa li je trgovac koji se bavi organizacijom tržnice na malo rabljenom tehničkom robom i ostalim rabljenim robama i rabljenim automobilima prekršio odredbe propisane tržnim redom"+
"\nDa li se trgovac koji pruža usluge trgovačkog centra, kao i korisnici usluga pridržavaju utvrđenog tržnog reda"+
"\nDa li se trgovac koji pruža usluge stočne pijace , kao i korisnici usluga pridržavaju utvrđenog tržnog reda."+
"\nDa li se trgovac na vašaru pridržavaju utvrđenog vašarskog reda i uvjeta i termina koje je propisao nadležni organ."+
"\nDa li se trgovac koji se bavi priređivanjem sajmova pridržava rokova predviđenih u kalendaru sajmova, a koji se utvrđuju u dogovoru sa Privrednom komorom Federacije BiH"+
"\nDa li je trgovac koji se bavi pružanjem usluga otkupne stanice i otkupnih mjesta utvrdio tržni red kojim se bliže uređuju tržna pravila"+
"\nDa li je trgovac koji se bavi pružanjem usluga otkupne stanice i otkupnih mjesta pridržava pravila utvrđenih tržnim redom."+
"\nDa li je trgovac na veliko obavljao trgovinu na veliko u tranzitu robama čiji promet u tranzitu nije dozvoljen."+
"\n%"+
"\nZakon o kontroli cijena Federacije BiH"+
"\n="+
"\nDa li subjekt nadzora ima utvrđena pravila o uvjetima i načinu formiranja cijena ?"+
"\nDa li se subjekt nadzora pridržava utvrđenih pravila o uvjetima i načinu formiranja cijena?"+
"\nDa li se subjekt nadzora pridržava propisanih mjera neposredne kontrole cjena?"+
"\nDa li se subjekt nadzora pri kupovini proizvoda (otkup) pridržava propisane zaštitne cjene?"+
"\nDa li je subjekat nadzora u određenom roku i na propisan način dostavio obavijest o promjeni cjenam odnosno marži?"+
"\n%"+
"\nZakon o kontroli predmeta od plemenitih metala u BiH/FBiH"+
"\n="+
"\nDa li je subjekt nadzora stavio u promet predmete od plemenitih metala koji nisu na propisan način označeni , ispitani i žigosani?"+
"\nDa li subjekat nadzora u trgovini drži predmete od plemenitih metala odvojeno od ostalih predmeta?"+
"\nDa li je subjekt nadzora stavio na raspolaganje slike žigova za označavanje stepena finoće predmeta od plemenitih metala ili slike sredstava kojima se ti žigovi i znakovi mogu raspoznati ?"+
"\n%"+
"\nZakon o mjeriteljstvu BiH/FBiH"+
"\n="+
"\nDa li subjekt nadzora upotrebljava mjerilo koje rezultate mjerenja ne izražava u mjernim jedinicama propisanim zakonom ?"+
"\nDa li subjekt nadzora upotrerbljava mjerilo za koje nije izdat certifikat o ocjenjivanju usklađenosti ili je ukinut certifikat o usklađenosti mjerila ?"+
"\nDa li je subjekt nadzora stavio u promet mjerilo iz uvoza za koje nije pribavljena potvrda Zavoda da ispunjava mjeriteljske i druge uvjete ?"+
"\nDa li je subjekta nadzora stavio u promet ili upotrebljava mjerilo koje nije na propisan način verifikovano ?"+
"\nDa li subjekt nadzora ne vrši prvu, narednu ili vanrednu verifikaciju mjerila ?"+
"\nDa li subjekt nadzora upotrebljava mjerilo kojem je istekao propisan rok periodične verifikacije ?"+
"\nDa li je subjekt nadzora stavio u promet pretpakirni proizvod bez oznake količine ?"+
"\nDa li je subjekt nadzora stavio u promet pretpakirni proizvod ako stvarna količina nije u okviru dozvoljenih odstupanja od naznačene količine ?"+
"\nDa li je subjekt nadzora stavio u promet proizvode od plemenitih metala bez otisnutog žiga ili sa neodgovarajućim žigom ?"+
"\nDa li subjekt nadzora uopće posjeduje mjerilo propisano za obavljanje djelatnosti ?"+
"\nDa li je subjekt nadzora obavjestio Zavod o djelatnosti pretpakiranja ?"+
"\n%"+
"\nZakon o mjernim jedinicama BiH"+
"\n="+
"\nDa li subjekt nadzora u prometu robe ili pri obavljanju usluga upotrebljava mjerne jedinice propisane Zakonom o mjernim jedinicama u BiH ?"+
"\nDa li subjekt nadzora u prometu robe ili pri obavljanju usluga upotrebljava mjerne jedinice suprotno odredbama člana 9. Zakonom o mjernim jedinicama U BiH ?"+
"\n%"+
"\nZakon o ograničenoj upotrebi duhanskih prerađevina"+
"\n="+
"\nDa li se na ambalaži proizvoda od duhana nalazi podatak o količini katrana i nikotina u miligramima ?"+
"\nDa li je podatak o količini katrana i nikotina u miligramima otisnut na propisan način na ambalaži proizvoda od duhana ?"+
"\nDa li je uvoznik ili proizvođač otisnuo na ambalaži upozorenje \"pušenje je štetno za zdravlja\""+
"\nDa li je uvoznik ili proizvođač otisnuo na ambalaži pored upozorenjea\"pušenje je štetno za zdravlja\" otisnuo i ostale podatke na način kako je opisan o članku 8."+
"\nDa li subjekat nadzora čiji se objekat nalazi na udaljenosti manjoj od 100m od predškolske ili školske ustanove , odnosno sportsko rekreativne površine , u istom vrši prodaju duhanskih prerađevina?"+
"\nDa li subjekt nadzora vrši prodaju duhanskih prerađevina licima mlađim od 15 godina?"+
"\nDa li subjekat nadzora vrši prodaju duhanskih prerađevina putem automata ?"+
"\nDa li subjekat nadzora prodaje duhanske prerađevine koje nisu u originalnom pakiranju proizvođača?"+
"\nDa li subjekt nadzora koji se bavi proizvodnjom i prometom duhanskih prerađevina iste reklamira u tisku, na radiju i televiziji, putem kino dijapozitiva , filmova, panoa, tabli, naljepnica i drugih oblika reklame na javnim mjestima , na objektima i sredstvima prijevoza (prometa) putem svjetlecih reklama, knjiga, casopisa, kalendara i odjevnih predmeta , ukljucujuci i sponzoriranje sportskih , kulturnih i drugih javnih priredbi?"+
"\n%"+
"\nPropisi o obilježavanju brašna"+
"\n="+
"\nDa li je subjekt nadzora stavio na tržište brašno koje nije obilježeno evidencijskom markicom?"+
"\nDa li subjekt nadzora prevozi brašno koje nije obilježeno evidencijskom markicom na pakovanju?"+
"\nDa li subjekt nadzora prevozi brašno koje nije obilježeno evidencijskom markicom na dokumentu koje prati brašno?"+
"\nDa li se subjekt nadzora bavi trgovinom brašna koje nije obilježeno evidencijskom markicom?"+
"\nDa li subjekt nadzora za proizvodnju proizvoda u čiji sastav ulazi brašno koristi brašno koje nije obilježeno evidencijskom markicom ?"+
"\nDa li subjekt nadzora vodi evidenciju o izdanim i iskorištenim evidencijskim markicama, na obrascu evidencije o izdanim i iskorištenim evidencijskim markicama (obrazac A3)?"+
"\nDa li subjekt nadzora primjenjuje odredbe člana 12. Pravilnika o posebnim uslovima evidentiranja i obilježavanja brašna u BiH ?"+
"\n%"+
"\nZakon o zaštiti potrošača u BiH"+
"\n="+
"\nDa li je subjekat nadzora za prodatu robu, odnosno izvršenu uslugu , kupcu izdao račun?"+
"\nDa li je subjekat nadzora omogućio kupcu provjeru ispravnosti zaračunatog iznosa u odnosu na kvalitet i količinu kupljenog proizvoda , odnosno usluge?"+
"\nDa li je trgovac izdao račun za isporuku energije , toplinske energije, vode, na osnovu stvarne potrošnje očitane s mjerila ?"+
"\nDa li račun za telekomunikacione usluge sadrži sve potrebne podatke koji potrošaču omogućavaju provjeru ispravnosti obračuna pruženih usluga u obračunskom periodu ?"+
"\nDa li se račun za pružene usluge isporuke energije , telekomunikacione, komunalne i druge usluge dostavlja posebno za svaku uslugu ?"+
"\nDa li istaknuta cijena odgovara cijeni iz knjige popisa robe?"+
"\nDa li je cijena proizvoda istaknuta za jedinicu mjere?"+
"\nDa li cijena proizvoda sadrži naziv i tip proizvoda ?"+
"\nDa li je cijena proizvoda i usluga istaknuta na proizvodu, omotu, odnosno na prodajnom mjestu?"+
"\nDa li je subjekat nadzora istaknuo cijenu proizvoda na izlogu?"+
"\nDa li je proizvod na rasprodaji jasno i vidljivo označen cijenom prije i nakon sniženja ?"+
"\nDa li se subjekt nadzora pridržava prodajne cjene proizvoda i usluga ?"+
"\nDa li se najveći procenat smanjenja cjena objavljen u rasponu odnosi na 1/5 svih proizvoda na rasprodaji?"+
"\nDa li je subjekt nadzora jasno i vidljivo istaknuo cjenu papira za zamotavanje, dodatnih ukrasa i dekoracije?"+
"\nDa li je trgovac koji prodaje proizvode kojima uskoro ističe rok upotrebe fizički odvojio od redovne prodaje ostalih proizvoda i vidljivo istaknuo da se radi o prodaji proizvoda kojima uskoro ističe rok upotrebe?"+
"\nDa li je trgovac koji na rasprodaji prodaje proizvod s nedostatkom ili greškom , takav proizvod fizički odvojio od redovne prodaje ispravnog proizvoda i vidljivo istaknuo da se radi o prodaji proizvoda s nedostatkom ili greškom i svaki pojedinačni proizvod posebno označio ?"+
"\nDa li je trgovac (pravno lice) u ispravnom stanju dostavio proizvod u kuću , stan potrošača ili na neko drugo mjesto u ugovorenom kvalitetu , količini, dogovorenom roku i tom prilikom uručio sve pripadajuće dokumente?"+
"\nDa li je trgovac u ispravnom stanju dostavio proizvod u kuću , stan potrošača ili na neko drugo mjesto?"+
"\nDa li je trgovac dostavio proizvod u kuću , stan potrošača ili na neko drugo mjesto u ugovorenom kvalitetu i količini ?"+
"\nDa li je trgovac dostavio proizvod u kuću , stan potrošača ili na neko drugo mjesto u dogovorenom roku?"+
"\nDa li je trgovac prilikom dostave proizvoda u kuću , stan potrošača ili na neko drugo mjesto, tom prilikom uručio sve pripadajuće dokumente ?"+
"\nDa li je trgovac sačuvao svojstva proizvoda koji je namjenjen prodaji na način utvrđen važećim propisima o kvalitetu proizvoda ili preporuci proizvođača , a naročito proizvoda koji ima ograničen rok upotrebe?"+
"\nDa li je na omotu proizvoda koji ima propisan rok upotrebe isti jasno i čitko označen ?"+
"\nDa li trgovac vrši prodaju proizvoda koji zbog svojih svojstava ne odgovaraju propisanom kvalitetu i uobičajenoj upotrebi ?"+
"\nDa li je trgovac , na zahtjev potrošača , istog upoznao sa svojstvima ponuđenog proizvoda?"+
"\nDa li je trgovac na izabranom uzorku proizvoda pokazao rad proizvoda i dokazao njegovu ispravnost?"+
"\nDa li trgovac daje detaljna uputstva i objašnjenja potrošaču o proizvodu koji prodaje ?"+
"\nDa li je trgovac povukao proizvod iz prodaje ukoliko nije bio u mogućnosti da prikaže način njegove upotrebe i dokaže njegovu ispravnost ?"+
"\nDa li je trgovac prilikom prodaje proizvoda potrošaču osigurao dokumenta iz člana 26. i 27. Zakona o zaštiti potrošača , propisane oznake, podatke i deklaraciju te spisak vlastitih i ovlaštenih servisa?"+
"\nDa li se proizvod prodaje sa originalnim omotom ili ambalažom ?"+
"\nDa li je trgovac , na zahtjev potrošača , posebno upakovao proizvod ?"+
"\nDa li trgovac omot koji ima logotip, naziv proizvođača ili trgovca posebno zaračunava kupcu?"+
"\nDa li je omot prilagođen obliku i masi proizvoda te u tom pogledu ne obmanjuje potrošača ?"+
"\nDa li je omot škodljiv za zdravlje ?"+
"\nDa li je, u slučaju nedostatka na proizvodu , trgovac , na zahtjev potrošača , postupio u skladu sa članom 18. Zakona o zaštiti potrošača (na zahtjev i po izboru potrošača)?"+
"\nDa li je u slučaju nepravilno ili djelimično obavljene usluge trgovac (pravno lice) postupio u skladu sa članom 19. stav 1., odnosno uslugu ponovno obavio ili dovršio , odnosno umanjio dogovorenu cijenu usluge zbog slabijeg kvaliteta ?"+
"\nDa li je trgovac u propisanom roku od dana prijema zahtjeva potrošača , odgovorio potrošaču u pisanoj formi ?"+
"\nDa li je trgovac ili ovlašteni servis, na zahtjev potrošača za izgubljeni ili uništeni proizvod koji je potrošač dao na popravku , održavanje ili doradu, po izboru potrošača u propisanom roku isporučio novi proizvod sa istim svojstvima i za istu namjenu ili mu bez odgađanja namirio pričinjenu štetu u visini maloprodajne cijene novog proizvoda ?"+
"\nDa li je trgovac ili ovlašteni servis, koji je primio proizvod na popravku , održavanje ili doradu, a koji je prilikom servisa oštetio ili pokvario , izvršio popravku oštećenja o vlastitom trošku ili otklonio kvar u roku od 3 dana pod uslovom da se na taj način nije umanjila vrijednost i upotrebljivost proizvoda ?"+
"\nDa li je trgovac prilikom prodaje proizvoda potrošaču obezbjedio deklaraciju u skladu sa zakonom, tehničkim i drugim propisima, odnosno standardima, napisanu na jednom od jezika koji je u službenoj upotrebi u BiH?"+
"\nDa li je trgovac obezbjedio deklaraciju?"+
"\nDa li je dobavljač stavio proizvod u prodaju sa deklaracijom koja sadrži podatke navedene u članu 23. stav 4. Zakona o zaštiti potrošača u BiH kao i u važećim podzakonskim aktima ?"+
"\nDa li deklaracija sadrži sve potrebne (propisane) podatke?"+
"\nDa li je dobavljač za tehnički složene proizvode u tehničkom uputstvu naveo rok osiguranog servisiranja i snabdjevanja tržišta rezervnim djelovima , priborom i drugom proizvodima bez kojih se taj proizvod ne može upotrijebiti prema njegovoj namjeni ?"+
"\nDa li je dobavljač svoje servise i ovlaštene servisere , kao i tržište, redovno snabdjeva potrebnom vrstom i količinom rezervnih djelova , pribora i drugih proizvoda bez kojih se tehnički složeni proizvod ne može upotrijebiti prema predviđenoj namjeni ?"+
"\nDa li je izdavalac EIP-a (pravno lice) obezbjedio da korisnik EIP -a može, u svako doba dana i noći , prijaviti gubitak ili krađu EIP -a?"+
"\nDa li izdavalac EIP-a poštuje odredbe člana 76. stav 3. Zakona o zaštiti potrošača BH ?"+
"\nDa li izdavalac EIP-a, nakon obavljenog prijenosa novčane vrijednosti , u pisanoj formi obavjestio vlasnika EIP-a o podacima iz člana 73. stav 1. Zakona o zaštiti potrošača BH ?"+
"\nDa li je izdavalac EIP-a vlasniku ili korisniku EIP -a pravovremeno lično saopćio promjenu uvjeta ugovora?"+
"\nDa li je izdavalac EIP-a na razuman način prilikom zaključenja ugovora i prije isporuke EIP -a, u pisanom, a po mogućnosti i u elektronskom obliku obavijestio zainteresiranu stranu o uvjetima upotrebe EIP –a iz člana 72. Zakona o zaštiti potrošača BH ?"+
"\nDa li je subjekt nadzora (kreditor) omogućio potrošaču da svoje obaveze iz ugovora o potrošačkom kreditu izmiri prije ugovorenog roka ?"+
"\nDa li je subjekt nadzora (kreditor) omogućio potrošaču smanjenje ukupnih troškova kredita za kamate i ostale troškove koji su bili obračunati za period nakon prijevremene otplate potrošačkog kredita?"+
"\nDa li je subjekt nadzora (kreditor) ispunio obavezu da potrošača u pismenoj formi obavještava osvakoj promjeni godišnje kamatne stope i troškova osam dana prije nastanka promjene , ili izuzetno u vrijemesaznanja promjene, ako je taj rok kraći od osam dana , kao i prilikom terećenja tekućeg računa potrošača ?"+
"\nDa li je kreditor, koji prešutno dozvoljava prekoračenje na tekućem računu potrošača , obavijestio potrošača u pisanoj formi o iznosu godišnjih kamata i kamatnih stopa , promjeni kamatnih stopa prilikom prekoračenja na tekućem računu dužem od tri mjeseca i troškovima kojima će teretiti tekući račun potrošačazbog prekoračenja, kao i o svim obavezama koje nastanu za potrošača zbog prekoračenja na njegovom tekućem računu?"+
"\nDa li ugovor o potrošačkom kreditu sklopljen između kreditora i potrošača sadrži sve odredbe iz člana 54. Zakona o zaštiti potrošača BiH ?"+
"\nDa li je kreditor u pisanoj formi obavijestio potrošača prije zaključenja ugovora o svim odredbama iz člana 58. stav 2. Zakona o zaštiti potrošača BiH i to o : a) dopuštenoj gornjoj granici prekoračenja na tekućem računu potrošača; b) godišnjoj kamatnoj stopi; c) uvjetima za promjenu kamatne stope ; d) načinima raskida ugovora?"+
"\nDa li je kreditor, prije zaključenja ugovora o potrošačkom kreditu , u pisanoj formi upoznao potrošača o svim ugovornim odredbama i ukupnim troškovima kredita ili ako oni nisu prikazani pojedinačno , za svaku stavku ugovora ?"+
"\nDa li je subjekt nadzora bez prethodnog pristanka potrošača upotrijebio pojedinačna sredstva za daljinsku komunikaciju (telefon, telefax, elektronsku pošti i dr.)?"+
"\nDa li je trgovac isporučio potrošaču robu koju nije naručio a da takva isporuka zahtjeva plaćanje?"+
"\nDa li je trgovac isporučio potrošaču robu ili uslugu u roku od 15 dana od dana kada je potrošač poslao narudžbu ?"+
"\nDa li je trgovac koji nije izvršio svoju obavezu isporuke naručene robe ili usluge zbog toga što je nema ili mu nije na raspolaganju , potrošača informisao o ovoj situaciji i da li mu je izvršio vraćanje bilo koje sume novca koju je uplatio što je prije moguće , a u bilo kojem slučaju u roku od 15 dana od dana kad je primio informaciju o nemogućnosti isporuke ?"+
"\nDa li je trgovac (pravno lice) potrošaču osim cjene zajedno sa zakonskim kamatama platio i dodatnih 10% iznosa kupovne cjene za svakih 30 dana kašnjenja?"+
"\nDa li je trgovac, koji ugovorom o prodaji na daljinu osigurava potrošaču kredit sam ili preko trećeg lica, u slučaju odustajanja od ugovora , zahtijevao zatezne kamate ili druge troškove raskida ugovora o kreditu kada potrošač koristi svoje pravo na raskid iz člana 47. Zakona o zaštiti potrpšača BH ?"+
"\nDa li je trgovac , neposredno nakon otpreme proizvoda , obavijestio potrošača o vremenu i načinu dostave ?"+
"\nDa li je trgovac, prije zaključenja ugovora o prodaji na daljinu , preko sredstava za daljinjsku komunikaciju obavijestio potrošača o svim odredbama iz člana 44. stav 1. Zakona o zaštiti potrošača u BiH, odnosno da li je ono u skladu sa stavom 2. istog člana?"+
"\nDa li je trgovac za vrijeme ugovaranja, a najkasnije prije isporuke , dao potrošaču pisano obavještenje o svim podacima iz člana 44. stav 1. Zakona o zaštiti potrošača u BiH ?"+
"\nDa li je trgovac, u pisanom obavještenju iz člana 44. Zakona o zaštiti potrošača u BiH sadržao obavezu trgovca da podatke o potrošaču neće saopćiti trećoj strani , niti strani koja kao pravno ili fizičko lice djeluje unutar iste grupe preduzeća kojoj pripada trgovac , osim ako to potrošač odobri trgovcu upisanoj formi?"+
"\nDa li je trgovac ili pružalac usluge, koji zahtijeva ili izričito uvjetuje kupovinu proizvoda ili pružanje usluge s djelimičnim ili ukupnim avansom , nakon isporuke proizvoda ili obavljene usluge po prijema avansa, potrošaču obračunao i isplatio kamate po stopi poslovne banke trgovca za oročene štedne uloge na tri mjeseca, ako je rok isporuke duži od jednog mjeseca"+
"\nDa li je isporučilac usluga omogućio potrošaču ugradnju potrošačkog mjerila ?"+
"\nDa li je trgovac potrošaču bez odlaganja vratio plaćeni iznos novca ?"+
"\nDa li trgovac vrši oglašavanje proizvoda i usluga u skladu sa odredbama člana 29. Zakona o zaštiti potrošača u BiH?"+
"\n%"+
"\nZakon o autorskom i srodnim pravima u BiH"+
"\n="+
"\nDa li je subjekt nadzora bez prijenosa odgovarajućeg autorskog imovinskog prava, kada je takav prijenos potreban prema odredbama Zakona o autorskim i srodnim pravima, reproducirao, distribuirao, dao u zakup, javno izvodio, javno prenio prenio, javno prikazao, javno saopćio s fonograma ili videograma, radiodifuzno emitirao, radiodifuzno reemitirao sekundarno koristio, emitirao učinio dostupnim javnosti, preradio, audiovizuelno prilagodio ili na drugi način koristio autorsko dijelo, odnosno njegov primjerak"+
"\nDa li je subjekt nadzora posjeduje kompjuterski program u komercijalne svrhe, a pri tome zna ili bi trebalo da zna da se radi o primjerku kojim se povređuje autorsko pravo."+
"\nDa li je subjekt nadzora bez prijenosa odgovarajućeg isključivog prava, kada je takav prijenos potreban prema odredbama ovog zakona, reproducira, snimi javno prenese ili radiodifuzno emitira živo izvođenje ili reproducira, učini dostupnim javnosti, distribuira ili daje u zakup fonogram ili videoigre sa snimljenim izođenjima ili na drugi način koristi izvođenje."+
"\nDa li je subjekt nadzora bez prijenosa odgovarajućeg isključivog prava, kada je takav prijenos potreban prema odredbama ovog zakona, reproducira, distribuira, daje u zakup, učini dostunim javnosti ili na drugi način koristi fonogram."+
"\nDa li je subjekt nadzora bez prijenosa odgovarajućeg isključivog prava, kada je takav prijenos potreban prema odredbama ovog zakona, reproducira, distribuira, daje u zakup, učini dostunim javnosti ili na drugi način koristi videogram."+
"\nDa li je subjekt nadzora bez prijenosa odgovarajućeg isključivog prava, kada je takav prijenos potreban prema odredbama ovog zakona, radiodifuzno reemitira, snimi, reproducira, distribuira učini dostupnim javnosti ili na drugi način iskoristi emisiju, odnosno njen snimak."+
"\nDa li je subjekt nadzora bez prijenosa odgovarajućeg isključivog prava, kada je takav prijenos potreban prema odredbama ovog zakona, reproducira, distribuira, da u zakup, učini dostupnim javnosti ili na drugi način iskoristi bazu podataka, odnosno njen primjerak."+
"\nDa li je subjekt nadzora uklonio ili preinačio bilo koji elektronski podatak za upravljanje autorskim ili srodnim pravima."+
"\nDa li subjekt nadzora reproducira, distribuira, uvozi radi daljnjeg distribuiranja, daje u zajup ili saopćava javnostin autorsko djelo ili predmet srodnih prava, odnosno njihov primjerak s kojeg je elektronski podatak o upravljanju pravima na nedopuštem način uklonjen ili preinačen."+
"\nDa li subjekt nadzora zaobiđe efektivne tehničke mjere ili proizvode, uvoze, distribuira, proda, da u najam, oglasi za prodaju ili zakup, ili posjeduje za komercijalne svrhe tehnologiju, uređaj, proizvod, sastavni dio ili kopjutorski program, ili pruži uslugu s namjerom nedopuštenog zaobilaženja efektivnih tehničkih mjera."+
"\nDa li subjekt nadzora proizveo, uvezao, distribuirao, prodao, dao u zakup, oglasio za prodaju ili zakup, ili posjeduje z komercijalne svrhe tehnologiju, uređaj, proizvod, sastvni dio ili kompjutorski programza uklanjanje ili preinačenje elektronskih podataka o upravljanju pravima."+
"\nDa li subjekt nadzora koji ima zakoniti pristup primjerku autorskog djela ili predmetu srodnih prava osigurao sredstva koja omogućuju ostvarivanje sadržajnih ograničenja prava."+
"\n%"+
"\nZakon o industrijskom dizajnu u BiH"+
"\n="+
"\nDa li subjekt nadzora povrjedio registrirani industrijski dizajn ili pravo prijave?"+
"\n%"+
"\nZakon o zaštiti oznaka geografskog porijekla u BiH"+
"\n="+
"\nDa li je subjekt nadzora povrijedio registrirano ime porijekla ili geografsku oznaku-"+
"\n%"+
"\nZakon o žigu u BiH"+
"\n="+
"\nDa li je subjekt nadzora povrijedio žig ili pravo iz prijave?"+
"\n%"+
"\nZakon o kolektivnom ostvarivanju autorskog i srodnih prava u BiH"+
"\n="+
"\nDa li je subjekt nadzora odgovarajućoj kolektivnoj organizacijio poslao u roku popis korištenih autorskih djela koji su točni?"+
"\nDa li je subjekt nadzora odgovarajućoj kolektivnoj organizacijio poslao u roku popis podatke o vrsti i broju prodatih ili uvezenih uređaja za zvučno i vizuelno snimanje, uređaja za fotokopiranje, praznih nosača zvuka i slike i podataka o prodatim fotokopijama, a koji su potrebni za izračunavanje dugovanog iznosa naknade za privatnu i drugu vlastitu upotrebu djela, prema odredbama zakona kojim se uređuje autorsko pravo i srodno pravo, a koji su točni?"+
"\nDa li je subjekt nadzora odgovarajućoj kolektivnoj organizacijio poslao u roku podatke koji su potrebni za izračunavanje dugovane naknade od prodaje orginala likovnih djela, a koji su točni?"+
"\nDa li je subjekt nadzora odgovarajućoj kolektivnoj organizacijio poslao u roku podatke koji su potrebni za izračunavanje dugovane naknade od davanja orginala ili primjeraka djela na poslugu, a koji su točni?"+
"\n%"+
"\nPropisi o špediciji i obavezama u prometu robe"+
"\n="+
"\nDa li subjekt nadzora / pravno lice / obavlja bez licence poslove međunarodne špedicije koji se odnose na zastupanje i obavljanje poslova u vezi sa carinjenjem roba?"+
"\nDa li kod subjekta nadzora / pravno lice / poslove međunarodne špedicije u vezi sa carinjenjem roba obavlja radnik koji ne ispunjava uslove u skladu sa Zakonom ?"+
"\nDa li je subjekt nadzora /pravno lice / radno vrijeme uskladio sa radnim vremenom nadležne carinarnice u skladu sa Zakonom ?"+
"\n%"+
"\nZakon o fiskalnim sistemima Federacije BiH"+
"\n="+
"\nDa li subjekt nadzora posjeduje fisalni sistem?"+
"\nDa li subjekt nadzora u slučaju neispravnosti fiskalnog sistema ili djela fiskalnog sitema poduzeo propisane aktivnosti za otkalnanje uzroka neispravnosti fiskalnog sistema ili djela fiskalnog sitema?"+
"\nDa li subjekt nadzora klijentu izdao fiskalni račun odštampan na fiskalnom uređaju preko kojeg je evidentiran promet, bez obzira da li to klijent zahtjeva ?"+
"\n%"+
"\nZakon o građevinskim proizvodima / propisi o građevinskim proizvodima"+
"\n="+
"\nDa li je subjekt nadzora izvršio distribuciju građevinskih proizvoda za koji nije izdao dokument o usklađenosti- koji nije označen oznakom usklađenosti ili koji nema tehničko upustvo?"+
"\nDa li je subjekt nadzora bez ovlaštenja izdao certifikat o usklađenosti građevinskih proizvoda?"+
"\nDa li je subjekt nadzora stavio na tržište građevinski proizvod koji nije označen oznakom usklađenosti ili koji nema tehničko upustvo?"+
"\nDa li je subjekt nadzora označio oznakom usklađenosti građevinski proizvod za koji nije izdat dokument o usklađenosti?"+
"\nDa li je subjekt nadzora označio oznakom usklađenosti građevinski proizvod na način koji je protiva ovom zakonu ili propisu koj je donesen na osnovu ovog zakona?"+
"\nDa li je subjekt nadzora osigurao da u distribuciji građevinski proizvod slijede tehnička upustva?"+
"\nDa li je subjekt nadzora izradio tehničko upustvo protivno ovome zakonu ili propisu donesenom na osnovg zakona?"+
"\nDa li je subjekt nadzora omogućio inspaktoru pregled prostora odnosno uvid u radnju ili dokument vezan za ocjenjivanje usklađenosti, dokazivanje upotrebljivost, stavljenje na tržište ili distribuciju građevinskog proizvoda?"+
"\n%"+
"\nPropisi o kvalitetu/kakvoći proizvoda"+
"\n="+
"\nDa li je subjekt nadzora uvezao ili izvezao proizvod bez uvjerenja ili potvrde?"+
"\nDa li je subjekt nadzora vratio , odnosno uništio proizvode za koje je izdato rješenje o vraćanju ili uništenju?"+
"\nDa li je subjekt nadzora stavio u promet proizvod bez uvjerenja o kakvoći proizvoda pri uvozu i izvozu?"+
"\nDa li je subjekt nadzora držao u karanteni proizvode za koje je dobio potvrdu , a ne uvjerenje o kakvoći?"+
"\nDa li je subjekt nadzora primio na prijevoz proizvode bez uvjerenja ili potvrde?"+
"\nDa li je subjekt nadzora pismeno obavjestio izdavaoca potvrde o mjestu uskladištenja proizvoda?"+
"\nDa li je subjekt nadzora u zahtjevu podnesenom za dobivanje uvjerenja dao netočne podatke o proizvodu koji uvozi odnosno izvozi ?"+
"\nDa li je carinski organ dopustio uvoz odnosno izvoz proizvoda za koje nije osigurano uvjerenje , odnosno potvrda?"+
"\n%"+
"\nZakon o federalnim robnim rezervama"+
"\n="+
"\nDa li subjekt nadzora koristi federalne robne rezerve suprotno obavezama koje utvrdi Vlada Federacije BiH ?"+
"\nDa li subjekt nadzora koristi federalne robne rezerve suprotno uvjetima koje odredi Vlada Federacije BiH ?"+
"\nDa li subjekt nadzora izvršava obaveze iz ugovora o skladištenju robnih rezervi ?"+
"\nDa li subjekt nadzora sredstva uzeta u zakup koristi suprotno ugovoru ?"+
"\nDa li subjekt nadzora vodi evidencije o robama povjerenim na skladištenje ?"+
"\nDa li je subjekt nadzora po zahtjevu stavio na uvid Federalnoj direkciji robnih rezervi evidencije o robama povjerenim na skladištenje ?"+
"\n%"+
"\nZakon o inspekcijama Federacije BiH"+
"\n="+
"\nDa li subjekt nadzora onemogućio inspektoru vršenje inspekcijskog nadzora u skladu sa nalogom za inspekcijski nadzor ili na traženje inspektora ?"+
"\nDa li subjekt nadzora na pisano traženje inspektora dostavio tačne i potpune podatke, materijale i obavjesti koje su mu potrebne za vršenje inspekcijskog nadzora ?"+
"\nDa li subjekt nadzora na traženje inspektora dao usmeno odnosno pisano izjašnjenje o činjenicama i dokazima koji su izneseni , odnosno utvrđeni u postupku inspekcijskog nadzora ?"+
"\nDa li subjekt nadzora onemogućio inspektoru privremeno oduzimanje poslovne i druge dokumentacije radi provjere autentičnosti i tačnosti navoda u njoj ?"+
"\nDa li subjekt nadzora inspektoru dao uzorak proizvoda za ispitivanje kvaliteta ?"+
"\nDa li se subjekt nadzora odazvao na poziv inspektora?"+
"\nDa li se subjekt nadzora nije odazvao na poziv inspektora, a izostanak nije opravdao u roku od 24 sata ?"+
"\nDa li je subjekt nadzora izvršio upravnu mjeru u roku i na način koji je inspektor naredio ?"+
"\nDa li je subjekt nadzora spriječio da se upravna mjera izvrši putem drugog lica ?"+
"\nDa li je subjekt nadzora u ostavljenom roku obavjestio inspektora o izvršenju upravne mjere ?"+
"\nDa li je subjekt nadzora dao lažnu prijavu ili lažne podatke koji su u inspekcijskom postupku uzeti kao dokaz ?"+
"\nDa li je subjekt nadzora teže narušio red ili učinio veću nepristojnost u vršenju inspekcijskog nadzora ?"+
"\nDa li je subjekt nadzora teže narušio red ili učinio veću nepristojnost u obavljanju radnje inspekcijskog postupka ?"+
"\n%"+
"\nPropisi o benzinskim pumpnim stanicama i mjernim uređajima"+
"\n="+
"\nDa li vlasnik BPS ima zaključen ugovor o ugradnji mjernih sistema sa serviserom koji vrši ugradnju i održavanje-servisiranje mjernih uređaja i koji je za te poslove ovlašten od strane Federalnog ministarstva trgovine?"+
"\nDa li faktičko stanje broja rezervoara za skladištenje tečnih naftnih goriva i pumpnih automata za istakanje na BPS odgovara stanju u tehnološkoj šemi BPS?"+
"\nDa li je označavanje tečnih naftnih goriva na rezervoarima za skladištenje i pumpnim automatima usklađeno sa propisanim standardom u skladu sa Odlukom o kvalitetu tečnih naftnih goriva?"+
"\nDa li prilikom provjere svih zabilježenih alarma na AMN konzoli uočene nepravilnosti , a odnose se na: količinu goriva u tanku (nisku i visoku razinu goriva), registrovanje neispravnosti nekih od sistema mjerenja, registrovanje da gorivo nije unutar propisanog praga gustoće, registrovanje alarma na curenje tanka, provjera sistemskih alarma koji signaliziraju neispravnost pojedinih dijelova sistema i greške u rukovanju?"+
"\nDa li BPS posjeduje odgovarajuće Tabele zapremine rezervoara za skladištenje tečnih naftnih goriva ovjerene u skladu sa posebnim propisom o vrsti i oblicima žigova koji su u upotrebi kod verificiranja mjerila?"+
"\n%"+
"\nZakon o općoj sigurnosti proizvoda u BiH"+
"\n="+
"\nDa li je subjekt nadzora (proizvođač) suprotno članu 3. ovog Zakona, stavio na tržište proizvod koji nije siguran?"+
"\nDa li je subjekt nadzora suprotno članu 4. ovog Zakona, proizveo, stavio na tržište uvezao ili izvezao opasnu imitaciju iz članka 2. točka i) ovog zakona?"+
"\nDa li je subjekt nadzora postupio suprotno članu 9. stav (1) ovog zakona, odnosno obavijestio na odgovarajući način potrošače ili preduzme odgovarajuće mjere kako bi im omogućilo da izbjegnu rizik?"+
"\nDa li je subjekt nadzora postupio suprotno članu 9. stav (3) tačka b) ovog zakona, odnosno nije preduzme odgovarajuće radnje, uključujući povlačenje neusklađenih proizvoda s tržišta, odgovarajuće i efikasno upozoravanje potrošača ili povrat proizvoda od potrošača kada je neophodno da se izbjegnu rizici koje predstavlja taj proizvod?"+
"\nDa li je subjekt nadzora postuio suprotno članu 10. stav (2) tačka b) ovog Zakona, odnosno da vodi dokumentaciju za praćenje porijekla proizvoda, odnosno na zahtjev nadležnog inspekcijskog organa ne stavi na raspolaganje dokumentaciju koja omogućava praćenje porijekla proizvoda?"+
"\nDa li je subjekt nadzora suprotno članu 11. stav (1) ovog Zakona, obavijestio Agenciju o rizicima koje predstavlja proizvod koji je stavljen na tržište?"+
"\nDa li je subjekt nadzora suprotno članu 11. stav (2) ovog Zakona, uskratio saradnju s nadležnim inspekcijskim organima i Agencijom?"+
"\n%"+
"\nZakon o udruženjima i fondacijama Federacije BiH"+
"\n="+
"\nDa li je subjekt nadzora obavljao djelatnost koje nisu u skladu sa Ciljevima i djelatnosti udruženja ili fondacije i u suprotnosti s ustavnim poretkom Bosne i Hercegovine ili Federacije Bosne i Hercegovine, ili je usmjeren ka njegovom nasilnom rušenju niti raspirivanju nacionalne, rasne, vjerske i druge mržnje ili diskriminacije zabranjene Ustavom i Zakonom"+
"\nDa li je subjekt nadzora obavljao djelatnost čiji su Ciljevi i djelatnost udruženja ili fondacije uključivanje i angažiranje u predizbornoj kampanji političkih stranaka i kandidata, prikupljanje sredstava za političke stranke i njihove kandidate i finansiranje kandidata, odnosno političkih stranaka?"+
"\nDa li je subjekt nadzora radi ostvarivanja svojih statutarnih ciljeva i djelatnosti osnivao subjekte za privrednu i drugu djelatnost pod uvjetima utvrđenim zakonom i statutom udruženja odnosno fondacije?"+
"\nDa li je subjekt nadzora obavljao nesrodne privredne djelatnosti (privredne djelatnosti koje nisu neposredno povezane s ostvarivanjem osnovnih statutarnih ciljeva udruženja ili fondacije) preko posebno osnovanog pravnog lica?"+
"\nDa li subjekt nadzora obavlja djelatnost suprotno statutu udruženja?"+
"\nDa li subjekt nadzora obavlja djelatnost suprotno statutu fondacije?"+
"\nDa li subjekt nadzora u pravnom prometu upotrebljava naziv pod kojim je upisano u registar?"+
"\nDa li subjekt nadzora Federalnom ministarstvu odnosno kantonalnom organu prijaviti promjenu statuta, naziva, sjedišta, djelatnosti, lica ovlaštenog za zastupanje i predstavljanje, članova organa upravljanja, pripajanja, razdvajanja ili transformaciju i prestanak rada udruženja odnosno fondacije u roku od 30 dana od dana izvršene promjene?"+
"\nDa li je Subjekt nadzora upotrijebio višak prihoda nad rashodima ostvarenim obavljanjem privrednih djelatnosti na način predviđen Zakonom i statutom?"+
"\n%"+
"\nPropisi o prometu naftnih derivata"+
"\n="+
"\nDa li je subjekt nadzora -energetski subjekt pravovremeno dostavio izvještaj o prometu naftnim derivatima ili je dostavio pogrešne podatke,"+
"\nDa li subjekt nadzora - energetski subjekt koji uvozi ili stavlja u promet naftne derivate koristi sredstva za poboljšanje parametara goriva direktnim dodavanjem gorivu."+
"\nDa li subjekt nadzora-energetcki subjekt na teritoriji Federacije BiH prodaje goriva nižeg kvalitetnog nivoa od kvaliteta goriva definiranog članom 32. ovog zakona."+
"\n4 Da li su subjekti nadzora-energetski subjekti iz člana 38. stav (4) ovog zakona dužni čuvati operativne zalihe u vlastitim skladištima ili ih osigurati ugovoranjem o prvenstvu kupovine sa energetskim subjektima iz člana 9. tač. b) i e) ovog zakona u njihovim skladištima"+
"\n%"+
"\nZakon o unutrašnjoj trgovini Federacije BiH"+
"\n="+
"\nDa li je trgovac otpočeo rad bez odobrenja nadležnog organa ili ne ispunjava minimalno tehničke uvjete"+
"\nDa li je trgovac formirao i istaknuo cijenu robe koju stavlja u promet u domaćoj valuti u apoenima novčanica koje su u opticaju u BiH i izdaje račune za prodatu robu."+
"\nDa li je trgovac prodaje alkoholna pića i druga pića koja sadrže alkohol, duhan i duhanske prerađevine osobama mlađim od 18 godina"+
"\nDa li je trgovac istakao obavjest o zabrani prodaje alkoholna pića i druga pića koja sadrže alkohol, duhan i duhanske prerađevine osobama mlađim od 18 godina"+
"\nDa li roba prometu posjeduje vjerodostojnu dokumentaciju iz koje se nedvosmisleno može utvrditi podrijetlo i vlasništvo nad istom"+
"\nDa li je trgovac drži u prodajnom objektu trgovačku knjigu"+
"\nDa li trgovac ažurno vodi trgovačku knjigu"+
"\nDa li je trgovac reklamiranjem, oglašavanjem ili ponudom robe ili usluga navodeći podatke ili upotrebljavajući izraze sa kojima se iskorištava ugled drugog trgovca, njegovog proizvoda ili usluga odnosno proizvoda drugog vršio nedopušteno trgovanje ?"+
"\nDa li je trgovac davao podatke o drugom trgovcu, ako ti podaci štete ili mogu nanijeti štetu ugledu ili poslovanju drugog trgovca"+
"\nDa li je trgovac prodavao robu sa oznakama ili podacima ili izgledom koji stvara ili bi mogao stvoriti zabunu u pogledu izvora, načina proizvodnje, količine, kakvoće ili drugih osobina robe"+
"\nDa li je trgovac poduzima radnje usmjerene na prekid poslovnog odnosa između drugih trgovaca ili koje sprečavaju ili otežavaju poslovne odnose drugih trgovaca"+
"\nDa li je trgovac neopravdano neispunjava ili raskida ugovore sa pojedinim trgovcem kako bi se sklopio isti ili povoljniji ugovor sa drugim trgovcem"+
"\nDa li je trgovac neovlašteno upotrebljava ime, firmu, pečat, marke, industrijski dizajn ili neke druge oznake drugog trgovca"+
"\nDa li je trgovac daje ili obećava darove, imovinsku korist ili druge koristi drugom trgovcu, njegovom djelatniku, ili osobi koja radi za drugog trgovca kako bi se davaocu omogućila pogodnost na štetu drugog trgovca ili potrošača?"+
"\nDa li je trgovac neovlašteno upotrebljava usluge trgovačkog putnika, trgovačkog predstavnika ili zastupnika drugog trgovca"+
"\nDa li je trgovac protupravno pribavlja poslovne tajne drugog trgovca ili bespravno iskorištava povjerene poslovne tajne drugog trgovca"+
"\nDa li je trgovac prodavao robu protivno Odluci Vlade Federacije o pribavljanju i prodaji određene vrste i količine robe, te prodaju robe određenim utvrđenim potrošečima po posebnom redosljedu"+
"\nDa li je trgovac po Odluci Vlade Federacije izvršavao obvezu čuvanja određene količine i vrste robe"+
"\nDa li je trgovac stavljao u promet proizvode koji ne ispunjavaju propisane uvjete kakvoće vezano za deklariranje proizvoda"+
"\nDa li je trgovac stavljao u promet proizvode koji ne ispunjavaju propisane uvjete kakvoće u slučajevima kada je labaratorijskim ispitivanjem kakvoće utvrđeno da po svom sastavu ne ispunjava propisane uvjete kakvoće, ali se može staviti u promet za daljnju prodaju"+
"\nDa li je trgovac stavljao u promet proizvode koji ne ispunjavaju propisane uvjete kakvoće u slučajevima kada je labaratorijskim ispitivanjem kakvoće utvrđeno da po svom sastavu ne ispunjava propisane uvjete kakvoće i nije za daljnju upotrebu."+
"\nDa li je trgovac obavljao trgovinu na veliko bez izdavanja fakture."+
"\nDa li je trgovac obavljao trgovinu na malo van prodavnice, a taj način prodaje je zabranjen posebnim propisom"+
"\nDa li je trgovac obavljao trgovinu na malo van prodavnice na mjestu koje svojom odlukom nije odredio nadležni organ kantona, općine ili grada"+
"\nDa li je trgovac prije početka rada u objektu većem od 1000 m2 u kome se obavlja prodaja prehrambenih i neprehrambenih proizvoda pribavio suglasnost Minisatarstva kojim se utvrđeuje ispunjenost uvjeta vezano za zastupljenost domaćih prehrambenih proizvoda u objektu"+
"\nDa li je trgovac prije početka rada u objektu većem od 1000 m2 u kome se obavlja prodaja prehrambenih i neprehrambenih proizvoda uz suglasnost Minisatarstva kojim se utvrđeuje ispunjenost uvjeta vezano za zastupljenost domaćih prehrambenih proizvoda u objektu dostavio pisanu izjavu o obaveznoj zastupljenisti domaćih preh. proiz."+
"\nDa li uposleni u trgovačkom objektu imaju najmanje III stupanj stručne spreme"+
"\nDa li je trgovac utvrdio pisana pravila o uvjetima prodaje (cijene, način plaćanja, i isporuke, bonifikacije i sl.)"+
"\nDa li je trgovac na prikladan način učinio kupcu dostupnim pisana pravila o uvjetima prodaje (cijene, način plaćanja, i isporuke, bonifikacije i sl.)"+
"\nDa li se trgovac pridržava pisanih pravila o uvjetima prodaje (cijene, način plaćanja, i isporuke, bonifikacije i sl.)"+
"\nDa li ugovor na daljinu koji je trgovac sklopio sa potrošačem sadrži cijenu i druge uvjete prodaje"+
"\nDa li je trgovac utvrdio radno vrijeme prodajnog objekta i drugog oblika trgovine u skladu sa ovim zakonom vodeći računa o broju uposlenih radnika poštujući njihova prava uređenih Zakonom o radu, drugim radno-pravnim propisima, kolektivnim ugovorima i ugorima o radu"+
"\nDa li je trgovac na vidnom mjestu istakao radno vrijeme, raspored dnevnog i tjednog radnog vremena, radno vrijeme u dane državnih praznika i neradne dane, radno vrijeme privremenog načina obavljanja trgovine."+
"\nDa li je trgovac pridržava utvrđenog radnog vremena"+
"\nDa li je trgovac uz oznaku cijene robe za prodaju ili pripremljene za prodaju označio redni broj iz trgovačke knjige na malo i godinu zaduženja na osnovu koje se može istaknuta cijena povezati sa prijemnim listom odnosno sa zapisnikom (evidencioni broj)"+
"\n. Da li je trgovac na tržnici na malo prodavao ostalu robu za čiju prodaju nisu ispunjeni uvjeti propisani odgovarajućim podzakonskim aktom"+
"\nDa li je trgovac u prodavnici namjenjenoj trgovačkoj djelatnosti fizički odvojio dio za obavljanje neke druge djelatnosti"+
"\nDa li je trgovac u prodavnici gdje dodatno obrađuje hranu omogućio potrošačima konzumiranje hrane i pića"+
"\nDa li je trgovac u prodavnici istknuo oznaku o besplatnom degustiranju pojednih proizvoda"+
"\nDa li je trgovac na svakom prodajnom objektu kao i pri prodaji robe van prodavnice istakao firmu pod kojom je upisan u registar kod nadležnog organa"+
"\nDa li je trgovac na veliko utvrdio tržni red"+
"\nDa li se trgovac na veliko pridržava utvrđenog tržnog reda"+
"\nDa li je trgovac utvrdio tržni red na tržnici na malo kojim se bliže uređuju tržna pravila za prodaju robe, vrstu robe, način izlaganja robe, te prodaju, održavanje prostora i opreme, uvjeta za obavljanje trgovine na tržnici na malo i sl"+
"\nDa li je trgovac koji se bavi organizacijom tržnice na malo rabljenom tehničkom robom i ostalim rabljenim robama i rabljenim automobilima prekršio odredbe propisane tržnim redom"+
"\nDa li se trgovac koji pruža usluge trgovačkog centra, kao i korisnici usluga pridržavaju utvrđenog tržnog reda"+
"\nDa li se trgovac koji pruža usluge stočne pijace , kao i korisnici usluga pridržavaju utvrđenog tržnog reda."+
"\nDa li se trgovac na vašaru pridržavaju utvrđenog vašarskog reda i uvjeta i termina koje je propisao nadležni organ."+
"\nDa li se trgovac koji se bavi priređivanjem sajmova pridržava rokova predviđenih u kalendaru sajmova, a koji se utvrđuju u dogovoru sa Privrednom komorom Federacije BiH"+
"\nDa li je trgovac koji se bavi pružanjem usluga otkupne stanice i otkupnih mjesta utvrdio tržni red kojim se bliže uređuju tržna pravila"+
"\nDa li je trgovac koji se bavi pružanjem usluga otkupne stanice i otkupnih mjesta pridržava pravila utvrđenih tržnim redom."+
"\nDa li je trgovac na veliko obavljao trgovinu na veliko u tranzitu robama čiji promet u tranzitu nije dozvoljen."+
"\n%"+
"\nZakon o kontroli predmeta od plemenitih metala u BiH/FBiH"+
"\n="+
"\nDa li je subjekat nadzora stavio u promet predmete od plemenitih metala koji nisu na propisan način označeni , ispitani i žigosani?"+
"\nDa li subjekat nadzora u trgovini drži predmete od plemenitih metala odvojeno od ostalih predmeta?"+
"\nDa li je subjekat nadzora stavio na raspolaganje slike žigova za označavanje stepena finoće predmeta od plemenitih metala ili slike sredstava kojima se ti žigovi i znakovi mogu raspoznati ?"+
"\n%"+
"\nZakon o ograničenoj upotrebi duhanskih prerađevina"+
"\n="+
"\nDa li subjekat nadzora vrši prodaju duhanskih prerađevina licima mlađim od 15 godina?"+
"\nDa li subjekat nadzora prodaje duhanske prerađevine koje nisu u originalnom pakiranju proizvođača?"+
"\nDa li subjekt nadzora čiji se objekat nalazi na udaljenosti manjoj od 100m od predškolske ili školske ustanove , odnosno sportsko rekreativne površine , u istom vrši prodaju duhanskih prerađevina?"+
"\n%"+
"\nZakon o mjeriteljstvu BiH/FBiH"+
"\n="+
"\nDa li subjekt nadzora ne vrši prvu, narednu ili vanrednu verifikaciju mjerila ?"+
"\nDa li subjekt nadzora upotrebljava mjerilo kojem je istekao propisan rok periodične verifikacije ?"+
"\nDa li je subjekt nadzora stavio u promet pretpakirni proizvod bez oznake količine ?"+
"\nDa li je subjekt nadzora stavio u promet pretpakirni proizvod ako stvarna količina nije u okviru dozvoljenih odstupanja od naznačene količine ?"+
"\nDa li je subjekt nadzora stavio u promet proizvode od plemenitih metala bez otisnutog žiga ili sa neodgovarajućim žigom ?"+
"\nDa li subjekt nadzora uopće posjeduje mjerilo propisano za obavljanje djelatnosti ?"+
"\nDa li je subjekt nadzora obavjestio Zavod o djelatnosti pretpakiranja ?"+
"\n%"+
"\nZakon o kontroli cijena Federacije BiH"+
"\n="+
"\nDa li subjekat nadzora ima utvrđena pravila o uvjetima i načinu formiranja cijena ?"+
"\nDa li se subjekat nadzora pridržava utvrđenih pravila o uvjetima i načinu formiranja cijena?"+
"\nDa li se subjekat nadzora pridržava propisanih mjera neposredne kontrole cjena?"+
"\nDa li je subjekat nadzora u određenom roku i na propisan način dostavio obavijest o promjeni cjenam odnosno marži?"+
"\n%"+
"\nPropisi o obilježavanju brašna"+
"\n="+
"\nDa li subjekt nadzora prevozi brašno koje nije obilježeno evidencijskom markicom na pakovanju ili na dokumentu ?"+
"\n. Da li se subjekt nadzora bavi trgovinom brašna koje nije obilježeno evidencijskom markicom?"+
"\nDa li subjekt nadzora za proizvodnju proizvoda u čiji sastav ulazi brašno koristi brašno koje nije obilježeno evidencijskom markicom ?"+
"\nDa li subjekt nadzora vodi evidenciju o izdanim i iskorištenim evidencijskim markicama, na obrascu evidencije o izdanim i iskorištenim evidencijskim markicama (obrazac A3)?"+
"\nDa li subjekt nadzora primjenjuje odredbe člana 12. Pravilnika o posebnim uslovima evidentiranja i obilježavanja brašna u BiH ?"+
"\nDa li subjekt nadzora prevozi brašno koje nije obilježeno evidencijskom markicom na pakovanju?"+
"\n%"+
"\nZakon o zaštiti potrošača u BiH"+
"\n="+
"\nDa li je subjekt nadzora za prodatu robu, odnosno izvršenu uslugu , kupcu izdao račun?"+
"\nDa li je subjekt nadzora omogućio kupcu provjeru ispravnosti zaračunatog iznosa u odnosu na kvalitet I količinu kupljenog proizvoda , odnosno usluge?"+
"\nDa li je istaknuta cijena konačna , tj. da li su u prodajnu cijenu uključeni svi porezi , doprinosi i takse?"+
"\nDa li istaknuta cijena odgovara cijeni iz knjige popisa robe ?"+
"\nDa li je cijena proizvoda istaknuta za jedinicu mjere ?"+
"\nDa li cijena proizvoda sadrži naziv i tip proizvoda ?"+
"\nDa li je cijena proizvoda i usluga istaknuta na proizvodu , omotu, odnosno na prodajnom mjestu ?"+
"\nDa li je subjekat nadzora istaknuo cijenu proizvoda na izlogu ?"+
"\nDa li je proizvod na rasprodaji jasno i vidljivo označen cijenom prije i nakon sniženja ?"+
"\nDa li se subjekt nadzora pridržava prodajne cjene proizvoda i usluga ?"+
"\nDa li se subjekt nadzora pridržava istaknute cjene proizvoda i usluga ?"+
"\nDa li se najveći procenat smanjenja cjena objavljen u rasponu odnosi na 1/5 svih proizvoda na rasprodaji?"+
"\nDa li je subjekat nadzora jasno i vidljivo istaknuo cjenu papira za zamotavanje , dodatnih ukrasa i dekoracije?"+
"\nDa li je proizvod na rasprodaji kojem uskoro ističe rok upotrebe imao dodatno vidljivo istaknut krajnji rok upotrebe?"+
"\nDa li je trgovac koji prodaje proizvode kojima uskoro ističe rok upotrebe fizički odvojio od redovne prodaje ostalih proizvoda i vidljivo istaknuo da se radi o prodaji proizvoda kojima uskoro ističe rok upotrebe?"+
"\nDa li je trgovac koji na rasprodaji prodaje proizvod s nedostatkom ili greškom , takav proizvod fizički odvojio od redovne prodaje ispravnog proizvoda i vidljivo istaknuo da se radi o prodaji proizvoda s nedostatkom ili greškom i svaki pojedinačni proizvod posebno označio ?"+
"\nDa li je trgovac u ispravnom stanju dostavio proizvod u kuću , stan potrošača ili na neko drugo mjesto u ugovorenom kvalitetu , količini, dogovorenom roku i tom prilikom uručio sve pripadajuće dokumente?"+
"\nDa li je trgovac u ispravnom stanju dostavio proizvod u kuću , stan potrošača ili na neko drugo mjesto?"+
"\nDa li je trgovac dostavio proizvod u kuću , stan potrošača ili na neko drugo mjesto u ugovorenom kvalitetu i količini ?"+
"\nDa li je trgovac dostavio proizvod u kuću , stan potrošača ili na neko drugo mjesto u dogovorenom roku?"+
"\nDa li je trgovac prilikom dostave proizvoda u kuću , stan potrošača ili na neko drugo mjesto, tom prilikom uručio sve pripadajuće dokumente ?"+
"\nDa li je trgovac sačuvao svojstva proizvoda koji je namjenjen prodaji na način utvrđen važećim propisima o kvalitetu proizvoda ili preporuci proizvođača , a naročito proizvoda koji ima ograničen rok upotrebe?"+
"\nDa li je na omotu proizvoda koji ima propisan rok upotrebe isti jasno i čitko označen ?"+
"\nDa li trgovac vrši prodaju proizvoda koji zbog svojih svojstava ne odgovaraju propisanom kvalitetu i uobičajenoj upotrebi ?"+
"\nDa li je trgovac na zahtjev potrošača , istog upoznao sa svojstvima ponuđenog proizvoda?"+
"\nDa li je trgovac na izabranom uzorku proizvoda pokazao rad proizvoda i dokazao njegovu ispravnost?"+
"\nDa li trgovac daje detaljna uputstva i objašnjenja potrošaču o proizvodu koji prodaje ?"+
"\nDa li je trgovac povukao proizvod iz prodaje ukoliko nije bio u mogućnosti da prikaže način njegove upotrebe i dokaže njegovu ispravnost ?"+
"\nDa li je trgovac prilikom prodaje proizvoda potrošaču osigurao dokumenta iz člana 26. i 27. Zakona o zaštiti potrošača , propisane oznake, podatke i deklaraciju te spisak vlastitih i ovlaštenih servisa?"+
"\nDa li se proizvod prodaje sa originalnim omotom ili ambalažom ?"+
"\nDa li je trgovac , na zahtjev potrošača , posebno upakovao proizvod ?"+
"\nDa li trgovac omot koji ima logotip, naziv proizvođača ili trgovca posebno zaračunava kupcu?"+
"\nDa li je omot prilagođen obliku i masi proizvoda te u tom pogledu ne obmanjuje potrošača ?"+
"\nDa li je omot škodljiv za zdravlje ?"+
"\nDa li je, u slučaju nedostatka na proizvodu , trgovac , na zahtjev potrošača , postupio u skladu sa članom 18. Zakona o zaštiti potrošača ?"+
"\nDa li je u slučaju nepravilno ili djelimično obavljene usluge trgovac (fizičko lice) postupio u skladu s članom 19. stav 1., odnosno uslugu ponovno obavio ili dovršio , odnosno umanjio dogovorenu cijenu usluge zbog slabijeg kvaliteta ?"+
"\nDa li je trgovac , u propisanom roku od dana prijema zahtjeva potrošača , odgovorio potrošaču u pisanoj formi ?"+
"\nDa li je trgovac ili ovlašteni servis, na zahtjev potrošača za igubljeni ili uništeni proizvod koji je potrošač dao na popravku , održavanje ili doradu, po izboru potrošača u propisanom roku isporučio novi proizvod sa istim svojstvima i za istu namjenu ili mu bez odgađanja namirio pričinjenu štetu u visini maloprodajne cijene novog proizvoda ?"+
"\nDa li je trgovac ili ovlašteni servis, koji je primio proizvod na popravku , održavanje ili doradu, a koji je prilikom servisa oštetio ili pokvario , izvršio popravku oštećenja o vlastitom trošku ili otklonio kvar u roku od 3 dana pod uslovom da se na taj način nije umanjila vrijednost i upotrebljivost proizvoda ?"+
"\nDa li je trgovac prilikom prodaje proizvoda potrošaču obezbjedio deklaraciju u skladu sa zakonom, tehničkim i drugim propisima, odnosno standardima, napisanu na jednom od jezika koji je u službenoj upotrebi u BiH?"+
"\nDa li je dobavljač stavio proizvod u prodaju sa deklaracijom koja sadrži podatke navedene u članu 23. stav 4. Zakona o zaštiti potrošača u BiH kao i u važećim podzakonskim aktima ?"+
"\nDa li deklaracija sadrži sve potrebne (propisane) podatke?"+
"\nDa li je dobavljač za tehnički složene proizvode u tehničkom uputstvu naveo rok osiguranog servisiranja i snabdjevanja tržišta rezervnim djelovima , priborom i drugom proizvodima bez kojih se taj proizvod ne može upotrijebiti prema njegovoj namjeni ?"+
"\nDa li dobavljač svoje servise i ovlaštene servisere , kao i tržište, redovno snabdjeva potrebnom vrstom i količinom rezervnih djelova , pribora i drugih proizvoda bez kojih se tehnički složeni proizvod ne može upotrijebiti prema predviđenoj namjeni ?"+
"\n%"+
"\nZakon o autorskom i srodnim pravima u BiH"+
"\n="+
"\nDa li je subjekt nadzora bez prijenosa odgovarajućeg autorskog imovinskog prava, kada je takav prijenos potreban prema odredbama Zakona o autorskim i srodnim pravima, reproducirao, distribuirao, dao u zakup, javno izvodio, javno prenio prenio, javno prikazao"+
"\nDa li je subjekt nadzora posjeduje kompjuterski program u komercijalne svrhe, a pri tome zna ili bi trebalo da zna da se radi o primjerku kojim se povređuje autorsko pravo."+
"\nDa li je subjekt nadzora bez prijenosa odgovarajućeg isključivog prava, kada je takav prijenos potreban prema odredbama ovog zakona, reproducira, snimi javno prenese ili radiodifuzno emitira živo izvođenje ili reproducira, učini dostupnim javnosti, dist"+
"\nDa li je subjekt nadzora bez prijenosa odgovarajućeg isključivog prava, kada je takav prijenos potreban prema odredbama ovog zakona, reproducira, distribuira, daje u zakup, učini dostunim javnosti ili na drugi način koristi fonogram."+
"\nDa li je subjekt nadzora bez prijenosa odgovarajućeg isključivog prava, kada je takav prijenos potreban prema odredbama ovog zakona, reproducira, distribuira, daje u zakup, učini dostunim javnosti ili na drugi način koristi videogram."+
"\nDa li je subjekt nadzora bez prijenosa odgovarajućeg isključivog prava, kada je takav prijenos potreban prema odredbama ovog zakona, radiodifuzno reemitira, snimi, reproducira, distribuira učini dostupnim javnosti ili na drugi način iskoristi emisiju, o"+
"\nDa li je subjekt nadzora bez prijenosa odgovarajućeg isključivog prava, kada je takav prijenos potreban prema odredbama ovog zakona, reproducira, distribuira, da u zakup, učini dostupnim javnosti ili na drugi način iskoristi bazu podataka, odnosno njen"+
"\nDa li je subjekt nadzora uklonio ili preinačio bilo koji elektronski podatak za upravljanje autorskim ili srodnim pravima."+
"\nDa li subjekt nadzora reproducira, distribuira, uvozi radi daljnjeg distribuiranja, daje u zajup ili saopćava javnostin autorsko djelo ili predmet srodnih prava, odnosno njihov primjerak s kojeg je elektronski podatak o upravljanju pravima na nedopuštem"+
"\nDa li subjekt nadzora zaobiđe efektivne tehničke mjere ili proizvode, uvoze, distribuira, proda, da u najam, oglasi za prodaju ili zakup, ili posjeduje za komercijalne svrhe tehnologiju, uređaj, proizvod, sastavni dio ili kopjutorski program, ili pruži"+
"\nDa li subjekt nadzora proizveo, uvezao, distribuirao, prodao, dao u zakup, oglasio za prodaju ili zakup, ili posjeduje z komercijalne svrhe tehnologiju, uređaj, proizvod, sastvni dio ili kompjutorski programza uklanjanje ili preinačenje elektronskih podat"+
"\nDa li subjekt nadzora koji ima zakoniti pristup primjerku autorskog djela ili predmetu srodnih prava osigurao sredstva koja omogućuju ostvarivanje sadržajnih ograničenja prava."+
"\n%"+
"\nZakon o industrijskom dizajnu u BiH"+
"\n="+
"\nDa li subjekt nadzora povrjedio registrirani industrijski dizajn ili pravo prijave?"+
"\n%"+
"\nZakon o zaštiti oznaka geografskog porijekla u BiH"+
"\n="+
"\nDa li je subjekt nadzora povrijedio registrirano ime porijekla ili geografsku oznaku-"+
"\n%"+
"\nZakon o žigu u BiH"+
"\n="+
"\nDa li je subjekt nadzora povrijedio žig ili pravo iz prijave?"+
"\n%"+
"\nZakon o kolektivnom ostvarivanju autorskog i srodnih prava u BiH"+
"\n="+
"\nDa li je subjekt nadzora odgovarajućoj kolektivnoj organizacijio poslao u roku popis korištenih autorskih djela koji su točni?"+
"\nDa li je subjekt nadzora odgovarajućoj kolektivnoj organizacijio poslao u roku popis podatke o vrsti i broju prodatih ili uvezenih uređaja za zvučno i vizuelno snimanje, uređaja za fotokopiranje, praznih nosača zvuka i slike i podataka o prodatim fotokopijama, a koji su potrebni za izračunavanje dugovanog iznosa naknade za privatnu i drugu vlastitu upotrebu djela, prema odredbama zakona kojim se uređuje autorsko pravo i srodno pravo, a koji su točni?"+
"\nDa li je subjekt nadzora odgovarajućoj kolektivnoj organizacijio poslao u roku podatke koji su potrebni za izračunavanje dugovane naknade od prodaje orginala likovnih djela, a koji su točni?"+
"\nDa li je subjekt nadzora odgovarajućoj kolektivnoj organizacijio poslao u roku podatke koji su potrebni za izračunavanje dugovane naknade od davanja orginala ili primjeraka djela na poslugu, a koji su točni?"+
"\n%"+
"\nZakon o fiskalnim sistemima Federacije BiH"+
"\n="+
"\nDa li subjekt nadzora posjeduje fisalni sistem?"+
"\nDa li subjekt nadzora u slučaju neispravnosti fiskalnog sistema ili djela fiskalnog sitema poduzeo propisane aktivnosti za otkalnanje uzroka neispravnosti fiskalnog sistema ili djela fiskalnog sitema?"+
"\nDa li subjekt nadzora klijentu izdao fiskalni račun oštampan na fiskalnom uređaju preko kojeg je evidnetiran promet, bez obzira da li to klijent zahtjeva?"+
"\n%"+
"\nZakon o građevinskim proizvodima / propisi o građevinskim proizvodima"+
"\n="+
"\nDa li je subjekt nadzora izvršio distribuciju građevinskih proizvoda za koji nije izdao dokument o usklađenosti- koji nije označen oznakom usklađenosti ili koji nema tehničko upustvo"+
"\nDa li je subjekt nadzora bez ovlaštenja izdao certifikat o usklađenosti građevinskih proizvoda."+
"\nDa li je subjekt nadzora stavio na tržište građevinski proizvod koji nije označen oznakom usklađenosti ili koji nema tehničko upustvo?"+
"\nDa li je subjekt nadzora označio oznakom usklađenosti građevinski proizvod za koji nije izdat dokument o usklađenosti?"+
"\nDa li je subjekt nadzora označio oznakom usklađenosti građevinski proizvod na način koji je protiva ovom zakonu ili propisu koji je donesen na osnovu ovog zakona?"+
"\nDa li je subjekt nadzora osigurao da u distribuciji građevinski proizvod slijede tehnička upustva?"+
"\nDa li je subjekt nadzora izradio tehničko upustvo protivno ovome zakonu ili propisu donesenom na osnovg zakona?"+
"\nDa li je subjekt nadzora omogućio inspaktoru pregled prostora odnosno uvid u radnju ili dokument vezan za ocjenjivanje usklađenosti, dokazivanje upotrebljivost, stavljenje na tržište ili distribuciju građevinskog proizvoda?"+
"\n%"+
"\nZakon o inspekcijama Federacije BiH"+
"\n="+
"\nDa li subjekt nadzora onemogućio inspektoru vršenje inspekcijskog nadzora u skladu sa nalogom za inspekcijski nadzor ili na traženje inspektora ?"+
"\nDa li subjekt nadzora na pisano traženje inspektora dostavio tačne i potpune podatke, materijale i obavjesti koje su mu potrebne za vršenje inspekcijskog nadzora ?"+
"\nDa li subjekt nadzora na traženje inspektora dao usmeno odnosno pisano izjašnjenje o činjenicama i dokazima koji su izneseni , odnosno utvrđeni u postupku inspekcijskog nadzora ?"+
"\nDa li subjekt nadzora onemogućio inspektoru privremeno oduzimanje poslovne i druge dokumentacije radi provjere autentičnosti i tačnosti navoda u njoj ?"+
"\nDa li subjekt nadzora inspektoru dao uzorak proizvoda za ispitivanje kvaliteta ?"+
"\nDa li se subjekt nadzora odazvao na poziv inspektora?"+
"\nDa li se subjekt nadzora nije odazvao na poziv inspektora, a izostanak nije opravdao u roku od 24 sata ?"+
"\nDa li je subjekt nadzora izvršio upravnu mjeru u roku i na način koji je inspektor naredio ?"+
"\nDa li je subjekt nadzora spriječio da se upravna mjera izvrši putem drugog lica ?"+
"\nDa li je subjekt nadzora u ostavljenom roku obavjestio inspektora o izvršenju upravne mjere ?"+
"\nDa li je subjekt nadzora dao lažnu prijavu ili lažne podatke koji su u inspekcijskom postupku uzeti kao dokaz ?"+
"\nDa li je subjekt nadzora teže narušio red ili učinio veću nepristojnost u vršenju inspekcijskog nadzora ?"+
"\nDa li je subjekt nadzora teže narušio red ili učinio veću nepristojnost u obavljanju radnje inspekcijskog postupka ?"+
"\n%"+
"\nZakon o općoj sigurnosti proizvoda u BiH"+
"\n="+
"\nDa li je subjekt nadzora (proizvođač) suprotno članu 3. ovog Zakona, stavio na tržište proizvod koji nije siguran?"+
"\nDa li je subjekt nadzora suprotno članu 4. ovog Zakona, proizveo, stavio na tržište uvezao ili izvezao opasnu imitaciju iz članka 2. točka i) ovog zakona?"+
"\nDa li je subjekt nadzora postupio suprotno članu 9. stav (1) ovog zakona, odnosno obavijestio na odgovarajući način potrošače ili preduzme odgovarajuće mjere kako bi im omogućilo da izbjegnu rizik?"+
"\nDa li je subjekt nadzora postupio suprotno članu 9. stav (3) tačka b) ovog zakona, odnosno nije preduzme odgovarajuće radnje, uključujući povlačenje neusklađenih proizvoda s tržišta, odgovarajuće i efikasno upozoravanje potrošača ili povrat proizvoda od potrošača kada je neophodno da se izbjegnu rizici koje predstavlja taj proizvod?"+
"\nDa li je subjekt nadzora postuio suprotno članu 10. stav (2) tačka b) ovog Zakona, odnosno da vodi dokumentaciju za praćenje porijekla proizvoda, odnosno na zahtjev nadležnog inspekcijskog organa ne stavi na raspolaganje dokumentaciju koja omogućava praćenje porijekla proizvoda?"+
"\nDa li je subjekt nadzora suprotno članu 11. stav (1) ovog Zakona, obavijestio Agenciju o rizicima koje predstavlja proizvod koji je stavljen na tržište?"+
"\nDa li je subjekt nadzora suprotno članu 11. stav (2) ovog Zakona, uskratio saradnju s nadležnim inspekcijskim organima i Agencijom?"+
"\n%"+
"\nZakon o unutrašnjoj trgovini Federacije BiH"+
"\n="+
"\nDa li roba prometu posjeduje vjerodostojnu dokumentaciju iz koje se nedvosmisleno može utvrditi podrijetlo i vlasništvo nad istom"+
"\nDa li fizička osoba-građanin obavlja djelatnost trgovine bez odobrenja nadležnog organa"+
"\n%"+
"\nZakon o fiskalnim sistemima Federacije BiH"+
"\n="+
"\nDa li je klijent uzeo i sačuvao fiskalni račun-reklamirani račun, pisani fiskalni račun i pisani reklamirani račun u krugu od 20 metara od napuštanja prodajnog mjesta i pokazao ga ovlaštenom licu koje obavlja poslove kontrole na njegov usmeni zahtjev?"+
"\n%";
        File.WriteAllText(path, content);

        Debug.Log("Written to: " + path);
    }

    public void ReadFromFile()
    {
        if (File.Exists(path))
        {
            string content = File.ReadAllText(path);
            Debug.Log(content);
        }
        else
        {
            Debug.Log("File does not exist");
        }
    }

    // helper functions
    
    public void AppendToFile()
    {
        string extra = "\nNew line added";

        File.AppendAllText(path, extra);
        Debug.Log("Dodao.");
    }

    public void DeleteFile()
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public void ResetujAplikaciju()
    {
        string content = "Zakon o radu FBiH" +
     "\n=" +
     "\nDa li je poslodavac sa zaposlenikom zaključio ugovor o radu?" +
     "\nDa li je poslodavac onemogućio organizovanje sindikata?" +
     "\nDa li je poslodavac stavio u nepovoljniji položaj radnika zbog članstva ili nečlanstva u sindikatu?" +
     "\nDa li je poslodavac omogućio pristup sindikalnim predstavnicima, odnosno osigurao uvjete za djelovanje sindikata?" +
     "\nDa li je poslodavac angažovao na radu lice mlađe od 15 godina?" +
     "\nDa li je poslodavac zaključio ugovor o radu sa maloljetnikom?" +
     "\nDa li je ugovor o radu zaključen u pisanoj formi?" +
     "\nDa li ugovor o radu sadrži podatke propisane odredbom člana 24. Zakona o radu?" +
     "\nDa li je poslodavac uputio radnika na rad u inozemstvo bez pismene saglasnosti u pogledu uvjeta ugovora?" +
     "\nDa li ugovor o radu za obavljanje poslova izvan prostorija poslodavca sadrži podatke propisane u odredbi člana 26. stav 2.?" +
     "\nDa li je poslodavac zaključio ugovor koji je opasan ili štetan po zdravlje radnika ili koji ugrožava radnu okolinu?" +
     "\nDa li je radno-pravni status direktora riješen zaključivanjem ugovora o radu odnosno posebnim ugovorom?" +
     "\nDa li je poslodavac radniku dostavio kopiju prijave na obavezno osiguranje u roku od 15 dana od dana zaključivanja ugovora?" +
     "\nDa li je poslodavac tražio od radnika podatke koji nisu u neposrednoj vezi sa radnim odnosom?" +
     "\nDa li je poslodavac prikupljao, obrađivao, koristio ili dostavljao trećim licima lične podatke radnika?" +
     "\nDa li je poslodavac zaključio ugovor o radu sa pripravnikom suprotno članu 32. Zakona o radu?" +
     "\nDa li je poslodavac ugovor o stručnom osposobljavanju zaključio u pisanoj formi i dostavio kopiju nadležnoj službi za zapošljavanje?" +
     "\nDa li je poslodavac zaključio ugovor o radu u kojem je puno ili nepuno radno vrijeme ugovoreno suprotno članu 36. Zakona o radu?" +
     "\nDa li je poslodavac zaključio ugovor o radu sa maloljetnim radnikom na radno vrijeme duže od 35 sati sedmično?" +
     "\nDa li je poslodavac od radnika zahtijevao da radi duže od skraćenog radnog vremena na poslovima sa štetnim uticajima?" +
     "\nDa li poslodavac od radnika zahtijeva prekovremeni rad suprotno članu 38. stav 1.?" +
     "\nDa li je poslodavac o prekovremenom radu obavjestio nadležnu inspekciju rada?" +
     "\nDa li je poslodavac naredio prekovremeni rad maloljetnom radniku?" +
     "\nDa li je poslodavac trudnici ili majci djeteta do 3 god. naložio prekovremeni rad bez pismene izjave o dobrovoljnom pristanku?" +
     "\nDa li je poslodavac izvršio preraspodjelu radnog vremena u skladu sa odredbom člana 39.?" +
     "\nDa li je poslodavac trudnici naredio rad u preraspodjeli radnog vremena bez pisanog pristanka?" +
     "\nDa li je poslodavac osigurao izmjenu smjena koje uključuju noćni rad?" +
     "\nDa li je poslodavac obezbijedio posebnu zaštitu radnika koji rade noću?" +
     "\nDa li je poslodavac naredio noćni rad trudnici počev od šestog mjeseca trudnoće?" +
     "\nDa li je poslodavac maloljetnom radniku naredio da radi noću?" +
     "\nDa li poslodavac vodi propisane evidencije o radnicima i licima angažovanim na radu?" +
     "\nDa li je poslodavac predočio inspektoru rada evidencije?" +
     "\nDa li je poslodavac radniku omogućio odmor u toku radnog dana?" +
     "\nDa li je poslodavac radniku omogućio dnevni i sedmični odmor?" +
     "\nDa li je poslodavac uskratio radniku pravo na odmor?" +
     "\nDa li je poslodavac radniku omogućio godišnji odmor?" +
     "\nDa li je poslodavac radniku uskratio pravo na godišnji odmor?" +
     "\nDa li je poslodavac radniku omogućio korištenje plaćenog odsustva?" +
     "\nDa li je poslodavac radniku omogućio upoznavanje sa propisima i sigurnošću na radu?" +
     "\nDa li je poslodavac odbio zaposliti ženu zbog trudnoće?" +
     "\nDa li je poslodavac otkazao ugovor trudnici?" +
     "\nDa li je poslodavac omogućio porodiljsko odsustvo?" +
     "\nDa li je poslodavac omogućio rad polovinom radnog vremena roditelju?" +
     "\nDa li je poslodavac omogućio odsustvo radi dojenja?" +
     "\nDa li je poslodavac isplatio plaću u roku od 30 dana?" +
     "\nDa li je poslodavac uručio obračun plaće?" +
     "\nDa li je poslodavac isplatio manju plaću od propisane?" +
     "\nDa li je poslodavac nadoknadio štetu radniku?" +
     "\nDa li je poslodavac uručio otkaz u pisanoj formi?" +
     "\nDa li je poslodavac omogućio radniku da se izjasni prije otkaza?" +
     "\nDa li je poslodavac vratio radnu knjižicu?" +
     "\nDa li je poslodavac zaključio ugovore o privremenim poslovima u skladu sa zakonom?" +
     "\nDa li je poslodavac uskladio pravilnik o radu sa zakonom?" +
     "\n%" +
     "\nZakon o zapošljavanju stranaca" +
     "\n=" +
     "\nDa li je poslodavac zaposlio stranca bez radne dozvole?" +
     "\nDa li je poslodavac sa strancem zaključio ugovor o radu u skladu sa zakonom?" +
     "\nDa li je poslodavac stranca rasporedio u skladu sa radnom dozvolom?" +
     "\nDa li je poslodavac prenio radnu dozvolu na drugog poslodavca?" +
     "\nDa li je poslodavac produžio rad bez važeće dozvole?" +
     "\n%" +
     "\nZakon o štrajku" +
     "\n=" +
     "\nDa li je sindikat organizirao štrajk u skladu sa zakonom?" +
     "\nDa li je štrajk započet prije mirenja?" +
     "\nDa li je poslodavac omogućio rad neophodnih poslova tokom štrajka?" +
     "\nDa li je poslodavac isključio radnike iz procesa rada?" +
     "\nDa li je poslodavac zaposlio nove radnike da zamijeni učesnike štrajka?" +
     "\n%" +
     "\nZakon o vijeću uposlenika" +
     "\n=" +
     "\nDa li je poslodavac omogućio učešće zaposlenika u odlučivanju?" +
     "\nDa li je poslodavac informirao vijeće o poslovanju?" +
     "\nDa li je poslodavac konsultirao vijeće prije odluka?" +
     "\nDa li je poslodavac obezbijedio uvjete za rad vijeća?" +
     "\n%" +
     "\nZakon o penzijskom i invalidskom osiguranju" +
     "\n=" +
     "\nDa li je poslodavac omogućio prava licu kojem ne pripadaju?" +
     "\nDa li je poslodavac uskratio prava osiguraniku?" +
     "\n%" +
     "\nFiskalizacija" +
     "\n=" +
     "\nDa li subjekt izdaje fiskalni račun?" +
     "\nDa li subjekt posjeduje fiskalni sistem?" +
     "\nDa li subjekt poduzima mjere kada sistem ne radi?" +
     "\n%" +
     "\nZaštita na radu" +
     "\n=" +
     "\nDa li poslodavac ima uredne isprave za rad?" +
     "\nDa li je donio opći akt o zaštiti na radu?" +
     "\nDa li je organizovao zaštitu na radu i imenovao stručno lice?" +
     "\nDa li su evidentirana profesionalna oboljenja?" +
     "\nDa li je radnik raspoređen prema sposobnosti?" +
     "\nDa li poslodavac prijavljuje povrede i nesreće?" +
     "\nDa li su radna mjesta definisana sa posebnim uvjetima?" +
     "\nDa li su obavljeni ljekarski pregledi radnika?" +
     "\nDa li su izvršeni periodični pregledi opreme?" +
     "\nDa li su radnici obučeni za siguran rad?" +
     "\nDa li su obezbijeđena zaštitna sredstva?" +
     "\nDa li se vodi evidencija o zaštiti na radu?" +
     "\nDa li poslodavac provodi mjere zaštite?" +
     "\nDa li je zabranjeno pušenje u radnim prostorima?" +
     "\nDa li su osigurane mjere sigurnosti u radnim prostorijama?" +
     "\nDa li je dokumentacija o zaštiti na radu ispravna?" +
     "\nDa li poslodavac omogućava inspekcijski nadzor?" +
     "\nDa li poslodavac postupa po rješenjima inspektora?" +
     "\n%";

        File.WriteAllText(path, content);
        Debug.Log("Aplikacija Resetovana!");
    } // ovo ti je bukvalno overwrite

}


