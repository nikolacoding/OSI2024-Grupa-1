#include "CreateDelete.h"
#include "HandleOperater.h"
#include <iostream>
#include <string>
#include <fstream>

int main() {
    std::cout << "Unesite:\n1 - za upravljanje nalozima\n"
              <<"2 - za pregled tiketa\n"
              <<"3 - za pregled operatera\n"
              <<"Izbor opcije: ";
    int glavniIzbor;
    std::cin >> glavniIzbor;

    if (glavniIzbor == 1) 
    {
        std:: cout<<"Unesite:\n1 - za kreiranje novog naloga\n"
                  <<"2 - za brisanje naloga\n"
             	  <<"Izbor opcije: ";
        int izborKB;
        std::cin >> izborKB;

        if (izborKB == 1) 
        {
            std::cout << "Unesite:\n1 - za kreiranje klijentskog naloga\n"
                      << "2 - za kreiranje administratorskog naloga\n"
                      << "3 - za kreiranje operaorskog naloga\nIzbor opcije: ";
            int izborNaloga;
            std::cin >> izborNaloga;

            std::string filePath;
            switch (izborNaloga) 
            {
                case 1: filePath = CLIENT_FILE; break;
                case 2: filePath = ADMIN_FILE; break;
                case 3: filePath = OPERATOR_FILE; break;
                default:
                    std::cerr << "Invalid option.\n";
                    return 1;
            }

            std::string imeNaloga, lozinka;
            std::cout << "Unesite:\nIme naloga: ";
            std::cin >> imeNaloga;
            std::cout << "Lozinka: ";
            std::cin >> lozinka;

            createAccount(filePath, imeNaloga, lozinka);
        }

        else if (izborKB == 2) 
        {
            std::cout << "Unesite:\n1 - za brisanje klijentskog naloga\n"
                      << "2 - za brisanje administratorskog naloga\n"
                      << "3 - za brisanje operaorskog naloga\nIzbor opcije: ";
            int izborNaloga;
            std::cin >> izborNaloga;

            std::string filePath;
            switch (izborNaloga) 
            {
                case 1: filePath = CLIENT_FILE; break;
                case 2: filePath = ADMIN_FILE; break;
                case 3: filePath = OPERATOR_FILE; break;
                default:
                    std::cerr << "Invalid option.\n";
                    return 1;
            }
            
            deleteAccount(filePath);
        }
    }
    else if(glavniIzbor==3)
    { 
       handleOperator();        
    }

    return 0;
}
