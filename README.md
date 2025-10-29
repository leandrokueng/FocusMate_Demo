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
![Timer] <img width="815" height="1876" alt="timer png" src="https://github.com/user-attachments/assets/38ab2882-cf46-40a2-9c20-23ebc2146a23" />


### **Statistik**
Zeigt, wie lange du dich heute fokussiert hast.  
![Statistik] <img width="819" height="1869" alt="statistik png" src="https://github.com/user-attachments/assets/c08b077d-0106-4dab-84a3-24e344458007" />


### **Einstellungen**
Darkmode-Umschalter, Shake-Pause und anpassbare Fokuszeit.  
![Einstellungen] <img width="817" height="1877" alt="Settings png" src="https://github.com/user-attachments/assets/1ec9ed80-e77f-4fd3-9c91-75a63b7447cd" />




