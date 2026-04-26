using System.IO;
using UnityEngine;

public class FileHandler : MonoBehaviour
{
    string path;
    string pathZaSeverity;

    void Awake()
    {
        path = Application.persistentDataPath + "/ZakoniData.txt";
        WriteToFile();
        WriteSeverityToFile();
    }

    public void WriteSeverityToFile()
    {
        pathZaSeverity = Application.persistentDataPath + "/SeverityData.txt";
        string content = "\n" + 
            "\nlegal|5|Član 4|Rad bez ugovora može dovesti do visokih kazni i pravnih sporova|Zaključiti ugovor o radu sa svim zaposlenim" +
            "\nlegal|5|Član 14|Onemogućavanje sindikata krši osnovna prava radnika|Omogućiti slobodno organizovanje sindikata" +
            "\nlegal|4|Član 15|Diskriminacija po osnovu sindikata vodi sudskim postupcima|Ukinuti diskriminatorne prakse" +
            "\nlegal|3|Član 18|Ometanje sindikata smanjuje pravnu usklađenost|Omogućiti pristup sindikalnim predstavnicima" +
            "\nlegal|5|Član 20|Zapošljavanje djece je teško kršenje zakona|Zabraniti rad licima mlađim od 15 godina" +
            "\nlegal|4|Član 20|Nepravilno zapošljavanje maloljetnika nosi pravni rizik|Poštovati posebne uvjete za maloljetnike" +
            "\nlegal|5|Član 24|Usmeni ugovori nisu pravno validni|Zaključiti ugovor u pisanoj formi" +
            "\nlegal|4|Član 24|Nepotpuni ugovori dovode do sporova|Dopuniti ugovore sa svim obaveznim elementima" +
            "\nlegal|4|Član 25|Rad u inostranstvu bez saglasnosti nosi pravni rizik|Osigurati pisanu saglasnost radnika" +
            "\nlegal|3|Član 26|Nepotpuni ugovori za rad van prostorija stvaraju rizik|Uskladiti ugovor sa zakonom" +
            "\nlegal|5|Član 26|Opasni ugovori ugrožavaju zdravlje radnika|Zabraniti rizične uslove rada" +
            "\nlegal|3|Član 27|Neregulisan status direktora stvara pravnu nesigurnost|Formalno regulisati status direktora" +
            "\nlegal|4|Član 28|Neprijavljivanje radnika nosi kazne|Dostaviti prijavu osiguranja na vrijeme" +
            "\nlegal|3|Član 29|Prikupljanje nepotrebnih podataka krši privatnost|Ograničiti prikupljanje podataka" +
            "\nlegal|4|Član 30|Zloupotreba ličnih podataka nosi pravne posljedice|Uskladiti obradu podataka sa zakonom" +
            "\nlegal|3|Član 32|Nepravilno angažovanje pripravnika smanjuje usklađenost|Uskladiti ugovore pripravnika" +
            "\nlegal|3|Član 34|Nepravilno stručno osposobljavanje nosi administrativne rizike|Dostaviti ugovor nadležnim institucijama" +
            "\nlegal|4|Član 36|Nepravilno radno vrijeme krši zakon|Uskladiti radno vrijeme sa propisima" +
            "\nlegal|5|Član 36|Prekomjeran rad maloljetnika nosi ozbiljne kazne|Ograničiti radno vrijeme maloljetnika" +
            "\nlegal|5|Član 37|Rad u štetnim uslovima bez ograničenja ugrožava zdravlje|Poštovati skraćeno radno vrijeme" +
            "\nlegal|4|Član 38|Nezakonit prekovremeni rad nosi kazne|Uskladiti prekovremeni rad" +
            "\nlegal|3|Član 38|Neprijavljen prekovremeni rad nosi administrativni rizik|Obavijestiti inspekciju" +
            "\nlegal|5|Član 38|Prekovremeni rad maloljetnika je zabranjen|Zabraniti prekovremeni rad maloljetnika" +
            "\nlegal|5|Član 38|Prekovremeni rad trudnica nosi ozbiljan rizik|Osigurati pisani pristanak" +
            "\nlegal|3|Član 39|Nepravilna preraspodjela smanjuje usklađenost|Uskladiti raspored rada" +
            "\nlegal|5|Član 39|Rad trudnica bez pristanka nosi pravni rizik|Osigurati saglasnost" +
            "\noperational|3|Član 40|Neorganizovane smjene smanjuju efikasnost|Optimizovati raspored rada" +
            "\nlegal|4|Član 41|Nezaštićen noćni rad nosi pravne posljedice|Osigurati zaštitu radnika" +
            "\nlegal|5|Član 41|Noćni rad trudnica je zabranjen|Zabraniti noćni rad trudnicama" +
            "\nlegal|5|Član 42|Noćni rad maloljetnika je zabranjen|Zabraniti noćni rad maloljetnicima" +
            "\nlegal|4|Član 43|Nedostatak evidencija nosi kazne|Voditi evidenciju radnika" +
            "\nlegal|3|Član 43|Nedostupne evidencije otežavaju kontrolu|Omogućiti uvid inspekciji" +
            "\nlegal|3|Član 44|Uskraćen odmor smanjuje prava radnika|Omogućiti dnevni odmor" +
            "\nlegal|4|Član 45|Nedostatak odmora nosi pravni rizik|Osigurati sedmični odmor" +
            "\nlegal|4|Član 45|Uskraćivanje odmora nosi kazne|Poštovati pravo na odmor" +
            "\nlegal|4|Član 46|Neodobravanje godišnjeg odmora krši zakon|Omogućiti godišnji odmor" +
            "\nlegal|4|Član 46|Uskraćivanje odmora nosi kazne|Poštovati pravo radnika" +
            "\nlegal|3|Član 47|Neodobravanje odsustva smanjuje prava|Omogućiti plaćeno odsustvo" +
            "\noperational|3|Član 48|Nedovoljna edukacija povećava rizik|Uvesti obuku radnika" +
            "\nlegal|5|Član 49|Diskriminacija trudnica nosi ozbiljne kazne|Zabraniti diskriminaciju" +
            "\nlegal|5|Član 50|Otkaz trudnici je težak prekršaj|Zabraniti otkaz trudnicama" +
            "\nlegal|4|Član 51|Neomogućeno porodiljsko odsustvo nosi kazne|Omogućiti odsustvo" +
            "\nlegal|3|Član 52|Nepravilno radno vrijeme roditelja smanjuje prava|Omogućiti fleksibilan rad" +
            "\nlegal|3|Član 53|Onemogućavanje dojenja krši prava|Omogućiti odsustvo" +
            "\nfinancial|5|Član 54|Kašnjenje plata nosi visoke kazne|Isplaćivati plate na vrijeme" +
            "\nfinancial|4|Član 54|Nedostatak obračuna smanjuje transparentnost|Dostaviti obračun" +
            "\nfinancial|5|Član 54|Manja plata nosi ozbiljne kazne|Isplaćivati zakonski minimum" +
            "\nfinancial|4|Član 55|Neisplaćena šteta vodi sporovima|Nadoknaditi štetu" +
            "\nlegal|4|Član 56|Nepravilni otkazi nose sudske sporove|Uručiti pisani otkaz" +
            "\nlegal|4|Član 57|Bez izjave radnika otkaz nije validan|Omogućiti izjašnjenje" +
            "\nlegal|3|Član 58|Nevraćanje dokumenata krši zakon|Vratiti dokumentaciju" +
            "\nlegal|3|Član 59|Nepravilni privremeni ugovori nose rizik|Uskladiti ugovore" +
            "\nlegal|3|Član 60|Neusklađen pravilnik nosi kazne|Uskladiti pravilnik" +
            "\n" +
            "\n" +
            "\n" +
            "\nlegal|5|Zakon o strancima|Rad bez dozvole nosi velike kazne|Osigurati radne dozvole" +
            "\nlegal|4|Zakon o strancima|Nepravilni ugovori nose rizik|Uskladiti ugovor" +
            "\nlegal|4|Zakon o strancima|Nepravilno raspoređivanje krši zakon|Poštovati dozvolu" +
            "\nlegal|5|Zakon o strancima|Prenos dozvole je zabranjen|Zabraniti prenos" +
            "\nlegal|5|Zakon o strancima|Rad bez važeće dozvole nosi kazne|Produžiti dozvole" + 
            "\n" +
            "\n" +
            "\n" +
            "\nlegal|3|Zakon o štrajku|Nepravilno organizovan štrajk nosi rizik|Poštovati proceduru" +
            "\nlegal|3|Zakon o štrajku|Izostanak mirenja krši zakon|Provesti mirenje" +
            "\noperational|3|Zakon o štrajku|Neosigurani procesi smanjuju rad|Omogućiti minimum rada" +
            "\nlegal|4|Zakon o štrajku|Isključenje radnika nosi sporove|Izbjegavati zabrane rada" +
            "\nlegal|5|Zakon o štrajku|Zamjena radnika je zabranjena|Zabraniti zamjene" +
            "\n" +
            "\n" +
            "\n" +
            "\nlegal|3|Zakon o vijeću|Neuključivanje radnika smanjuje prava|Omogućiti učešće" +
            "\nlegal|3|Zakon o vijeću|Neinformisanje vijeća nosi rizik|Dostavljati informacije" +
            "\nlegal|3|Zakon o vijeću|Nekonsultovanje vijeća krši zakon|Uvesti konsultacije" +
            "\noperational|2|Zakon o vijeću|Loši uvjeti rada vijeća smanjuju funkciju|Osigurati uvjete" +
            "\n" +
            "\n" +
            "\n" +
            "\nlegal|4|PIO zakon|Neosnovana prava nose rizik|Uskladiti prava" +
            "\nlegal|4|PIO zakon|Uskraćivanje prava nosi sporove|Osigurati prava" +
            "\n" +
            "\n" +
            "\n" +
            "\nfinancial|5|Fiskalizacija|Neizdavanje računa nosi kazne|Uvesti fiskalni sistem" +
            "\nfinancial|5|Fiskalizacija|Nedostatak sistema nosi kazne|Instalirati sistem" +
            "\nfinancial|4|Fiskalizacija|Neaktivan sistem nosi rizik|Održavati sistem" +
            "\n" +
            "\n" +
            "\n" +
            "\noperational|3|Zaštita na radu|Neuredna dokumentacija nosi rizik|Urediti dokumente" +
            "\nlegal|4|Zaštita na radu|Nedostatak akta nosi kazne|Donijeti akt" +
            "\nlegal|4|Zaštita na radu|Neorganizovana zaštita nosi rizik|Imenovati odgovorno lice" +
            "\noperational|3|Zaštita na radu|Neevidentirana oboljenja smanjuju kontrolu|Voditi evidenciju" +
            "\noperational|3|Zaštita na radu|Loš raspored radnika smanjuje sigurnost|Rasporediti pravilno" +
            "\nlegal|4|Zaštita na radu|Neprijavljene povrede nose kazne|Prijaviti povrede" +
            "\nlegal|3|Zaštita na radu|Nedefinisana radna mjesta nose rizik|Definisati uslove" +
            "\nlegal|4|Zaštita na radu|Nedostatak pregleda ugrožava zdravlje|Organizovati preglede" +
            "\nlegal|4|Zaštita na radu|Neispitana oprema nosi rizik|Pregledati opremu" +
            "\noperational|3|Zaštita na radu|Neobučeni radnici povećavaju rizik|Organizovati obuku" +
            "\nlegal|4|Zaštita na radu|Nedostatak opreme nosi kazne|Obezbijediti opremu" +
            "\nlegal|3|Zaštita na radu|Nevođenje evidencije smanjuje kontrolu|Voditi evidenciju" +
            "\nlegal|4|Zaštita na radu|Neprovođenje mjera nosi kazne|Primijeniti mjere" +
            "\nlegal|2|Zaštita na radu|Pušenje povećava rizik|Zabraniti pušenje" +
            "\nlegal|4|Zaštita na radu|Nesigurni uslovi rada ugrožavaju radnike|Osigurati sigurnost" +
            "\nlegal|3|Zaštita na radu|Loša dokumentacija nosi rizik|Ažurirati dokumente" +
            "\nlegal|4|Zaštita na radu|Ometanje inspekcije nosi kazne|Omogućiti nadzor" +
            "\nlegal|5|Zaštita na radu|Neprovođenje rješenja nosi velike kazne|Postupiti po rješenjima" +
            "\n";
        File.WriteAllText(pathZaSeverity, content);

        Debug.Log("Written to: " + pathZaSeverity);
    }

