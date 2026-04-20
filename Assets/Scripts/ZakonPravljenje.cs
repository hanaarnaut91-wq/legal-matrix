using System.IO;
using UnityEngine;

public class FileHandler : MonoBehaviour
{
    string path;

    void Awake()
    {
        path = Application.persistentDataPath + "/ZakoniData.txt";
        WriteToFile();
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
