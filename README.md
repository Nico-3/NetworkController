# Welcome to NC - NetworkController!

### Was ist NC?

NC ist ein Programm zur Kontrolle & Überprüfung der Stabilität der Internetleitung.

##

### Wie installiere ich NC?

NC ist eine Standalone Anwendung und muss deshalb nicht installiert werden! Man muss nur Zip Datei herunterladen, entpacken und die Datei starten!

##

### Wie funktioniert NC?

Wenn man das Programm startet wird man nach einer IP / Webadresse gefragt die man angeben will (Das Programm wird ohne IP / Webadresse nicht funktionieren!). Diese IP / Webadresse wird auf dem PC in der Datei *"C:\netprogram\install\ipfile.txt"* gespeichert. Diese kann man, je nachdem ob man das möchte, nach jedem Neustart des Programms überschreiben. Wenn die IP / Webadresse festgelegt wurde startet das eigentliche Programm mit einem Dauerping an diese genannte Adresse! Je nachdem wie gut die Internetleitung ist wird der Status des Pings in verschiedenen Farben angezeigt.

> GRÜN: Gute Verbindung | Ping ist kleiner als 100 ms<br>
> GELB: Mittlere Verbindung | Ping ist kleiner als 500 ms<br>
> ROT: Schlechte Verbindung | Ping ist größer als 500 ms<br>
> DUNKELROT: Kritische Verbindung | Ping ist größer als 1000 ms oder IP ist nicht erreichbar<br>

Die Pings werden jede Sekunde gesendet!
##

### Wie beende ich das Programm?

Wenn man einmal in der Ping Schleife drin ist kann man das Programm nur beenden um da wieder raus zu kommen!

##

### Logs?

Es werden zwei Sachen geloggt / gespeichert. Die Pings werden in der Datei *"C:/netprogram/netlog/pinglog.txt"* gespeichert. Falls es Abstürze gibt werden diese in die *"C:/netprogram/netlog/errorlog.txt"* Datei gespeichert.

##

### Bugs?

Falls Bugs vorkommen sollten bitte ich darum den ausführlichen Log (*"C:/netprogram/netlog/errorlog.txt"*) oder ein Screenshot davon an diese Email zu schicken: developeremailnifa@gmail.com

### Dateien

[NC-v1.zip](https://github.com/Nico-3/NetworkController/files/8080232/NC-v1.zip)
