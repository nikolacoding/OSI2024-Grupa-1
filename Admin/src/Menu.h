#ifndef MENU_H
#define MENU_H

#include <iostream>
#include <string>
#include <vector>

#include "FileManager.h"

class Menu final {
public:
    Menu(const std::string& username) : 
        m_accountUsername(username), m_firmName(FileManager::GetFirmName()), m_paid(FileManager::CheckPaidVersion()) { 
        if (!m_paid)
            m_lines.insert(m_lines.begin() + 10, "10 - Aktivacija komercijalne verzije");
    }
    ~Menu() = default;

    void show() const noexcept {
        for (const auto& line : m_lines)
            std::cout << line << std::endl;
        std::cout << "Izbor: ";
    }

    void wipe() const noexcept {
        for (size_t i = 0; i < m_wipeRows; i++)
            std::cout << std::endl;
    }

    inline bool isPaid() const noexcept { return m_paid; }

private:
    bool m_paid;
    const size_t m_wipeRows = 25;

    const std::string m_accountUsername;
    const std::string m_firmName;
    std::vector<std::string> m_lines = {
        "Korisnicka podrska - " + m_firmName + " - " + (m_paid ? "Komercijalna verzija" : "Besplatna verzija"),
        "Nalog: " + m_accountUsername,
        "1 - Lista aktivnih tiketa",
        "2 - Detaljan pregled tiketa",
        "3 - Lista operatera",
        "4 - Lista klijenata",
        "5 - Promjena podataka naloga",
        "6 - Kreiranje/brisanje naloga",
        "7 - Menadzment tiketa",
        "8 - Pregled statistike",
        "9 - Raspodijeli otvorene tikete operaterima",
        "0 - Izlaz"
    };
};

#endif