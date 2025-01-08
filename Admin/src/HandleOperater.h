#pragma once
#include "CreateDelete.h"
#include "Tickets.h"
#include <iostream>
#include <fstream>
#include <cstdio>

void handleOperator()
{
    while (true) 
        {
            std::cout << "Unesite:\n"
                    << "Ime naloga: ";
            std::string accountName;
            std::cin >> accountName;

            std::ifstream inputFile(OPERATOR_FILE);
            if (!inputFile) 
            {
                std::cout << "Error: Could not open the file." << std::endl;
                return;
            }

            std::string fileLine;
            bool operatorFound = false;

            while (std::getline(inputFile, fileLine)) 
            {
                std::string firstWord = "";
                for (int i = 0; i < fileLine.length(); ++i) 
                {
                    char ch = fileLine[i];
                    if (ch == ':') break;
                    firstWord += ch;
                }

                if (firstWord == accountName)
                {
                    operatorFound = true;
                    std::cout<<"Lozinka operatera: ";
                    for(int i=firstWord.length();i<fileLine.length();i++)
                    {
                        std::cout<<fileLine[i];
                    }
                    std::cout<<std::endl;
                }
            }

            inputFile.close();

            if (!operatorFound)
            {
                std::cout << "Operator does not exist\n";
                continue;
            }

            activeTickets(accountName);
            break;
        }  
}
