#include "AccountManager.h"
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

void deleteAccount(const std::string &filePath, const std::string &accountName, const std::string &password)
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

    std::string inputLine = accountName + ":" + password;
    std::string fileLine;

    while (std::getline(inputFile, fileLine)) 
    {
        if (fileLine != inputLine) {
            tempFile << fileLine << "\n";
        }
    }

    inputFile.close();
    tempFile.close();

    if (std::remove(filePath.c_str()) == 0)
    {
        std::cout << "File successfully deleted.\n";
    } 
    else 
    {
        std::cerr << "Error: Unable to delete the file.\n";
    }

    const char* oldName = "../../Data/TempAccounts.txt";
    if (std::rename(oldName,filePath.c_str()) == 0)
    {
        std::cout << "File successfully renamed.\n";
    } 
    else 
    {
        std::cerr << "Error: Unable to rename the file.\n";
    }
}
