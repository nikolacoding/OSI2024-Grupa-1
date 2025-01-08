#include "CreateDelete.h"
#include "RemoveRenameFile.h"
#include "Tickets.h"
#include <iostream>
#include <fstream>
#include <cstdio>
#include <string>

void createAccount(const std::string &filePath, const std::string &accountName, const std::string &password)
{
    std::ofstream outputFile(filePath, std::ios::app);
    if (!outputFile) 
    {
        std::cerr << "Error: Unable to open the file.\n";
        return;
    }
    outputFile << accountName << ":" << password << "\n";
    outputFile.close();
}

void deleteAccount(const std::string &filePath)
{
    while(true)
    {
        std::string accountName;
            std::cout << "Unesite:\nIme naloga: ";
            std::cin >> accountName;

        std::ifstream inputFile(filePath);
        if (!inputFile) 
        {
            std::cerr << "Error: Unable to open the file.\n";
            return;
        }

        std::ofstream tempFile("../../Data/TempAccounts.txt", std::ios::app);
        if (!tempFile) 
        {
            std::cerr << "Error: Unable to open the temporary file.\n";
            inputFile.close();
            return;
        }

        std::string password;
        std::string fileLine;
        bool accountFound = false;
        int accountCount=0;

        if(filePath==ADMIN_FILE)
        {
            while(std::getline(inputFile,fileLine))
            {
                accountCount++;
            }
            inputFile.clear(); 
            inputFile.seekg(0, std::ios::beg);
        }
        if(accountCount==1)
        {
            std::cout<<"Jedini administrator,nalog ne moze biti obrisan\n";
            inputFile.close();
            tempFile.close();
            removeFile("../../Data/TempAccounts.txt");
            return;
         }

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
                            accountFound = true;
                            for(int i=firstWord.length();i<fileLine.length();i++)
                            {
                                password+=fileLine[i];
                            }
                            continue;
                        }

                        tempFile << fileLine << std::endl;
            }

            inputFile.close();
            tempFile.close();

            removeFile(filePath);

            const char* oldName = "../../Data/TempAccounts.txt";
            renameFile(filePath,oldName);

            if(!accountFound)
            {
                std::cout<<"Account does not exist\n";
                continue;
            }

            if(filePath == CLIENT_FILE)
            {
                closeTicket(accountName);
                std::cout<<"Klijentski nalog je obrisan\n";
            }
            else if(filePath == OPERATOR_FILE)
            {
                std::cout<<"Operaterski nalog "<<accountName<<" je obrisan\n";
                std::cout<<"Podaci o nalogu:\n"
                        <<"Ime naloga:"<<accountName<<"\n"
                        <<"Lozinka:"<<password<<"\n";
                reassignOperatorTasks(accountName,TICKETS_FILE,filePath);
            }
            else if(filePath == ADMIN_FILE)
            {
                std::cout<<"Administratorski nalog je obrisan\n";
            }
        break;
    }   
}