    public void WriteToFile()
    {
        string content = "Zakon o radu FBiH" +
            "\n="+
            "\nDa li je poslodavac sa zaposlenikom zaključio ugovor o radu (član 4.)?" +
            "\nDa li je poslodavac onemogućio organizovanje sindikata? (član 14. stav 1.)" +
            "\nDa li je poslodavac stavio u nepovoljniji položaj radnika zbog članstva ili nečlanstva u sindikatu? (član 15. stav 2.)" +
            "\nDa li je poslodavac omogućio pristup sindikalnim predstavnicima, odnosno osigurao uvjete za djelovanje sindikata? (Član 18.)" +
            "\nDa li je poslodavac angažovao na radu lice mlađe od 15 godina? (Član 20. stav 1.)" +
            "\nDa li je poslodavac zaključio ugovor o radu sa maloljetnikom? (Član 20 stav 2.)" +
            "\nDa li je ugovor o radu zaključen u pisanoj formi (Član 24. stav 1)?" +
            "\nDa li ugovor o radu sadrži podatke propisane odredbom člana 24. Zakona o radu?" +
            "\nDa li je poslodavac uputio radnika na rad u inozemstvo bez pismene saglasnosti u pogledu uvjeta ugovora? (član 25.)" +
            "\nDa li ugovor o radu za obavljanje poslova izvan prostorija poslodavca sadrži podatke propisane u odredbi člana 26. stav 2.?" +
            "\nDa li je poslodavac zaključio ugovor koji je opasan ili štetan po zdravlje radnika ili koji ugrožava radnu okolinu (član 26. stav 3.)?" +
            "\nDa li je radno-pravni status direktora riješen zaključivanjem ugovora o radu odnosno posebnim ugovorom (član 27.)?" +
            "\nDa li je poslodavac radniku dostavio kopiju prijave na obavezno osiguranje u roku od 15 dana od dana zaključivanja ugovora? (Član 28.)" +
            "\nDa li je poslodavac tražio od radnika podatke koji nisu u neposrednoj vezi sa radnim odnosom? (Član 29.)" +
            "\nDa li je poslodavac prikupljao, obrađivao, koristio ili dostavljao trećim licima lične podatke radnika? (Član 30.)" +
            "\nDa li je poslodavac zaključio ugovor o radu sa pripravnikom suprotno članu 32. Zakona o radu?" +
            "\nDa li je poslodavac ugovor o stručnom osposobljavanju zaključio u pisanoj formi i dostavio kopiju nadležnoj službi za zapošljavanje? (Član 34.)" +
            "\nDa li je poslodavac zaključio ugovor o radu u kojem je puno ili nepuno radno vrijeme ugovoreno suprotno članu 36. Zakona o radu?" +
            "\nDa li je poslodavac zaključio ugovor o radu sa maloljetnim radnikom na radno vrijeme duže od 35 sati sedmično?" +
            "\nDa li je poslodavac od radnika zahtijevao da radi duže od skraćenog radnog vremena na poslovima sa štetnim uticajima? (Član 37.)" +
            "\nDa li poslodavac od radnika zahtijeva prekovremeni rad suprotno članu 38. stav 1.?" +
            "\nDa li je poslodavac o prekovremenom radu obavjestio nadležnu inspekciju rada? (Član 38. stav 2.)" +
            "\nDa li je poslodavac naredio prekovremeni rad maloljetnom radniku? (Član 38. stav 3.)" +
            "\nDa li je poslodavac trudnici ili majci djeteta do 3 god. naložio prekovremeni rad bez pismene izjave o dobrovoljnom pristanku? (Član 38. stav 4.)" +
            "\nDa li je poslodavac izvršio preraspodjelu radnog vremena u skladu sa odredbom člana 39.?" +
            "\nDa li je poslodavac trudnici naredio rad u preraspodjeli radnog vremena bez pisanog pristanka? (Član 39. stav 5.)" +
            "\nDa li je poslodavac osigurao izmjenu smjena koje uključuju noćni rad? (Član 40. stav 2.)" +
            "\nDa li je poslodavac obezbijedio posebnu zaštitu radnika koji rade noću? (Član 41. stav 3.)" +
            "\nDa li je poslodavac naredio noćni rad trudnici počev od šestog mjeseca trudnoće? (Član 41. stav 5.)" +
            "\nDa li je poslodavac maloljetnom radniku naredio da radi noću? (Član 42.)" +
            "\nDa li poslodavac vodi propisane evidencije o radnicima i licima angažovanim na radu? (Član 43.)" +
            "\nDa li je poslodavac predočio inspektoru rada evidencije?" +
            "\nDa li je poslodavac radniku omogućio odmor u toku radnog dana? (Član 44.)" +
            "\nDa li je poslodavac radniku omogućio dnevni i sedmični odmor? (Član 45. i 46.)" +
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
     "\nDa li je poslodavac sa zaposlenikom zaključio ugovor o radu (član 4.)?" +
     "\nDa li je poslodavac onemogućio organizovanje sindikata? (član 14. stav 1.)" +
     "\nDa li je poslodavac stavio u nepovoljniji položaj radnika zbog članstva ili nečlanstva u sindikatu? (član 15. stav 2.)" +
     "\nDa li je poslodavac omogućio pristup sindikalnim predstavnicima, odnosno osigurao uvjete za djelovanje sindikata? (Član 18.)" +
     "\nDa li je poslodavac angažovao na radu lice mlađe od 15 godina? (Član 20. stav 1.)" +
     "\nDa li je poslodavac zaključio ugovor o radu sa maloljetnikom? (Član 20 stav 2.)" +
     "\nDa li je ugovor o radu zaključen u pisanoj formi (Član 24. stav 1)?" +
     "\nDa li ugovor o radu sadrži podatke propisane odredbom člana 24. Zakona o radu?" +
     "\nDa li je poslodavac uputio radnika na rad u inozemstvo bez pismene saglasnosti u pogledu uvjeta ugovora? (član 25.)" +
     "\nDa li ugovor o radu za obavljanje poslova izvan prostorija poslodavca sadrži podatke propisane u odredbi člana 26. stav 2.?" +
     "\nDa li je poslodavac zaključio ugovor koji je opasan ili štetan po zdravlje radnika ili koji ugrožava radnu okolinu (član 26. stav 3.)?" +
     "\nDa li je radno-pravni status direktora riješen zaključivanjem ugovora o radu odnosno posebnim ugovorom (član 27.)?" +
     "\nDa li je poslodavac radniku dostavio kopiju prijave na obavezno osiguranje u roku od 15 dana od dana zaključivanja ugovora? (Član 28.)" +
     "\nDa li je poslodavac tražio od radnika podatke koji nisu u neposrednoj vezi sa radnim odnosom? (Član 29.)" +
     "\nDa li je poslodavac prikupljao, obrađivao, koristio ili dostavljao trećim licima lične podatke radnika? (Član 30.)" +
     "\nDa li je poslodavac zaključio ugovor o radu sa pripravnikom suprotno članu 32. Zakona o radu?" +
     "\nDa li je poslodavac ugovor o stručnom osposobljavanju zaključio u pisanoj formi i dostavio kopiju nadležnoj službi za zapošljavanje? (Član 34.)" +
     "\nDa li je poslodavac zaključio ugovor o radu u kojem je puno ili nepuno radno vrijeme ugovoreno suprotno članu 36. Zakona o radu?" +
     "\nDa li je poslodavac zaključio ugovor o radu sa maloljetnim radnikom na radno vrijeme duže od 35 sati sedmično?" +
     "\nDa li je poslodavac od radnika zahtijevao da radi duže od skraćenog radnog vremena na poslovima sa štetnim uticajima? (Član 37.)" +
     "\nDa li poslodavac od radnika zahtijeva prekovremeni rad suprotno članu 38. stav 1.?" +
     "\nDa li je poslodavac o prekovremenom radu obavjestio nadležnu inspekciju rada? (Član 38. stav 2.)" +
     "\nDa li je poslodavac naredio prekovremeni rad maloljetnom radniku? (Član 38. stav 3.)" +
     "\nDa li je poslodavac trudnici ili majci djeteta do 3 god. naložio prekovremeni rad bez pismene izjave o dobrovoljnom pristanku? (Član 38. stav 4.)" +
     "\nDa li je poslodavac izvršio preraspodjelu radnog vremena u skladu sa odredbom člana 39.?" +
     "\nDa li je poslodavac trudnici naredio rad u preraspodjeli radnog vremena bez pisanog pristanka? (Član 39. stav 5.)" +
     "\nDa li je poslodavac osigurao izmjenu smjena koje uključuju noćni rad? (Član 40. stav 2.)" +
     "\nDa li je poslodavac obezbijedio posebnu zaštitu radnika koji rade noću? (Član 41. stav 3.)" +
     "\nDa li je poslodavac naredio noćni rad trudnici počev od šestog mjeseca trudnoće? (Član 41. stav 5.)" +
     "\nDa li je poslodavac maloljetnom radniku naredio da radi noću? (Član 42.)" +
     "\nDa li poslodavac vodi propisane evidencije o radnicima i licima angažovanim na radu? (Član 43.)" +
     "\nDa li je poslodavac predočio inspektoru rada evidencije?" +
     "\nDa li je poslodavac radniku omogućio odmor u toku radnog dana? (Član 44.)" +
     "\nDa li je poslodavac radniku omogućio dnevni i sedmični odmor? (Član 45. i 46.)" +
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
