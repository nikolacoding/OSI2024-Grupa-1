#ifndef MENU_H
#define MENU_H

#include <iostream>
#include <string>
#include <vector>

class Menu final {
public:
    Menu(const std::string& username) : m_accountUsername(username) {}
    ~Menu() = default;

    void show() const noexcept {
        for (const auto& line : m_lines)
            std::cout << line << std::endl;
        std::cout << "Izbor: ";
    }

    void wipe() const noexcept {
        for (size_t i = 0; i < wipeRows; i++)
            std::cout << std::endl;
    }

private:
    const size_t wipeRows = 25;
    const std::string m_accountUsername;
    const std::vector<std::string> m_lines = {
        "Nalog: " + m_accountUsername,
        "1 - Lista aktivnih tiketa",
        "2 - Lista operatera",
        "3 - Lista klijenata",
        "4 - Promjena podataka naloga",
        "5 - Kreiranje/brisanje naloga",
        "6 - Menadzment tiketa",
        "0 - Izlaz"
    };
};

#endif