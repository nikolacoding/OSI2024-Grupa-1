#pragma once
#include "Operator.h"

#include <fstream>
#include <string>
#include <iostream>
#include <sstream>

bool login(std::string &username)
{
    const std::string OPERATOR_FILE = "../../Data/OperatorAccounts.txt";
    std::ifstream file(OPERATOR_FILE);

    if (!file.is_open())
    {
        std::cerr << "Error: Could not open the file " << OPERATOR_FILE << std::endl;
        return false;
    }

    std::string inputUsername, inputPassword;
    std::string line;

    while (true)
    {
        std::cout << "Unesi korisnicko ime: ";
        std::cin >> inputUsername;

        bool usernameFound = false;
        file.clear();
        file.seekg(0);
        while (std::getline(file, line))
        {
            std::istringstream ss(line);
            std::string fileUsername, filePassword;
            if (std::getline(ss, fileUsername, ':') && std::getline(ss, filePassword, ':'))
            {
                if (inputUsername == fileUsername)
                {
                    usernameFound = true;
                    while (true)
                    {
                        std::cout << "Unesi sifru: ";
                        std::cin >> inputPassword;
                        if (inputPassword == filePassword)
                        {
                            username = fileUsername;
                            return true;
                        }
                        else
                        {
                            std::cout << "Nepostojeca sifra! Pokusaj opet." << std::endl;
                        }
                    }
                }
            }
        }

        if (!usernameFound)
        {
            std::cout << "Nepostojece korisnicko ime! Pokusaj opet." << std::endl;
        }
    }
}
