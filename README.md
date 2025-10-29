# ⏱️ FocusMate (Demo)

**FocusMate** ist eine mobile App, die beim **konzentrierten Arbeiten** hilft.  
Sie basiert auf der **Pomodoro-Methode** und wurde mit **.NET MAUI (C#)** entwickelt.  
Die App wurde im Rahmen des Moduls **LB335 – Mobile Applikationen entwickeln** erstellt.

---

## 🚀 Funktionen

- **Fokus-Timer:** Stelle deine gewünschte Arbeitszeit ein und starte den Countdown.  
- **Shake-to-Pause:** Schüttle das Gerät, um den Timer automatisch zu pausieren.  
- **Darkmode:** Aktiviere den Auto-Darkmode für augenschonendes Arbeiten.  
- **Statistik:** Sieh, wie lange du dich heute bereits konzentriert hast.  
- **Einstellungen:** Passe Fokuszeit, Darkmode und Shake-Funktion individuell an.  
- **Datenhaltung mit SQLite:** Fokuszeiten werden lokal gespeichert.

---

## 🧠 Architektur

Die App verwendet das **MVVM-Muster (Model-View-ViewModel)**:  
- **Models:** enthalten Datenstrukturen (z. B. Fokus-Sitzung)  
- **ViewModels:** steuern Logik und Datenbindung (Start, Pause, Speicherung)  
- **Views:** stellen die Oberfläche dar (XAML-Seiten für Timer, Statistik, Settings)

Die Navigation erfolgt über eine **Shell mit Tab-Bar**, die die drei Hauptseiten verbindet.

---

## 📱 Screenshots

### **Timer**
Startseite mit Countdown, Start-/Pause-Buttons und Navigation unten.  
![Timer](docs/timer.png)

### **Statistik**
Zeigt, wie lange du dich heute fokussiert hast.  
![Statistik](docs/stats.png)

### **Einstellungen**
Darkmode-Umschalter, Shake-Pause und anpassbare Fokuszeit.  
![Einstellungen](docs/settings.png)

---

## 🗂️ Projektstruktur

