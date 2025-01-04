#include "CreateDelete.h"
#include <iostream>
#include <fstream>
#include <cstdio>

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

void deleteAccount(const std::string &filePath, const std::string &accountName)
{
    std::ifstream inputFile(filePath);
    if (!inputFile) 
    {
        std::cerr << "Error: Unable to open the file.\n";
        return;
    }

    std::ofstream tempFile("../../Data/TempAccounts.txt", std::ios::out);
    if (!tempFile) 
    {
        std::cerr << "Error: Unable to open the temporary file.\n";
        inputFile.close();
        return;
    }
    std::string password;
    while(true)
    {
        std::string fileLine;
        bool accountFound = false;

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

        if (std::remove(filePath.c_str()) == 0)
        {
            if(filePath==CLIENT_FILE)
            {
                std::cout<<"Klijentski nalog obrisan\n";
            }
            else   
            {   
                std::cout <<"Podaci o obrisanom korisniku:\n"
                            <<"Ime naloga: "<<accountName<<"\n"
                            <<"Lozinka:"<<password<<"\n";
            }
        }
        else
        {
            std::cerr << "Error: Unable to delete the file.\n";
        }
        
        const char* oldName = "../../Data/TempAccounts.txt";

        if (std::rename(oldName,filePath.c_str()) != 0)
        {
            std::cerr << "Error: Unable to rename the file.\n";
        }

        if(!accountFound)
        {
            std::cout<<"Account does not exist\n";
            continue;
        }
        break;
    }   
}
