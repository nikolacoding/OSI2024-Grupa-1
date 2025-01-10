#include "Menu.h"
#include <iostream>

Menu::Menu(const std::string& name, const std::vector<std::string>& ticketList)
    : operatorName(name), tickets(ticketList) {}

void Menu::displayMenu() const {
    std::cout << "\nPrijavljeni operater - [" << operatorName << "]\n";
    std::cout << "Dodijeljeni tiketi:\n";

    for (size_t i = 0; i < tickets.size(); ++i) {
        std::cout << "ID:" << i + 1 << " - [" << tickets[i] << "]\n";
    }

    std::cout << "\nOpcije:\n";
    std::cout << "1 - pregledaj detalje jednog tiketa\n";
    std::cout << "2 - vrati tiket klijentu\n";
    std::cout << "3 - zatvori tiket\n";
    std::cout << "0 - kraj rada\n";
}

void Menu::runMenu() {
    int choice = -1;

    while (choice != 0) {
        displayMenu();
        std::cout << "\nUnesite opciju: ";
        std::cin >> choice;

        if (choice == 0) {
            std::cout << "Zavrsavanje rada...\n";
        } else {
            std::cout << "Opcija nije implementirana u ovom zadatku.\n";
        }
    }
}
