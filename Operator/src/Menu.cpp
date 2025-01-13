#include "Menu.h"
#include "Operator.h"
#include <iostream>

Menu::Menu(const std::string &name, const std::vector<TicketData> &ticketList)
    : operatorName(name), tickets(ticketList) {}

void Menu::displayMenu() const
{
    std::cout << "\nPrijavljeni operater - [" << operatorName << "]\n";
    std::cout << "Dodijeljeni tiketi:\n";

    for (size_t i = 0; i < tickets.size(); ++i)
    {
        tickets[i].displayShort(i);
    }

    std::cout << "\nOpcije:\n";
    std::cout << "1 - pregledaj detalje jednog tiketa\n";
    std::cout << "2 - vrati tiket klijentu\n";
    std::cout << "3 - zatvori tiket\n";
    std::cout << "0 - kraj rada\n";
}

void Menu::ChangeTicketStatus(int index, std::string newStatus)
{
    std::string client = tickets[index].clientName;
    {
        std::ifstream inputFile(TICKETS_FILE);

        if (!inputFile)
        {
            std::cerr << "Error: Unable to open file " << TICKETS_FILE << " for reading." << std::endl;
            return;
        }

        std::ostringstream tempBuffer;
        std::string line;
        bool clientFound = false;

        while (std::getline(inputFile, line))
        {
            if (line.rfind("CLIENT=", 0) == 0 && line.substr(7) == client)
            {
                clientFound = true;
                tempBuffer << line << '\n';

                while (std::getline(inputFile, line) && !line.empty())
                {
                    if (line.rfind("STATUS=", 0) == 0)
                    {
                        tempBuffer << "STATUS=" << newStatus << '\n';
                    }
                    else
                    {
                        tempBuffer << line << '\n';
                    }
                }

                tempBuffer << '\n';
            }
            else
            {
                tempBuffer << line << '\n';
            }
        }

        inputFile.close();

        if (!clientFound)
        {
            std::cerr << "Error: Klijent \"" << client << "\" nije u fajlu." << std::endl;
            return;
        }

        std::ofstream outputFile(TICKETS_FILE);
        if (!outputFile)
        {
            std::cerr << "Error: Unable to open file " << TICKETS_FILE << " for writing." << std::endl;
            return;
        }

        outputFile << tempBuffer.str();
        outputFile.close();
    }
}

void Menu::ChangeOperatorResponse(int index, std::string response)
{
    std::string client = tickets[index].clientName;
    std::ifstream inputFile(TICKETS_FILE);

    if (!inputFile)
    {
        std::cerr << "Error: Unable to open file " << TICKETS_FILE << " for reading." << std::endl;
        return;
    }

    std::ostringstream tempBuffer;
    std::string line;
    bool clientFound = false;

    while (std::getline(inputFile, line))
    {
        if (line.rfind("CLIENT=", 0) == 0 && line.substr(7) == client)
        {
            clientFound = true;
            tempBuffer << line << '\n';

            // Copy the next lines until we find OPERATOR_RESPONSE and update it.
            while (std::getline(inputFile, line) && !line.empty())
            {
                if (line.rfind("OPERATOR_RESPONSE=", 0) == 0)
                {
                    tempBuffer << "OPERATOR_RESPONSE=" << response << '\n';
                }
                else
                {
                    tempBuffer << line << '\n';
                }
            }

            tempBuffer << '\n'; // Add an extra line break after the ticket block.
        }
        else
        {
            tempBuffer << line << '\n';
        }
    }

    inputFile.close();

    if (!clientFound)
    {
        std::cerr << "Error: Klijent \"" << client << "\" nije u fajlu." << std::endl;
        return;
    }

    std::ofstream outputFile(TICKETS_FILE);
    if (!outputFile)
    {
        std::cerr << "Error: Unable to open file " << TICKETS_FILE << " for writing." << std::endl;
        return;
    }

    outputFile << tempBuffer.str();
    outputFile.close();
}

void Menu::CloseTicket(int index, std::string response)
{
    const std::string filename = "..\\..\\Data\\Tickets.txt";
    const std::string archiveFilename = "..\\..\\Data\\ArchivedTickets.txt";
    std::string client = tickets[index].clientName;
    std::ifstream inputFile(filename);

    if (!inputFile)
    {
        std::cerr << "Error: Unable to open file " << filename << " for reading." << std::endl;
        return;
    }

    std::ofstream archiveFile(archiveFilename, std::ios::app);
    if (!archiveFile)
    {
        std::cerr << "Error: Unable to open file " << archiveFilename << " for appending." << std::endl;
        inputFile.close();
        return;
    }

    std::ostringstream tempBuffer;
    std::string line;
    bool clientFound = false;
    std::ostringstream ticketBuffer;

    while (std::getline(inputFile, line))
    {
        if (line.rfind("CLIENT=", 0) == 0 && line.substr(7) == client)
        {
            clientFound = true;
            ticketBuffer << line << '\n';

            // Copy the ticket details and add the operator response
            while (std::getline(inputFile, line) && !line.empty())
            {
                if (line.rfind("OPERATOR_RESPONSE=", 0) == 0)
                {
                    ticketBuffer << "OPERATOR_RESPONSE=" << response << '\n';
                }
                else
                {
                    ticketBuffer << line << '\n';
                }
            }

            // Write the completed ticket to the archive file
            archiveFile << ticketBuffer.str() << '\n';
        }
        else
        {
            tempBuffer << line << '\n';
        }
    }

    inputFile.close();
    archiveFile.close();

    if (!clientFound)
    {
        std::cerr << "Error: Client \"" << client << "\" not found in the file." << std::endl;
        return;
    }

    std::ofstream outputFile(filename);
    if (!outputFile)
    {
        std::cerr << "Error: Unable to open file " << filename << " for writing." << std::endl;
        return;
    }

    outputFile << tempBuffer.str();
    outputFile.close();
}

void Menu::runMenu()
{
    int choice = -1;

    while (choice != 0)
    {
        displayMenu();
        std::cout << "\nIzbor: ";
        std::cin >> choice;

        if (choice == 0)
        {
            std::cout << "Zavrsavanje rada...\n";
        }
        if (choice == 1)
        {
            int ID;
            do
            {
                std::cout << "\nTicket ID: ";
                std::cin >> ID;
            } while (ID < 1);

            if (tickets.size() > ID)
                tickets[ID - 1].display();
            else
                std::cout << "Tiket sa datim ID-jem ne postoji." << std::endl;
        }
        if (choice == 2)
        {
            int ID;
            std::string response;
            do
            {
                std::cout << "\nTicked ID: ";
                std::cin >> ID;
            } while (ID < 1);

            std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');

            std::cout << "Enter operator response: ";
            std::getline(std::cin, response);

            ChangeTicketStatus(ID - 1, "Vracen");
            ChangeOperatorResponse(ID - 1, response);
        }
        if (choice == 3)
        {
            int ID;
            std::string response;
            do
            {
                std::cout << "\nTicked ID: ";
                std::cin >> ID;
            } while (ID < 1);

            std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');

            std::cout << "Enter operator response: ";
            std::getline(std::cin, response);

            ChangeTicketStatus(ID - 1, "Zatvoren");
            CloseTicket(ID - 1, response);
        }
    }
}
